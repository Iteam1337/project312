using System;
using Npgsql;

namespace project312.modules
{
    public class DatabaseInitializer
    {
        public static void initDatabase()
        {
            bool dbExists = false;
            var adminConnectionString = "Host=" + Settings.PostgresHost + ";Username=admin;Password=" + Settings.PostgresPassword + ";Database=postgres;";
            using (var conn = new NpgsqlConnection(adminConnectionString))
            {

                conn.Open();
                dbExists = databaseExists(conn, Settings.DatabaseName);
                if (!dbExists)
                {
                    if (!dbUserExists(conn, Settings.DatabaseName))
                    {
                        createDbUser(conn, Settings.DatabaseName);
                    }
                    createDb(conn, Settings.DatabaseName);
                }
                else
                {
                    Console.WriteLine("Database " + Settings.DatabaseName + " already exists, movin on");
                }

            }

            if (!dbExists)
            {
                using (var conn = new NpgsqlConnection(Settings.ConnectionString))
                {
                    conn.Open();
                    createTables(conn);
                }
            }

        }

        static bool databaseExists(NpgsqlConnection conn, string databaseName)
        {
            bool dbExists = false;
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "SELECT 1 FROM pg_database WHERE datname = '" + Settings.DatabaseName + "'";
                dbExists = cmd.ExecuteScalar() != null;
            }
            return dbExists;
        }

        static bool dbUserExists(NpgsqlConnection conn, string databaseName)
        {
            bool userExists = false;


            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "SELECT 1 FROM pg_roles WHERE rolname='subs_user'";
                userExists = cmd.ExecuteScalar() != null;

            }
            return userExists;
        }

        static void createDbUser(NpgsqlConnection conn, string databaseName)
        {
            Console.WriteLine("db user does not exist, creating now...");
            try
            {
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "CREATE USER subs_user WITH PASSWORD '531h4Kb%6$y9' INHERIT CREATEDB";
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            Console.WriteLine("db user subs_user created successfully!");
        }

        static void createDb(NpgsqlConnection conn, string databaseName)
        {
            Console.WriteLine("No database found, creating now...");
            try
            {
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "CREATE DATABASE " + Settings.DatabaseName + " WITH OWNER subs_user";
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            Console.WriteLine("database " + Settings.DatabaseName + " created successfully!");
        }

        static void createTables(NpgsqlConnection conn)
        {
            Console.WriteLine("Creating Tables");
            try
            {
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    // Tables
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS subscribers(id SERIAL PRIMARY KEY, email varchar(64) not null, name varchar(64) not null)";
                    cmd.ExecuteNonQuery();

                    // // Indexes 
                    cmd.CommandText = "CREATE INDEX subscribers_email_idx ON subscribers USING btree (email)";
                    cmd.ExecuteNonQuery();


                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());



                throw;
            }
            Console.WriteLine("Created Tables");
        }
    }
}