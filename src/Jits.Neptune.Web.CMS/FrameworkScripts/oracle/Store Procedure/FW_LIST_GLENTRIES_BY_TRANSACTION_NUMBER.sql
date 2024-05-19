CREATE OR REPLACE PROCEDURE FW_LIST_GLENTRIES_BY_TRANSACTION_NUMBER (
    p_WorkflowScheme nvarchar2,
    p_IsReverse nvarchar2, -- SQLINES DEMO *** rmal
    p_OutputWorkflowScheme OUT nvarchar2)
AS

  v_TransactionNumber VARCHAR2(50);
  v_listGL NCLOB;
  v_Error NCLOB;
  v_FullError NCLOB;
  v_RefId VARCHAR2(50);
  v_TransactionCode VARCHAR2(50);
    BEGIN
    NULL;
    END;

