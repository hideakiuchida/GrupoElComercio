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
    public class BancoBL : IBancoBL
    {
        public bool Create(Banco item)
        {
            string sql = @"INSERT INTO BANCO(Nombre, Direccion, FechaRegistro)
                            VALUES(@Nombre, @Direccion, @FechaRegistro)";
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
            string sql = @"DELETE FROM BANCO
                          WHERE BancoID=@BancoID";
            try
            {
                using (SqlConnection con = SQLServerConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@BancoID", SqlDbType.Int).Value = id;
     
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

        public List<Banco> GetAll()
        {
            List<Banco> bancos = new List<Banco>();
            string sql = @"SELECT * FROM BANCO";
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
                            bancos = SQLServerConnection.DataReaderMapToList<Banco>(reader);

                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            
            return bancos;
        }

        public Banco GetById(int id)
        {
            Banco banco = new Banco();
            string sql = @"SELECT * FROM BANCO WHERE BancoID=@BancoID";
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
                            banco = SQLServerConnection.DataReaderMapToList<Banco>(reader).FirstOrDefault();

                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return banco;
        }

        public bool Update(Banco item)
        {
            string sql = @"UPDATE BANCO 
                          SET Nombre=@Nombre,
                              Direccion=@Direccion,
                              FechaRegistro =@FechaRegistro
                          WHERE BancoID=@BancoID";
            try
            {
                using (SqlConnection con = SQLServerConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@BancoID", SqlDbType.Int).Value = item.BancoID;
                        cmd.Parameters.Add("@Direccion", SqlDbType.VarChar, 300).Value = item.Direccion;
                        cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 200).Value = item.Nombre;
                        cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = item.FechaRegistro;
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
