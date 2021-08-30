using System;
using System.Data.SqlClient;


namespace DB_Automation
{
    public class DBOperations
    {
        // for the connection to 
        // sql server database
        public static string constr = @"Server=(localdb)\ProjectsV13; Database =Spotify_API; Trusted_Connection = True";
         SqlConnection conn = new SqlConnection(constr);
        // use to perform read and write
        // operations in the database
        SqlCommand cmd;

        // use to read a row in
        // table one by one
        SqlDataReader dreader;

        // to store SQL command and
        // the output of SQL command
        string sql, output = "";
        int count = 0;

        // data adapter object is use to
        // insert, update or delete commands
        SqlDataAdapter adap = new SqlDataAdapter();

        public int ReadData()
        {
            // to open the connection
            conn.Open();
            try
            {
                // use to fetch rwos from demo table
                sql = "Select userid,username from User_Table";

                // to execute the sql statement
                cmd = new SqlCommand(sql, conn);

                // fetch all the rows 
                // from the user table
                dreader = cmd.ExecuteReader();

                // for one by one reading row
                while (dreader.Read())
                {
                    output = output + dreader.GetValue(0) + " - " +
                                        dreader.GetValue(1) + "\n";
                    count++;
                }

                // to display the output
                Console.Write(output);
               
            }

            catch (Exception e)
            {
                // to close all the objects
                dreader.Close();
                cmd.Dispose();
                conn.Close();
            }
            return count;
        }
        public int insertRecords()
        {
            try
            {

                conn.Open();

                SqlCommand insertComand = new SqlCommand("INSERT INTO User_Table(username,Emailid) VALUES (@0,@1)", conn);
                insertComand.Parameters.Add(new SqlParameter("0", "krishna"));
                insertComand.Parameters.Add(new SqlParameter("1", "krish@gmail.com4"));

                int count = insertComand.ExecuteNonQuery();
            }
            catch (Exception e)
            { 
                conn.Close();
            }

            return count;
        
    }

    public int Update()
        {
            // to open the connection
            conn.Open();
            try
            {
                // use the define sql 
                // statement against our database
                sql = "update User_Table set username='soubar' where userid=1";

                // use to execute the sql command so we 
                // are passing query and connection object
                cmd = new SqlCommand(sql, conn);

                // associate the insert SQL
                // command to adapter object
                adap.InsertCommand = new SqlCommand(sql, conn);

                // use to execute the DML statement against 
                // our database 
                count = adap.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                // closing all the objects
                cmd.Dispose();
                conn.Close();
            }
            return count;
        }

        public int Delete()
        {

            // to open the connection
            conn.Open();
            try { 
            string sql = "delete from User_Table where userid=6";
            // use to execute the sql command so we 
            // are passing query and connection object
            cmd = new SqlCommand(sql, conn);

            // associate the insert SQL 
            // command to adapter object
            adap.InsertCommand = new SqlCommand(sql, conn);

            // use to execute the DML statement
            // against our database
            count = adap.InsertCommand.ExecuteNonQuery();
        }
           catch (Exception e)
            {
                // closing all the objects
                cmd.Dispose();
                conn.Close();
            }
            return count;
        }
    }
}
