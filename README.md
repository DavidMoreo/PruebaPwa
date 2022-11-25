**La aplicación cuenta con 3 ventanas **
**Carrito: **
•	Permite ver los productos seleccionado.
•	Solo permite el ingreso si se ingresaron los datos de dirección y cedula.
**Producto:**
•	Es la página primaria en donde se pueden ver y los productos existentes en la tienda.
•	Se puede agregar artículos al carrito de compras.
**Nuevo Productos:**
•	Permite crear un nuevo producto y cargarlo a la tienda.

**Sql Server :**
La backet de la base de datos se encuentra en la primera carpeta en la misma ubicación del .sln para compilación de la solución.

`Ruta: PruebaPwa/SqlServer/`


------------


HomeController**

`public class HomeController : Controller`

Es  el controlador encargado de las vistas existentes.

------------


**ApiController**

`public class ApiController : Controller`

Es el controlador encargado de las solicitudes a la Api.

# API

**Leer productos **
**Metodo Get**

`public string Product()
Url: https://localhost:44340/Api/Product
`

**Nuevo Producto **
**Metodo Post**

`public string Product(tblProduct Product)
Url: https://localhost:44340/Api/Product
`
**Objeto solicitado**

`public class tblProduct
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int cantidad_p { get; set; }
        public decimal value { get; set; }
        public decimal value_c { get; set; }
        public string img { get; set; }
    }
`
**Campos requeridos:**
Name = nombre de producto.
cantidad_p =cantidad del producto nuevo.
Value = valor de producto por unidad.
Img = Url de la imagen del producto.
Los demás campos se envían con parámetro defaul “no null”.


**Agregar a carrito de compras 
Metodo Post**

`public string CartAdd(string id, string count)`

Campos requeridos:
Id = id del producto.
Count = cantidad del producto.

**Leer carrito de compras
Metodo Get
**
`public string Cart()
Url: https://localhost:44340/Api/CartAdd 
`
**
Eliminar producto del carrito 
Metodo Post**
`
public string CartDelete(string id)
`
Campos requeridos:
Id = id del producto.











