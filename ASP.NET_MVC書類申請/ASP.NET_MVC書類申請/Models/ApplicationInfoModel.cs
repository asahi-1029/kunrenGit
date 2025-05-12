using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP.NET_MVC追加機能.Models;

namespace ASP.NET_MVC追加機能.Models
{
    public class ApplicationInfoModel
    {
        public List<ApplicationInfoRowModel> 検索結果一覧;
        public void Find(string 状態)

        {
            if (状態 == "5")
            {
                string sql1 = "select * from application_info";
                MySqlConnection con = new MySqlConnection("server=localhost;user id=root; password=csharp;" + "database=csharp; convert zero datetime=True");
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(sql1, con);
                DataTable tb = new DataTable();

                da.Fill(tb);
                da.Dispose();
                con.Close();
                検索結果一覧 = new List<ApplicationInfoRowModel>();
                foreach (DataRow row in tb.Rows)
                {
                    ApplicationInfoRowModel result = new ApplicationInfoRowModel();
                    result.状態 = row["APPLY_STATUS"].ToString();
                    result.申請ID = row["APPLY_ID"].ToString();
                    result.申請種類 = row["APPLY_TYPE"].ToString();
                    result.タイトル = row["TITLE"].ToString();
                    result.申請日 = row["APPLY_TIME"].ToString();
                    result.承認日 = row["APPROVE_TIME"].ToString();
                    result.連絡事項 = row["NOTICE_MATTER"].ToString();

                    検索結果一覧.Add(result);
                }
            }
            else
            {
                string sql2 = "select APPLY_STATUS,APPLY_ID,APPLY_TYPE,TITLE,APPLY_TIME,APPROVE_TIME,NOTICE_MATTER from application_info where APPLY_STATUS ='" + 状態 + "'";


                MySqlConnection con2 = new MySqlConnection("server=localhost;user id=root; password=csharp;" + "database=csharp; convert zero datetime=True");
                con2.Open();
                MySqlDataAdapter da2 = new MySqlDataAdapter(sql2, con2);
                DataTable tb2 = new DataTable();

                da2.Fill(tb2);
                da2.Dispose();
                con2.Close();


                検索結果一覧 = new List<ApplicationInfoRowModel>();
                foreach (DataRow row in tb2.Rows)
                {
                    ApplicationInfoRowModel result = new ApplicationInfoRowModel();
                    result.状態 = row["APPLY_STATUS"].ToString();
                    result.申請ID = row["APPLY_ID"].ToString();
                    result.申請種類 = row["APPLY_TYPE"].ToString();
                    result.タイトル = row["TITLE"].ToString();
                    result.申請日 = row["APPLY_TIME"].ToString();
                    result.承認日 = row["APPROVE_TIME"].ToString();
                    result.連絡事項 = row["NOTICE_MATTER"].ToString();

                    検索結果一覧.Add(result);
                }
            }
                



        }



        
    }
}