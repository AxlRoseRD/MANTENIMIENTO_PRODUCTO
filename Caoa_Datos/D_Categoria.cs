using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidad;
using System.Data;

namespace Capa_Datos
{
    public class D_Categoria
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);
        
        public List<E_Categoria> ListarCategoria(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
            LeerFilas = cmd.ExecuteReader();

            List<E_Categoria> listar = new List<E_Categoria>();
            while (LeerFilas.Read())
            {
                listar.Add(new E_Categoria
                {
                    IdCategoria = LeerFilas.GetInt32(0),
                    CodigoCategoria = LeerFilas.GetString(1),
                    Nombre = LeerFilas.GetString(2),
                    Descripcion = LeerFilas.GetString(3)
                });
            }
            conexion.Close();
            LeerFilas.Close();
            return listar;
        }

        public void InsertarCategoria(E_Categoria Categoria) 
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", Categoria.Nombre);
            cmd.Parameters.AddWithValue("@DESCRIPCION", Categoria.Descripcion);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EditarCategoria(E_Categoria Categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IDCATEGORIA",Categoria.IdCategoria);
            cmd.Parameters.AddWithValue("@NOMBRE", Categoria.Nombre);
            cmd.Parameters.AddWithValue("@DESCRIPCION", Categoria.Descripcion);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarCategoria(E_Categoria Categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IDCATEGORIA", Categoria.IdCategoria);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
