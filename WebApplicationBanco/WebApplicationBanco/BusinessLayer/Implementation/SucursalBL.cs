using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.DTO;
using System.Data.SqlClient;
using System.Data;
using BusinessLayer.Connection;

namespace BusinessLayer.Implementation
{
    public class SucursalBL : ISucursalBL
    {
        public bool Create(Sucursal item)
        {
            string sql = @"INSERT INTO SUCURSAL(Nombre, Direccion, FechaRegistro, BancoID)
                            VALUES(@Nombre, @Direccion, @FechaRegistro, @BancoID)";
            try
            {
                using (SqlConnection con = SQLServerConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@Direccion", SqlDbType.VarChar, 300).Value = item.Direccion;
                        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 200).Value = item.Nombre;
                        cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = DateTime.Now;
                        cmd.Parameters.Add("@BancoID", SqlDbType.Int).Value = item.BancoID;
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
            string sql = @"DELETE FROM SUCURSAL
                          WHERE SucursalID=@SucursalID";
            try
            {
                using (SqlConnection con = SQLServerConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@SucursalID", SqlDbType.Int).Value = id;

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

        public List<Sucursal> GetAll()
        {
            List<Sucursal> sucursales = new List<Sucursal>();
            string sql = @"SELECT * FROM SUCURSAL";
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
                            sucursales = SQLServerConnection.DataReaderMapToList<Sucursal>(reader);

                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return sucursales;
        }

        public Sucursal GetById(int id)
        {
            Sucursal sucursal = new Sucursal();
            string sql = @"SELECT * FROM SUCURSAL WHERE SucursalID=@SucursalID";
            try
            {
                using (SqlConnection con = SQLServerConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@SucursalID", SqlDbType.Int).Value = id;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader != null)
                            sucursal = SQLServerConnection.DataReaderMapToList<Sucursal>(reader).FirstOrDefault();

                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return sucursal;
        }

        public List<Sucursal> GetSucursalByBanco(int id)
        {
            List<Sucursal> sucursales = new List<Sucursal>();
            string sql = @"SELECT * FROM SUCURSAL WHERE BancoID=@BancoID";
            try
            {
                using (SqlConnection con = SQLServerConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@BancoID", SqlDbType.Int).Value = id;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader != null)
                            sucursales = SQLServerConnection.DataReaderMapToList<Sucursal>(reader);

                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return sucursales;
        }

        public bool Update(Sucursal item)
        {
            string sql = @"UPDATE SUCURSAL 
                          SET Nombre=@Nombre,
                              Direccion=@Direccion,
                              FechaRegistro =@FechaRegistro
                          WHERE SucursalID=@SucursalID";
            try
            {
                using (SqlConnection con = SQLServerConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@SucursalID", SqlDbType.Int).Value = item.SucursalID;
                        cmd.Parameters.Add("@Direccion", SqlDbType.VarChar, 300).Value = item.Direccion;
                        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 200).Value = item.Nombre;
                        cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = DateTime.Now;
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
