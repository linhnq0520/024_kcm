-- 'neptune'
USE master
GO
CREATE DATABASE neptune CONTAINMENT = NONE
GO
CREATE LOGIN neptune WITH PASSWORD = 'neptune', DEFAULT_DATABASE = neptune, DEFAULT_LANGUAGE = us_english, CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF
GO
USE neptune
GO
CREATE USER neptune FOR LOGIN neptune
GO
USE master
GO
GRANT CONTROL SERVER TO neptune
GO

-- 'neptune_archive'
USE master
GO
CREATE DATABASE neptune_archive CONTAINMENT = NONE
GO
CREATE LOGIN neptune_archive WITH PASSWORD = 'neptune_archive', DEFAULT_DATABASE = neptune_archive, DEFAULT_LANGUAGE = us_english, CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF
GO
USE neptune_archive
GO
CREATE USER neptune_archive FOR LOGIN neptune_archive
GO
USE master
GO
GRANT CONTROL SERVER TO neptune_archive
GO

-- 'o9accounting'
USE master
GO
CREATE DATABASE o9accounting CONTAINMENT = NONE
GO
CREATE LOGIN o9accounting WITH PASSWORD = 'o9accounting', DEFAULT_DATABASE = o9accounting, DEFAULT_LANGUAGE = us_english, CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF
GO
USE o9accounting
GO
CREATE USER o9accounting FOR LOGIN o9accounting
GO
USE master
GO
GRANT CONTROL SERVER TO o9accounting
GO

-- 'o9admin'
USE master
GO
CREATE DATABASE o9admin CONTAINMENT = NONE
GO
CREATE LOGIN o9admin WITH PASSWORD = 'o9admin', DEFAULT_DATABASE = o9admin, DEFAULT_LANGUAGE = us_english, CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF
GO
USE o9admin
GO
CREATE USER o9admin FOR LOGIN o9admin
GO
USE master
GO
GRANT CONTROL SERVER TO o9admin
GO

-- 'o9batch'
USE master
GO
CREATE DATABASE o9batch CONTAINMENT = NONE
GO
CREATE LOGIN o9batch WITH PASSWORD = 'o9batch', DEFAULT_DATABASE = o9batch, DEFAULT_LANGUAGE = us_english, CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF
GO
USE o9batch
GO
CREATE USER o9batch FOR LOGIN o9batch
GO
USE master
GO
GRANT CONTROL SERVER TO o9batch
GO

-- 'o9card'
USE master
GO
CREATE DATABASE o9card CONTAINMENT = NONE
GO
CREATE LOGIN o9card WITH PASSWORD = 'o9card', DEFAULT_DATABASE = o9card, DEFAULT_LANGUAGE = us_english, CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF
GO
USE o9card
GO
CREATE USER o9card FOR LOGIN o9card
GO
USE master
GO
GRANT CONTROL SERVER TO o9card
GO

-- 'o9cash'
USE master
GO
CREATE DATABASE o9cash CONTAINMENT = NONE
GO
CREATE LOGIN o9cash WITH PASSWORD = 'o9cash', DEFAULT_DATABASE = o9cash, DEFAULT_LANGUAGE = us_english, CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF
GO
USE o9cash
GO
CREATE USER o9cash FOR LOGIN o9cash
GO
USE master
GO
GRANT CONTROL SERVER TO o9cash
GO

-- 'o9cms'
USE master
GO
CREATE DATABASE o9cms CONTAINMENT = NONE
GO
CREATE LOGIN o9cms WITH PASSWORD = 'o9cms', DEFAULT_DATABASE = o9cms, DEFAULT_LANGUAGE = us_english, CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF
GO
USE o9cms
GO
CREATE USER o9cms FOR LOGIN o9cms
GO
USE master
GO
GRANT CONTROL SERVER TO o9cms
GO

-- 'o9credit'
USE master
GO
CREATE DATABASE o9credit CONTAINMENT = NONE
GO
CREATE LOGIN o9credit WITH PASSWORD = 'o9credit', DEFAULT_DATABASE = o9credit, DEFAULT_LANGUAGE = us_english, CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF
GO
USE o9credit
GO
CREATE USER o9credit FOR LOGIN o9credit
GO
USE master
GO
GRANT CONTROL SERVER TO o9credit
GO

-- 'o9customer'
USE master
GO
CREATE DATABASE o9customer CONTAINMENT = NONE
GO
CREATE LOGIN o9customer WITH PASSWORD = 'o9customer', DEFAULT_DATABASE = o9customer, DEFAULT_LANGUAGE = us_english, CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF
GO
USE o9customer
GO
CREATE USER o9customer FOR LOGIN o9customer
GO
USE master
GO
GRANT CONTROL SERVER TO o9customer
GO

-- 'o9deposit'
USE master
GO
CREATE DATABASE o9deposit CONTAINMENT = NONE
GO
CREATE LOGIN o9deposit WITH PASSWORD = 'o9deposit', DEFAULT_DATABASE = o9deposit, DEFAULT_LANGUAGE = us_english, CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF
GO
USE o9deposit
GO
CREATE USER o9deposit FOR LOGIN o9deposit
GO
USE master
GO
GRANT CONTROL SERVER TO o9deposit
GO

-- 'o9email'
USE master
GO
CREATE DATABASE o9email CONTAINMENT = NONE
GO
CREATE LOGIN o9email WITH PASSWORD = 'o9email', DEFAULT_DATABASE = o9email, DEFAULT_LANGUAGE = us_english, CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF
GO
USE o9email
GO
CREATE USER o9email FOR LOGIN o9email
GO
USE master
GO
GRANT CONTROL SERVER TO o9email
GO

-- 'o9ems'
USE master
GO
CREATE DATABASE o9ems CONTAINMENT = NONE
GO
CREATE LOGIN o9ems WITH PASSWORD = 'o9ems', DEFAULT_DATABASE = o9ems, DEFAULT_LANGUAGE = us_english, CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF
GO
USE o9ems
GO
CREATE USER o9ems FOR LOGIN o9ems
GO
USE master
GO
GRANT CONTROL SERVER TO o9ems
GO

-- 'o9fixedasset'
USE master
GO
CREATE DATABASE o9fixedasset CONTAINMENT = NONE
GO
CREATE LOGIN o9fixedasset WITH PASSWORD = 'o9fixedasset', DEFAULT_DATABASE = o9fixedasset, DEFAULT_LANGUAGE = us_english, CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF
GO
USE o9fixedasset
GO
CREATE USER o9fixedasset FOR LOGIN o9fixedasset
GO
USE master
GO
GRANT CONTROL SERVER TO o9fixedasset
GO

-- 'o9fx'
USE master
GO
CREATE DATABASE o9fx CONTAINMENT = NONE
GO
CREATE LOGIN o9fx WITH PASSWORD = 'o9fx', DEFAULT_DATABASE = o9fx, DEFAULT_LANGUAGE = us_english, CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF
GO
USE o9fx
GO
CREATE USER o9fx FOR LOGIN o9fx
GO
USE master
GO
GRANT CONTROL SERVER TO o9fx
GO

-- 'o9import'
USE master
GO
CREATE DATABASE o9import CONTAINMENT = NONE
GO
CREATE LOGIN o9import WITH PASSWORD = 'o9import', DEFAULT_DATABASE = o9import, DEFAULT_LANGUAGE = us_english, CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF
GO
USE o9import
GO
CREATE USER o9import FOR LOGIN o9import
GO
USE master
GO
GRANT CONTROL SERVER TO o9import
GO

-- 'o9mortgage'
USE master
GO
CREATE DATABASE o9mortgage CONTAINMENT = NONE
GO
CREATE LOGIN o9mortgage WITH PASSWORD = 'o9mortgage', DEFAULT_DATABASE = o9mortgage, DEFAULT_LANGUAGE = us_english, CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF
GO
USE o9mortgage
GO
CREATE USER o9mortgage FOR LOGIN o9mortgage
GO
USE master
GO
GRANT CONTROL SERVER TO o9mortgage
GO

-- 'o9party'
USE master
GO
CREATE DATABASE o9party CONTAINMENT = NONE
GO
CREATE LOGIN o9party WITH PASSWORD = 'o9party', DEFAULT_DATABASE = o9party, DEFAULT_LANGUAGE = us_english, CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF
GO
USE o9party
GO
CREATE USER o9party FOR LOGIN o9party
GO
USE master
GO
GRANT CONTROL SERVER TO o9party
GO

-- 'o9payment'
USE master
GO
CREATE DATABASE o9payment CONTAINMENT = NONE
GO
CREATE LOGIN o9payment WITH PASSWORD = 'o9payment', DEFAULT_DATABASE = o9payment, DEFAULT_LANGUAGE = us_english, CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF
GO
USE o9payment
GO
CREATE USER o9payment FOR LOGIN o9payment
GO
USE master
GO
GRANT CONTROL SERVER TO o9payment
GO

-- 'o9report'
USE master
GO
CREATE DATABASE o9report CONTAINMENT = NONE
GO
CREATE LOGIN o9report WITH PASSWORD = 'o9report', DEFAULT_DATABASE = o9report, DEFAULT_LANGUAGE = us_english, CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF
GO
USE o9report
GO
CREATE USER o9report FOR LOGIN o9report
GO
USE master
GO
GRANT CONTROL SERVER TO o9report
GO

-- 'o9voucher'
USE master
GO
CREATE DATABASE o9voucher CONTAINMENT = NONE
GO
CREATE LOGIN o9voucher WITH PASSWORD = 'o9voucher', DEFAULT_DATABASE = o9voucher, DEFAULT_LANGUAGE = us_english, CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF
GO
USE o9voucher
GO
CREATE USER o9voucher FOR LOGIN o9voucher
GO
USE master
GO
GRANT CONTROL SERVER TO o9voucher
GO