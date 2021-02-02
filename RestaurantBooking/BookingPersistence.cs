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
using Newtonsoft;

namespace RestaurantBooking
{
    public class BookingPersistence
    {
        public string saveBooking(Booking BookingToSave)
        {

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["localDB"].ConnectionString))
            {
               
                string json;
                try
                {
                    connection.Open();
                   

                    // Create SQL statement.



                    SqlCommand command = new SqlCommand(null, connection);
                    command.CommandText = "SELECT [Index] FROM ClientiSesiuni WHERE [Token] = @tok  FOR JSON PATH;";
                    command.Parameters.AddWithValue("@tok", BookingToSave.Token);
                    string indc = BookingToSave.Token;
                    //command.Parameters.AddWithValue(indc, BookingToSave.IndexClient);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        StringBuilder serial = new StringBuilder();
                        while (reader.Read())
                        {
                             SqlCommand command2 = new SqlCommand(null, connection);
                            command2.CommandText = "INSERT INTO [Rezervari] ([IndexClient], [IndexRestaurant], [Nume],  [DataInceput], [DataFinal], [IndexMasa1], [IndexMasa2]) VALUES (@IndexClient, @IndexRestaurant, @Nume,  @DataInceput, @DataFinal, @IndexMasa1, @IndexMasa2);";

                            command2.Parameters.AddWithValue("@IndexClient", indc);
                            command2.Parameters.AddWithValue("@IndexRestaurant", BookingToSave.IndexRestaurant);
                            command2.Parameters.AddWithValue("@Nume", BookingToSave.Nume);
                            command2.Parameters.AddWithValue("@DataInceput", BookingToSave.DataInceput);
                            command2.Parameters.AddWithValue("@DataFinal", BookingToSave.DataFinal);
                            command2.Parameters.AddWithValue("@IndexMasal", BookingToSave.IndexMasa1);
                            command2.Parameters.AddWithValue("@IndexMasa2", BookingToSave.IndexMasa2);


                            serial.Append(reader[0]);


                        }


                    }





                       /* command2.CommandText = "INSERT INTO [Rezervari] ([IndexClient], [IndexRestaurant], [Nume],  [DataInceput], [DataFinal], [IndexMasa1], [IndexMasa2]) VALUES (@IndexClient, @IndexRestaurant, @Nume,  @DataInceput, @DataFinal, @IndexMasa1, @IndexMasa2);";

                    command2.Parameters.AddWithValue("@IndexClient", BookingToSave.IndexClient);
                    command2.Parameters.AddWithValue("@IndexRestaurant", BookingToSave.IndexRestaurant);
                    command2.Parameters.AddWithValue("@Nume", BookingToSave.Nume);
                    command2.Parameters.AddWithValue("@DataInceput", BookingToSave.DataInceput);
                    command2.Parameters.AddWithValue("@DataFinal", BookingToSave.DataFinal);
                    command2.Parameters.AddWithValue("@IndexMasal", BookingToSave.IndexMasa1);
                    command2.Parameters.AddWithValue("@IndexMasa2", BookingToSave.IndexMasa2);
                       */
                    
                    

                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }

                return " ";



            }
        }
    }
}