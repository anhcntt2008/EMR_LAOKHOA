UPDATE [dbo].[ADConfigValues] SET [AAStatus] = 'Delete', [ADConfigKey] = N'MEParamFormatTypeDate', [ADConfigKeyValue] = N'Date', [ADConfigText] = N'Ngày tháng (dd/MM/yyyy)', [ADConfigKeyDesc] = NULL, [ADConfigKeyGroup] = N'ParamFormatType', [IsActive] = '1' WHERE [ADConfigValueID] = 1424;

INSERT INTO [dbo].[MEParamLookups] VALUES (0, N'Dummy', 'Dummy', N'Dummy', '0', '2018-04-16 18:44:15.967', N'emr', '2018-04-17 14:23:43.553', N'emr');
