-- B.1 -----
ALTER TABLE [dbo].[MEEmrs] DROP COLUMN MEEmrMetaNum1;
ALTER TABLE [dbo].[MEEmrs] DROP COLUMN MEEmrMetaNum2;
ALTER TABLE [dbo].[MEEmrs] DROP COLUMN MEEmrMetaNum3;
ALTER TABLE [dbo].[MEEmrs] DROP COLUMN MEEmrMetaNum4;
ALTER TABLE [dbo].[MEEmrs] DROP COLUMN MEEmrMetaNum5;
-- B.2 -----
 ALTER TABLE [dbo].[MEEmrs] ADD MEEmrMetaNum1 float
 ALTER TABLE [dbo].[MEEmrs] ADD MEEmrMetaNum2 float
 ALTER TABLE [dbo].[MEEmrs] ADD MEEmrMetaNum3 float
 ALTER TABLE [dbo].[MEEmrs] ADD MEEmrMetaNum4 float
 ALTER TABLE [dbo].[MEEmrs] ADD MEEmrMetaNum5 float
-- B.3 -----
 UPDATE [dbo].[MEEmrs] SET MEEmrMetaNum1 = 0
 UPDATE [dbo].[MEEmrs] SET MEEmrMetaNum2 = 0
 UPDATE [dbo].[MEEmrs] SET MEEmrMetaNum3 = 0
 UPDATE [dbo].[MEEmrs] SET MEEmrMetaNum4 = 0
 UPDATE [dbo].[MEEmrs] SET MEEmrMetaNum5 = 0

-- B.4 -----
------------------------
ALTER TABLE [dbo].[MEEmrs] ALTER COLUMN MEEmrMetaNum1 float NOT NULL
GO
ALTER TABLE [dbo].[MEEmrs] ALTER COLUMN MEEmrMetaNum2 float NOT NULL
GO
ALTER TABLE [dbo].[MEEmrs] ALTER COLUMN MEEmrMetaNum3 float NOT NULL
GO
ALTER TABLE [dbo].[MEEmrs] ALTER COLUMN MEEmrMetaNum4 float NOT NULL
GO
ALTER TABLE [dbo].[MEEmrs] ALTER COLUMN MEEmrMetaNum5 float NOT NULL
GO
-- B.5 -----
UPDATE [dbo].[MEEmrs] SET [MEEmrMetaDate1] = '9999-12-31 23:59:59.000' WHERE MEEmrMetaDate1 IS NULL
UPDATE [dbo].[MEEmrs] SET [MEEmrMetaDate2] = '9999-12-31 23:59:59.000' WHERE MEEmrMetaDate2 IS NULL
UPDATE [dbo].[MEEmrs] SET [MEEmrMetaDate3] = '9999-12-31 23:59:59.000' WHERE MEEmrMetaDate3 IS NULL
UPDATE [dbo].[MEEmrs] SET [MEEmrMetaDate4] = '9999-12-31 23:59:59.000' WHERE MEEmrMetaDate4 IS NULL
UPDATE [dbo].[MEEmrs] SET [MEEmrMetaDate5] = '9999-12-31 23:59:59.000' WHERE MEEmrMetaDate5 IS NULL

-- B.6 -----
------------------------
ALTER TABLE [dbo].[MEEmrs] ALTER COLUMN MEEmrMetaDate1 DATETIME NOT NULL
GO
ALTER TABLE [dbo].[MEEmrs] ALTER COLUMN MEEmrMetaDate2 DATETIME NOT NULL
GO
ALTER TABLE [dbo].[MEEmrs] ALTER COLUMN MEEmrMetaDate3 DATETIME NOT NULL
GO
ALTER TABLE [dbo].[MEEmrs] ALTER COLUMN MEEmrMetaDate4 DATETIME NOT NULL
GO
ALTER TABLE [dbo].[MEEmrs] ALTER COLUMN MEEmrMetaDate5 DATETIME NOT NULL
GO