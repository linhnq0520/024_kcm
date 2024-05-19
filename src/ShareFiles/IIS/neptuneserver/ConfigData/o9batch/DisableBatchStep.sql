USE o9batch
UPDATE [o9batch].[dbo].[BatchProgram] SET Enabled = 0 WHERE ProgramName = 'P_ACT_EVAL_EXEC'
UPDATE [o9batch].[dbo].[BatchJob] SET Enabled = 0 WHERE JobName = 'J_ACT_EVAL_EXEC'