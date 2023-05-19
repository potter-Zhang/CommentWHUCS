
using MySql.Data.MySqlClient;
using System;
using System.Buffers;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.SqlClient;
using System.Net.Sockets;

namespace Mail 
{ 
    class Permutation
    {
       
        public List<int> shape;
        public List<int> num;
        public Permutation(params int[] s)
        {
            shape = s.ToList();
            num = new List<int>(shape.Count);
        }

        private void Add(int pos = 0)
        {
            if (pos > shape.Count)
                return;
            num[pos]++;
            if (num[pos] == shape[pos])
            {
                num[pos] = 0;
                Add(pos + 1);
            }
 
        }

        public int Next(int pos)
        {
            Add();
            return num[pos];
        }
    }
    class Mail
    {
        string[] name = { "Bob", "Harry", "Mary" };
        string[] phone_num = { "13510999888", "1123456", "12306" };
        string[] address = { "guangba road", "wuhan road", "beijing road" };
        string[] p_category = { "small", "large", "danger", "ordinary" };
        string[] s_category = { "today", "next day", "in a week" };
        string[] requirement = { "need a declaration", "can't be transport by plane", "none" };
        string[] r_category = { "static", "dynamic" };
        string[] payment = { "wechat", "cash", "credit card" };
        string[] route = { "wuhan->beijing", "shanghai->shenzhen", "zhejiang->hainan" };
        string[] location = { "guangba road", "wuhan road", "beijing road", "bejing road301", "guangba road102", "tiananmen" };
        string[] warehouse = { "A1", "A2", "B1", "B2" };
        Random rand;
        Permutation p;
        public Mail()
        {
            p = new Permutation(name.Length, phone_num.Length, address.Length);
            rand = new Random();
        }
        public static void Main()
        {
            const string connectionStr = "server=localhost;uid=root;password=lpWZ38sql;database=maildb";
            using (MySqlConnection connection = new MySqlConnection(connectionStr))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand("insert into package values(@name, @gender, @title, @email, @research, @dblp)", connection))
                {
                    
                    cmd.ExecuteNonQuery();

                }
            }


        }

        public void CreatePackage(MySqlConnection connection, string id)
        {
            
            
            using (MySqlCommand cmd = new MySqlCommand("insert into package values(@id, @weight, @category)")) 
            {
                cmd.Parameters.Add(new MySqlParameter("@id", id.Substring(0, 16)));
                cmd.Parameters.Add(new MySqlParameter("@weight", rand.NextDouble() * 100));
                cmd.Parameters.Add(new SqlParameter("@category", p_category[rand.Next(0, p_category.Length)]));
                cmd.ExecuteNonQuery();
            }
        }

        public void CreateService(MySqlConnection connection, string id)
        {
            
            
            using (MySqlCommand cmd = new MySqlCommand("insert into service values(@package_id, @category, @requirement)", connection))
            {
                cmd.Parameters.Add(new MySqlParameter("@package_id", id.Substring(0, 16)));
                cmd.Parameters.Add(new MySqlParameter("@category", s_category[rand.Next(0, s_category.Length)]));
                cmd.Parameters.Add(new SqlParameter("@requirement", requirement[rand.Next(0, s_category.Length)]));
                cmd.ExecuteNonQuery();
            }
        }

        public void CreateCustomer(MySqlConnection connection, string id)
        {
 
            using (MySqlCommand cmd = new MySqlCommand("insert into customer values(@id, @name, @phone_number, @address)", connection))
            {
                cmd.Parameters.Add(new MySqlParameter("@id", id.Substring(0, 16)));
                cmd.Parameters.Add(new MySqlParameter("@name", name[p.Next(0)]));
                cmd.Parameters.Add(new MySqlParameter("@phone_number", phone_num[p.Next(1)]));
                cmd.Parameters.Add(new MySqlParameter("@address", address[p.Next(2)]));
                cmd.ExecuteNonQuery();
            }
        }

        public void CreateOrderForm(MySqlConnection connection, string id, string c_id)
        {
            using (MySqlCommand cmd = new MySqlCommand("insert into order_form values(@package_id, @price, @payment, @order_time, @customer_id)", connection))
            {
                cmd.Parameters.Add(new MySqlParameter("@id", id.Substring(0, 16)));
                cmd.Parameters.Add(new MySqlParameter("@price", rand.NextDouble() * 100));
                cmd.Parameters.Add(new MySqlParameter("@payment", payment[rand.Next(0, payment.Length)]));
                cmd.Parameters.Add(new MySqlParameter("@order_time", DateTime.Now));
                cmd.Parameters.Add(new MySqlParameter("@customer_id", c_id.Substring(0, 16)));
                cmd.ExecuteNonQuery();
            }
        }

        public void CreateTransport(MySqlConnection connection, string id, string p_id)
        {
            using (MySqlCommand cmd = new MySqlCommand("insert into transport values(@id, @package_id, @route, @start_location, @end_location)", connection))
            {
                cmd.Parameters.Add(new MySqlParameter("@id", id.Substring(0, 16)));
                cmd.Parameters.Add(new MySqlParameter("@package_id", p_id.Substring(0, 16)));
                cmd.Parameters.Add(new MySqlParameter("@route", route[rand.Next(0, route.Length)]));
                cmd.Parameters.Add(new MySqlParameter("@start_location", location[rand.Next(0, location.Length)]));
                cmd.Parameters.Add(new MySqlParameter("@end_location", location[rand.Next(0, location.Length)]));

                cmd.ExecuteNonQuery();
            }
        }

        public void CreateRecord(MySqlConnection connection, string r_id, string t_id)
        {
            using (MySqlCommand cmd = new MySqlCommand("insert into record values(@record_id, @transport_id, @record_time, @location, @category)", connection))
            {
                cmd.Parameters.Add(new MySqlParameter("@record_id", r_id.Substring(0, 16)));
                cmd.Parameters.Add(new MySqlParameter("@transport_id", t_id.Substring(0, 16)));
                cmd.Parameters.Add(new MySqlParameter("@record_time", DateTime.Now));
                cmd.Parameters.Add(new MySqlParameter("@location", location[rand.Next(0, location.Length)]));
                cmd.Parameters.Add(new MySqlParameter("@category", r_category[rand.Next(0, r_category.Length)]));
                
                cmd.ExecuteNonQuery();
            }
        }

        public void CreateWareHouse(MySqlConnection connection, string r_id, string t_id)
        {
            using (MySqlCommand cmd = new MySqlCommand("insert into record values(@record_id, @transport_id, @record_time, @location, @category)", connection))
            {
                cmd.Parameters.Add(new MySqlParameter("@record_id", r_id.Substring(0, 16)));
                cmd.Parameters.Add(new MySqlParameter("@transport_id", wa);
                cmd.Parameters.Add(new MySqlParameter("@record_time", DateTime.Now));
                cmd.Parameters.Add(new MySqlParameter("@location", location[rand.Next(0, location.Length)]));
                cmd.Parameters.Add(new MySqlParameter("@category", r_category[rand.Next(0, r_category.Length)]));

                cmd.ExecuteNonQuery();
            }
        }


    }

}
