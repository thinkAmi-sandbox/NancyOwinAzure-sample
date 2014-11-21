using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using Nancy;

namespace AspNetHosting.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => "Hello World";


            Get["/json"] = _ =>
            {
                var ringo = new[]
                {
                    new { Id = 1, Name = "ふじ"},
                    new { Id = 2, Name = "シナノゴールド"}
                };

                return Response.AsJson(ringo);
            };


            Get["/1"] = _ =>
            {
                var ringo = DapperClass.SelectByID("1");
                var response = (Response)(ringo.FirstOrDefault().ContentCol);

                // DBから持ってきた日本語を表示する場合、charsetを指定しないと文字化けする
                response.ContentType = "text/html; charset=utf8";
                return response;
            };


            Get["/ringo/{id}"] = _ =>
            {
                // Response.AsJson()は動的クラスには使えないので、明示的にキャストする
                var ringo = (IEnumerable<DapperClass.Ringo>)DapperClass.SelectByID(_.id);

                // AsJsonの場合は、特にcharsetを指定しなくても日本語は文字化けしない
                return Response.AsJson(ringo);
            };


            // 接続文字列の確認
            // Web.config
            Get["/connection/webconfig"] = _ =>
            {
                var result = "";
                foreach (ConnectionStringSettings cs in ConfigurationManager.ConnectionStrings)
                {
                    result += ("[Name]" + cs.Name + "[Provider]" + cs.ProviderName + "[ConnectionString]" + cs.ConnectionString + " , ");
                }

                return result;
            };


            // Azureの環境変数による接続文字列
            Get["/connection/environment"] = _ =>
            {
                return Environment.GetEnvironmentVariable("SQLAZURECONNSTR_NancyOwinAzure").ToString();
            };
        }
    }
}