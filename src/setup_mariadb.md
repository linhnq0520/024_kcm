## 1. Modify settings.json (src/ShareFiles/{service-name}/settings.json)
Example:
```json
{
    "ConnectionStrings": {
      "ConnectionString": "server=neptunedb_mariadb;database=o9admin;allowuservariables=True;user id=o9admin;password=o9admin;port=3306",
      "DataProvider": "mysql",
      "SQLCommandTimeout": null
    },
    "CacheConfig": {
      "DefaultCacheTime": 60,
      "ShortTermCacheTime": 3,
      "BundledFilesCacheTime": 120
    },
    "Kestrel": {
      "Endpoints": {
        "Grpc": {
          "Protocols": "Http2",
          "Url": "https://*:5000",
          "Certificate": {
            "Path": "NT.pfx",
            "Password": "123456"
          }
        },
        "webApi": {
          "Protocols": "Http1",
          "Url": "http://*:80"
        }
      }
    },
    "NeptuneConfiguration": {
    "NeptuneGrpcToken": "123456",
      "NeptuneGrpcURL": "https://neptuneserver:109/",
      "YourServiceID": "ADM",
      "YourGrpcURL": "https://admin.api:5000"
    }
}
```

## 2. Deploy Portainer, Phpmyadmin, NeptuneServer and Services.
At Directory `src/ShareFiles` run:
```
docker compose -f ./docker-compose.mariadb.yml up -d --build portainer
docker compose -f ./docker-compose.mariadb.yml up -d --build phpmyadmin
docker compose -f ./docker-compose.mariadb.yml up -d --build neptunedb_mariadb
```
## 3. Run script: `src/ShareFiles/neptuneserver/0.schema_scripts.sql`
## 4. Import structure database `neptune`
## 5. Insert data `neptune`
```sql
UPDATE `ENVIRONMENT_VARIABLE` SET `E1` = 'rabbitmq' WHERE `ENVIRONMENT_VARIABLE`.`VARIABLE_NAME` = 'MESSAGE_BROKER_HOSTNAME';
UPDATE `ENVIRONMENT_VARIABLE` SET `E1` = 'guest' WHERE `ENVIRONMENT_VARIABLE`.`VARIABLE_NAME` = 'MESSAGE_BROKER_USERNAME';
UPDATE `ENVIRONMENT_VARIABLE` SET `E1` = 'guest' WHERE `ENVIRONMENT_VARIABLE`.`VARIABLE_NAME` = 'MESSAGE_BROKER_PASSWORD';

DELETE FROM `SERVICE_DEF` WHERE SERVICE_CODE IN ('ADM', 'ACT', 'CSH', 'CRD', 'CTM', 'DPT', 'IFC', 'FX', 'FAC', 'PMT', 'MTG', 'BCH', 'CMS', 'SPL', 'VCH');

INSERT INTO `SERVICE_DEF` (`SERVICE_ID`, `SERVICE_CODE`, `SERVICE_NAME`, `STATUS`, `QUEUE_NAME`, `ACCEPT_TIME`, `GRPC_URL`, `GRPC_STATUS`, `GRPC_TIMEOUT`, `EVENT_REGISTRATION`, `IMPORT_EXPORT_STEP_CODE`, `CONCURRENT_THREADS`) VALUES ('ACT', 'ACT', 'Accounting service', 'Active', 'queue-act', '0', '', '0', '60', 'Mine', 'Yes', 8);
INSERT INTO `SERVICE_DEF` (`SERVICE_ID`, `SERVICE_CODE`, `SERVICE_NAME`, `STATUS`, `QUEUE_NAME`, `ACCEPT_TIME`, `GRPC_URL`, `GRPC_STATUS`, `GRPC_TIMEOUT`, `EVENT_REGISTRATION`, `IMPORT_EXPORT_STEP_CODE`, `CONCURRENT_THREADS`) VALUES ('ADM', 'ADM', 'Admin service', 'Active', 'queue-adm', '0', '', '0', '60', 'Always', 'Yes', 8);
INSERT INTO `SERVICE_DEF` (`SERVICE_ID`, `SERVICE_CODE`, `SERVICE_NAME`, `STATUS`, `QUEUE_NAME`, `ACCEPT_TIME`, `GRPC_URL`, `GRPC_STATUS`, `GRPC_TIMEOUT`, `EVENT_REGISTRATION`, `IMPORT_EXPORT_STEP_CODE`, `CONCURRENT_THREADS`) VALUES ('CSH', 'CSH', 'Cash service', 'Active', 'queue-csh', '0', '', '0', '60', 'Mine', 'Yes', 8);
INSERT INTO `SERVICE_DEF` (`SERVICE_ID`, `SERVICE_CODE`, `SERVICE_NAME`, `STATUS`, `QUEUE_NAME`, `ACCEPT_TIME`, `GRPC_URL`, `GRPC_STATUS`, `GRPC_TIMEOUT`, `EVENT_REGISTRATION`, `IMPORT_EXPORT_STEP_CODE`, `CONCURRENT_THREADS`) VALUES ('CRD', 'CRD', 'Credit service', 'Active', 'queue-crd', '0', '', '0', '60', 'Mine', 'Yes', 8);
INSERT INTO `SERVICE_DEF` (`SERVICE_ID`, `SERVICE_CODE`, `SERVICE_NAME`, `STATUS`, `QUEUE_NAME`, `ACCEPT_TIME`, `GRPC_URL`, `GRPC_STATUS`, `GRPC_TIMEOUT`, `EVENT_REGISTRATION`, `IMPORT_EXPORT_STEP_CODE`, `CONCURRENT_THREADS`) VALUES ('CTM', 'CTM', 'Customer service', 'Active', 'queue-ctm', '0', '', '0', '60', 'Mine', 'Yes', 8);
INSERT INTO `SERVICE_DEF` (`SERVICE_ID`, `SERVICE_CODE`, `SERVICE_NAME`, `STATUS`, `QUEUE_NAME`, `ACCEPT_TIME`, `GRPC_URL`, `GRPC_STATUS`, `GRPC_TIMEOUT`, `EVENT_REGISTRATION`, `IMPORT_EXPORT_STEP_CODE`, `CONCURRENT_THREADS`) VALUES ('DPT', 'DPT', 'Deposit service', 'Active', 'queue-dpt', '0', '', '0', '60', 'Mine', 'Yes', 8);
INSERT INTO `SERVICE_DEF` (`SERVICE_ID`, `SERVICE_CODE`, `SERVICE_NAME`, `STATUS`, `QUEUE_NAME`, `ACCEPT_TIME`, `GRPC_URL`, `GRPC_STATUS`, `GRPC_TIMEOUT`, `EVENT_REGISTRATION`, `IMPORT_EXPORT_STEP_CODE`, `CONCURRENT_THREADS`) VALUES ('FAC', 'FAC', 'Fixed Asset service', 'Active', 'queue-fac', '0', '', '0', '60', 'Mine', 'Yes', 8);
INSERT INTO `SERVICE_DEF` (`SERVICE_ID`, `SERVICE_CODE`, `SERVICE_NAME`, `STATUS`, `QUEUE_NAME`, `ACCEPT_TIME`, `GRPC_URL`, `GRPC_STATUS`, `GRPC_TIMEOUT`, `EVENT_REGISTRATION`, `IMPORT_EXPORT_STEP_CODE`, `CONCURRENT_THREADS`) VALUES ('FX', 'FX', 'Foreign Exchange service', 'Active', 'queue-fx', '0', '', '0', '60', 'Mine', 'Yes', 8);
INSERT INTO `SERVICE_DEF` (`SERVICE_ID`, `SERVICE_CODE`, `SERVICE_NAME`, `STATUS`, `QUEUE_NAME`, `ACCEPT_TIME`, `GRPC_URL`, `GRPC_STATUS`, `GRPC_TIMEOUT`, `EVENT_REGISTRATION`, `IMPORT_EXPORT_STEP_CODE`, `CONCURRENT_THREADS`) VALUES ('IFC', 'IFC', 'IFC service', 'Active', 'queue-ifc', '0', '', '0', '60', 'Mine', 'Yes', 8);
INSERT INTO `SERVICE_DEF` (`SERVICE_ID`, `SERVICE_CODE`, `SERVICE_NAME`, `STATUS`, `QUEUE_NAME`, `ACCEPT_TIME`, `GRPC_URL`, `GRPC_STATUS`, `GRPC_TIMEOUT`, `EVENT_REGISTRATION`, `IMPORT_EXPORT_STEP_CODE`, `CONCURRENT_THREADS`) VALUES ('MTG', 'MTG', 'Mortgage service', 'Active', 'queue-mtg', '0', '', '0', '60', 'Mine', 'Yes', 8);
INSERT INTO `SERVICE_DEF` (`SERVICE_ID`, `SERVICE_CODE`, `SERVICE_NAME`, `STATUS`, `QUEUE_NAME`, `ACCEPT_TIME`, `GRPC_URL`, `GRPC_STATUS`, `GRPC_TIMEOUT`, `EVENT_REGISTRATION`, `IMPORT_EXPORT_STEP_CODE`, `CONCURRENT_THREADS`) VALUES ('PMT', 'PMT', 'Payment service', 'Active', 'queue-pmt', '0', '', '0', '60', 'Mine', 'Yes', 8);
INSERT INTO `SERVICE_DEF` (`SERVICE_ID`, `SERVICE_CODE`, `SERVICE_NAME`, `STATUS`, `QUEUE_NAME`, `ACCEPT_TIME`, `GRPC_URL`, `GRPC_STATUS`, `GRPC_TIMEOUT`, `EVENT_REGISTRATION`, `IMPORT_EXPORT_STEP_CODE`, `CONCURRENT_THREADS`) VALUES ('BCH', 'BCH', 'Batch service', 'Active', 'queue-bch', '0', '', '0', '60', 'Mine', 'Yes', 8);
INSERT INTO `SERVICE_DEF` (`SERVICE_ID`, `SERVICE_CODE`, `SERVICE_NAME`, `STATUS`, `QUEUE_NAME`, `ACCEPT_TIME`, `GRPC_URL`, `GRPC_STATUS`, `GRPC_TIMEOUT`, `EVENT_REGISTRATION`, `IMPORT_EXPORT_STEP_CODE`, `CONCURRENT_THREADS`) VALUES ('CMS', 'CMS', 'CMS service', 'Active', 'queue-cms', '0', '', '0', '60', 'Always', 'Yes', 8);
INSERT INTO `SERVICE_DEF` (`SERVICE_ID`, `SERVICE_CODE`, `SERVICE_NAME`, `STATUS`, `QUEUE_NAME`, `ACCEPT_TIME`, `GRPC_URL`, `GRPC_STATUS`, `GRPC_TIMEOUT`, `EVENT_REGISTRATION`, `IMPORT_EXPORT_STEP_CODE`, `CONCURRENT_THREADS`) VALUES ('VCH', 'VCH', 'Voucher service', 'Active', 'queue-vch', '0', '', '0', '60', 'Mine', 'Yes', 8);
INSERT INTO `SERVICE_DEF` (`SERVICE_ID`, `SERVICE_CODE`, `SERVICE_NAME`, `STATUS`, `QUEUE_NAME`, `ACCEPT_TIME`, `GRPC_URL`, `GRPC_STATUS`, `GRPC_TIMEOUT`, `EVENT_REGISTRATION`, `IMPORT_EXPORT_STEP_CODE`, `CONCURRENT_THREADS`) VALUES ('SPL', 'SPL', 'Sample service', 'Active', 'queue-spl', '0', '', '0', '60', 'Mine', 'Yes', 8);
```