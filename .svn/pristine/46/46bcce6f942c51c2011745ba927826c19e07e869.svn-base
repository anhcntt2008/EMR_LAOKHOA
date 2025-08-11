
ALTER TABLE [dbo].[MEParams] ADD MEParamControlType nvarchar(100) null;
GO
INSERT INTO [dbo].[AAColumnAlias] VALUES (
(SELECT MAX([AAColumnAliasID])+1 FROM [dbo].[AAColumnAlias] )
, 0, '', 'Alive', 'MEParamControlType', N'Loại control', 'MEParams');
GO

INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX(ADConfigValueID) + 1 FROM [ADConfigValues]), 'Alive', N'ParamControlTypeTextbox', N'Textbox', N'Textbox', NULL, N'ParamControlType', '1');
INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX(ADConfigValueID) + 1 FROM [ADConfigValues]), 'Alive', N'ParamControlTypeDatePicker', N'DatePicker', N'Date Picker', NULL, N'ParamControlType', '1');
INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX(ADConfigValueID) + 1 FROM [ADConfigValues]), 'Alive', N'ParamControlTypeRadio', N'Radio', N'Radio', NULL, N'ParamControlType', '1');
INSERT INTO [dbo].[ADConfigValues] VALUES ((SELECT MAX(ADConfigValueID) + 1 FROM [ADConfigValues]), 'Alive', N'ParamControlTypeCheckbox', N'Checkbox', N'Checkbox', NULL, N'ParamControlType', '1');