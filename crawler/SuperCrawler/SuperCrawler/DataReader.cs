using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SuperCrawler
{
    public class DataReader
    {
        public static void ReadFromCsv(string connectionString, string file)
        {
            
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            StreamReader sr = new StreamReader(file, Encoding.GetEncoding("gb2312"));
            using (var connect = new MySqlConnection(connectionString))
            {
                string line = "";
                sr.ReadLine();
                
                connect.Open();
                while ((line = sr.ReadLine()) != null)
                {
                    var values = line.Split(',');
                    using (MySqlCommand cmd = new MySqlCommand("insert into teacherinfo values(@name, @gender, @title, @email, @research, @dblp)", connect))
                    {
                        cmd.Parameters.Add(new MySqlParameter("@name", values[0]));
                        cmd.Parameters.Add(new MySqlParameter("@gender", values[1]));
                        cmd.Parameters.Add(new MySqlParameter("@title", values[2]));
                        cmd.Parameters.Add(new MySqlParameter("@email", values[3]));
                        cmd.Parameters.Add(new MySqlParameter("@research", values[4]));
                        cmd.Parameters.Add(new MySqlParameter("@dblp", values[5]));
                        cmd.ExecuteNonQuery();

                    }
                }
                connect.Close();
            }
            sr.Close();
        }
    }
}
