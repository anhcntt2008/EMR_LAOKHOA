
--backup db 
--chạy từng dòng
UPDATE [dbo].[MEEmrDocuments] set [MEEmrDocumentCode] = [MEEmrDocumentNo]
--------
UPDATE [dbo].[MEEmrDocuments] set MEEmrDocumentNo = (SELECT METemplateNo FROM METemplates WHERE [MEEmrDocuments].FK_METemplateID = METemplateID)

--------
BEGIN
WITH TB (MEEmrDocumentID, STT) as (
SELECT MEEmrDocumentID,
   ROW_NUMBER() OVER (PARTITION BY FK_MEEmrID, MEEmrDocumentGroup  ORDER BY MEEmrDocumentCreatedDate) as ROW
FROM [MEEmrDocuments])
UPDATE [MEEmrDocuments] SET MEEmrDocumentSubOrder = (SELECT STT FROM TB WHERE [MEEmrDocuments].MEEmrDocumentID = TB.MEEmrDocumentID)
END
-------