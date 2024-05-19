-- Check if procedure exists and drop it if it does
DO $$
BEGIN
    IF EXISTS (SELECT * FROM pg_proc WHERE proname = 'purge_workflows') THEN
        EXECUTE 'DROP PROCEDURE purge_workflows';
    END IF;
END$$;

-- Create the procedure
CREATE OR REPLACE PROCEDURE purge_workflows(
    IN DeletePointOfTime bigint DEFAULT 0, 
    IN MaximumRows bigint DEFAULT 1000, 
    OUT OutputNumberOfDeletedWorkflows bigint
)
LANGUAGE plpgsql
AS $$
DECLARE
    DeletePoint bigint := DeletePointOfTime;
BEGIN
    SELECT COUNT(*) INTO OutputNumberOfDeletedWorkflows FROM wf_exec_done WHERE created_on <= DeletePoint;

    IF MaximumRows < OutputNumberOfDeletedWorkflows THEN
        OutputNumberOfDeletedWorkflows := MaximumRows;
    END IF;

    -- Workflow data deletion
    DELETE FROM wf_step_exec_done WHERE execution_id IN (SELECT execution_id FROM wf_exec_done WHERE created_on <= DeletePoint LIMIT MaximumRows);
    DELETE FROM wf_group_exec_done WHERE execution_id IN (SELECT execution_id FROM wf_exec_done WHERE created_on <= DeletePoint LIMIT MaximumRows);
    DELETE FROM wf_exec_done WHERE execution_id IN (SELECT execution_id FROM wf_exec_done WHERE created_on <= DeletePoint LIMIT MaximumRows);

    -- LOG data deletion
    DELETE FROM log_api WHERE utc_time <= DeletePoint;
    DELETE FROM log_event WHERE utc_time <= DeletePoint;
    DELETE FROM log_grpc WHERE server_time <= DeletePoint;
    DELETE FROM log_http_request WHERE time_in <= DeletePoint;
    DELETE FROM log_incoming_queue_message WHERE coming_time <= DeletePoint;
    DELETE FROM log_receiving_http WHERE time_start <= DeletePoint;
END;
$$;
