DROP PROCEDURE [dbo].[MEVisitMedications_Insert]
GO
CREATE PROCEDURE [dbo].[MEVisitMedications_Insert]
	@MEVisitMedicationID int,
	@AAStatus varchar(50),
	@FK_MEPatientVisitID int,
	@FK_MEPatientID int,
	@FK_HREmployeeID int,
	@MEVisitMedicationDate datetime,
	@MEVisitMedicationFollowUpDate datetime,
	@MEVisitMedicationStatus varchar(50),
	@MEVisitMedicationRemark nvarchar(512),
	@MEVisitMedicationDiscountFix float,
	@MEVisitMedicationDiscountPercent float,
	@MEVisitMedicationNetAmount float,
	@MEVisitMedicationTaxAmount float,
	@MEVisitMedicationSubTotalAmount float,
	@MEVisitMedicationTotalAmount float,
	@MEVisitMedicationDoctorNote nvarchar(512),
	@MEVisitMedicationICD10No varchar(20),
	@MEVisitMedicationNotes nvarchar(512)

AS
BEGIN
SET NOCOUNT ON
INSERT INTO [dbo].[MEVisitMedications](
	[MEVisitMedicationID],
	[AAStatus],
	[FK_MEPatientVisitID],
	[FK_MEPatientID],
	[FK_HREmployeeID],
	[MEVisitMedicationDate],
	[MEVisitMedicationFollowUpDate],
	[MEVisitMedicationStatus],
	[MEVisitMedicationRemark],
	[MEVisitMedicationDiscountFix],
	[MEVisitMedicationDiscountPercent],
	[MEVisitMedicationNetAmount],
	[MEVisitMedicationTaxAmount],
	[MEVisitMedicationSubTotalAmount],
	[MEVisitMedicationTotalAmount],
	[MEVisitMedicationDoctorNote],
	[MEVisitMedicationICD10No],
	[MEVisitMedicationNotes]

) VALUES ( 
	@MEVisitMedicationID,
	@AAStatus,
	@FK_MEPatientVisitID,
	@FK_MEPatientID,
	@FK_HREmployeeID,
	@MEVisitMedicationDate,
	@MEVisitMedicationFollowUpDate,
	@MEVisitMedicationStatus,
	@MEVisitMedicationRemark,
	@MEVisitMedicationDiscountFix,
	@MEVisitMedicationDiscountPercent,
	@MEVisitMedicationNetAmount,
	@MEVisitMedicationTaxAmount,
	@MEVisitMedicationSubTotalAmount,
	@MEVisitMedicationTotalAmount,
	@MEVisitMedicationDoctorNote,
	@MEVisitMedicationICD10No,
	@MEVisitMedicationNotes

)
END

GO

DROP PROCEDURE [dbo].[MEVisitMedications_Update]

GO 

CREATE PROCEDURE [dbo].[MEVisitMedications_Update]
	@MEVisitMedicationID int,
	@AAStatus varchar(50),
	@FK_MEPatientVisitID int,
	@FK_MEPatientID int,
	@FK_HREmployeeID int,
	@MEVisitMedicationDate datetime,
	@MEVisitMedicationFollowUpDate datetime,
	@MEVisitMedicationStatus varchar(50),
	@MEVisitMedicationRemark nvarchar(512),
	@MEVisitMedicationDiscountFix float,
	@MEVisitMedicationDiscountPercent float,
	@MEVisitMedicationNetAmount float,
	@MEVisitMedicationTaxAmount float,
	@MEVisitMedicationSubTotalAmount float,
	@MEVisitMedicationTotalAmount float,
	@MEVisitMedicationDoctorNote nvarchar(512),
	@MEVisitMedicationICD10No varchar(20),
	@MEVisitMedicationNotes nvarchar(512)

AS
BEGIN
SET NOCOUNT ON
UPDATE [dbo].[MEVisitMedications] SET
	[AAStatus]=@AAStatus,
	[FK_MEPatientVisitID]=@FK_MEPatientVisitID,
	[FK_MEPatientID]=@FK_MEPatientID,
	[FK_HREmployeeID]=@FK_HREmployeeID,
	[MEVisitMedicationDate]=@MEVisitMedicationDate,
	[MEVisitMedicationFollowUpDate]=@MEVisitMedicationFollowUpDate,
	[MEVisitMedicationStatus]=@MEVisitMedicationStatus,
	[MEVisitMedicationRemark]=@MEVisitMedicationRemark,
	[MEVisitMedicationDiscountFix]=@MEVisitMedicationDiscountFix,
	[MEVisitMedicationDiscountPercent]=@MEVisitMedicationDiscountPercent,
	[MEVisitMedicationNetAmount]=@MEVisitMedicationNetAmount,
	[MEVisitMedicationTaxAmount]=@MEVisitMedicationTaxAmount,
	[MEVisitMedicationSubTotalAmount]=@MEVisitMedicationSubTotalAmount,
	[MEVisitMedicationTotalAmount]=@MEVisitMedicationTotalAmount,
	[MEVisitMedicationDoctorNote]=@MEVisitMedicationDoctorNote,
	[MEVisitMedicationICD10No]=@MEVisitMedicationICD10No,
	[MEVisitMedicationNotes]=@MEVisitMedicationNotes
WHERE 
		[MEVisitMedicationID]=@MEVisitMedicationID
END
GO