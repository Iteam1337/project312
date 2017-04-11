using System;
using Npgsql;
using project312.Models;

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
    }
}