using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using Dapper;

namespace AspNetHosting
{
    public class DapperClass
    {
        public static IEnumerable<Ringo> SelectByID(string id)
        {
            // Nancyで例外を表示しているのを確認するために、数字以外は例外を出すようにする
            var parsedID = int.Parse(id);


            using (var cn = new SqlConnection(Environment.GetEnvironmentVariable("SQLAZURECONNSTR_NancyOwinAzure").ToString()))
            {
                cn.Open();

                var sql = "SELECT * FROM Ringo WHERE IDCol = @ID";
                var result = cn.Query<Ringo>(sql, new { ID = parsedID });

                cn.Close();

                return result;
            }
        }

        public class Ringo
        {
            public int IDCol { get; set; }
            public string ContentCol { get; set; }
        }
    }
}