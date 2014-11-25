rem deploy to azure
%MSBUILD_PATH% AspNetHosting\AspNetHosting.csproj /t:pipelinePreDeployCopyAllFilesToOneFolder /p:_PackageTempDir="%DEPLOYMENT_TARGET%";AutoParameterizationWebConfigConnectionStrings=false;Configuration=Debug;SolutionDir="%DEPLOYMENT_SOURCE%"

rem run FluentMigrator
"%DEPLOYMENT_SOURCE%\packages\FluentMigrator.Tools.1.3.0.0\tools\AnyCPU\40\Migrate.exe" /conn "%SQLAZURECONNSTR_NancyOwinAzure%" /provider sqlserver2012 /assembly "%DEPLOYMENT_SOURCE%\AspNetHosting\bin\AspNetHosting.dll" /verbose true
