using System;
using Npgsql;
using project312.Models;
using System.Collections.Generic;

namespace project312.modules
{
    public class DatabaseAccess : IDatabaseAccess
    {
        public void AddSubscriber(Subscriber subscriber)
        {
            using (var conn = new NpgsqlConnection(Settings.ConnectionString))
            {
                conn.Open();
                NpgsqlTransaction tx = conn.BeginTransaction();
                try
                {
                    using (var cmd = new NpgsqlCommand("INSERT INTO subscribers(email, name) values (:email, :name)", conn))
                    {
                        cmd.Parameters.Add(new NpgsqlParameter("email", NpgsqlTypes.NpgsqlDbType.Varchar));
                        cmd.Parameters.Add(new NpgsqlParameter("name", NpgsqlTypes.NpgsqlDbType.Varchar));
                        cmd.Prepare();

                        cmd.Parameters[0].Value = subscriber.Email;
                        cmd.Parameters[1].Value = subscriber.Name;
                        cmd.ExecuteNonQuery();
                    }
                    tx.Commit();
                }
                catch
                {
                    tx.Rollback();
                    throw new Exception("Error");
                }
            }
        }

        public List<Subscriber> GetSubscribers() {
            var subscribers = new List<Subscriber>();
            using (var conn = new NpgsqlConnection(Settings.ConnectionString))
            {
                conn.Open();
                try
                {
                    using (var cmd = new NpgsqlCommand("SELECT * FROM subscribers", conn))
                    {
                        using (NpgsqlDataReader dr = cmd.ExecuteReader())
                        {
                            // Output rows
                            while (dr.Read())
                                subscribers.Add(new Subscriber {
                                    Id = (int) dr[0],
                                    Email = (string) dr[1],
                                    Name = (string) dr[2]
                                });

                            conn.Close();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw new Exception("Error");
                }
            }

            return subscribers;
        }
    }
}