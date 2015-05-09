using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Data.SQLite;
using System.Windows.Forms;

/* 
 * Helper class for managing the database.
 * Code was originally taken from a post on dreamincode.net, but has some supplements
 * added, specifically the database creation method.
 */
namespace PasswordManager
{
    public class SQLiteDatabase
    {
        string databaseConnection;

        public SQLiteDatabase()
        {
            databaseConnection = Properties.Settings.Default.DatabaseConnectionString;
        }

        public void CreateDatabase()
        {
            // Create the database file and every table in the database
            if (!File.Exists(Properties.Settings.Default.DatabaseFilename))
            {
                SQLiteConnection.CreateFile(Properties.Settings.Default.DatabaseFilename);
            }
            
            try
            {
                SQLiteConnection connection = new SQLiteConnection(databaseConnection);
                connection.Open();
                // Set database password
                connection.ChangePassword(Properties.Settings.Default.DatabaseConnectionString.Substring(Properties.Settings.Default.DatabaseConnectionString.IndexOf("Password=") + 9));
                // Remove database password
                // connection.ChangePassword("")
                connection.Close();
                
                this.ExecuteNonQuery("CREATE TABLE Password (PasswordID INTEGER PRIMARY KEY, Hash TEXT, Salt TEXT)");
                this.ExecuteNonQuery("CREATE TABLE Information (InformationID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, URL TEXT, Description TEXT)");
                this.ExecuteNonQuery("CREATE TABLE Credential (CredentialID INTEGER PRIMARY KEY AUTOINCREMENT, Username TEXT, Password TEXT, InformationID INTEGER, FOREIGN KEY(InformationID) REFERENCES Information(InformationID))");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void DeleteDatabase()
        {
            try
            {
                this.ExecuteNonQuery("DROP TABLE Password");
                this.ExecuteNonQuery("DROP TABLE Information");
                this.ExecuteNonQuery("DROP TABLE Credential");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public string ExecuteScalar(string sql)
        {
            SQLiteConnection connection = new SQLiteConnection(databaseConnection);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = sql;
            object value = command.ExecuteScalar();
            connection.Close();
            
            if (value != null)
            {
                return value.ToString();
            }
            return "";
        }

        public void ExecuteNonQuery(string sql)
        {
            SQLiteConnection connection = new SQLiteConnection(databaseConnection);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = sql;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public DataTable GetDataTable(string sql)
        {
            DataTable datatable = new DataTable();

            SQLiteConnection connection = new SQLiteConnection(databaseConnection);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = sql;
            SQLiteDataReader reader = command.ExecuteReader();
            datatable.Load(reader);
            reader.Close();
            connection.Close();
            
            return datatable;
        }

        public void InsertHash(string hash, string salt)
        {
            try
            {
                ExecuteNonQuery("INSERT INTO Password (PasswordID, Hash, Salt) VALUES (1, '" + hash + "', '" + salt + "')");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void UpdateHash(string hash)
        {
            try
            {
                ExecuteNonQuery("UPDATE Password SET Hash = '" + hash + "' WHERE PasswordID = 1");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public string SelectHash()
        {
            try
            {
                return ExecuteScalar("SELECT Hash FROM Password WHERE PasswordID = 1");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return "";
        }

        public string SelectSalt()
        {
            try
            {
                return ExecuteScalar("SELECT Salt FROM Password WHERE PasswordID = 1");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return "";
        }

        public int CountCredentials()
        {
            try
            {
                return Convert.ToInt32(ExecuteScalar("SELECT COUNT(*) FROM Information"));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return 0;
        }

        public List<string> SelectCredentialNames()
        {
            DataTable credentialTable = new DataTable();
            List<string> credentialNames = new List<string>();

            try
            {
                credentialTable = GetDataTable("SELECT Name FROM Information ORDER BY Name");
                
                foreach (DataRow row in credentialTable.Rows)
                {
                    credentialNames.Add(row["Name"].ToString());
                }

                return credentialNames;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
            return null;
        }

        public Credential SelectCredentialByName(string name)
        {
            DataTable internetData = new DataTable();
            DataTable credentialData = new DataTable();
            Credential credential = new Credential();

            try
            {
                int selectID = Convert.ToInt32(ExecuteScalar("SELECT InformationID FROM Information WHERE Name = '" + name + "'"));
                
                internetData = GetDataTable("SELECT InformationID, Name, URL, Description FROM Information WHERE InformationID = " + selectID);
                credentialData = GetDataTable("SELECT Username, Password FROM Credential WHERE InformationID = " + selectID);

                foreach (DataRow row in internetData.Rows)
                {
                    credential.id = Convert.ToInt32(row["InformationID"]);
                    credential.name = row["Name"].ToString();
                    credential.url = row["URL"].ToString();
                    credential.description = row["Description"].ToString();
                }

                foreach (DataRow row in credentialData.Rows)
                {
                    credential.username = row["Username"].ToString();
                    credential.password = row["Password"].ToString();
                }
                return credential;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return null;
        }

        public Credential SearchCredentialByName(string name)
        {
            DataTable internetData = new DataTable();
            DataTable credentialData = new DataTable();
            Credential credential = new Credential();

            try
            {
                int selectID = Convert.ToInt32(ExecuteScalar("SELECT InformationID FROM Information WHERE Name LIKE '%" + name.Replace("'", "''") + "%'"));

                internetData = GetDataTable("SELECT InformationID, Name, URL, Description FROM Information WHERE InformationID = " + selectID);
                credentialData = GetDataTable("SELECT Username, Password FROM Credential WHERE InformationID = " + selectID);

                foreach (DataRow row in internetData.Rows)
                {
                    credential.id = Convert.ToInt32(row["InformationID"]);
                    credential.name = row["Name"].ToString();
                    credential.url = row["URL"].ToString();
                    credential.description = row["Description"].ToString();
                }

                foreach (DataRow row in credentialData.Rows)
                {
                    credential.username = row["Username"].ToString();
                    credential.password = row["Password"].ToString();
                }
                return credential;
            }
            catch (FormatException e)
            {
                string error = e.Message;
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return null;
        }

        public Credential SelectFirstCredential()
        {
            DataTable internetData = new DataTable();
            DataTable credentialData = new DataTable();
            Credential credential = new Credential();

            try
            {
                internetData = GetDataTable("SELECT InformationID, Name, URL, Description FROM Information LIMIT 1");
                

                foreach (DataRow row in internetData.Rows)
                {
                    credential.id = Convert.ToInt32(row["InformationID"]);
                    credential.name = row["Name"].ToString();
                    credential.url = row["URL"].ToString();
                    credential.description = row["Description"].ToString();
                }

                credentialData = GetDataTable("SELECT Username, Password FROM Credential WHERE InformationID = " + credential.id);

                foreach (DataRow row in credentialData.Rows)
                {
                    credential.username = row["Username"].ToString();
                    credential.password = row["Password"].ToString();
                }
                return credential;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return null;
        }
        
        public Credential SelectInternetCredential(int selectID)
        {
            DataTable internetData = new DataTable();
            DataTable credentialData = new DataTable();
            Credential credential = new Credential();
            
            try
            {
                //results = GetDataTable("SELECT Information.Name, Credential.Username, Credential.Password, Information.URL, Information.Description FROM Information INNER JOIN Credential ON Information.InformationID = " + selectID + " AND Information.InformationID = Credential.InformationID");
                
                internetData = GetDataTable("SELECT InformationID, Name, URL, Description FROM Information WHERE InformationID = " + selectID);
                credentialData = GetDataTable("SELECT Username, Password FROM Credential WHERE InformationID = " + selectID);

                foreach (DataRow row in internetData.Rows)
                {
                    credential.id = Convert.ToInt32(row["InformationID"]);
                    credential.name = row["Name"].ToString();
                    credential.url = row["URL"].ToString();
                    credential.description = row["Description"].ToString(); 
                }

                foreach (DataRow row in credentialData.Rows)
                {
                    credential.username = row["Username"].ToString();
                    credential.password = row["Password"].ToString();
                }
                return credential;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return null;
        }

        public List<Credential> SelectAllCredentials()
        {
            DataTable credentialData = new DataTable();
            Credential credential;
            List<Credential> allCredentials = new List<Credential>();

            try
            {
                credentialData = GetDataTable("SELECT Information.Name, Credential.Username, Credential.Password, Information.URL, Information.Description FROM Information JOIN Credential ON Information.InformationID = Credential.InformationID");

                foreach (DataRow row in credentialData.Rows)
                {
                    credential = new Credential();

                    credential.name = row["Name"].ToString();
                    credential.username = row["Username"].ToString();
                    credential.password = row["Password"].ToString();
                    credential.url = row["URL"].ToString();
                    credential.description = row["Description"].ToString();

                    allCredentials.Add(credential);
                }

                return allCredentials;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return null;
        }
        
        public List<Credential> SelectAllSecureCredentials()
        {
            DataTable credentialData = new DataTable();
            Credential internetCredential;
            List<Credential> encryptedCredentials = new List<Credential>();

            try
            {
                credentialData = GetDataTable("SELECT CredentialID, Username, Password FROM Credential");

                foreach (DataRow row in credentialData.Rows)
                {
                    internetCredential = new Credential();
                    
                    internetCredential.id = Convert.ToInt32(row["CredentialID"]);
                    internetCredential.username = row["Username"].ToString();
                    internetCredential.password = row["Password"].ToString();

                    encryptedCredentials.Add(internetCredential);
                }

                return encryptedCredentials;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return null;
        }

        public void InsertInternetCredential(Credential dataInsert)
        {
            try
            {
                // Insert information into the Information table, then get autonumber to use for foreign key when inserting username and password
                ExecuteNonQuery("INSERT INTO Information (Name, URL, Description) VALUES ('" + dataInsert.name.Replace("'", "''") + "', '" + dataInsert.url.Replace("'", "''") + "', '" + dataInsert.description.Replace("'", "''") + "')");
                int foreignKeyValue = Int32.Parse(ExecuteScalar("SELECT InformationID FROM Information WHERE Name = '" + dataInsert.name + "'"));
                ExecuteNonQuery("INSERT INTO Credential (Username, Password, InformationID) VALUES ('" + dataInsert.username.Replace("'", "''") + "', '" + dataInsert.password.Replace("'", "''") + "', " + foreignKeyValue + ")");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void UpdateInternetCredential(Credential dataUpdate, int updateID)
        {
            try
            {
                ExecuteNonQuery("UPDATE Information SET Name = '" + dataUpdate.name.Replace("'", "''") + "', URL = '" + dataUpdate.url.Replace("'", "''") + "', Description = '" + dataUpdate.description.Replace("'", "''") + "' WHERE InformationID = " + updateID);
                ExecuteNonQuery("UPDATE Credential SET Username = '" + dataUpdate.username.Replace("'", "''") + "', Password = '" + dataUpdate.password.Replace("'", "''") + "' WHERE InformationID = " + updateID);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void UpdateSecureCredential(Credential dataUpdate, int updateID)
        {
            try
            {
                ExecuteNonQuery("UPDATE Credential SET Username = '" + dataUpdate.username.Replace("'", "''") + "', Password = '" + dataUpdate.password.Replace("'", "''") + "' WHERE CredentialID = " + updateID);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void DeleteInternetCredential(int deleteID)
        {
            try
            {
                ExecuteNonQuery("DELETE FROM Credential WHERE InformationID = " + deleteID);
                ExecuteNonQuery("DELETE FROM Information WHERE InformationID = " + deleteID);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}


