##### SETTING
START TRANSACTION;

DELETE FROM `neptune`.`WF_DEF` WHERE `WFID` like 'CMS_SETTING_ADD';
DELETE FROM `neptune`.`WF_DEF` WHERE `WFID` like 'CMS_SETTING_UPDATE';
DELETE FROM `neptune`.`WF_DEF` WHERE `WFID` like 'CMS_SETTING_DELETE';
DELETE FROM `neptune`.`WF_DEF` WHERE `WFID` like 'CMS_SETTING_VIEW';
DELETE FROM `neptune`.`WF_DEF` WHERE `WFID` like 'CMS_SETTING_SEARCH';
DELETE FROM `neptune`.`WF_DEF` WHERE `WFID` like 'CMS_SETTING_ADSEARCH';
DELETE FROM `neptune`.`WF_STEP_DEF` WHERE `WFID` like 'CMS_SETTING_ADD';
DELETE FROM `neptune`.`WF_STEP_DEF` WHERE `WFID` like 'CMS_SETTING_UPDATE';
DELETE FROM `neptune`.`WF_STEP_DEF` WHERE `WFID` like 'CMS_SETTING_DELETE';
DELETE FROM `neptune`.`WF_STEP_DEF` WHERE `WFID` like 'CMS_SETTING_VIEW';
DELETE FROM `neptune`.`WF_STEP_DEF` WHERE `WFID` like 'CMS_SETTING_SEARCH';
DELETE FROM `neptune`.`WF_STEP_DEF` WHERE `WFID` like 'CMS_SETTING_ADSEARCH';

## VIEW
INSERT INTO `neptune`.`WF_DEF` (`WFID`, `Code`, `Name`, `Status`, `Description`, `TimeoutInMiliseconds`, `EventWorkflowRegistered`, `EventWorkflowCompleted`, `EventWorkflowError`, `EventWorkflowTimeout`, `EventWorkflowCompensated`, `EventWorkflowReversed`, `EventWorkflowStepStart`, `EventWorkflowStepCompleted`, `EventWorkflowStepError`, `EventWorkflowStepTimeout`, `EventWorkflowStepCompensated`) VALUES 
('CMS_SETTING_VIEW', 'CMS_SETTING_VIEW', 'ViewSetting', 'Active', 'ViewSetting', 60000, 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes');
INSERT INTO `neptune`.`WF_STEP_DEF` (`WFID`, `STEP_ORDER`, `STEP_GROUP`, `STEP_CODE`, `STATUS`, `DESCRIPTION`, `SERVICE_ID`, `SENDING_TEMPLATE`, `SUCCESS_CONDITION`, `REQUEST_PROTOCOL`, `REQUEST_SERVER_IP`, `REQUEST_SERVER_PORT`, `REQUEST_URI`, `SEND_BY_BROKER`, `STEP_TIMEOUT`, `STEP_MODE`) VALUES
('CMS_SETTING_VIEW', 1, 1, 'SQL_CAN_USER_INVOKE_COMMAND', 'Active', 'Step call service can user invoke command', 'ADM', '{}', '{\"p1_status\":\"Completed\",\"p2_response_status\":\"SUCCESS\"}', 'http', 'admin.api', '80', '', 'Y', '60000', 'TWOWAY'),
('CMS_SETTING_VIEW', 2, 2, 'CMS_SETTING_VIEW', 'Active', 'Step 2', 'CMS', '{"Id":{"func":"MapFromInput","type":"Number","paras":["$.execution.input.fields.id"]}}', '{\"p1_status\":\"Completed\",\"p2_response_status\":\"SUCCESS\"}', 'http', 'cms.api', '80', '', 'Y', '60000', 'TWOWAY');

## INSERT
INSERT INTO `neptune`.`WF_DEF` (`WFID`, `Code`, `Name`, `Status`, `Description`, `TimeoutInMiliseconds`, `EventWorkflowRegistered`, `EventWorkflowCompleted`, `EventWorkflowError`, `EventWorkflowTimeout`, `EventWorkflowCompensated`, `EventWorkflowReversed`, `EventWorkflowStepStart`, `EventWorkflowStepCompleted`, `EventWorkflowStepError`, `EventWorkflowStepTimeout`, `EventWorkflowStepCompensated`) VALUES ('CMS_SETTING_ADD', 'CMS_SETTING_ADD', 'InsertSetting', 'Active', 'InsertSetting', 60000, 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes');
INSERT INTO `neptune`.`WF_STEP_DEF` (`WFID`, `STEP_ORDER`, `STEP_GROUP`, `STEP_CODE`, `STATUS`, `DESCRIPTION`, `SERVICE_ID`, `SENDING_TEMPLATE`, `SUCCESS_CONDITION`, `REQUEST_PROTOCOL`, `REQUEST_SERVER_IP`, `REQUEST_SERVER_PORT`, `REQUEST_URI`, `SEND_BY_BROKER`, `STEP_TIMEOUT`, `STEP_MODE`) VALUES
('CMS_SETTING_ADD', 1, 1, 'SQL_CAN_USER_INVOKE_COMMAND', 'Active', 'Step call service can user invoke command', 'ADM', '{}', '{\"p1_status\":\"Completed\",\"p2_response_status\":\"SUCCESS\"}', 'http', 'admin.api', '80', '', 'Y', '60000', 'TWOWAY'),
('CMS_SETTING_ADD', 2, 2, 'CMS_SETTING_ADD', 'Active', 'Step 2', 'CMS', '{"Name":{"func":"MapFromInput","type":"String","paras":["$.execution.input.fields.name"]},"Value":{"func":"MapFromInput","type":"String","paras":["$.execution.input.fields.value"]},"OrganizationId":{"func":"MapFromInput","type":"Number","paras":["$.execution.input.fields.organization_id"]}}', '{\"p1_status\":\"Completed\",\"p2_response_status\":\"SUCCESS\"}', 'http', 'cms.api', '80', '', 'Y', '60000', 'TWOWAY');

## UPDATE
INSERT INTO `neptune`.`WF_DEF` (`WFID`, `Code`, `Name`, `Status`, `Description`, `TimeoutInMiliseconds`, `EventWorkflowRegistered`, `EventWorkflowCompleted`, `EventWorkflowError`, `EventWorkflowTimeout`, `EventWorkflowCompensated`, `EventWorkflowReversed`, `EventWorkflowStepStart`, `EventWorkflowStepCompleted`, `EventWorkflowStepError`, `EventWorkflowStepTimeout`, `EventWorkflowStepCompensated`) VALUES 
('CMS_SETTING_UPDATE', 'CMS_SETTING_UPDATE', 'UpdateSetting', 'Active', 'UpdateSetting', 60000, 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes');
INSERT INTO `neptune`.`WF_STEP_DEF` (`WFID`, `STEP_ORDER`, `STEP_GROUP`, `STEP_CODE`, `STATUS`, `DESCRIPTION`, `SERVICE_ID`, `SENDING_TEMPLATE`, `SUCCESS_CONDITION`, `REQUEST_PROTOCOL`, `REQUEST_SERVER_IP`, `REQUEST_SERVER_PORT`, `REQUEST_URI`, `SEND_BY_BROKER`, `STEP_TIMEOUT`, `STEP_MODE`) VALUES
('CMS_SETTING_UPDATE', 1, 1, 'SQL_CAN_USER_INVOKE_COMMAND', 'Active', 'Step call service can user invoke command', 'ADM', '{}', '{\"p1_status\":\"Completed\",\"p2_response_status\":\"SUCCESS\"}', 'http', 'admin.api', '80', '', 'Y', '60000', 'TWOWAY'),
('CMS_SETTING_UPDATE', 2, 2, 'CMS_SETTING_UPDATE', 'Active', 'Step 2', 'CMS', '{"Id":{"func":"MapFromInput","type":"Number","paras":["$.execution.input.fields.id"]},"Name":{"func":"MapFromInput","type":"String","paras":["$.execution.input.fields.name"]},"Value":{"func":"MapFromInput","type":"String","paras":["$.execution.input.fields.value"]},"OrganizationId":{"func":"MapFromInput","type":"Number","paras":["$.execution.input.fields.organization_id"]}}', '{\"p1_status\":\"Completed\",\"p2_response_status\":\"SUCCESS\"}', 'http', 'cms.api', '80', '', 'Y', '60000', 'TWOWAY');

## DELETE
INSERT INTO `neptune`.`WF_DEF` (`WFID`, `Code`, `Name`, `Status`, `Description`, `TimeoutInMiliseconds`, `EventWorkflowRegistered`, `EventWorkflowCompleted`, `EventWorkflowError`, `EventWorkflowTimeout`, `EventWorkflowCompensated`, `EventWorkflowReversed`, `EventWorkflowStepStart`, `EventWorkflowStepCompleted`, `EventWorkflowStepError`, `EventWorkflowStepTimeout`, `EventWorkflowStepCompensated`) VALUES 
('CMS_SETTING_DELETE', 'CMS_SETTING_DELETE', 'DeleteSetting', 'Active', 'DeleteSetting', 60000, 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes');
INSERT INTO `neptune`.`WF_STEP_DEF` (`WFID`, `STEP_ORDER`, `STEP_GROUP`, `STEP_CODE`, `STATUS`, `DESCRIPTION`, `SERVICE_ID`, `SENDING_TEMPLATE`, `SUCCESS_CONDITION`, `REQUEST_PROTOCOL`, `REQUEST_SERVER_IP`, `REQUEST_SERVER_PORT`, `REQUEST_URI`, `SEND_BY_BROKER`, `STEP_TIMEOUT`, `STEP_MODE`) VALUES
('CMS_SETTING_DELETE', 1, 1, 'SQL_CAN_USER_INVOKE_COMMAND', 'Active', 'Step call service can user invoke command', 'ADM', '{}', '{\"p1_status\":\"Completed\",\"p2_response_status\":\"SUCCESS\"}', 'http', 'admin.api', '80', '', 'Y', '60000', 'TWOWAY'),
('CMS_SETTING_DELETE', 2, 2, 'CMS_SETTING_DELETE', 'Active', 'Step 2', 'CMS', '{"Id":{"func":"MapFromInput","type":"Number","paras":["$.execution.input.fields.id"]}}', '{\"p1_status\":\"Completed\",\"p2_response_status\":\"SUCCESS\"}', 'http', 'cms.api', '80', '', 'Y', '60000', 'TWOWAY');

## SEARCH
INSERT INTO `neptune`.`WF_DEF` (`WFID`, `Code`, `Name`, `Status`, `Description`, `TimeoutInMiliseconds`, `EventWorkflowRegistered`, `EventWorkflowCompleted`, `EventWorkflowError`, `EventWorkflowTimeout`, `EventWorkflowCompensated`, `EventWorkflowReversed`, `EventWorkflowStepStart`, `EventWorkflowStepCompleted`, `EventWorkflowStepError`, `EventWorkflowStepTimeout`, `EventWorkflowStepCompensated`) VALUES 
('CMS_SETTING_SEARCH', 'CMS_SETTING_SEARCH', 'SimpleSearchSetting', 'Active', 'SimpleSearchSetting', 60000, 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes');
INSERT INTO `neptune`.`WF_STEP_DEF` (`WFID`, `STEP_ORDER`, `STEP_GROUP`, `STEP_CODE`, `STATUS`, `DESCRIPTION`, `SERVICE_ID`, `SENDING_TEMPLATE`, `SUCCESS_CONDITION`, `REQUEST_PROTOCOL`, `REQUEST_SERVER_IP`, `REQUEST_SERVER_PORT`, `REQUEST_URI`, `SEND_BY_BROKER`, `STEP_TIMEOUT`, `STEP_MODE`) VALUES
('CMS_SETTING_SEARCH', 1, 1, 'SQL_CAN_USER_INVOKE_COMMAND', 'Active', 'Step call service can user invoke command', 'ADM', '{}', '{\"p1_status\":\"Completed\",\"p2_response_status\":\"SUCCESS\"}', 'http', 'admin.api', '80', '', 'Y', '60000', 'TWOWAY'),
('CMS_SETTING_SEARCH', 2, 2, 'CMS_SETTING_SEARCH', 'Active', 'Step 2', 'CMS', '{\"SearchText\":{\"func\":\"MapFromInput\",\"type\":\"String\",\"paras\":[\"$.execution.input.fields.search_text\"]},\"PageSize\":{\"func\":\"MapFromInput\",\"type\":\"Number\",\"paras\":[\"$.execution.input.fields.page_size\"]},\"PageIndex\":{\"func\":\"MapFromInput\",\"type\":\"Number\",\"paras\":[\"$.execution.input.fields.page_index\"]}}', '{\"p1_status\":\"Completed\",\"p2_response_status\":\"SUCCESS\"}', 'http', 'cms.api', '80', '', 'Y', '60000', 'TWOWAY');

## ADVANCE SEARCH
INSERT INTO `neptune`.`WF_DEF` (`WFID`, `Code`, `Name`, `Status`, `Description`, `TimeoutInMiliseconds`, `EventWorkflowRegistered`, `EventWorkflowCompleted`, `EventWorkflowError`, `EventWorkflowTimeout`, `EventWorkflowCompensated`, `EventWorkflowReversed`, `EventWorkflowStepStart`, `EventWorkflowStepCompleted`, `EventWorkflowStepError`, `EventWorkflowStepTimeout`, `EventWorkflowStepCompensated`) VALUES 
('CMS_SETTING_ADSEARCH', 'CMS_SETTING_ADSEARCH', 'AdvanceSearchSetting', 'Active', 'AdvanceSearchSetting', 60000, 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes', 'Yes');
INSERT INTO `neptune`.`WF_STEP_DEF` (`WFID`, `STEP_ORDER`, `STEP_GROUP`, `STEP_CODE`, `STATUS`, `DESCRIPTION`, `SERVICE_ID`, `SENDING_TEMPLATE`, `SUCCESS_CONDITION`, `REQUEST_PROTOCOL`, `REQUEST_SERVER_IP`, `REQUEST_SERVER_PORT`, `REQUEST_URI`, `SEND_BY_BROKER`, `STEP_TIMEOUT`, `STEP_MODE`) VALUES
('CMS_SETTING_ADSEARCH', 1, 1, 'SQL_CAN_USER_INVOKE_COMMAND', 'Active', 'Step call service can user invoke command', 'ADM', '{}', '{\"p1_status\":\"Completed\",\"p2_response_status\":\"SUCCESS\"}', 'http', 'admin.api', '80', '', 'Y', '60000', 'TWOWAY'),
('CMS_SETTING_ADSEARCH', 2, 2, 'CMS_SETTING_ADSEARCH', 'Active', 'Step 2', 'CMS', '{"Name":{"func":"MapFromInput","type":"String","paras":["$.execution.input.fields.name"]},"Value":{"func":"MapFromInput","type":"String","paras":["$.execution.input.fields.value"]},"OrganizationId":{"func":"MapFromInput","type":"String","paras":["$.execution.input.fields.organization_id"]},"PageIndex":{"func":"MapFromInput","type":"Number","paras":["$.execution.input.fields.page_index"]},"PageSize":{"func":"MapFromInput","type":"Number","paras":["$.execution.input.fields.page_size"]}}', '{\"p1_status\":\"Completed\",\"p2_response_status\":\"SUCCESS\"}', 'http', 'cms.api', '80', '', 'Y', '60000', 'TWOWAY');

COMMIT;
