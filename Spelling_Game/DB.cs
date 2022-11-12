using Spelling_Game.Models;
using System.Data.SqlClient;

public class DB
{
    private string connStr;

    public DB(string connStr)
    {
        this.connStr = connStr;
    }

    public List<Word> GetGameWords()
    {
        List<Word> gamewords = new List<Word>();

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();

            string q = String.Format(@"select top 5 * from [Word] order by newid()");

            using (SqlCommand cmd = new SqlCommand(q, conn))
            {   
                using (SqlDataReader reader = cmd.ExecuteReader())
                {   
                    while (reader.Read())
                    {
                        Word myword = new Word()
                        {   
                            spelling = (string) reader["Word"],
                            url = (string)reader["PictureURL"]
                        };
                        gamewords.Add(myword);
                    }
                }
            }

            conn.Close();
        }

        return gamewords;
    }
}