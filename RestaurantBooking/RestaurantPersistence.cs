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
using Newtonsoft.Json;


namespace RestaurantBooking
{


    public class RestaurantPersistence
    {

        public RestaurantPersistence()
        { }



        public string Restaurante10(Restaurante clientTointerogate)
        {
            string rez = " ";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["localDB"].ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command2 = new SqlCommand(null, connection);
                    command2.CommandText = "SELECT TOP 10 Index, Nume, CategoriePret, Specific, Descriere, Scor FROM Restaurante   ORDER BY Nume  FOR JSON PATH  ;";
                    using (SqlDataReader reader = command2.ExecuteReader())
                    {

                        StringBuilder serial = new StringBuilder();
                        while(reader.Read())
                        {
                            serial.Append(reader[0]);


                        }
                        //rez = System.Text.Json.JsonSerializer.Serialize(_ChartLoc);
                        rez = Convert.ToString(serial);
                        System.Diagnostics.Debug.WriteLine("Serial" + serial);
                    }
                    
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();

                }

            }
            return rez;
        }

    }
    
    }







