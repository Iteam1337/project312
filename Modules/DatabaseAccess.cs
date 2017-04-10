using System;
using Npgsql;

namespace project312.modules
{
    public class DatabaseAccess : IDatabaseAccess
    {
        public void AddSubscriber(string email, string name)
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

                        cmd.Parameters[0].Value = email;
                        cmd.Parameters[1].Value = name;
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