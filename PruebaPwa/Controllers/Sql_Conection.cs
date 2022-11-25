using PruebaPwa.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PruebaPwa.Controllers
{
    public class Sql_Conection
    {
        private string ConectionString = "";
        private string Saource { get; set; }
        private string Catalog { get; set; }
        private string User { get; set; }
        private string Pasword { get; set; }
        public static int  status = 0;
        TypeSqlCommand _TypeSqlCommand = new TypeSqlCommand();

        public Sql_Conection(string Saource, string Catalog, string User, string Pasword)
        {
            this.Saource = Saource;
            this.Catalog = Catalog;
            this.User = User;
            this.Pasword = Pasword;
        }
        private SqlConnection GetConectionSql()
        {
            ConectionString = $"Data Source={Saource};Initial Catalog={Catalog};User={User};Password={Pasword}";
            SqlConnection sqlConnection = null;

            sqlConnection = new SqlConnection(ConectionString);

            return sqlConnection;
        }


        public List<tblProduct> SqlQuery(tblProduct _Product, string _Type)
        {
            List<tblProduct> _ProductList = new List<tblProduct>();
            SqlQuery _SqlQuery = new SqlQuery();
            _SqlQuery = converProductToQuery(_Product);
            TypeSqlCommand validate_Type = new TypeSqlCommand();
            using (SqlConnection Sql = GetConectionSql())
            {
                SqlCommand _SqlCommand = GetSqlCommand(_SqlQuery, Sql);
                _SqlCommand.Parameters.AddWithValue("@Mode", _Type);

                Sql.Open();
                if (_Type == validate_Type.ReadP)
                {
                    SqlDataReader ReadData = _SqlCommand.ExecuteReader();
                    while (ReadData.Read())
                    {
                        _ProductList.Add(new tblProduct()
                        {
                            Id = ReadData.GetInt32(0),
                            name = ReadData.GetString(1),
                            cantidad_p = ReadData.GetInt32(2),
                            value = ReadData.GetDecimal(3),
                            img = ReadData.GetString(4)


                        });
                        status = 1;
                    }
                }

                if (_Type == validate_Type.SaveP)
                {
                    status = _SqlCommand.ExecuteNonQuery();

                }
                Sql.Close();

                try
                { }
                catch
                {

                }

            }




            return _ProductList;
        }

        public List<tblCar> SqlQuery(tblCar _Car, string _Type)
        {
            List<tblCar> _ProductList = new List<tblCar>();
            SqlQuery _SqlQuery = new SqlQuery();
            _SqlQuery = converCartToQuery(_Car);
            TypeSqlCommand validate_Type = new TypeSqlCommand();
            using (SqlConnection Sql = GetConectionSql())
            {
                SqlCommand _SqlCommand = GetSqlCommand(_SqlQuery, Sql);
                _SqlCommand.Parameters.AddWithValue("@Mode", _Type);

                Sql.Open();
                if (_Type == validate_Type.ReadC)
                {
                    SqlDataReader ReadData = _SqlCommand.ExecuteReader();
                    while (ReadData.Read())
                    {
                        _ProductList.Add(new tblCar()
                        {
                            Id = ReadData.GetInt32(0),
                            Id_product = ReadData.GetInt32(1),
                            cantidad_c = ReadData.GetInt32(2),
                            //cantidad_p = ReadData.GetInt32(3),
                            //name = ReadData.GetString(3),
                            value_c = ReadData.GetDecimal(3)


                        });
                        status = 1;
                    }
                }

                if (_Type != validate_Type.ReadC)
                {
                    status = _SqlCommand.ExecuteNonQuery();

                }
                Sql.Close();

                try
                { }
                catch
                {

                }

            }

            return _ProductList;
        }

        public bool SqlQuery(tblBuy _Buy, string _Type)
        {
            List<tblBuy> _ProductList = new List<tblBuy>();
            SqlQuery _SqlQuery = new SqlQuery();
            _SqlQuery = converBuyToQuery(_Buy);
            TypeSqlCommand validate_Type = new TypeSqlCommand();
            using (SqlConnection Sql = GetConectionSql())
            {
                SqlCommand _SqlCommand = GetSqlCommand(_SqlQuery, Sql);
                _SqlCommand.Parameters.AddWithValue("@Mode", _Type);

                Sql.Open();
                if (_Type == validate_Type.ReadB)
                {
                    SqlDataReader ReadData = _SqlCommand.ExecuteReader();
                    while (ReadData.Read())
                    {
                        _ProductList.Add(new tblBuy()
                        {
                            Id = ReadData.GetInt32(0),
                            Id_product = ReadData.GetInt32(1),
                            cantidad_b = ReadData.GetInt32(2),                          
                            name = ReadData.GetString(3),
                            value = ReadData.GetInt32(5)


                        });
                    }
                }

                if (_Type != validate_Type.ReadB )
                {
                    status = _SqlCommand.ExecuteNonQuery();

                }
                Sql.Close();

                try
                { }
                catch
                {

                }

            }




            return false;
        }

        private SqlCommand GetSqlCommand(SqlQuery query, SqlConnection Sql)
        {
            SqlCommand _SqlCommand = new SqlCommand("Sp_pwa", Sql);

            _SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            _SqlCommand.Parameters.AddWithValue("@Id_product", query.Id_product);
            _SqlCommand.Parameters.AddWithValue("@name", query.name);
            _SqlCommand.Parameters.AddWithValue("@cantidad", query.cantidad);
            _SqlCommand.Parameters.AddWithValue("@value", query.value);
            _SqlCommand.Parameters.AddWithValue("@value_c", query.value_c);
            _SqlCommand.Parameters.AddWithValue("@img", query.img);         

            return _SqlCommand;
        }
        private SqlQuery converProductToQuery(tblProduct _Product)
        {

            var _SqlQuery = new SqlQuery()
            {
                Id_product = _Product.Id,
                name = _Product.name!=null?  _Product.name:"",
                cantidad = _Product.cantidad_p,
                value = _Product.value,
                img = _Product.img !=null ? _Product.img:""
            };
            return _SqlQuery;
        }
        private SqlQuery converCartToQuery(tblCar _tblCar)
        {

            var _SqlQuery = new SqlQuery()
            {
                Id_product = _tblCar.Id_product,
                name = "",
                cantidad = _tblCar.cantidad_c,
                value_c = _tblCar.value_c,
                img = "",
            };
            return _SqlQuery;
        }
        private SqlQuery converBuyToQuery(tblBuy _tblBuy)
        {

            var _SqlQuery = new SqlQuery()
            {
                Id_product = _tblBuy.Id_product,
                name = "",
                cantidad = _tblBuy.cantidad_b,
                value = 0,
                img = "",
            };
            return _SqlQuery;
        }

    }

    public class TypeSqlCommand
    {
        public string SaveP { get; }
        public string SaveC { get; }
        public string SaveB { get; }
        public string ReadP { get; }
        public string ReadC { get; }
        public string ReadB { get; }
        public string DeleteC { get; }
        public string UpdC { get; }
        public TypeSqlCommand()
        {
            SaveP = "SaveP";
            SaveC = "SaveC";
            SaveB = "SaveB";
            ReadP = "ReadP";
            ReadC = "ReadC";
            ReadB = "ReadB";
            DeleteC = "DeleteC";
            UpdC = "UpdC";
        }

    }
}