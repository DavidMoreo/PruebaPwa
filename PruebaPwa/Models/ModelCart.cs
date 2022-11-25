using PruebaPwa.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static PruebaPwa.Controllers.HomeController;

namespace PruebaPwa.Models
{
    public class ModelCart
    {
        private static User user { get; set; }
        public static User GetUser { get { return user; }  }
        public static void setUser(User _user)
        {
            user = _user;
        }
        public List<tblCar> ListProduct { get; set; }
        public  User UserView { get { return user !=null ? user: user = new User() { address="",identification=""}; } }

        public ModelCart()
        {
            List<tblProduct> LisProduct = new List<tblProduct>();
            Sql_Conection SQL;
            TypeSqlCommand _Type = new TypeSqlCommand();
            SQL = ConectionSql.getConection();            
            User user = ModelCart.GetUser;           
            ListProduct = SQL.SqlQuery(new tblCar(), _Type.ReadC);
            LisProduct = SQL.SqlQuery(new tblProduct(), _Type.ReadP);
            foreach (var item in ListProduct)
            {
                item.name = LisProduct.Where(s => s.Id == item.Id_product).Select(n=>n.name).FirstOrDefault();
               
            }
        }

    }

    public class User
    {
        public string address { get; set; }
        public string identification { get; set; }
    }
}