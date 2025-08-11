-- << BE CAREFUL >>
-- DO STEP BY STEP
-- 1. RUN SCRIPT BELLOW AND SAVE RESULT TO EXCEL - REMEMBER FOR FUTURE.
select ta.*, t.METemplateNo, t.AAStatus as [TemplateStatus] from MEEmrTemplateActions ta
INNER JOIN METemplates t ON ta.FK_METemplateID = t.METemplateID
WHERE ta.AAStatus = 'Alive' 
AND t.AAStatus ='Delete'

-- 2. RUN SCRIPT BELLOW FOR UPDATE 
UPDATE MEEmrTemplateActions 
SET AAStatus='Delete', AAUpdatedUser = 'sysupdatesql', AAUpdatedDate=GETDATE()
where MEEmrTemplateActionID in (select ta.MEEmrTemplateActionID from MEEmrTemplateActions ta
INNER JOIN METemplates t ON ta.FK_METemplateID = t.METemplateID
WHERE ta.AAStatus = 'Alive' 
AND t.AAStatus ='Delete')