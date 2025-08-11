ALTER TABLE ADUsers add ADUserHISID varchar(100);
INSERT INTO [dbo].[AAColumnAlias] VALUES ((SELECT MAX(AAColumnAliasID)+1 FROM AAColumnAlias), 0, '', 'Alive', 'ADUserHISID', N'ID người dùng của HIS', 'ADUsers');


--UPDATE ADUsers set ADUserHISID = '9b57832b5c30b667eb3a52274ad25d2e' where ADUserName = 'KIOS'