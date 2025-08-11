UPDATE GENumbering set GENumberingPrefix = 'P' Where GENumberingName = 'MEPatient'
UPDATE GENumbering set GENumberingPrefix = 'E', GENumberingLength= 6, GENumberingStart = 100003  Where GENumberingName = 'MEEmr'
