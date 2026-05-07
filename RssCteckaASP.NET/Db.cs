
namespace RssCteckaASP.NET
{
    using Dapper;
    using Microsoft.Data.Sqlite;
    using Models;

    public class Db
    {
        private string url = "Data Source=rss.db";
        public void Insert(AddFeed model) {
            using (SqliteConnection con = new SqliteConnection(url)) {
                string sql = "INSERT INTO Rss(Name,Url,Description,Label) VALUES (@Nazev,@URL,@popis,@Stitek)";
                con.Execute(sql,new {
                    model.Nazev,
                    model.URL,
                    model.popis,
                    model.Stitek
                });
            }
        }
        public void Update(AddFeed model)
        {
            using (SqliteConnection con = new SqliteConnection(url))
            {
                string sql = "Update Rss Set Name = @Nazev, Url = @URL, Description = @popis, Label = @Stitek" +
                    " WHERE Id = @id ";
                con.Execute(sql, new
                {
                    model.Nazev,
                    model.URL,
                    model.popis,
                    model.Stitek,
                    model.Id
                });
            }
        }
        public List<AddFeed>Select()
        {
            using (SqliteConnection con = new SqliteConnection(url))
            {
                string sql = "SELECT Id, Name AS Nazev, Url as URL, Description AS popis, Label AS Stitek FROM Rss";

                return con.Query<AddFeed>(sql).ToList();
            }
        }

    }
}
