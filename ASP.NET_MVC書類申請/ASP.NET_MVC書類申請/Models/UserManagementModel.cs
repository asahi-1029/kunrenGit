using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP.NET_MVC追加機能.Models;

namespace ASP.NET_MVC追加機能.Models
{
    public class UserManagementModel
    {
        public List<UserManagementRowModel> 検索結果一覧;
        public List<UserManagementRowModel> 表示一覧;
        public int 表示件数;
        public int 現ページ;
        public string ソート順;
        public string ソート列;

        public void Find(string 表示区分)
        {
            現ページ = 1;
            ソート順 = "▲";
            string sql = "select USER_NAME,SEX,BIRTHDAY,TEL,EMAIL,ADDRESS,AFFILIATION,POSITION from profile_info p inner join user_master u on p.USER_ID = u.USER_ID where TYPE = '" + 表示区分 + "'";
            MySqlConnection con = new MySqlConnection("server=localhost;user id=root; password=csharp;" + "database=csharp; convert zero datetime=True");
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
            DataTable tb = new DataTable();

            da.Fill(tb);
            da.Dispose();
            con.Close();
            検索結果一覧 = new List<UserManagementRowModel>();
            foreach (DataRow row in tb.Rows)
            {
                UserManagementRowModel result = new UserManagementRowModel();
                result.氏名 = row["USER_NAME"].ToString();
                result.性別 = row["SEX"].ToString();
                result.生年月日 = row["BIRTHDAY"].ToString();
                result.メール = row["EMAIL"].ToString();
                result.住所 = row["ADDRESS"].ToString();
                result.所属 = row["AFFILIATION"].ToString();
                result.役職 = row["POSITION"].ToString();
                検索結果一覧.Add(result);
            }
            SortAll(ソート列, ソート順);
            GetPage(表示件数, 現ページ);
        }

        public void GetPage(int rowCount, int pageNum)//rowCountは表示したい件数、pageaNumは今回表示したいページ番号
        {
            if (rowCount == 0 || 検索結果一覧.Count <= rowCount)//改ページが必要ない
            {
                表示一覧 = 検索結果一覧;
            }
            else
            {
                if (rowCount == 表示件数)//表示件数が変わってないとき
                {
                    表示一覧 = 検索結果一覧
                        .Where((item, index) => index >= (pageNum - 1) * rowCount && index < pageNum * rowCount)
                        .ToList();
                }
                else//1ページ目のデータを選択する
                {
                    表示一覧 = 検索結果一覧.Where((item, index) => index < rowCount).ToList();
                }
            }
            表示件数 = rowCount;
            現ページ = pageNum;
        }

        public void SortAll(string colName, string sortOrder)//colNameはソート対象列名、sortOrderはソート順
        {
            //昇順でソートする
            if (sortOrder == "▲" || sortOrder == "")
            {
                if (ソート列 == "氏名")
                {
                    検索結果一覧 = 検索結果一覧.OrderBy(x => x.氏名).ToList();
                }
                if (ソート列 == "性別")
                {
                    検索結果一覧 = 検索結果一覧.OrderBy(x => x.性別).ToList();
                }
                if (ソート列 == "生年月日")
                {
                    検索結果一覧 = 検索結果一覧.OrderBy(x => x.生年月日).ToList();
                }
                if (ソート列 == "メール")
                {
                    検索結果一覧 = 検索結果一覧.OrderBy(x => x.メール).ToList();
                }
                if (ソート列 == "住所")
                {
                    検索結果一覧 = 検索結果一覧.OrderBy(x => x.住所).ToList();
                }
                if (ソート列 == "所属")
                {
                    検索結果一覧 = 検索結果一覧.OrderBy(x => x.所属).ToList();
                }
                if (ソート列 == "役職")
                {
                    検索結果一覧 = 検索結果一覧.OrderBy(x => x.役職).ToList();
                }
            }
            else
            {
                if (ソート列 == "氏名")
                {
                    検索結果一覧 = 検索結果一覧.OrderByDescending(x => x.氏名).ToList();
                }
                if (ソート列 == "性別")
                {
                    検索結果一覧 = 検索結果一覧.OrderByDescending(x => x.性別).ToList();
                }
                if (ソート列 == "生年月日")
                {
                    検索結果一覧 = 検索結果一覧.OrderByDescending(x => x.生年月日).ToList();
                }
                if (ソート列 == "メール")
                {
                    検索結果一覧 = 検索結果一覧.OrderByDescending(x => x.メール).ToList();
                }
                if (ソート列 == "住所")
                {
                    検索結果一覧 = 検索結果一覧.OrderByDescending(x => x.住所).ToList();
                }
                if (ソート列 == "所属")
                {
                    検索結果一覧 = 検索結果一覧.OrderByDescending(x => x.所属).ToList();
                }
                if (ソート列 == "役職")
                {
                    検索結果一覧 = 検索結果一覧.OrderByDescending(x => x.役職).ToList();
                }
            }
        }

        public void Sort(string colName, string sortOrder)
        {
            //ソート情報と開示したいページ番号を再設定する
            ソート列 = colName;
            ソート順 = sortOrder;
            現ページ = 1;
            //検索結果一覧をソートする
            SortAll(colName, sortOrder);
            //ソートされた「検索結果一覧」からデータを抜き差して、表示一覧に設定する
            GetPage(表示件数, 現ページ);
        }
                


            
        

    }
}