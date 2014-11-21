rem deploy to azure
%MSBUILD_PATH% AspNetHosting\AspNetHosting.csproj /t:pipelinePreDeployCopyAllFilesToOneFolder /p:_PackageTempDir="%DEPLOYMENT_TARGET%";AutoParameterizationWebConfigConnectionStrings=false;Configuration=Debug;SolutionDir="%DEPLOYMENT_SOURCE%"

rem run FluentMigrator
"\packages\FluentMigrator.Tools.1.3.0.0\tools\AnyCPU\40\Migrate.exe" /conn "%SQLAZURECONNSTR_NancyOwinAzure%" /provider sqlserver2012 /assembly "\AspNetHosting\bin\AspNetHosting.dll" /verbose true
