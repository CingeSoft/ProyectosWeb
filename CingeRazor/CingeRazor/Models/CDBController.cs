using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CingeRazor.Models
{
    public class CDBController : Controller
    {

        private static CDBController objConexionDB = null;
        private SqlConnection con;
        private CDBController()
        {
            con = new SqlConnection("Data Source=.;Initial Catalog=CingeWeb;Integrated Security=True");
        }

        public static CDBController saberEstado()
        {
            if (objConexionDB == null)
            {
                objConexionDB = new CDBController();

            }
            return objConexionDB;
        }

        public SqlConnection getCon()
        {
            return con;
        }

        public void closeDB()
        {
            objConexionDB = null;
        }
    }

}

    