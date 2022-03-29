using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using Capa_Datos;

namespace CapaNegocio
{
    public class N_Categoria
    {
        D_Categoria objDato = new D_Categoria();
        
        public List<E_Categoria> ListarCategoria(string buscar) 
        {
            return objDato.ListarCategoria(buscar);
        }

        public void InsertarCategoria(E_Categoria Categoria)
        {
            objDato.InsertarCategoria(Categoria);
        }

        public void EditarCategoria(E_Categoria Categoria)
        {
            objDato.EditarCategoria(Categoria);
        }
        public void EliminarCategoria(E_Categoria Categoria) 
        {
            objDato.EliminarCategoria(Categoria);
        }

    }
}
