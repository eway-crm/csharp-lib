"C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin\MSBuild.exe" "..\eWayCRM.sln" /p:Configuration="Release" /p:Platform="Any CPU" /noconsolelogger /v:minimal
"C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" "..\eWayCRM.API.UnitTests\bin\Release\eWayCRM.API.UnitTests.dll"

COPY "bin\Release\eWayCRM.API.*" "..\..\eWay-3\Tools\eWayCRM.API"

nuget.exe pack -properties Configuration=Release

PAUSE