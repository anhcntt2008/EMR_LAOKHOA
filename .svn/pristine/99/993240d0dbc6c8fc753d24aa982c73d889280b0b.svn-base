@ECHO OFF
set /p version="Version: "
ECHO ENCRYPT
.\Confuser\ConfuserEx_v1\Confuser.CLI.exe .\Confuser\emrConfuxer_core_16xx_dev_v2.crproj
ECHO PACKING
.\NugetPacking\.nuget\nuget.exe pack .\NugetPacking\.nuget\Clas.Emr.Core.v1.nuspec -OutputDirectory ".\NugetPacking\Release\\" -properties version=%version% 
ECHO PUSHING
.\NugetPacking\.nuget\nuget.exe push -Source "Clas.Emr.Core" -ApiKey az .\NugetPacking\Release\Clas.Emr.Core.%version%.nupkg -configFile ".\NugetPacking\.nuget\Nuget.Config"
ECHO DONE
PAUSE