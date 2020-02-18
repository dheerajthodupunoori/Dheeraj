using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

namespace AdoDotNetDemo
{
    class Program
    {
        private static SqlConnection sqlConnection = null;
        static void Main(string[] args)
        {
            Console.WriteLine("Process started");
            //createTable();
            //InsertToEmployeeTable();
            //AlterColumnDataType();
            //ChangeDBConnection();
            //DemoSqlDataReader();
            //DemoSqlDataSet();
            //CreateTableForBlob();
            //UpdateImageColumn();
            ReadImageToByteArray();
            Console.ReadLine();
        }

        public static void ReadImageToByteArray()
        {
            string imageFilePath = "C:\\Users\\Dheeraj_Thodupunuri\\Desktop\\demo.jpeg";
            

        }

        public static void InsertImageIntoImageTable()
        {
            string connectionString = "Data Source=EPINHYDW0042;Initial Catalog=Test;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);

            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
                Console.WriteLine("Connection opened succesfully");
            }

        }


        public static void UpdateImageColumn()
        {
            string connectionString = "Data Source=EPINHYDW0042;Initial Catalog=Test;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);

            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
                Console.WriteLine("Connection opened succesfully");
            }

            string commandText = "Alter table Image " +
                "Alter column photo varbinary(MAX)";

            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            try
            {
                    var result = sqlCommand.ExecuteNonQuery();
                    Console.WriteLine("Column altered successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void CreateTableForBlob()
        {
            bool tableExists = false;
            string connectionString = "Data Source=EPINHYDW0042;Initial Catalog=Test;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);

            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
                Console.WriteLine("Connection opened succesfully");
            }

            string commandText = "create table Image (photo image not null)";
            
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            try
            {
                DataTable dTable = sqlConnection.GetSchema("TABLES");

                foreach (DataRow row in dTable.Rows)
                {
                    if(row.ItemArray[2].Equals("Image"))
                    {
                        tableExists = true;
                        Console.WriteLine("Image table already exists in database");
                    }
                }
                if(!tableExists)
                {
                    var result = sqlCommand.ExecuteNonQuery();
                    Console.WriteLine("Table created successfully");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            }
        public static void DemoSqlDataSet()
        {
            string connectionString = "Data Source=EPINHYDW0042;Initial Catalog=Test;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
                Console.WriteLine("Connection opened succesfully");
            }
            string commandText = "select * from employee";
            SqlCommand command = new SqlCommand(commandText, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            dataSet.DataSetName = "EmployeeDataSet";
            Console.WriteLine("DataSet Name is :" + dataSet.DataSetName);
            Console.WriteLine("Count of tables after initiating dataset :" + dataSet.Tables.Count);
         
            sqlDataAdapter.Fill(dataSet, "employee");
            Console.WriteLine("Count of tables after filling dataset :" + dataSet.Tables.Count);

            Console.WriteLine(dataSet.DefaultViewManager);

            var xmlData = dataSet.GetXml();
            Console.WriteLine(xmlData);
        }


        public static void InsertIntoStudent()
        {
            string connectionString = "Data Source=EPINHYDW0042;Initial Catalog=Test;Integrated Security=True;pooling=True";
            sqlConnection = new SqlConnection(connectionString);
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
                Console.WriteLine("Connection opened succesfully");
            }
        }

        public static void DemoSqlDataReader()
        {
            string connectionString = "Data Source=EPINHYDW0042;Initial Catalog=Test;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
                Console.WriteLine("Connection opened succesfully");
            }
            string commandText = "select * from employee";
            try
            {
                SqlCommand command = new SqlCommand(commandText, sqlConnection);

                var reader = command.ExecuteReader();
                Console.WriteLine("Data retrieved Succesfully");
                while (reader.Read())
                {
                    Console.WriteLine(reader["id"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            //Console.ReadLine();
        }

        public static void createTable()
        {
            string connectionString = "Data Source=EPINHYDW0042;Initial Catalog=Test;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            if(sqlConnection.State!=ConnectionState.Open)
            {
                sqlConnection.Open();
                Console.WriteLine("Connection opened succesfully");
            }
            string commandText = "CREATE TABLE Employee (id INT NOT NULL PRIMARY KEY,Name  varchar null," + 
                "Phone varchar null, State varchar null,City varchar null)";
            try
            { 
            SqlCommand command = new SqlCommand(commandText,sqlConnection);

            var createTableStatus = command.ExecuteNonQuery();
               Console.WriteLine("Table created Succesfully");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            Console.ReadLine();
        }

        public static void InsertToEmployeeTable()
        {
            string connectionString = "Data Source=EPINHYDW0042;Initial Catalog=Test;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
                Console.WriteLine("Connection opened succesfully");
            }
            string commandText = 
                "Insert into Employee " +
               " (id, name, phone, state , city)values(103, 'R', 'r', 'd','h')"+
                "Insert into Employee " +
               " (id, name, phone, state , city)values(104, 'R', 'r', 'd','h')"+
                "Insert into Employee " +
               " (id, name, phone, state , city)values(105, 'R', 'r', 'd','h')"+
                "Insert into Employee " +
               " (id, name, phone, state , city)values(106, 'R', 'r', 'd','h')"
               ;
            try
            {
                SqlCommand command = new SqlCommand(commandText, sqlConnection);

                var createTableStatus = command.ExecuteNonQuery();
                Console.WriteLine("Inserted rows Succesfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            Console.ReadLine();
        }

        public static void AlterColumnDataType()
        {
            string connectionString = "Data Source=EPINHYDW0042;Initial Catalog=Test;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
                Console.WriteLine("Connection opened succesfully");
            }
            string commandText = "ALTER TABLE Employee ALTER COLUMN Name varchar(255)" +
                "ALTER TABLE Employee ALTER COLUMN Phone varchar(255)"+
                "ALTER TABLE Employee ALTER COLUMN State varchar(255)"+
                "ALTER TABLE Employee ALTER COLUMN City varchar(255)";

            try
            {
                SqlCommand command = new SqlCommand(commandText, sqlConnection);

                var createTableStatus = command.ExecuteNonQuery();
                Console.WriteLine("altered  type Succesfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            Console.ReadLine();
        }

        public static void ChangeDBConnection()
        {
            string connectionString = "Data Source=EPINHYDW0042;Initial Catalog=Test;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
                Console.WriteLine("Connection opened succesfully");
            }
          

            try
            {
                sqlConnection.ChangeDatabase("SchoolDB");
                Console.WriteLine("DB changed Succesfully");
                var schema = sqlConnection.GetSchema("Tables");
                foreach(DataRow  row in schema.Rows)
                { 
                Console.WriteLine(row.ItemArray[2]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            Console.ReadLine();
        }
    }
}
