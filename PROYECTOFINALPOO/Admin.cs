using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTOFINALPOO
{
    internal class Admin
    {
        public string Codigo { get; set; }
        public string Proveedor { get; set; }
        public string TipoSueter { get; set; }
        public string Talla { get; set; }
        public int Stock { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }


   


        public static class DatosSistema
        {
            public static List<Admin> Inventario =
                new List<Admin>();
        }



    }
}
