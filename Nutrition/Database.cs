using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections;
//TODO https://stackoverflow.com/questions/60919/does-sqlcommand-dispose-close-the-connection
//TODO https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcommand?view=dotnet-plat-ext-3.1
namespace Nutrition
{
    class Database
    {
        string Server = "tcp:nutrition.database.windows.net,1433";
        string DB = "Nutrition";
        string Username = "csci150";
        string Password = "NutritionPass1";
      
        public Database()
        {
            string connectionString = GetConnectionString();
            using SqlConnection c = new SqlConnection(connectionString);
            try
            {
                c.Open();
                //MessageBox.Show("Connected to database");
            }
            catch (SqlException err)
            {
                MessageBox.Show("Database Error: " + err.Message);
            }
        }

        public bool checkUserExists(string user)
        {
            string sql = "SELECT * from [dbo].[Users] where [username] = @user";

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@user", user);
                    using (SqlDataReader result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {
                            //MessageBox.Show("User already exists try a different name");//Debug
                            return true;
                        }
                        else
                        {
                            //MessageBox.Show("No user exists");//Debug
                            return false;
                        }
                    }
                }
            }
        }

        public string getPasswordHash(string user)
        {
            string hash = "";
            string sql = "SELECT * from [dbo].[Users] where [username] = @user";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@user", user);
                    using (SqlDataReader result = command.ExecuteReader())
                    {
                        if (result.HasRows)//Check if there is a result
                        {
                            result.Read();//Read the row
                            hash = result["password"].ToString();
                        }
                    }
                }
            }
            return hash;
        }

        public void RegisterUser(IDictionary<string, string> data)
        {
            String sql = "INSERT INTO [dbo].[Users] (username,password,admin_powers,gluten_allergy,peanut_allergy,fish_allergy,soy_allergy,dairy_allergy,join_date,last_login) VALUES (@username,@password,@admin,@gluten,@peanut,@fish,@soy,@dairy,@join_date,@last_login)";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@username", data["username"]);
                    command.Parameters.AddWithValue("@password", data["password"]);
                    command.Parameters.AddWithValue("@admin", data["admin"]);
                    command.Parameters.AddWithValue("@gluten", data["gluten"]);
                    command.Parameters.AddWithValue("@peanut", data["peanut"]);
                    command.Parameters.AddWithValue("@fish", data["fish"]);
                    command.Parameters.AddWithValue("@soy", data["soy"]);
                    command.Parameters.AddWithValue("@dairy", data["dairy"]);
                    command.Parameters.AddWithValue("@join_date", DateTime.Now);
                    command.Parameters.AddWithValue("@last_login", DateTime.Now);

                    int result = command.ExecuteNonQuery();
                    // Check Error
                    if (result < 0)
                        MessageBox.Show("Error inserting data into Database!");
                    else
                        MessageBox.Show("Congratulations " + data["username"] + " on registering!");
                }
            }
        }

        public void makeAdmin(string user)
        {
            string sql = "UPDATE [dbo].[Users] SET [admin_powers] = '1' where [username] = @user";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@user", user);
                    var result = command.ExecuteNonQuery();
                    if (result > 0)
                        MessageBox.Show("Updated " + user + " to be an administrator");
                    else
                        MessageBox.Show("Failed to make " + user + " an administrator");
                }
            }
        }

        public void updateLastLogin(string user)
        {
            string sql = "UPDATE [dbo].[Users] SET [last_login] = @last where [username] = @user";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@last", DateTime.Now);
                    command.Parameters.AddWithValue("@user", user);
                    var result = command.ExecuteNonQuery();
                    if (result > 0)
                        MessageBox.Show("Updated " + user + " last login");//Debug
                    else
                        MessageBox.Show("Failed to update " + user + " last login");//Debug
                }
            }
        }

        public void changePassword(string user, string pass)
        {
            string sql = "UPDATE [dbo].[Users] SET [password] = @pass where [username] = @user";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@pass", pass);
                    command.Parameters.AddWithValue("@user", user);
                    var result = command.ExecuteNonQuery();
                    if (result > 0)
                        MessageBox.Show("Updated " + user + " password");//Debug
                    else
                        MessageBox.Show("Failed to update " + user + " password");//Debug
                }
            }
        }

        public IDictionary<string, string> getUserData(string user)
        {
            //Prepare an associative data (key,pair)
            IDictionary<string, string> data = new Dictionary<string, string>();

            //Query DB for data
            string sql = "SELECT * from [dbo].[Users] where [username] = @user";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@user", user);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)//Check if there is a result
                        {
                            reader.Read();//Read the row

                            //Fill in the key,pairs
                            data["username"] = reader["username"].ToString();
                            data["admin_powers"] = reader["admin_powers"].ToString();
                            data["gluten_allergy"] = reader["gluten_allergy"].ToString();
                            data["peanut_allergy"] = reader["peanut_allergy"].ToString();
                            data["fish_allergy"] = reader["fish_allergy"].ToString();
                            data["soy_allergy"] = reader["soy_allergy"].ToString();
                            data["dairy_allergy"] = reader["dairy_allergy"].ToString();
                            data["join_date"] = reader["join_date"].ToString();
                            data["last_login"] = reader["last_login"].ToString();
                            return data;
                        }
                        else throw new System.ArgumentException("No data available for user " + user);
                    }
                }
            }
        }

        public void FINISH_HIM(string user, int age, string gender, int height_inches, int weight, int bmr, int bmi)
        {
            string sql = "UPDATE [dbo].[Users] SET [age] = @age," +
                "[gender] = @gender," +
                "[height_inches] = @inches," +
                "[weight] = @weight," +
                "[bmr] = @bmr," +
                "[bmi] = @bmi WHERE [username] = @user";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@age", age);
                    command.Parameters.AddWithValue("@gender", gender);
                    command.Parameters.AddWithValue("@inches", height_inches);
                    command.Parameters.AddWithValue("@weight", weight);
                    command.Parameters.AddWithValue("@bmr", bmr);
                    command.Parameters.AddWithValue("@bmi", bmi);
                    command.Parameters.AddWithValue("@user", user);
                    var result = command.ExecuteNonQuery();
                    if (result == 0)
                        MessageBox.Show("Failed to update " + user);
                }
            }
        }

        private string GetConnectionString()
        {
            return @"Server=" + Server + ";Initial Catalog=" + DB + ";Persist Security Info=False;User ID=" + Username + ";Password=" + Password + ";MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }
    }
}
