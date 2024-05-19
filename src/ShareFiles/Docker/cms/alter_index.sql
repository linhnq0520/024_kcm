
ALTER TABLE Bo ADD INDEX idx_app_txcode (App,TxCode);
ALTER TABLE Fo ADD INDEX idx_app_txcode (App,TxCode);
ALTER TABLE ParaServer ADD INDEX idx_app (App);
ALTER TABLE LearnApi ADD INDEX idx_app_id (App,LearnApiId);

CREATE INDEX Idx_Cdlist
ON  [dbo].[Cdlist] (Cdgrp, Cdname, App);