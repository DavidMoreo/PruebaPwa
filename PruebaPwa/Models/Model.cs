using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaPwa.Models
{
    public class SqlQuery
    {
        public int Id_product { get; set; }
        public string name { get; set; }
        public int cantidad { get; set; }
        public decimal value { get; set; }
        public decimal value_c { get; set; }
        public string img { get; set; }

    }


    public class tblProduct
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int cantidad_p { get; set; }
        public decimal value { get; set; }
        public decimal value_c { get; set; }
        public string img { get; set; }
    }

    public class tblCar
    {
        public int Id { get; set; }
        public int Id_product { get; set; }
        public int cantidad_c { get; set; }
        public int cantidad_p { get; set; }
        public decimal value { get; set; }
        public decimal value_c { get; set; }
        public string name { get; set; }
    }

    public class tblBuy
    {

        public int Id { get; set; }
        public int Id_product { get; set; }
        public int cantidad_b { get; set; }
        public decimal value { get; set; }
        public string name { get; set; }

    }



    class ModelEmpy
    {
        public static tblBuy getEmpytblBuy()
        {
            var Buy = new tblBuy()
            {
                Id = 0,
                Id_product = 0,
                cantidad_b = 0,
                name = "",
                value = 0,

            };

            return Buy;
        }

        public static tblProduct getEmpytblProduct()
        {
            var Buy = new tblProduct()
            {
                Id = 0,
                name = "",
                value = 0,
                img = "",
                cantidad_p = 0

            };

            return Buy;
        }

        public static tblCar getEmpytblCart()
        {
            var Buy = new tblCar()
            {
                Id = 0,
                Id_product = 0,
                name = "",
                value = 0,               
                cantidad_c = 0,
                cantidad_p=0,

            };

            return Buy;
        }


    }


}