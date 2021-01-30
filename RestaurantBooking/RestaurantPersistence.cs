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
                    command2.CommandText = "SELECT TOP 1 Nume, CategoriePret, Specific, Descriere, Scor FROM Restaurante   ORDER BY Nume   ;";

                    using (SqlDataReader reader = command2.ExecuteReader())
                    {
                        List<Models.ChartLoc> _ChartLoc = new List<ChartLoc>();

                        while (reader.Read())
                        {​​​​​
                    Models.ChartLoc chart = new Models.ChartLoc();
                            chart.Data.Add(reader[1].ToString());
                            chart.Data.Add(reader[2].ToString());
                            chart.Data.Add(reader[3].ToString());
                            chart.Data.Add(reader[4].ToString());



                            //if (reader["store"] != DBNull.Value)
                            //  chart.Category = reader["col1"].ToString();
                            _ChartLoc.Add(chart);


                        }​​​​​
                         rez = System.Text.Json.JsonSerializer.Serialize(_ChartLoc);


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


}




