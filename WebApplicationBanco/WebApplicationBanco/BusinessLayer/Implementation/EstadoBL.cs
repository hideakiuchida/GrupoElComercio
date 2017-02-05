using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.DTO;
using BusinessLayer.Connection;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLayer.Implementation
{
    public class EstadoBL : IEstado
    {
        public List<Estado> GetAll()
        {
            List<Estado> monedas = new List<Estado>();
            string sql = @"SELECT * FROM ESTADO";
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
                            monedas = SQLServerConnection.DataReaderMapToList<Estado>(reader);

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
