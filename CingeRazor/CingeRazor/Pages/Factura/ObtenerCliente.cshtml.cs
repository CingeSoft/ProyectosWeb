using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using CingeRazor.Models;

namespace CingeRazor.Pages.Factura
{

    public class ObtenerClienteModel : PageModel
    {
        private CDBController objConexinDB;
        private SqlCommand comando;
        public void OnGet()
        {
        }
        public List<Models.Clientes> findAll()
        {
            List<Models.Clientes> listaClientes = new List<Models.Clientes>();
            string findAll = "select * from clientes";
            try
            {
                comando = new SqlCommand(findAll, objConexinDB.getCon());
                objConexinDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Models.Clientes objCliente = new Models.Clientes();
                    objCliente.Código = reader[0].ToString();
                    objCliente.Nombre = reader[1].ToString();
                    objCliente.Cédula = reader[2].ToString();
                    objCliente.Teléfono = reader[3].ToString();
                    objCliente.Dirección = reader[4].ToString();
                    objCliente.Email = reader[5].ToString();
                    listaClientes.Add(objCliente);

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexinDB.getCon().Close();
                objConexinDB.closeDB();
            }

            return listaClientes;

        }
    }

}