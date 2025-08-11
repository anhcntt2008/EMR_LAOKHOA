--MEEmrTypeActions
IF EXISTS(SELECT * FROM sys.indexes WHERE OBJECT_ID = OBJECT_ID('MEEmrTypeActions') AND NAME ='IX_MEEmrTypeActions_GetAllByTypeIdAndWhen')
    DROP INDEX IX_MEEmrTypeActions_GetAllByTypeIdAndWhen ON MEEmrTypeActions;
CREATE INDEX IX_MEEmrTypeActions_GetAllByTypeIdAndWhen ON MEEmrTypeActions(AAStatus, FK_MEEmrTypeID, MEEmrTypeActionWhen, MEEmrTypeActionOrder ASC);
