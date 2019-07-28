using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUD.Object.CRUD
{
    public class CRUDHelper
    {
        static string strConnString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;

        public static void Create(string Name, int Age)
        {
            using (SqlConnection conn = new SqlConnection(strConnString))
            {
                conn.Open();
                //String SQLString = "select Id, Name, Age  from[dbo].[Member] where Id = @Id";
                SqlCommand scom = new SqlCommand("", conn);
                scom.CommandText = @"
                                        INSERT INTO [dbo].[Member](Id, Name, Age)
                                        VALUES(@Id, @Name, @Age)
                                    ";
                scom.Parameters.Add("@Id", SqlDbType.NVarChar, 32);
                scom.Parameters["@Id"].Value = Guid.NewGuid().ToString();
                scom.Parameters.Add("@Name", SqlDbType.NVarChar, 20);
                scom.Parameters["@Name"].Value = Name;
                scom.Parameters.Add("@Age", SqlDbType.Int, 4);
                scom.Parameters["@Age"].Value = Age;
                SqlDataReader sread = scom.ExecuteReader();
            }
        }

        public static List<CRUDModel> Retrieve()
        {
            List<CRUDModel> List = new List<CRUDModel>();
            return List;
        }

        public CRUDModel U()
        {
            CRUDModel CRUD = new CRUDModel();
            return CRUD;
        }

        public CRUDModel D()
        {
            CRUDModel CRUD = new CRUDModel();
            return CRUD;
        }
    }
}