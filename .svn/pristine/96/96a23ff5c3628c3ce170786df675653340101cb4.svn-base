ALTER TABLE MEEmrShareHistories ADD MEEmrShareHistoryMode varchar(10) 
GO
UPDATE MEEmrShareHistories SET MEEmrShareHistoryMode='Edit'
GO
ALTER TABLE MEEmrShareHistories ADD CONSTRAINT DF_MEEmrShareHistories_MEEmrShareHistoryMode DEFAULT 'Edit' FOR MEEmrShareHistoryMode
