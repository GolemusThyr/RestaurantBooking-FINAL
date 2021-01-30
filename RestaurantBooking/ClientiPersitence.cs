using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using System.Security.Cryptography;
using RestaurantBooking.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace RestaurantBooking
{
    public class ClientiPersistence
    {

        public ClientiPersistence()
        {
            /*myConnectionString = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
            try
            {

                conn.ConnectionString = myConnectionString;
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

            }*/
        }




        






        



        public int saveClient(Clienti clientToSave)
        {

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["localDB"].ConnectionString))
            {
                int indexC = 0;
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(null, connection);

                    // Create SQL statement.
                    command.CommandText = "INSERT INTO Clienti (NumePrenume, IndexOras, Email, Parola) output INSERTED.[Index] VALUES (@nume, @oras, @email, @parola);";

                    command.Parameters.AddWithValue("@nume", clientToSave.NumePrenume);
                    command.Parameters.AddWithValue("@oras", clientToSave.IndexOras);
                    command.Parameters.AddWithValue("@email", clientToSave.Email);
                    command.Parameters.AddWithValue("@parola", sha256_hash(clientToSave.Parola));

                    indexC = (int)command.ExecuteScalar();

                    System.Diagnostics.Debug.WriteLine("Client: " + indexC);

                    // Create client session token
                    string Token = Convert.ToBase64String(BitConverter.GetBytes(DateTime.UtcNow.ToBinary()).Concat(Guid.NewGuid().ToByteArray()).ToArray());
                    command.CommandText = "INSERT INTO ClientiSesiuni (IndexClient, Token, DeviceId) VALUES (@indexClient, @token, @device)";
                    command.Parameters.AddWithValue("@indexClient", indexC);
                    command.Parameters.AddWithValue("@token",Token);
                    command.Parameters.AddWithValue("@device", sha256_hash(clientToSave.DeviceID));

                    command.ExecuteNonQuery();
                   clientToSave.Token = Token;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }

                return indexC;
            }
        }

        private static String sha256_hash(String value)
        {
            System.Text.StringBuilder Sb = new System.Text.StringBuilder();

            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}