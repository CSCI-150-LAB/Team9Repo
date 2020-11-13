﻿using System;
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

        //takes all info from user, completing registration
        public void FINISH_HIM(string user, int age, string gender, double height_inches, double weight, double bmr, double bmi)
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

        //TODO:
        //Maker query for reccomended BMR
        //Make query to compare progress against BMR

        //Reccomend calorie intake for losing/gaining/maintenance weight
        //Projectings losses/gains for weight
        //based on BMR
        //400 calories 1 lbs /week

        //Get the past 24 hours of macro data (protein, carbohydrates, and fats
        public IDictionary<string, double> sumMacroData(string user)
        {
            //Prepare an associative data (key,pair)
            IDictionary<string, double> data = new Dictionary<string, double>();

            //Setup some default values if no values exist in the database
            data["calories"] = 0;
            data["fat"] = 0;
            data["carbs"] = 0;
            data["protein"] = 0;

            //Query DB for data
            string sql = "SELECT sum(UserTracking.calories) as 'calories', sum(UserTracking.fat) as 'fat', sum(UserTracking.carbohydrate) as 'carbs', sum(UserTracking.protein) as 'protein' " +
               "FROM UserTracking " +
               "INNER JOIN Users ON UserTracking.username = Users.username AND DATEDIFF(hour, UserTracking.date_logged, GETDATE()) <= 24 " +
               "where Users.username = @user";
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

                            if (reader["calories"] != System.DBNull.Value) //Check for a null database value
                                data["calories"] = (int)reader["calories"];

                            if (reader["fat"] != System.DBNull.Value) //Check for a null database value
                                data["fat"] = (double)(decimal)reader["fat"];

                            if (reader["carbs"] != System.DBNull.Value) //Check for a null database value
                                data["carbs"] = (double)(decimal)reader["carbs"];

                            if (reader["protein"] != System.DBNull.Value) //Check for a null database value
                                data["protein"] = (double)(decimal)reader["protein"];

                        }
                        return data;
                    }
                }
            }
        }

        public void selectWeeklyData()
        {
            /* Using dateDiff for "last 7 days"
             SELECT Users.username, UserTracking.id, UserTracking.item_name, UserTracking.calories, UserTracking.meal_type, UserTracking.date_logged
FROM UserTracking
INNER JOIN Users ON UserTracking.username=Users.username AND DATEDIFF(day, UserTracking.date_logged, Users.last_login) < 7; --Bigger date on the right
             */
        }

        public List<string> getLastTenMeals(string username)
        {
            /*SELECT Users.username as 'usr', UserTracking.id, UserTracking.item_name, UserTracking.protein as 'summed', UserTracking.date_logged
    FROM UserTracking
    INNER JOIN Users ON UserTracking.username=Users.username AND DATEDIFF(hour, UserTracking.date_logged, DateTime.Now) <= 24
    where Users.username = '<username>'
    ORDER BY UserTracking.date_logged DESC
    OFFSET 10 ROWS FETCH NEXT 10 ROWS ONLY*/
            List<string> lastTen = new List<string>();//empty list
            string sql = "SELECT TOP 10 Users.username as 'usr', UserTracking.item_name, UserTracking.date_logged " +
    "FROM UserTracking " +
    "INNER JOIN Users ON UserTracking.username = Users.username AND DATEDIFF(hour, UserTracking.date_logged, GETDATE()) <= 24 " +
    "where Users.username = @user " +
    "ORDER BY UserTracking.date_logged DESC";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@user", username);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lastTen.Add(reader["item_name"].ToString());
                        }
                    }
                }
            }
            return lastTen;
        }

        public bool FinishedAssessment(string username)
        {
            bool finishedAssessment = true;
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
                            if (result["weight"] == DBNull.Value || result["gender"] == DBNull.Value)
                                return false;
                        }
                    }
                }
            }
            return finishedAssessment;
        }

        public int GetBMR(string username)
        {
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

        public string GetGoal(string username)
        {
            string goal = "";
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
                            goal = result["activity_level_goal"].ToString();
                        }
                    }
                }
            }
            return goal;
        }

        public void SetGoal(string username, string goal)
        {
            string sql = "UPDATE [dbo].[Users] SET [activity_level_goal] = @goal where [username] = @user";
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

        public void DeleteFoodEntry(string item, string username)
        {
            string sql = "DELETE FROM [dbo].[UserTracking] WHERE [item_name] = @food," +
                "[username] = @user " +
                "AND DATEDIFF(hour, UserTracking.date_logged, GETDATE()) <= 24";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@food", item);
                    command.Parameters.AddWithValue("@user", username);
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
                    if (result < 0)
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
