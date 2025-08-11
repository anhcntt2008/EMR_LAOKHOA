
delete GELookupTables
where AAStatus = 'alive' and GELookupTableName ='HREmployeeStates'

INSERT INTO GELookupTables
values ((select max(GELookupTableID) from GELookupTables) + 1,'Alive','HREmployeeStates','HREmployeeStates','HREmployeeStateName')