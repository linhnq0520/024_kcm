-- Run in Neptune to grant all rights for Workflows
start transaction;
-- truncate table `AUTH_ROLE_WF`;
-- INSERT INTO `AUTH_USER` (`UserID`, `UserCode`, `OrganizationID`, `UserName`, `FullName`, `Status`, `LanguageCode`, `SessionExpirationInMinutes`, `HashPassword`, `TimeZone`) VALUES ('f9ccca8c6ea6444db38b822ef1222b29', 'NEPTUNE', '062231ae503b4e2e8cd764876db56642', 'Neptune administrator', 'Neptune administrator', 'Active', 'en', '60', '012fe7576f153d24399c0717a30aa50c33a3c40e2db58d16e0f7ef876a0e46d1', 0);
-- INSERT INTO `AUTH_ROLE` (`RoleID`, `RoleCode`, `RoleName`) VALUES ('470cc13f2c7d4f9eb530be460df1025a', 'ADMINISTRATOR', 'Adminitrator');
-- INSERT INTO `AUTH_ROLE` (`RoleID`, `RoleCode`, `RoleName`) VALUES ('1473acdaac6c4e089fbaee3678f5aa74', 'EXECUTOR', 'Workflow Executor');
-- INSERT INTO `AUTH_ROLE_USER` (`RoleID`, `UserID`) VALUES ('470cc13f2c7d4f9eb530be460df1025a', 'f9ccca8c6ea6444db38b822ef1222b29');
select roleid into @RoleID from `AUTH_ROLE` where rolecode = 'ADMINISTRATOR';
INSERT INTO `AUTH_ROLE_WF` (`RoleID`, `WorflowID`) SELECT @RoleID, wfid from `WF_DEF`;
commit;

-- Rune in CBS Admin 

-- Add Admin role
-- INSERT INTO `UserRole` (`Id`, `rolename`, `userrolestatus`) VALUES (NULL, 'Admin', '1');

START TRANSACTION;
Set @roleId = '2', @Userid = '1';
INSERT INTO `RoleOfUser` (`roleid`, `usrid`) VALUES ( @roleId, @UserId);

INSERT INTO `UserRight` (`RoleId`, `CommandId`, `CommandIdDetail`, `Invoke`, `Approve`)
SELECT @roleId, WFID, 'A', 1, 1 FROM `neptune`.`WF_DEF`;
COMMIT;