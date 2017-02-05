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
    public class OrdenPagoBL : IOrdenPagoBL
    {
        public bool Create(OrdenPago item)
        {
            string sql = @"INSERT INTO ORDENPAGO(Monto, MonedaID, EstadoID, FechaPago, SucursalID)
                            VALUES(@Monto, @Moneda, @Estado, @FechaPago, @SucursalID)";
            try
            {
                using (SqlConnection con = SQLServerConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@Monto", SqlDbType.Decimal).Value = item.Monto;
                        cmd.Parameters.Add("@Moneda", SqlDbType.Int, 200).Value = item.MonedaID;
                        cmd.Parameters.Add("@Estado", SqlDbType.Int, 200).Value = item.EstadoID;
                        cmd.Parameters.Add("@FechaPago", SqlDbType.DateTime).Value = DateTime.Now;
                        cmd.Parameters.Add("@SucursalID", SqlDbType.Int).Value = item.SucursalID;
                        int result = cmd.ExecuteNonQuery();
                        if (result == 1)
                            return true;
                        return false;

                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool DeleteByID(int? id)
        {
            string sql = @"DELETE FROM ORDENPAGO
                          WHERE OrdenPagoID=@OrdenPagoID";
            try
            {
                using (SqlConnection con = SQLServerConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@OrdenPagoID", SqlDbType.Int).Value = id;

                        int result = cmd.ExecuteNonQuery();
                        if (result == 1)
                            return true;
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<OrdenPago> GetAll()
        {
            List<OrdenPago> ordenpagos = new List<OrdenPago>();
            string sql = @"SELECT * FROM ORDENPAGO";
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
                            ordenpagos = SQLServerConnection.DataReaderMapToList<OrdenPago>(reader);

                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return ordenpagos;
        }

        public OrdenPago GetById(int id)
        {
            OrdenPago banco = new OrdenPago();
            string sql = @"SELECT * FROM ORDENPAGO WHERE OrdenPagoID=@OrdenPagoID";
            try
            {
                using (SqlConnection con = SQLServerConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@OrdenPagoID", SqlDbType.Int).Value = id;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader != null)
                            banco = SQLServerConnection.DataReaderMapToList<OrdenPago>(reader).FirstOrDefault();

                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return banco;
        }

        public List<OrdenPago> GetOrdenPagoByMoneda(int monedaID)
        {
            List<OrdenPago> ordenpagos = new List<OrdenPago>();
            string sql = @"SELECT * FROM ORDENPAGO WHERE MonedaID=@MonedaID";
            try
            {
                using (SqlConnection con = SQLServerConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@MonedaID", SqlDbType.Int).Value = monedaID;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader != null)
                            ordenpagos = SQLServerConnection.DataReaderMapToList<OrdenPago>(reader);

                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return ordenpagos;
        }

        public bool Update(OrdenPago item)
        {
            string sql = @"UPDATE ORDENPAGO 
                          SET Monto=@Monto,
                              MonedaID=@Moneda,
                              EstadoID =@Estado,
                              FechaPago=@FechaPago,
                              SucursalID=@SucursalID
                          WHERE OrdenPagoID=@OrdenPagoID";
            try
            {
                using (SqlConnection con = SQLServerConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@OrdenPagoID", SqlDbType.Int).Value = item.OrdenPagoID;
                        cmd.Parameters.Add("@Monto", SqlDbType.Decimal).Value = item.Monto;
                        cmd.Parameters.Add("@Moneda", SqlDbType.Int).Value = item.MonedaID;
                        cmd.Parameters.Add("@Estado", SqlDbType.Int).Value = item.EstadoID;
                        cmd.Parameters.Add("@FechaPago", SqlDbType.DateTime).Value = DateTime.Now;
                        cmd.Parameters.Add("@SucursalID", SqlDbType.Int).Value = item.SucursalID;
                        int result = cmd.ExecuteNonQuery();
                        if (result == 1)
                            return true;
                        return false;

                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
