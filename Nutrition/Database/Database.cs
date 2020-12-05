using System;
using System.Collections.Generic;
using System.Data;
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
                if (Program.debugMode)
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
            string sql = "INSERT INTO [dbo].[Users] (username,password,admin_powers,gluten_allergy,peanut_allergy,fish_allergy,soy_allergy,dairy_allergy,join_date,last_login) VALUES (@username,@password,@admin,@gluten,@peanut,@fish,@soy,@dairy,@join_date,@last_login)";
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
                    {
                        if (Program.debugMode)
                            MessageBox.Show("Inserted user " + data["username"]);
                    }
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
                    if (result > 0 && Program.debugMode)
                        MessageBox.Show("Changed " + user + " to be an administrator");
                    else if (Program.debugMode)
                        MessageBox.Show("Failed to make " + user + " an administrator");
                }
            }
        }

        public void RemoveAdmin(string user)
        {
            string sql = "UPDATE [dbo].[Users] SET [admin_powers] = '0' where [username] = @user";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@user", user);
                    var result = command.ExecuteNonQuery();
                    if (result > 0 && Program.debugMode)
                        MessageBox.Show("Removed " + user + " from the administrators");
                    else if (Program.debugMode)
                        MessageBox.Show("Failed to remove " + user + " from administrators");
                }
            }
        }

        public bool isAdmin(string user)
        {
            string sql = "SELECT * from [dbo].[Users] where [username] = @user";
            bool admin = false;
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
                            int value = int.Parse(result["admin_powers"].ToString());
                            if (value == 1)
                                admin = true;
                        }
                    }
                }
            }
            return admin;
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
                    if (result < 0)
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
                "[activity_level_goal] = 'Maintain'," +
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
                    if (result < 0)
                        MessageBox.Show("Failed to update " + user);
                }
            }
        }

        public void InsertFood(IDictionary<string, string> item)
        {
            string sql = "INSERT INTO [dbo].[Nutrition] (item_name,calories,fat,carbohydrate,protein,contains_gluten,contains_nuts,contains_fish,contains_dairy,contains_soy) VALUES (@item,@calories,@fat,@carbs,@protein,@gluten,@nuts,@fish,@dairy,@soy)";
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
                    else if (Program.debugMode)
                        MessageBox.Show("Inserted " + item["name"] + " successfully");
                }
            }
        }

        public void InsertFood(Food item)
        {
            string sql = "INSERT INTO [dbo].[Nutrition] (item_name,calories,fat,carbohydrate,protein,contains_gluten,contains_nuts,contains_fish,contains_dairy,contains_soy) VALUES (@item,@calories,@fat,@carbs,@protein,@gluten,@nuts,@fish,@dairy,@soy)";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {//@item,@calories,@fat,@carbs,@protein,@gluten,@nuts,@fish,@dairy,@soy
                    command.Parameters.AddWithValue("@item", item.name);
                    command.Parameters.AddWithValue("@calories", item.calories);
                    command.Parameters.AddWithValue("@fat", item.fat);
                    command.Parameters.AddWithValue("@carbs", item.carbs);
                    command.Parameters.AddWithValue("@protein", item.protein);
                    command.Parameters.AddWithValue("@gluten", item.allergies[0]);
                    command.Parameters.AddWithValue("@nuts", item.allergies[1]);
                    command.Parameters.AddWithValue("@fish", item.allergies[2]);
                    command.Parameters.AddWithValue("@dairy", item.allergies[3]);
                    command.Parameters.AddWithValue("@soy", item.allergies[4]);

                    int result = command.ExecuteNonQuery();
                    // Check Error
                    if (result < 0)
                        MessageBox.Show("Error inserting data into Database!");
                    else if (Program.debugMode)
                        MessageBox.Show("Inserted " + item.name + " successfully");
                }
            }
        }

        public void UpdateFood(Food item)
        {
            string sql = "UPDATE [dbo].[Nutrition] SET " +
                "item_name = @item," +
                "calories = @calories," +
                "fat = @fat," +
                "carbohydrate = @carbs," +
                "protein = @protein," +
                "contains_gluten = @gluten," +
                "contains_nuts = @nuts," +
                "contains_fish = @fish," +
                "contains_dairy = @dairy," +
                "contains_soy = @soy WHERE id = @id";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {//@item,@calories,@fat,@carbs,@protein,@gluten,@nuts,@fish,@dairy,@soy
                    command.Parameters.AddWithValue("@item", item.name);
                    command.Parameters.AddWithValue("@calories", item.calories);
                    command.Parameters.AddWithValue("@fat", item.fat);
                    command.Parameters.AddWithValue("@carbs", item.carbs);
                    command.Parameters.AddWithValue("@protein", item.protein);
                    command.Parameters.AddWithValue("@gluten", item.allergies[0]);
                    command.Parameters.AddWithValue("@nuts", item.allergies[1]);
                    command.Parameters.AddWithValue("@fish", item.allergies[2]);
                    command.Parameters.AddWithValue("@dairy", item.allergies[3]);
                    command.Parameters.AddWithValue("@soy", item.allergies[4]);
                    command.Parameters.AddWithValue("@id", item.id);

                    int result = command.ExecuteNonQuery();
                    // Check Error
                    if (result < 0)
                        MessageBox.Show("Error updating data in Database!");
                    else if (Program.debugMode)
                        MessageBox.Show("Updated " + item.name + " successfully");
                }
            }
        }

        public void insertUserTracking(IDictionary<string, string> item)
        {
            string sql = "INSERT INTO [dbo].[UserTracking] (username,item_name,calories,fat,carbohydrate,protein,meal_type,date_logged) VALUES (@user,@item,@cal,@fat,@carb,@pro,@meal_type,@date)";
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
        public void InsertUserWeight(String username, double weight)
        {
            string sql = "INSERT INTO [dbo].[UserWeightTracking] (username,weight,date) VALUES (@user,@weight,GETDATE())";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@user", username);
                    command.Parameters.AddWithValue("@weight", weight);

                    int result = command.ExecuteNonQuery();
                    // Check Error
                    if (result < 0)
                        MessageBox.Show("Error inserting user weight");
                }
            }
        }

        public void UpdateUserWeight(string username, double weight)
        {
            string sql = "UPDATE [dbo].[Users] SET [weight] = @weight where [username] = @user";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@weight", weight);
                    command.Parameters.AddWithValue("@user", username);
                    var result = command.ExecuteNonQuery();
                    if (result < 0)
                        MessageBox.Show("Failed to update weight for " + username);//Debug
                }
            }
        }

        /**
         * Retrieves the weights the user has logged into the database.
         * 
         * This function retrieves all of the values
         * The first element is the lastest value and the remaining are in Descending order.
         */
        public List<Weight> GetWeightLog(string username)
        {
            List<Weight> log = new List<Weight>();//empty list
            string sql = "SELECT * from dbo.UserWeightTracking where username = @user ORDER BY date DESC";
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
                            log.Add(new Weight((double)(decimal)reader["weight"], (DateTime)reader["date"]));
                        }
                    }
                }
            }
            return log;
        }

        //Get the past 24 hours of each macro data sum(protein, carbohydrates, and fats)
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

            //Old query used a join statement which was not needed since the username is already indexed and logged in the tracking table
            //No data was used from the User table except the username so joining is not necessary. Save this query as an example on how to join the table if needed in the future.
            /*string sql = "SELECT sum(UserTracking.calories) as 'calories', sum(UserTracking.fat) as 'fat', sum(UserTracking.carbohydrate) as 'carbs', sum(UserTracking.protein) as 'protein' " +
               "FROM UserTracking " +
               "INNER JOIN Users ON UserTracking.username = Users.username AND DATEDIFF(hour, UserTracking.date_logged, GETDATE()) <= 24 " +
               "where Users.username = @user";*/

            //No join necessary to get the right results
            string sql = "SELECT sum(UserTracking.calories) as 'calories', sum(UserTracking.fat) as 'fat', sum(UserTracking.carbohydrate) as 'carbs', sum(UserTracking.protein) as 'protein' " +
               "FROM UserTracking " +
               "where username = @user AND DATEDIFF(hour, date_logged, GETDATE()) <= 24";
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

        //Fill a DataTable with SQL results to use with the ViewFormGrid as a DataSource
        public DataTable getLastTenMeals(string username)
        {//SELECT TOP 10 ...
            DataTable lastTen = new DataTable();
            string sql = "SELECT Users.username as 'usr', UserTracking.id, UserTracking.item_name, UserTracking.date_logged, UserTracking.meal_type " +
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
                    using (SqlDataAdapter sqlData = new SqlDataAdapter(command))
                    {
                        sqlData.Fill(lastTen);
                    }
                }
            }
            return lastTen;
        }

        public List<string> GetUserList()
        {
            List<string> log = new List<string>();//empty list
            string sql = "SELECT * from dbo.Users ORDER BY join_date DESC";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["username"] != DBNull.Value)
                                log.Add(reader["username"].ToString());
                        }
                    }
                }
            }
            return log;
        }

        //Check if a user finished the Assessment from after registering
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
                            if (result["weight"] == DBNull.Value || result["gender"] == DBNull.Value)//Redundant to check two row values since both are empty
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

        public void DeleteFood(int id, string item)
        {
            string sql = "DELETE FROM [dbo].[Nutrition] WHERE [id] = @id AND [item_name] = @food";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@food", item);
                    var result = command.ExecuteNonQuery();
                    if (result > 0 && Program.debugMode)
                        MessageBox.Show("Deleted " + result + " " + item + " from the DB");//Debug
                    else if (Program.debugMode)
                        MessageBox.Show(item + " not found");//Debug
                }
            }
        }

        public void DeleteFoodEntry(int itemId, string username)
        {
            if (itemId < 0) //item id's are always > 0
                return;
            string sql = "DELETE FROM [dbo].[UserTracking] WHERE [id] = @itemId " +
                "AND [username] = @user " +
                "AND DATEDIFF(hour, UserTracking.date_logged, GETDATE()) <= 24";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@itemId", itemId);
                    command.Parameters.AddWithValue("@user", username);
                    var result = command.ExecuteNonQuery();
                    if (result > 0 && Program.debugMode)
                        MessageBox.Show("Deleted " + result + " " + itemId + " from the DB");//Debug
                    else if (Program.debugMode)
                        MessageBox.Show(itemId + " not found");//Debug
                }
            }
        }

        public DataTable GetFoodItems2()
        {
            DataTable foodItems = new DataTable();
            string sql = "SELECT * from [dbo].[Nutrition]";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    using (SqlDataAdapter sqlData = new SqlDataAdapter(command))
                    {
                        sqlData.Fill(foodItems);
                    }
                }
            }
            //  recipes.Columns.Add("Recipe", typeof(string));
            // recipes.Columns.Add("Value", typeof(int));

            return foodItems;
        }

        public List<Food> GetFoodItems()
        {
            List<Food> foodItems = new List<Food>();
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
                            if (reader["item_name"] != DBNull.Value)
                            { //Check for a null database value
                                int id = (int)reader["id"];
                                string name = reader["item_name"].ToString();
                                int calories = (int)reader["calories"];
                                double fat = (double)(decimal)reader["fat"];
                                double carbs = (double)(decimal)reader["carbohydrate"];
                                double protein = (double)(decimal)reader["protein"];
                                int gluten = (int)reader["contains_gluten"], nuts = (int)reader["contains_nuts"], fish = (int)reader["contains_fish"], dairy = (int)reader["contains_dairy"], soy = (int)reader["contains_soy"];
                                int[] allergies = new int[] { gluten, nuts, fish, dairy, soy };
                                foodItems.Add(new Food(id, name, calories, fat, protein, carbs, allergies));
                            }
                        }
                    }
                }
            }
            return foodItems;
        }

        public List<Food> GetNoAllergyFoodItems(string username)
        {
            List<Food> foodItems = new List<Food>();
            string sql = "SELECT * from [dbo].[Nutrition] " +
                        "JOIN Users " +
                        "ON(Users.gluten_allergy = 0 or Nutrition.contains_gluten = 0) " +
                        "AND(Users.peanut_allergy = 0 or Nutrition.contains_nuts = 0) " +
                        "AND(Users.fish_allergy = 0 or Nutrition.contains_fish = 0) " +
                        "AND(Users.soy_allergy = 0 or Nutrition.contains_soy = 0) " +
                        "AND(Users.dairy_allergy = 0 or Nutrition.contains_dairy = 0) " +
                        "where Users.username = @user ";
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
                            if (reader["item_name"] != DBNull.Value)
                            { //Check for a null database value
                                int id = (int)reader["id"];
                                string name = reader["item_name"].ToString();
                                int calories = (int)reader["calories"];
                                double fat = (double)(decimal)reader["fat"];
                                double carbs = (double)(decimal)reader["carbohydrate"];
                                double protein = (double)(decimal)reader["protein"];
                                int gluten = (int)reader["contains_gluten"], nuts = (int)reader["contains_nuts"], fish = (int)reader["contains_fish"], dairy = (int)reader["contains_dairy"], soy = (int)reader["contains_soy"];
                                int[] allergies = new int[] { gluten, nuts, fish, dairy, soy };
                                foodItems.Add(new Food(id, name, calories, fat, protein, carbs, allergies));
                            }
                        }
                    }
                }
            }
            return foodItems;
        }

        public Food GetFoodData(int id, string item_name)
        {
            Food foodItem = null;
            string sql = "SELECT * from [dbo].[Nutrition] where [id] = @id AND [item_name] = @name";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", item_name);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (reader["item_name"] != DBNull.Value)
                            { //Check for a null database value
                                int row_id = (int)reader["id"];
                                string name = reader["item_name"].ToString();
                                int calories = (int)reader["calories"];
                                double fat = (double)(decimal)reader["fat"];
                                double carbs = (double)(decimal)reader["carbohydrate"];
                                double protein = (double)(decimal)reader["protein"];
                                int gluten = (int)reader["contains_gluten"], nuts = (int)reader["contains_nuts"], fish = (int)reader["contains_fish"], dairy = (int)reader["contains_dairy"], soy = (int)reader["contains_soy"];
                                int[] allergies = new int[] { gluten, nuts, fish, dairy, soy };
                                foodItem = new Food(row_id, name, calories, fat, protein, carbs, allergies);
                            }
                        }
                    }
                }
            }
            return foodItem;
        }

        public Food GetFoodData(string name)
        {
            Food foodItems = null;
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
                            int id = (int)reader["id"];
                            string n = reader["item_name"].ToString();
                            int calories = (int)reader["calories"];
                            double fat = (double)(decimal)reader["fat"];
                            double carbs = (double)(decimal)reader["carbohydrate"];
                            double protein = (double)(decimal)reader["protein"];
                            int gluten = (int)reader["contains_gluten"], nuts = (int)reader["contains_nuts"], fish = (int)reader["contains_fish"], dairy = (int)reader["contains_dairy"], soy = (int)reader["contains_soy"];
                            int[] allergies = new int[] { gluten, nuts, fish, dairy, soy };
                            foodItems = new Food(id, n, calories, fat, protein, carbs, allergies);
                        }
                    }
                }
            }
            return foodItems;
        }

        //Get recipes from the database
        public List<Recipe> GetRecipeList()
        {
            List<Recipe> recipes = new List<Recipe>();
            string sql = "SELECT * from [dbo].[Recipes]";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Fill in the recipe information
                            string name = reader["name"].ToString();
                            string description = reader["description"].ToString();
                            string instructions = reader["instructions"].ToString();
                            string recipeID = reader["recipeid"].ToString();

                            //Get the recipe ingredients
                            List<Food> ingredients = GetRecipeIngredients(recipeID);

                            //Construct the recipe object
                            Recipe d = new Recipe(name, description, instructions, ingredients);

                            //Add the recipe to the list
                            recipes.Add(d);
                        }
                    }
                }
            }
            return recipes;
        }

        public DataTable getRecipeList()
        {
            DataTable recipes = new DataTable();
            string sql = "SELECT * from [dbo].[Recipes]";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    using (SqlDataAdapter sqlData = new SqlDataAdapter(command))
                    {
                        sqlData.Fill(recipes);
                    }
                }
            }
            //  recipes.Columns.Add("Recipe", typeof(string));
            // recipes.Columns.Add("Value", typeof(int));

            return recipes;
        }

        //Recipe helper to grab the ingredients for a given recipe
        private List<Food> GetRecipeIngredients(string recipeID)
        {
            List<Food> ingredients = new List<Food>();
            string sql = "SELECT Nutrition.id, Nutrition.item_name as 'name', Nutrition.calories, Nutrition.fat, Nutrition.carbohydrate as 'carbs', Nutrition.protein, Nutrition.contains_gluten, Nutrition.contains_nuts, Nutrition.contains_fish, Nutrition.contains_dairy, Nutrition.contains_soy from [dbo].[RecipeData] " +
                         "JOIN Nutrition ON RecipeData.item_name = Nutrition.item_name " +
                         "where recipeid = @id";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@id", recipeID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["name"] != DBNull.Value)
                            { //Check for a null database value
                                int id = (int)reader["id"];
                                string name = reader["name"].ToString();
                                int calories = (int)reader["calories"];
                                double fat = (double)(decimal)reader["fat"];
                                double carbs = (double)(decimal)reader["carbs"];
                                double protein = (double)(decimal)reader["protein"];
                                int gluten = (int)reader["contains_gluten"], nuts = (int)reader["contains_nuts"], fish = (int)reader["contains_fish"], dairy = (int)reader["contains_dairy"], soy = (int)reader["contains_soy"];
                                int[] allergies = new int[] { gluten, nuts, fish, dairy, soy };
                                Food d = new Food(id, name, calories, fat, protein, carbs, allergies, Food.MealType.Dinner);//Default to dinner--this value is not used
                                ingredients.Add(d);
                            }
                        }
                    }
                }
            }
            return ingredients;
        }

        //Insert recipes to the database
        public void InsertRecipe(string username, string recipeName, string description, string instructions, List<Food> ingredients)
        {
            string recipeID = generateRecipeID(); //Generate a recipe ID
            string sql = "INSERT INTO [dbo].[Recipes] (name,description,instructions,createdBy,recipeid,date) VALUES (@name,@des,@inst,@by,@id,GETDATE())";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@name", recipeName);
                    command.Parameters.AddWithValue("@des", description);
                    command.Parameters.AddWithValue("@inst", instructions);
                    command.Parameters.AddWithValue("@by", username);
                    command.Parameters.AddWithValue("@id", recipeID); //Call generate recipe ID function to build a recipe ID

                    int result = command.ExecuteNonQuery();
                    // Check Error
                    if (result < 0)
                        MessageBox.Show("Error inserting user weight");
                    else
                        InsertRecipeHelper(recipeID, ingredients); //Insert the ingredients list under the given the recipe ID

                }
            }
        }

        /**
         * Insert Recipe Helper function to insert the ingredients list to the recipe's ingredients table (RecipeData)
         */
        private void InsertRecipeHelper(string recipeID, List<Food> ingredients)
        {
            List<Food> foodItems = ingredients;
            string sql = "INSERT INTO [dbo].[RecipeData] (recipeid,item_name) VALUES (@id,@name)";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    //Explicitly define the parameters
                    command.Parameters.Add("@id", SqlDbType.VarChar);
                    command.Parameters.Add("@name", SqlDbType.VarChar);

                    //Loop through all of the food items
                    foreach (Food f in foodItems)
                    {
                        command.Parameters["@id"].Value = recipeID;
                        command.Parameters["@name"].Value = f.name;

                        int result = command.ExecuteNonQuery();
                        // Check Error
                        if (result < 0)
                            MessageBox.Show("Error inserting item " + f.name + " into the recipe data");
                    }
                }
            }
        }

        public void UpdateRecipe(Recipe item, string recipeID)
        {//"INSERT INTO [dbo].[Recipes] (name,description,instructions,createdBy,recipeid,date) VALUES (@name,@des,@inst,@by,@id,GETDATE())";
            DeleteRecipeHelper(recipeID);//Get rid of old ingredients

            string sql = "UPDATE [dbo].[Recipes] SET " +
                "name = @name," +
                "description = @des," +
                "instructions = @ins " +
                "WHERE recipeid = @id";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {//@item,@calories,@fat,@carbs,@protein,@gluten,@nuts,@fish,@dairy,@soy
                    command.Parameters.AddWithValue("@name", item.name);
                    command.Parameters.AddWithValue("@des", item.description);
                    command.Parameters.AddWithValue("@ins", item.instructions);
                    command.Parameters.AddWithValue("@id", recipeID);

                    int result = command.ExecuteNonQuery();
                    // Check Error
                    if (result < 0)
                        MessageBox.Show("Error updating data in Database!");
                    else
                    {
                        InsertRecipeHelper(recipeID, item.ingredients);  //Insert the ingredients list under the given the recipe ID
                        if (Program.debugMode)
                            MessageBox.Show("Updated recipe " + item.name + " successfully");
                    }
                }
            }
        }

        public string GetRecipeMaker(string recipeID)
        {
            string maker = "";
            string sql = "SELECT [createdBy] FROM [dbo].[Recipes] WHERE recipeid = @id";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@id", recipeID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (reader["createdBy"] != DBNull.Value)
                                maker = reader["createdBy"].ToString();
                        }
                    }
                }
            }
            return maker;
        }

        //Delete REcipe
        public void DeleteRecipe(string recipeID, string username)
        {
            string sql = "DELETE FROM [dbo].[Recipes] WHERE [recipeid] = @ID " +
                "AND [createdBy] = @user";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@ID", recipeID);
                    command.Parameters.AddWithValue("@user", username);
                    var result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        DeleteRecipeHelper(recipeID); //Clean up objects in the database by deleting fragmented recipe ingredients
                        if (Program.debugMode)
                            MessageBox.Show("Deleted recipe: " + recipeID + " from the DB");//Debug
                    }
                    else
                        MessageBox.Show(recipeID + " not found");//Debug
                }
            }
        }

        //Delete Recipe helper to delete objects in the recipe ingredient table (RecipeData)
        //Prevents fragments of recipe data that is no longer going to be used again
        private void DeleteRecipeHelper(string recipeID)
        {
            string sql = "DELETE FROM [dbo].[RecipeData] WHERE [recipeid] = @ID";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@ID", recipeID);
                    var result = command.ExecuteNonQuery();
                    if (result < 0)
                        MessageBox.Show(recipeID + " not found");//Debug
                }
            }
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
                    if (result > 0 && Program.debugMode)
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

        /**
         * Generate a random 12-char string as the recipe id
         * This recipe id is later used to join a recipe to it's recipe ingredients table
         */
        private string generateRecipeID()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[12];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            return new String(stringChars);
        }

        private string GetConnectionString()
        {
            return @"Server=" + Server + ";Initial Catalog=" + DB + ";Persist Security Info=False;User ID=" + Username + ";Password=" + Password + ";MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }
    }
}
