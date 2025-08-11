@ECHO OFF
set /p version="Version: "

ECHO DELETE Release\Dev
if exist "D:\emr\Repos\Emr.Desktop\SourceCode\BOSERPSolution\BOSERP\bin\Release\Dev\" rd /q /s "D:\emr\Repos\Emr.Desktop\SourceCode\BOSERPSolution\BOSERP\bin\Release\Dev"
if exist "D:\emr\Repos\Emr.Desktop\SourceCode\BOSERPSolution\BOSERP\bin\Release\Templates\" rd /q /s "D:\emr\Repos\Emr.Desktop\SourceCode\BOSERPSolution\BOSERP\bin\Release\Templates"

ECHO DELETE .xml
del /s /q /f D:\emr\Repos\Emr.Desktop\SourceCode\BOSERPSolution\BOSERP\bin\Release\*.xml

ECHO DELETE .pdb
del /s /q /f D:\emr\Repos\Emr.Desktop\SourceCode\BOSERPSolution\BOSERP\bin\Release\*.pdb

ECHO DELETE .pdb
del /s /q /f D:\emr\Repos\Emr.Desktop\SourceCode\BOSERPSolution\BOSERP\bin\Release\plugins\*.*

ECHO ENCRYPT
.\Confuser\ConfuserEx_v1\Confuser.CLI.exe .\Confuser\emrConfuxer_core_16xx_release_v2.crproj

"C:\Program Files\7-Zip\7z.exe" a -r %version%.zip -w "D:\emr\Repos\Emr.Desktop\SourceCode\BOSERPSolution\BOSERP\bin\Release\*.*"

ECHO DONE
PAUSE