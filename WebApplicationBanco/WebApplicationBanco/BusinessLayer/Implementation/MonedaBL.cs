using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.DTO;
using System.Data.SqlClient;
using BusinessLayer.Connection;
using System.Data;

namespace BusinessLayer.Implementation
{
    public class MonedaBL : IMoneda
    {
        public List<Moneda> GetAll()
        {
            List<Moneda> monedas = new List<Moneda>();
            string sql = @"SELECT * FROM MONEDA";
            try
            {
                using (SqlConnection con = SQLServerConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader != null)
                            monedas = SQLServerConnection.DataReaderMapToList<Moneda>(reader);

                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return monedas;
        }
    }
}
