using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaPwa.Models
{
    public class ModelLoading
    {

      

       public static List<tblProduct>  getLisProduct()
        {
            List<tblProduct> ListProduct = new List<tblProduct>();
            return getLoadingProduct(ListProduct);
        }

        private static List<tblProduct> getLoadingProduct(List<tblProduct> ListProduct)
        {
            ListProduct.Add(new tblProduct() { 
            name = "Aceite Vegetal 1000 ml",
            value = 14000,
            cantidad_p = 12,
            Id = 0,
            img = "https://png.pngtree.com/element_our/20200609/ourlarge/pngtree-cereal-oil-soybean-oil-image_2231474.jpg",
            
            });

            ListProduct.Add(new tblProduct()
            {
                name = "Azúcar lb",
                value = 3000,
                cantidad_p = 12,
                Id = 0,
                img = "https://www.elnuevoherald.com/ultimas-noticias/d80nrb/picture27109312/alternates/LANDSCAPE_1140/azucar.jpg-580x400.jpg",

            });

            ListProduct.Add(new tblProduct()
            {
                name = "Chocolate lb",
                value = 5000,
                cantidad_p = 2,
                Id = 0,
                img = "https://thumbs.dreamstime.com/b/chocolate-54067353.jpg",

            });

            ListProduct.Add(new tblProduct()
            {
                name = "Sandía lb",
                value = 15000,
                cantidad_p = 22,
                Id = 0,
                img = "https://thumbs.dreamstime.com/b/chocolate-54067353.jpg",

            });

            ListProduct.Add(new tblProduct()
            {
                name = "Sandía lb",
                value = 15000,
                cantidad_p = 22,
                Id = 0,
                img = "https://frutasolivar.com/wp-content/webp-express/webp-images/doc-root/wp-content/uploads/2020/07/31606320_s-1.jpg.webp",

            });

            ListProduct.Add(new tblProduct()
            {
                name = "Yuca lb",
                value = 5000,
                cantidad_p = 22,
                Id = 0,
                img = "https://image.shutterstock.com/image-photo/cassava-isolated-on-white-background-260nw-379049854.jpg",

            });

            ListProduct.Add(new tblProduct()
            {
                name = "Yuca lb",
                value = 5000,
                cantidad_p = 22,
                Id = 0,
                img = "https://5aldia.cl/wp-content/uploads/2018/03/zanahoria.jpg",

            });

            return ListProduct;
        }



    }






}