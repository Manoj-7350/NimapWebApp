using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.CodeAnalysis;
using NimapWebApp.Models;
using System.Data;
using System.Data.SqlClient;

namespace NimapWebApp.Repository
{
    public class NimapRepo
    {

        private SqlConnection con;
        public string constr = null;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = "Server = LAPTOP-J988CH9N\\SQLEXPRESS; Database = NimapDB; Integrated Security = SSPI";
            con = new SqlConnection(constr);

        }
        //To Add Employee details    
        public bool AddProduct(clsProduct objProduct)
        {

            connection();
            SqlCommand com = new SqlCommand("sp_AddNewProdDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProductName ", objProduct.ProductName);
            com.Parameters.AddWithValue("@ProductType", objProduct.ProductType);
            com.Parameters.AddWithValue("@ProductColor", objProduct.ProductColor);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }
        //To view employee details with generic list
        public List<clsProduct> GetAllProduct(int val1,int val2)
        {
            connection();
            List<clsProduct> EmpList = new List<clsProduct>();
     

           SqlCommand com = new SqlCommand("Sp_pagination", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@offseVal ", val1);
            com.Parameters.AddWithValue("@rowlim", val2);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                EmpList.Add(

                    new clsProduct
                    {

                        Productid = Convert.ToInt32(dr["ProdId"]),
                        ProductName = Convert.ToString(dr["ProdName"]),
                        ProductType = Convert.ToString(dr["ProdType"]),
                        ProductColor = Convert.ToString(dr["ProdColor"])


                    }
                    );
            }

            return EmpList;
        }
        //To Update Employee details    


        public List<clsProduct> GetAllProduct()
        {
            connection();
            List<clsProduct> EmpList = new List<clsProduct>();


            SqlCommand com = new SqlCommand("sp_getProdDetails", con);
            com.CommandType = CommandType.StoredProcedure;
           
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                EmpList.Add(

                    new clsProduct
                    {

                        Productid = Convert.ToInt32(dr["ProdId"]),
                        ProductName = Convert.ToString(dr["ProdName"]),
                        ProductType = Convert.ToString(dr["ProdType"]),
                        ProductColor = Convert.ToString(dr["ProdColor"])


                    }
                    );
            }

            return EmpList;
        }
        public bool UpdateProduct(clsProduct objProduct)
        {

            connection();
            SqlCommand com = new SqlCommand("sp_UpdateProdDetails", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@productid", objProduct.Productid);
            com.Parameters.AddWithValue("@ProductName ", objProduct.ProductName);
            com.Parameters.AddWithValue("@ProductType", objProduct.ProductType);
            com.Parameters.AddWithValue("@ProductColor", objProduct.ProductColor);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        //To delete Employee details    
        public bool DeleteProduct(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("sp_DeleteProdDetails", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@productid", Id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {

                return false;
            }
        }



        public clsProduct DetailsOfProduct(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("sp_SelectProdDetails", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@productid", Id);

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            //con.Close();

            ///  con.Open();
            // int i = com.ExecuteNonQuery();
            con.Close();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                // lbl_name = row["name"].ToString();
                clsProduct objClsProduct = new clsProduct();
                objClsProduct.Productid = Convert.ToInt32(row["ProdId"]);
                objClsProduct.ProductName = row["ProdName"].ToString();// Convert.ToString("ProdName");
                objClsProduct.ProductType = row["ProdType"].ToString(); //Convert.ToString("ProdType");
                objClsProduct.ProductColor = row["ProdColor"].ToString(); //Convert.ToString("ProdColor");
                return objClsProduct;
            }
            else
            {

                return null;
            }
        }
    }
}
