-- Xuan: Add index single/multi column
--MEEmrs
IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrs') AND NAME ='IX_MEEmrs_FK_BRBranchID_AAStatus')
    DROP INDEX IX_MEEmrs_FK_BRBranchID_AAStatus ON MEEmrs;
CREATE INDEX IX_MEEmrs_FK_BRBranchID_AAStatus ON MEEmrs(FK_BRBranchID, AAStatus);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrs') AND NAME ='IX_MEEmrs_FK_HRDepartmentID_AAStatus')
    DROP INDEX IX_MEEmrs_FK_HRDepartmentID_AAStatus ON MEEmrs;
CREATE INDEX IX_MEEmrs_FK_HRDepartmentID_AAStatus ON MEEmrs(FK_HRDepartmentID, AAStatus);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrs') AND NAME ='IX_MEEmrs_FK_HREmployeeClosedID_AAStatus')
    DROP INDEX IX_MEEmrs_FK_HREmployeeClosedID_AAStatus ON MEEmrs;
CREATE INDEX IX_MEEmrs_FK_HREmployeeClosedID_AAStatus ON MEEmrs(FK_HREmployeeClosedID, AAStatus);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrs') AND NAME ='IX_MEEmrs_FK_HREmployeeCreatedID_AAStatus')
    DROP INDEX IX_MEEmrs_FK_HREmployeeCreatedID_AAStatus ON MEEmrs;
CREATE INDEX IX_MEEmrs_FK_HREmployeeCreatedID_AAStatus ON MEEmrs(FK_HREmployeeCreatedID, AAStatus);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrs') AND NAME ='IX_MEEmrs_FK_MEEmrTypeID_AAStatus')
    DROP INDEX IX_MEEmrs_FK_MEEmrTypeID_AAStatus ON MEEmrs;
CREATE INDEX IX_MEEmrs_FK_MEEmrTypeID_AAStatus ON MEEmrs(FK_MEEmrTypeID, AAStatus);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrs') AND NAME ='IX_MEEmrs_FK_MEPatientID_AAStatus')
    DROP INDEX IX_MEEmrs_FK_MEPatientID_AAStatus ON MEEmrs;
CREATE INDEX IX_MEEmrs_FK_MEPatientID_AAStatus ON MEEmrs(FK_MEPatientID, AAStatus);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrs') AND NAME ='IX_MEEmrs_FK_MEPatientVisitID_AAStatus')
    DROP INDEX IX_MEEmrs_FK_MEPatientVisitID_AAStatus ON MEEmrs;
CREATE INDEX IX_MEEmrs_FK_MEPatientVisitID_AAStatus ON MEEmrs(FK_MEPatientVisitID, AAStatus);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrs') AND NAME ='IX_MEEmrs_MEEmrNo_AAStatus')
    DROP INDEX IX_MEEmrs_MEEmrNo_AAStatus ON MEEmrs;
CREATE INDEX IX_MEEmrs_MEEmrNo_AAStatus ON MEEmrs(MEEmrNo DESC, AAStatus);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrs') AND NAME ='IX_MEEmrs_MEEmrID_AAStatus')
    DROP INDEX IX_MEEmrs_MEEmrID_AAStatus ON MEEmrs;
CREATE INDEX IX_MEEmrs_MEEmrID_AAStatus ON MEEmrs(MEEmrID DESC, AAStatus);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrs') AND NAME ='IX_MEEmrs_AAStatus_FK_HRDepartmentID_MEEmrID')
    DROP INDEX IX_MEEmrs_AAStatus_FK_HRDepartmentID_MEEmrID ON MEEmrs;
CREATE INDEX IX_MEEmrs_AAStatus_FK_HRDepartmentID_MEEmrID ON MEEmrs(AAStatus, FK_HRDepartmentID, MEEmrID DESC);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrs') AND NAME ='IX_MEEmrs_FK_MEPatientID_AAStatus_MEEmrTypeProfile_MEEmrStatus')
    DROP INDEX IX_MEEmrs_FK_MEPatientID_AAStatus_MEEmrTypeProfile_MEEmrStatus ON MEEmrs;
CREATE INDEX IX_MEEmrs_FK_MEPatientID_AAStatus_MEEmrTypeProfile_MEEmrStatus ON MEEmrs(FK_MEPatientID, AAStatus,MEEmrTypeProfile, MEEmrStatus);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrs') AND NAME ='IX_MEEmrs_AAStatus_FK_MEEmrTypeID_MEEmrStatus_FK_MEPatientID')
    DROP INDEX IX_MEEmrs_AAStatus_FK_MEEmrTypeID_MEEmrStatus_FK_MEPatientID ON MEEmrs;
CREATE INDEX IX_MEEmrs_AAStatus_FK_MEEmrTypeID_MEEmrStatus_FK_MEPatientID ON MEEmrs(AAStatus, FK_MEEmrTypeID, MEEmrStatus, FK_MEPatientID);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrs') AND NAME ='IX_MEEmrs_Search')
    DROP INDEX IX_MEEmrs_Search ON MEEmrs;
CREATE INDEX IX_MEEmrs_Search ON MEEmrs(MEEmrNo, MEEmrStatus, FK_MEPatientID, FK_MEEmrTypeID, MEEmrCreatedDate DESC, MEEmrPatientGroup, MEEmrDateOut, AAStatus, FK_HRDepartmentID, MEEmrID DESC);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrs') AND NAME ='IX_MEEmrs_QuickSearch')
    DROP INDEX IX_MEEmrs_QuickSearch ON MEEmrs;
CREATE INDEX IX_MEEmrs_QuickSearch ON MEEmrs(MEEmrCreatedDate DESC, AAStatus, FK_HRDepartmentID, MEEmrID DESC);

--MEEmrDocuments
IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrDocuments') AND NAME ='IX_MEEmrDocuments_FK_EditingUserID_AAStatus')
    DROP INDEX IX_MEEmrDocuments_FK_EditingUserID_AAStatus ON MEEmrDocuments;
CREATE INDEX IX_MEEmrDocuments_FK_EditingUserID_AAStatus ON MEEmrDocuments(FK_EditingUserID, AAStatus);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrDocuments') AND NAME ='IX_MEEmrDocuments_FK_METemplateID_AAStatus')
    DROP INDEX IX_MEEmrDocuments_FK_METemplateID_AAStatus ON MEEmrDocuments;
CREATE INDEX IX_MEEmrDocuments_FK_METemplateID_AAStatus ON MEEmrDocuments(FK_METemplateID, AAStatus);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrDocuments') AND NAME ='IX_MEEmrDocuments_FK_HRDepartmentID_AAStatus')
    DROP INDEX IX_MEEmrDocuments_FK_HRDepartmentID_AAStatus ON MEEmrDocuments;
CREATE INDEX IX_MEEmrDocuments_FK_HRDepartmentID_AAStatus ON MEEmrDocuments(FK_HRDepartmentID, AAStatus);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrDocuments') AND NAME ='IX_MEEmrDocuments_FK_HREmployeeCreatedID_AAStatus')
    DROP INDEX IX_MEEmrDocuments_FK_HREmployeeCreatedID_AAStatus ON MEEmrDocuments;
CREATE INDEX IX_MEEmrDocuments_FK_HREmployeeCreatedID_AAStatus ON MEEmrDocuments(FK_HREmployeeCreatedID, AAStatus);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrDocuments') AND NAME ='IX_MEEmrDocuments_FK_MEEmrID_AAStatus')
    DROP INDEX IX_MEEmrDocuments_FK_MEEmrID_AAStatus ON MEEmrDocuments;
CREATE INDEX IX_MEEmrDocuments_FK_MEEmrID_AAStatus ON MEEmrDocuments(FK_MEEmrID DESC, AAStatus);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrDocuments') AND NAME ='IX_MEEmrDocuments_AAStatus_FK_MEEmrID_MEEmrDocumentGroup')
    DROP INDEX IX_MEEmrDocuments_AAStatus_FK_MEEmrID_MEEmrDocumentGroup ON MEEmrDocuments;
CREATE INDEX IX_MEEmrDocuments_AAStatus_FK_MEEmrID_MEEmrDocumentGroup ON MEEmrDocuments(AAStatus, FK_MEEmrID DESC, MEEmrDocumentGroup);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrDocuments') AND NAME ='IX_MEEmrDocuments_AAStatus_MEEmrDocumentCreatedDate')
    DROP INDEX IX_MEEmrDocuments_AAStatus_MEEmrDocumentCreatedDate ON MEEmrDocuments;
CREATE INDEX IX_MEEmrDocuments_AAStatus_MEEmrDocumentCreatedDate ON MEEmrDocuments(AAStatus, MEEmrDocumentCreatedDate DESC);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrDocuments') AND NAME ='IX_MEEmrDocuments_AAStatus_FK_MEEmrID_MEEmrDocumentStatus')
    DROP INDEX IX_MEEmrDocuments_AAStatus_FK_MEEmrID_MEEmrDocumentStatus ON MEEmrDocuments;
CREATE INDEX IX_MEEmrDocuments_AAStatus_FK_MEEmrID_MEEmrDocumentStatus ON MEEmrDocuments(AAStatus, FK_MEEmrID DESC, MEEmrDocumentStatus);

-- MEEmrShareHistories
IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrShareHistories') AND NAME ='IX_MEEmrShareHistories_SearchEmr')
    DROP INDEX IX_MEEmrShareHistories_SearchEmr ON MEEmrShareHistories;
CREATE INDEX IX_MEEmrShareHistories_SearchEmr ON MEEmrShareHistories(AAStatus, MEEmrShareHistoryActive, MEEmrShareHistoryFromDate, MEEmrShareHistoryToDate, FK_HRDepartmentID, FK_HREmployeeID);

-- MEEmrTypes
IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrTypes') AND NAME ='IX_MEEmrTypes_AAStatus_MEEmrTypeMaxCountPerPatient_MEEmrTypeIsTmp')
    DROP INDEX IX_MEEmrTypes_AAStatus_MEEmrTypeMaxCountPerPatient_MEEmrTypeIsTmp ON MEEmrTypes;
CREATE INDEX IX_MEEmrTypes_AAStatus_MEEmrTypeMaxCountPerPatient_MEEmrTypeIsTmp ON MEEmrTypes(AAStatus,MEEmrTypeMaxCountPerPatient, MEEmrTypeIsTmp);

-- MEPatients
IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEPatients') AND NAME ='IX_MEPatients_AAStatus_MEPatientID')
    DROP INDEX IX_MEPatients_AAStatus_MEPatientID ON MEPatients;
CREATE INDEX IX_MEPatients_AAStatus_MEPatientID ON MEPatients(AAStatus, MEPatientID);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEPatients') AND NAME ='IX_MEPatients_AAStatus_MEPatientBs24x7ID')
    DROP INDEX IX_MEPatients_AAStatus_MEPatientBs24x7ID ON MEPatients;
CREATE INDEX IX_MEPatients_AAStatus_MEPatientBs24x7ID ON MEPatients(AAStatus, MEPatientBs24x7ID);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEPatients') AND NAME ='IX_MEPatients_AAStatus_MEPatientContactEmail')
    DROP INDEX IX_MEPatients_AAStatus_MEPatientContactEmail ON MEPatients;
CREATE INDEX IX_MEPatients_AAStatus_MEPatientContactEmail ON MEPatients(AAStatus, MEPatientContactEmail);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEPatients') AND NAME ='IX_MEPatients_AAStatus_MEPatientIDCard')
    DROP INDEX IX_MEPatients_AAStatus_MEPatientIDCard ON MEPatients;
CREATE INDEX IX_MEPatients_AAStatus_MEPatientIDCard ON MEPatients(AAStatus, MEPatientIDCard);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEPatients') AND NAME ='IX_MEPatients_AAStatus_MEPatientNo')
    DROP INDEX IX_MEPatients_AAStatus_MEPatientNo ON MEPatients;
CREATE INDEX IX_MEPatients_AAStatus_MEPatientNo ON MEPatients(AAStatus, MEPatientNo);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEPatients') AND NAME ='IX_MEPatients_AAStatus_MEPatientName_MEPatientBirthday_MEGender_MEPatientIDCard')
    DROP INDEX IX_MEPatients_AAStatus_MEPatientName_MEPatientBirthday_MEGender_MEPatientIDCard ON MEPatients;
CREATE INDEX IX_MEPatients_AAStatus_MEPatientName_MEPatientBirthday_MEGender_MEPatientIDCard ON MEPatients(AAStatus, MEPatientName, MEPatientBirthday, MEGender, MEPatientIDCard);

-- METemplates
IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('METemplates') AND NAME ='IX_METemplates_AAStatus_METemplateType_FK_METemplateID')
    DROP INDEX IX_METemplates_AAStatus_METemplateType_FK_METemplateID ON METemplates;
CREATE INDEX IX_METemplates_AAStatus_METemplateType_FK_METemplateID ON METemplates(AAStatus, METemplateType, FK_METemplateID);

-- METemplateUserGroups : ok

-- ADUserGroups : ok

-- MEEmrDocumentSigns
IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrDocumentSigns') AND NAME ='IX_MEEmrDocumentSigns_FK_HRDepartmentID_AAStatus')
    DROP INDEX IX_MEEmrDocumentSigns_FK_HRDepartmentID_AAStatus ON MEEmrDocumentSigns;
CREATE INDEX IX_MEEmrDocumentSigns_FK_HRDepartmentID_AAStatus ON MEEmrDocumentSigns(FK_HRDepartmentID, AAStatus);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrDocumentSigns') AND NAME ='IX_MEEmrDocumentSigns_FK_HREmployeeID_AAStatus')
    DROP INDEX IX_MEEmrDocumentSigns_FK_HREmployeeID_AAStatus ON MEEmrDocumentSigns;
CREATE INDEX IX_MEEmrDocumentSigns_FK_HREmployeeID_AAStatus ON MEEmrDocumentSigns(FK_HREmployeeID, AAStatus);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrDocumentSigns') AND NAME ='IX_MEEmrDocumentSigns_FK_MEEmrDocumentID_AAStatus')
    DROP INDEX IX_MEEmrDocumentSigns_FK_MEEmrDocumentID_AAStatus ON MEEmrDocumentSigns;
CREATE INDEX IX_MEEmrDocumentSigns_FK_MEEmrDocumentID_AAStatus ON MEEmrDocumentSigns(FK_MEEmrDocumentID DESC, AAStatus);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrDocumentSigns') AND NAME ='IX_MEEmrDocumentSigns_FK_MEEmrDocumentID_MEEmrDocumentSignFileExt_AAStatus_MEEmrDocumentSignType')
    DROP INDEX IX_MEEmrDocumentSigns_FK_MEEmrDocumentID_MEEmrDocumentSignFileExt_AAStatus_MEEmrDocumentSignType ON MEEmrDocumentSigns;
CREATE INDEX IX_MEEmrDocumentSigns_FK_MEEmrDocumentID_MEEmrDocumentSignFileExt_AAStatus_MEEmrDocumentSignType ON MEEmrDocumentSigns(FK_MEEmrDocumentID DESC, MEEmrDocumentSignFileExt, AAStatus, MEEmrDocumentSignType);

-- MEEmrActions
IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrActions') AND NAME ='IX_MEEmrActions_MEEmrActionNo_AAStatus')
    DROP INDEX IX_MEEmrActions_MEEmrActionNo_AAStatus ON MEEmrActions;
CREATE INDEX IX_MEEmrActions_MEEmrActionNo_AAStatus ON MEEmrActions(MEEmrActionNo, AAStatus);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrActions') AND NAME ='IX_MEEmrActions_MEEmrActionName_AAStatus')
    DROP INDEX IX_MEEmrActions_MEEmrActionName_AAStatus ON MEEmrActions;
CREATE INDEX IX_MEEmrActions_MEEmrActionName_AAStatus ON MEEmrActions(MEEmrActionName, AAStatus);

-- MEParams
IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEParams') AND NAME ='IX_MEParams_MEParamNo_AAStatus')
    DROP INDEX IX_MEParams_MEParamNo_AAStatus ON MEParams;
CREATE INDEX IX_MEParams_MEParamNo_AAStatus ON MEParams(MEParamNo DESC, AAStatus);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEParams') AND NAME ='IX_MEParams_MEParamName_AAStatus')
    DROP INDEX IX_MEParams_MEParamName_AAStatus ON MEParams;
CREATE INDEX IX_MEParams_MEParamName_AAStatus ON MEParams(MEParamName, AAStatus);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEParams') AND NAME ='IX_MEParams_AAStatus_MEParamID')
    DROP INDEX IX_MEParams_AAStatus_MEParamID ON MEParams;
CREATE INDEX IX_MEParams_AAStatus_MEParamID ON MEParams(AAStatus, MEParamID);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEParams') AND NAME ='IX_MEParams_AACreatedDate')
    DROP INDEX IX_MEParams_AACreatedDate ON MEParams;
CREATE INDEX IX_MEParams_AACreatedDate ON MEParams(AACreatedDate);

IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEParams') AND NAME ='IX_MEParams_AAUpdatedDate')
    DROP INDEX IX_MEParams_AAUpdatedDate ON MEParams;
CREATE INDEX IX_MEParams_AAUpdatedDate ON MEParams(AAUpdatedDate);

-- MEParamLookupDatas
IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEParamLookupDatas') AND NAME ='IX_MEParamLookupDatas_AAStatus_MEParamLookupDataValue')
    DROP INDEX IX_MEParamLookupDatas_AAStatus_MEParamLookupDataValue ON MEParamLookupDatas;
CREATE INDEX IX_MEParamLookupDatas_AAStatus_MEParamLookupDataValue ON MEParamLookupDatas(AAStatus, MEParamLookupDataValue);

-- MEEmrActionParams
IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrActionParams') AND NAME ='IX_MEEmrActionParams_FK_MEEmrActionID_AAStatus')
    DROP INDEX IX_MEEmrActionParams_FK_MEEmrActionID_AAStatus ON MEEmrActionParams;
CREATE INDEX IX_MEEmrActionParams_FK_MEEmrActionID_AAStatus ON MEEmrActionParams(FK_MEEmrActionID, AAStatus);

-- MEParamRelations
IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEParamRelations') AND NAME ='IX_MEParamRelations_FK_MEParamParentID_AAStatus')
    DROP INDEX IX_MEParamRelations_FK_MEParamParentID_AAStatus ON MEParamRelations;
CREATE INDEX IX_MEParamRelations_FK_MEParamParentID_AAStatus ON MEParamRelations(FK_MEParamParentID, AAStatus);

-- MEEmrTemplateActions
IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrTemplateActions') AND NAME ='IX_MEEmrTemplateActions_AAStatus_FK_METemplateID_MEEmrTemplateActionWhen')
    DROP INDEX IX_MEEmrTemplateActions_AAStatus_FK_METemplateID_MEEmrTemplateActionWhen ON MEEmrTemplateActions;
CREATE INDEX IX_MEEmrTemplateActions_AAStatus_FK_METemplateID_MEEmrTemplateActionWhen ON MEEmrTemplateActions(AAStatus, FK_METemplateID, MEEmrTemplateActionWhen);

-- MEEmrTypeTemplates
IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrTypeTemplates') AND NAME ='IX_MEEmrTypeTemplates_AAStatus_FK_MEEmrTypeID_FK_METemplateID')
    DROP INDEX IX_MEEmrTypeTemplates_AAStatus_FK_MEEmrTypeID_FK_METemplateID ON MEEmrTypeTemplates;
CREATE INDEX IX_MEEmrTypeTemplates_AAStatus_FK_MEEmrTypeID_FK_METemplateID ON MEEmrTypeTemplates(AAStatus, FK_MEEmrTypeID, FK_METemplateID);

-- MEEmrActionRelations
IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrActionRelations') AND NAME ='IX_MEEmrActionRelations_FK_MEEmrActionParentID_AAStatus')
    DROP INDEX IX_MEEmrActionRelations_FK_MEEmrActionParentID_AAStatus ON MEEmrActionRelations;
CREATE INDEX IX_MEEmrActionRelations_FK_MEEmrActionParentID_AAStatus ON MEEmrActionRelations(FK_MEEmrActionParentID, AAStatus);

-- HREmployees
IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('HREmployees') AND NAME ='IX_HREmployees_HREmployeeID_AAStatus')
    DROP INDEX IX_HREmployees_HREmployeeID_AAStatus ON HREmployees;
CREATE INDEX IX_HREmployees_HREmployeeID_AAStatus ON HREmployees(HREmployeeID, AAStatus);

-- ADUserConfigs
IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('ADUserConfigs') AND NAME ='IX_ADUserConfigs_FK_ADUserID_AAStatus')
    DROP INDEX IX_ADUserConfigs_FK_ADUserID_AAStatus ON ADUserConfigs;
CREATE INDEX IX_ADUserConfigs_FK_ADUserID_AAStatus ON ADUserConfigs(FK_ADUserID, AAStatus);

-- METemplateParams
IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('METemplateParams') AND NAME ='IX_METemplateParams_AAStatus_FK_METemplateID_METemplateParamRequired')
    DROP INDEX IX_METemplateParams_AAStatus_FK_METemplateID_METemplateParamRequired ON METemplateParams;
CREATE INDEX IX_METemplateParams_AAStatus_FK_METemplateID_METemplateParamRequired ON METemplateParams(AAStatus, FK_METemplateID, METemplateParamRequired);

-- METemplateIndexs
IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('METemplateIndexs') AND NAME ='IX_METemplateIndexs_AAStatus_FK_MEEmrTypeID_METemplateIndexName')
    DROP INDEX IX_METemplateIndexs_AAStatus_FK_MEEmrTypeID_METemplateIndexName ON METemplateIndexs;
CREATE INDEX IX_METemplateIndexs_AAStatus_FK_MEEmrTypeID_METemplateIndexName ON METemplateIndexs(AAStatus, FK_MEEmrTypeID, METemplateIndexName);




