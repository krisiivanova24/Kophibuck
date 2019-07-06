using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace kophibuck
{
    class Database
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public Database()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "35.224.20.143";
            database = "kophibuck";
            uid = "kophibuck";
            password = "kophibuck";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public List<string> CheckIn(string name, string pass)
        {
            List<string> Name = new List<string>();
            char[] symbols = new char[] { '*', '&', '#', '!', '@', ':', ';', '%', '/', '.', '(', ')', '{', '}', '[', ']', ',' };
            bool whetherContainsSymbolorNot = false;
            foreach (var symbol in symbols)
            {
                if (name.Contains(symbol.ToString()) || pass.Contains(symbol.ToString()))
                {
                    whetherContainsSymbolorNot = true;
                }
            }
            if (whetherContainsSymbolorNot == false)
            {
                string query = $"select * from kophibuck.admin where adminName = '{name}' and adminPassword = '{pass}'";

                //Open connection
                if (this.OpenConnection() == true)
                {
                    try
                    {
                        // Create Command
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        //Create a data reader and Execute the command
                        MySqlDataReader dataReader = cmd.ExecuteReader();

                        //Read the data and store them in the list
                        if (dataReader.Read())
                        {
                            MessageBox.Show("Welcome, admin!","Successfully loged",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            Name.Add(dataReader["adminName"].ToString());
                            Name.Add(dataReader["variant"].ToString());
                            Name.Add(dataReader["placeId"].ToString());
                        }
                        else
                        {
                            MessageBox.Show("Wrong given information! Please, try again!", "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        //close Data Reader
                        dataReader.Close();

                        //close Connection
                        this.CloseConnection();

                        //return list to be displayed

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Wrong given information! Please, try again!","Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid inputs! Please, try again!","Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Name;
        }


        public List<string> SignIn(string name, string number)
        {
            List<string> information = new List<string>();
            char[] symbols = new char[] { '*', '&', '#', '!', '@', ':', ';', '%', '/', '.', '(', ')', '{', '}', '[', ']', ',' };
            bool whetherContainsSymbolorNot = false;
            foreach (var symbol in symbols)
            {
                if (name.Contains(symbol.ToString()) || number.Contains(symbol.ToString()))
                {
                    whetherContainsSymbolorNot = true;
                }
            }
            if (whetherContainsSymbolorNot == false)
            {
                string query = $"select * from kophibuck.clients where firstname = '{name}' and phone_number = '{number}'";

                //Open connection
                if (this.OpenConnection() == true)
                {
                    try
                    {
                        // Create Command
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        //Create a data reader and Execute the command
                        MySqlDataReader dataReader = cmd.ExecuteReader();

                        //Read the data and store them in the list
                        if (dataReader.Read())
                        {
                            information.Add(dataReader["firstname"].ToString());
                            information.Add(dataReader["lastname"].ToString());
                            information.Add(dataReader["address"].ToString());
                            information.Add(dataReader["phone_number"].ToString());
                            MessageBox.Show($"Welcome, {name}!","Login successfully",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Wrong given information! Please, try again!","Something went wrong",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }

                        //close Data Reader
                        dataReader.Close();

                        //close Connection
                        this.CloseConnection();

                        //return list to be displayed
                        
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Wrong given information! Please, try again!", "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid inputs! Please, try again!","Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return information;
        }
        public List<string> SelectPlaceAdmin(string variant, int placeId)
        {
            List<string> information = new List<string>();
            string query = $"select * from kophibuck.{variant} where id = '{placeId}'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                try
                {
                    // Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    if (dataReader.Read())
                    {
                        information.Add(dataReader["name"].ToString());
                        information.Add(dataReader["seats"].ToString());
                        information.Add(dataReader["tables"].ToString());                        
                    }
                    else
                    {
                        MessageBox.Show("Wrong given information! Please, try again!", "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    this.CloseConnection();

                    //return list to be displayed

                }
                catch (Exception)
                {
                    MessageBox.Show("Wrong given information! Please, try again!", "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return information;

        }

        //Select statement
        public List<string> SelectPlace(string variant)
        {
            string query = $"SELECT city, country, address FROM kophibuck.{variant}";

            //Create a list to store the result
            List<string> list = new List<string>();


            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list.Add(String.Concat(dataReader["city"] + ", " + dataReader["country"] + ", ", dataReader["address"]).ToString().ToString());
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }


        }

        public List<string> SelectThisPlace(string variant, string[] cafe)
        {
            string query = $"SELECT * FROM kophibuck.{variant} where city = '{cafe[0].Trim()}' and country = '{cafe[1].Trim()}' and address = '{cafe[2].Trim()}'";

            //Create a list to store the result
            List<string> list = new List<string>();


            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list.Add(dataReader["name"].ToString());
                    list.Add(dataReader["working_time"].ToString());
                    list.Add(dataReader["phone_number"].ToString());
                    list.Add(dataReader["seats"].ToString());
                    list.Add(dataReader["tables"].ToString());
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        public void UpdatePlace(string variant, string name, string phone_number, int seats, int tables, int seatsYouWant, int tablesYouWant)
        {
            string query = $"UPDATE kophibuck.{variant} SET seats ='{seats - seatsYouWant}', tables = '{tables - tablesYouWant}' WHERE name='{name}' and phone_number = '{phone_number}'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public List<int> UpdatePlaceBook(string variant, int id, int seats, int tables, int seatsToBook, int tablesToBook)
        {
            string query = $"UPDATE kophibuck.{variant} SET seats ='{seats - seatsToBook}', tables = '{tables - tablesToBook}' WHERE id = {id}";
            List<int> results = new List<int>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                results.Add(seats - seatsToBook);
                results.Add(tables - tablesToBook);
                //close connection
                this.CloseConnection();
            }
            return results;
        }

        public List<int> UpdatePlaceFree(string variant, int id, int seats, int tables, int seatsToBook, int tablesToBook)
        {
            string query = $"UPDATE kophibuck.{variant} SET seats ='{seats + seatsToBook}', tables = '{tables + tablesToBook}' WHERE id = {id}";
            List<int> results = new List<int>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                results.Add(seats + seatsToBook);
                results.Add(tables + tablesToBook);
                //close connection
                this.CloseConnection();
            }
            return results;
        }

        public void SignUpNewClient(string firstname, string lastname, string address, string phone_number)
        {
            string query = $"INSERT INTO clients(firstname, lastname, address, phone_number) VALUES ('{firstname}', '{lastname}', '{address}', '{phone_number}');";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
                MessageBox.Show("Congratulations! You sign up successfully!","Successfully registered",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Something went wrong", "Please contact support", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void SelectAdmin() {
        }
    }
}

