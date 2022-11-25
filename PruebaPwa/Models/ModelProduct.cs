using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaPwa.Models
{
    public class ModelProduct
    {
       
        public List<tblProduct> listProduct { get; set; }
        public bool view { get; set; }
        public string User { get; set; }

        public ModelProduct()
        {
            User user = ModelCart.GetUser;
            if (user != null)
            {
                if (user.address == "" || user.identification == "") { view = true; } else { view = false; }
            }
            else { view = true; }

            listProduct = null;
            User = "";
        }

    }
}