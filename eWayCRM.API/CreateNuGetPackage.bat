@ECHO OFF

"C:\Program Files\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe" "..\eWayCRM.sln" /p:Configuration="Release" /p:Platform="Any CPU" /noconsolelogger /v:minimal
IF %ERRORLEVEL% NEQ 0 GOTO Error

"C:\Program Files\Microsoft Visual Studio\2022\Enterprise\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" "..\eWayCRM.API.UnitTests\bin\Release\eWayCRM.API.UnitTests.dll"
IF %ERRORLEVEL% NEQ 0 GOTO Error

COPY "bin\Release\eWayCRM.API.*" "..\..\Tools\eWayCRM.API"
IF %ERRORLEVEL% NEQ 0 GOTO Error

%~dp0..\..\Tools\nuget\nuget.exe pack -properties Configuration=Release
IF %ERRORLEVEL% NEQ 0 GOTO Error

ECHO.
ECHO Done
GOTO End

:Error
ECHO.
ECHO An error occured
GOTO End

:End
PAUSE