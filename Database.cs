using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
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

        public bool CheckUserExists(string user)
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

        public string GetPasswordHash(string user)
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
                        MessageBox.Show("Inserted user " + data["username"]);
                }
            }
        }

        public void MakeAdmin(string user)
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

        public void UpdateRow(string user, string data, string row)
        {
            string sql = "UPDATE [dbo].[Users] SET " + row + " = @data WHERE [username] = @user";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@data", data);
                    command.Parameters.AddWithValue("@user", user);
                    var result = command.ExecuteNonQuery();
                    if (result == 0)
                        MessageBox.Show("Failed to update " + user + "'s [" + row + "] with " + data);
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

        public void InsertFood(IDictionary<string, string> item)
        {
            String sql = "INSERT INTO [dbo].[Nutrition] (item_name,calories,fat,carbohydrate,protein,contains_gluten,contains_nuts,contains_fish,contains_dairy,contains_soy) VALUES (@item,@calories,@fat,@carbs,@protein,@gluten,@nuts,@fish,@dairy,@soy)";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {//@item,@calories,@fat,@carbs,@protein,@gluten,@nuts,@fish,@dairy,@soy
                    command.Parameters.AddWithValue("@item", item["name"]);
                    command.Parameters.AddWithValue("@calories", item["calories"]);
                    command.Parameters.AddWithValue("@fat", item["fat"]);
                    command.Parameters.AddWithValue("@carbs", item["carbs"]);
                    command.Parameters.AddWithValue("@protein", item["protein"]);
                    command.Parameters.AddWithValue("@gluten", item["contains_gluten"]);
                    command.Parameters.AddWithValue("@nuts", item["contains_nuts"]);
                    command.Parameters.AddWithValue("@fish", item["contains_fish"]);
                    command.Parameters.AddWithValue("@dairy", item["contains_dairy"]);
                    command.Parameters.AddWithValue("@soy", item["contains_soy"]);

                    int result = command.ExecuteNonQuery();
                    // Check Error
                    if (result < 0)
                        MessageBox.Show("Error inserting data into Database!");
                    else
                        MessageBox.Show("Inserted " + item["name"] + " successfully");
                }
            }
        }

        public void insertUserTracking(IDictionary<string, string> item)
        {
            String sql = "INSERT INTO [dbo].[UserTracking] (username,item_name,calories,fat,carbohydrate,protein,meal_type,date_logged) VALUES (@user,@item,@cal,@fat,@carb,@pro,@meal_type,@date)";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {//@user,@item,@cal,@fat,@carb,@pro,@meal_type,@date
                    command.Parameters.AddWithValue("@user", item["username"]);
                    command.Parameters.AddWithValue("@item", item["item_name"]);
                    command.Parameters.AddWithValue("@cal", item["cals"]);
                    command.Parameters.AddWithValue("@fat", item["fat"]);
                    command.Parameters.AddWithValue("@carb", item["carbs"]);
                    command.Parameters.AddWithValue("@pro", item["protein"]);
                    command.Parameters.AddWithValue("@meal_type", item["meal_type"]);
                    command.Parameters.AddWithValue("@date", DateTime.Now);

                    int result = command.ExecuteNonQuery();
                    // Check Error
                    if (result < 0)
                        MessageBox.Show("Error inserting data into Database!");
                    //else
                      //  MessageBox.Show("Inserted " + item["item_name"] + " successfully");
                }
            }
        }

        // TODO:
        //Maker query for reccomended BMR
        //Make query to compare progress against BMR

        //Reccomend calorie intake for losing/gaining/maintenance weight
        //Projectings losses/gains for weight
            //based on BMR
            //400 calories 1 lbs /week


        public int sumUserCalories(string username)
        {//https://stackoverflow.com/questions/52071646/sql-sum-on-multiple-inner-join
            /*
             SELECT sum(calories)
FROM(
SELECT Users.username, UserTracking.id, UserTracking.item_name, UserTracking.calories as 'calories', UserTracking.date_logged
FROM UserTracking
INNER JOIN Users ON UserTracking.username=Users.username) tmp;
             */

            //method 2

            /*
             SELECT sum(UserTracking.calories) as 'calories'
FROM UserTracking
INNER JOIN Users ON UserTracking.username=Users.username; 
             */
            return 0;
        }

        public void selectWeeklyData()
        {

            /* Using dateDiff for "last 7 days"
             SELECT Users.username, UserTracking.id, UserTracking.item_name, UserTracking.calories, UserTracking.meal_type, UserTracking.date_logged
FROM UserTracking
INNER JOIN Users ON UserTracking.username=Users.username AND DATEDIFF(day, UserTracking.date_logged, Users.last_login) < 7; --Bigger date on the right
      
             */
        }

        public int GetBMR(string username) {
            int bmr = -1;
            string sql = "SELECT * from [dbo].[Users] where [username] = @user";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@user", username);
                    using (SqlDataReader result = command.ExecuteReader())
                    {
                        if (result.HasRows)//Check if there is a result
                        {
                            result.Read();//Read the row
                            bmr = Int32.Parse(result["bmr"].ToString());
                        }
                    }
                }
            }
            return bmr > 0 ? bmr : 0;
        }

public int GetBMI(string username)
        {
            int bmi = -1;
            string sql = "SELECT * from [dbo].[Users] where [username] = @user";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@user", username);
                    using (SqlDataReader result = command.ExecuteReader())
                    {
                        if (result.HasRows)//Check if there is a result
                        {
                            result.Read();//Read the row
                            bmi = Int32.Parse(result["bmi"].ToString());
                        }
                    }
                }
            }
            return bmi > 0 ? bmi : 0;
        }

public int GetGoal(string username)
        {
            int goal = -1;
            string sql = "SELECT * from [dbo].[Users] where [username] = @user";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@user", username);
                    using (SqlDataReader result = command.ExecuteReader())
                    {
                        if (result.HasRows)//Check if there is a result
                        {
                            result.Read();//Read the row
                            goal = Int32.Parse(result["goal"].ToString());
                        }
                    }
                }
            }
            return goal > 0 ? goal : 0;
        }

public void SetGoal(string username, int goal)
        {
            string sql = "UPDATE [dbo].[Users] SET [goal] = @goal where [username] = @user";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@goal", goal);
                    command.Parameters.AddWithValue("@user", username);
                    var result = command.ExecuteNonQuery();
                    if (result < 0)
                        MessageBox.Show("Failed set goal for " + username);//Debug
                }
            }
        }

        public void DeleteFood(string item)
        {
            string sql = "DELETE FROM [dbo].[Nutrition] WHERE [item_name] = @food";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@food", item);
                    var result = command.ExecuteNonQuery();
                    if (result > 0)
                        MessageBox.Show("Deleted " + result + " " + item + " from the DB");//Debug
                    else
                        MessageBox.Show(item + " not found");//Debug
                }
            }
        }

        public List<string> GetFoodItems()
        {
            List<string> foodItems = new List<string>();
            string sql = "SELECT * from [dbo].[Nutrition]";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            foodItems.Add(reader["item_name"].ToString());
                        }
                    }
                }
            }
            return foodItems;
        }

        public List<string> GetFoodData(string name)
        {
            List<string> foodItems = new List<string>();
            string sql = "SELECT * from [dbo].[Nutrition] where [item_name] = @name";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@name", name);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            foodItems.Add(reader["item_name"].ToString());
                            foodItems.Add(reader["calories"].ToString());
                            foodItems.Add(reader["fat"].ToString());
                            foodItems.Add(reader["carbohydrate"].ToString());
                            foodItems.Add(reader["protein"].ToString());
                            foodItems.Add(reader["contains_gluten"].ToString());
                            foodItems.Add(reader["contains_nuts"].ToString());
                            foodItems.Add(reader["contains_fish"].ToString());
                            foodItems.Add(reader["contains_dairy"].ToString());
                            foodItems.Add(reader["contains_soy"].ToString());
                        }
                    }
                }
            }
            return foodItems;
        }

        public void UpdateLastLogin(string user)
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

        public void ChangePassword(string user, string pass)
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

        public IDictionary<string, string> GetUserData(string user)
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
                            data["age"] = reader["age"].ToString();
                            data["gender"] = reader["gender"].ToString();
                            data["height_inches"] = reader["height_inches"].ToString();
                            data["weight"] = reader["weight"].ToString();
                            data["bmr"] = reader["bmr"].ToString();
                            data["bmi"] = reader["bmi"].ToString();
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

        private string GetConnectionString()
        {
            return @"Server=" + Server + ";Initial Catalog=" + DB + ";Persist Security Info=False;User ID=" + Username + ";Password=" + Password + ";MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }
    }
}
