NancyOwinAzure-sample
=====================

　  
## Deploy to Azure
[![Deploy to Azure](http://azuredeploy.net/deploybutton.png)](https://azuredeploy.net/)

　  
after deployment, run FlumentMigrator task. (use `.deployment`file and `deploy.cmd`. see: [deploy.cmd](https://github.com/thinkAmi/NancyOwinAzure-sample/blob/master/deploy.cmd))

　  
## Tested environment

- Windows7 x64
- .NET Framework 4.5
- NuGet package
  - Nancy.Owin 0.23.2
  - Dapper 1.38
  - FluentMigrator 1.3.0.0

　   
## Notes
URL `<AppName>.azurewebsites.com//connection/webconfig` shows all connection strings, contains Sql database's id and password.

　  
## Related slide (written in Japanese)
[デプロイボタンを使ってみた // Speaker Deck](https://speakerdeck.com/thinkami/depuroibotanwoshi-tutemita)
