-- Check if the procedure exists and drop it if it does
BEGIN
   FOR c IN (SELECT object_name FROM user_procedures WHERE object_name = 'PURGE_WORKFLOWS') LOOP
      EXECUTE IMMEDIATE 'DROP PROCEDURE PURGE_WORKFLOWS';
   END LOOP;
END;
/

-- Create the procedure
CREATE OR REPLACE PROCEDURE PURGE_WORKFLOWS (
    DeletePointOfTime IN NUMBER DEFAULT 0,
    MaximumRows IN NUMBER DEFAULT 1000,
    OutputNumberOfDeletedWorkflows OUT NUMBER
) IS
    DeletePoint NUMBER := DeletePointOfTime;
BEGIN
    SELECT COUNT(*) INTO OutputNumberOfDeletedWorkflows FROM WF_EXEC_DONE WHERE CREATED_ON <= DeletePoint;

    IF MaximumRows < OutputNumberOfDeletedWorkflows THEN
        OutputNumberOfDeletedWorkflows := MaximumRows;
    END IF;

    -- Workflow data deletion
    FOR rec IN (SELECT EXECUTION_ID FROM WF_EXEC_DONE WHERE CREATED_ON <= DeletePoint AND ROWNUM <= MaximumRows) LOOP
        DELETE FROM WF_STEP_EXEC_DONE WHERE EXECUTION_ID = rec.EXECUTION_ID;
        DELETE FROM WF_GROUP_EXEC_DONE WHERE EXECUTION_ID = rec.EXECUTION_ID;
        DELETE FROM WF_EXEC_DONE WHERE EXECUTION_ID = rec.EXECUTION_ID;
    END LOOP;

    -- LOG data deletion
    DELETE FROM LOG_API WHERE UTC_TIME <= DeletePoint;
    DELETE FROM LOG_EVENT WHERE UTC_TIME <= DeletePoint;
    DELETE FROM LOG_GRPC WHERE SERVER_TIME <= DeletePoint;
    DELETE FROM LOG_HTTP_REQUEST WHERE TIME_IN <= DeletePoint;
    DELETE FROM LOG_INCOMING_QUEUE_MESSAGE WHERE COMING_TIME <= DeletePoint;
    DELETE FROM LOG_RECEIVING_HTTP WHERE TIME_START <= DeletePoint;
END;
/

