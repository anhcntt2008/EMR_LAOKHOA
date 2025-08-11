
-- ======================================================================
-- Author: UtHV
-- Lay danh sach Tu viet tat dc chia se de chon them vao lib cua minh
-- ======================================================================

CREATE PROCEDURE [dbo].[MEEmrAbbrevs_GetShared]
	@FK_HREmployeeID int
AS
BEGIN
SET NOCOUNT ON
SELECT
	*
FROM
	[dbo].[MEEmrAbbrevs]
WHERE
	[FK_HREmployeeID]<>@FK_HREmployeeID
	AND
		MEEmrAbbrevShared = 1
	AND
		[AAStatus]='Alive'
	AND 
		MEEmrAbbrevNo NOT IN (SELECT MEEmrAbbrevNo 
									FROM [MEEmrAbbrevs] 
									WHERE [FK_HREmployeeID]=@FK_HREmployeeID
											AND [AAStatus]='Alive')
END
GO