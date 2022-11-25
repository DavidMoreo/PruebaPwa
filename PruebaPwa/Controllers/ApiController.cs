using PruebaPwa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace PruebaPwa.Controllers
{
    public class ApiController : Controller
    {
        Sql_Conection SQL;
        [HttpGet]
        public string Product()
        {
            List<tblProduct> LisProduct = new List<tblProduct>();
            TypeSqlCommand _Type = new TypeSqlCommand();
            SQL = ConectionSql.getConection();
            ModelProduct _ModelProduct = new ModelProduct();
            tblProduct Product = ModelEmpy.getEmpytblProduct();
            LisProduct = SQL.SqlQuery(Product, _Type.ReadP);
            _ModelProduct.listProduct = LisProduct;
            return JsonConvert.SerializeObject(LisProduct);
           
        }
        [HttpPost]
        public string Product(tblProduct Product)
        {
            Sql_Conection.status = 0;
            List<tblProduct> LisProduct = new List<tblProduct>();
            TypeSqlCommand _Type = new TypeSqlCommand();
            SQL = ConectionSql.getConection();
            ModelProduct _ModelProduct = new ModelProduct();
            if (Product.name != null && Product.img != null)
            {
                SQL.SqlQuery(Product, _Type.SaveP);
            }

            return Sql_Conection.status == 1 ? "Realizado" : "No realizado";
        }
        public string Cart()
        {                     
            ModelCart Modelcart = new ModelCart();
            return JsonConvert.SerializeObject(Modelcart.ListProduct);
            
        }
        [HttpPost]
        public string CartAdd(string id, string count)
        {
            Sql_Conection.status = 0;
            string status = "ok";
            tblProduct product = new tblProduct();
            TypeSqlCommand _Type = new TypeSqlCommand();
            SQL = ConectionSql.getConection();
            User user = ModelCart.GetUser;
            List<tblCar> ListCart = SQL.SqlQuery(new tblCar(), _Type.ReadC);
            List<tblProduct> ListProduct = SQL.SqlQuery(product, _Type.ReadP);
            var countProduct = ListProduct.Where(p => p.Id == Convert.ToInt32(id.Trim())).FirstOrDefault() != null ? ListProduct.Where(p => p.Id == Convert.ToInt32(id)).FirstOrDefault():new tblProduct();
           
            if (user.address == "" || user.identification == "" || user==null) { status = "Msg para continuar complete la siguiente información"; }
            else
            {
                if ((ListCart.Where(s=>s.Id_product== Convert.ToInt32(id.Trim())).Sum(c=>c.cantidad_c) + Convert.ToInt32(count)) <= countProduct.cantidad_p)
                {
                   tblCar cart = ListCart.Where(s => s.Id_product == Convert.ToInt32(id.Trim())).FirstOrDefault();
                    if (cart == null)
                    {                 
                     cart = new tblCar()
                    {
                        name = countProduct.name,
                        cantidad_c = Convert.ToInt32(count),                      
                        value_c = (countProduct.value * Convert.ToInt32(count)),
                        Id_product = Convert.ToInt32(id)

                    };
                        SQL.SqlQuery(cart, _Type.SaveC);
                    }
                    else
                    {
                       
                      
                        cart.cantidad_c = cart.cantidad_c + Convert.ToInt32(count);
                        cart.value_c = cart.value_c + (countProduct.value * Convert.ToInt32(count));
                        SQL.SqlQuery(cart, _Type.UpdC);

                    }
                   
                    status = Sql_Conection.status >= 1 ? " Realizado" : " No se guardo el producto ";
                    
                }
                else
                {
                    status = "Cantidad no disponible";
                }
            }
            return status;
        }
        [HttpPost]
        public string CartDelete(string id)
        {
            Sql_Conection.status = 0;
            string status = "ok";         
            TypeSqlCommand _Type = new TypeSqlCommand();
            SQL = ConectionSql.getConection();          
            List<tblCar> ListCart = SQL.SqlQuery(new tblCar(), _Type.ReadC);            
               
            tblCar cart = ListCart.Where(s => s.Id == Convert.ToInt32(id.Trim())).FirstOrDefault();
            if (cart!=null)
            {
                cart.Id_product = Convert.ToInt32(id.Trim());
                SQL.SqlQuery(cart, _Type.DeleteC);
                status = Sql_Conection.status >= 1 ? " Eliminado" : " No se guardo el producto ";
                Sql_Conection.status = 0;
            }
            else
            {
                status = "Msg articulo no existe";
            }
               
            
            return status;
        }       
        [HttpPost]
        public string NewProduct(tblProduct product)
        {
            string Status = "";
            TypeSqlCommand _Type = new TypeSqlCommand();
            SQL = ConectionSql.getConection();
            ModelProduct _ModelProduct = new ModelProduct();
            if (product != null)
            {
                if (product.name == null || product.name == "") Status = "Msg Nombre requerido";
                if (product.value <= 0) Status = "Msg valor de la unbidad debe ser mayor a '0'";
                if (product.img == null || product.img == "") Status = "Msg url de imagen requerida";
                if (product.cantidad_p <= 0) Status = "Msg Cantidad requerida";
                if (Status == "")
                {
                    SQL.SqlQuery(product, _Type.SaveP);
                    Status = Sql_Conection.status == 1 ? "Se guardo el producto" : "Msg no se guardo el producto";
                    Sql_Conection.status = 0;
                }
            }
            else
            {
                Status = "Msg Campos requeridos";
            }
            return Status;
        }       
        public class ConectionSql
        {
            public static Sql_Conection getConection()
            {
                Config Config = new Config();
                return new Sql_Conection(Config.Source, "DB_1", Config.Usuario, Config.Clave);
            }
        }

    }
}