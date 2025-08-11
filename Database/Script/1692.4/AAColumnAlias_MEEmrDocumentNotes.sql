
DELETE FROM AAColumnAlias WHERE [AATableName] = 'MEEmrDocumentNotes'
INSERT INTO [dbo].[AAColumnAlias]([AAColumnAliasID], [AANumberInt], [AANumberString], [AAStatus], [AAColumnAliasName], [AAColumnAliasCaption], [AATableName]) VALUES (
(SELECT MAX(AAColumnAliasID)+ 1 FROM [AAColumnAlias]), 0, '', 'Alive', 'FK_HRDepartmentID', N'Khoa', 'MEEmrDocumentNotes');
INSERT INTO [dbo].[AAColumnAlias]([AAColumnAliasID], [AANumberInt], [AANumberString], [AAStatus], [AAColumnAliasName], [AAColumnAliasCaption], [AATableName]) VALUES (
(SELECT MAX(AAColumnAliasID)+ 1 FROM [AAColumnAlias]), 0, '', 'Alive', 'FK_HREmployeeID', N'Người ghi', 'MEEmrDocumentNotes');
INSERT INTO [dbo].[AAColumnAlias]([AAColumnAliasID], [AANumberInt], [AANumberString], [AAStatus], [AAColumnAliasName], [AAColumnAliasCaption], [AATableName]) VALUES (
(SELECT MAX(AAColumnAliasID)+ 1 FROM [AAColumnAlias]), 0, '', 'Alive', 'MEEmrDocumentNoteTime', N'Thời điểm', 'MEEmrDocumentNotes');
INSERT INTO [dbo].[AAColumnAlias]([AAColumnAliasID], [AANumberInt], [AANumberString], [AAStatus], [AAColumnAliasName], [AAColumnAliasCaption], [AATableName]) VALUES (
(SELECT MAX(AAColumnAliasID)+ 1 FROM [AAColumnAlias]), 0, '', 'Alive', 'MEEmrDocumentNoteText', N'Nội dung ghi chú', 'MEEmrDocumentNotes');