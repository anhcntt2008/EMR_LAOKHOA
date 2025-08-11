-- sp_helpindex '[dbo].[GEObjectHistory]'
IF NOT EXISTS(SELECT * FROM sys.indexes WHERE name = 'IX_AAStatus_GEObjectHistoryObjectName_GEObjectHistoryObjectID_GEObjectHistoryAction_GEObjectHistory' AND object_id = OBJECT_ID('GEObjectHistory'))
BEGIN
	CREATE NONCLUSTERED INDEX IX_AAStatus_GEObjectHistoryObjectName_GEObjectHistoryObjectID_GEObjectHistoryAction_GEObjectHistory ON GEObjectHistory(AAStatus, GEObjectHistoryObjectName, GEObjectHistoryObjectID, GEObjectHistoryAction);
END