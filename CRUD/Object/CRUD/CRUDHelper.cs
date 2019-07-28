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
            using (SqlConnection conn = new SqlConnection(strConnString))
            {
                conn.Open();
                SqlCommand scom = new SqlCommand("", conn);
                scom.CommandText = @"
                                        select Id, Name, Age
                                        from [dbo].[Member]
                                    ";
                SqlDataReader sread = scom.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sread);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        CRUDModel temp = new CRUDModel();
                        temp.Id = dt.Rows[i]["Id"].ToString();
                        temp.Name = dt.Rows[i]["Name"].ToString();
                        temp.Age = int.Parse(dt.Rows[i]["Age"].ToString());
                        List.Add(temp);
                    }
                }
            }
            return List;
        }

        public static void Update(string Name, int ChangeAge)
        {
            List<CRUDModel> List = new List<CRUDModel>();
            using (SqlConnection conn = new SqlConnection(strConnString))
            {
                conn.Open();
                SqlCommand scom = new SqlCommand("", conn);
                scom.CommandText = @"
                                        UPDATE [dbo].[Member]
                                        SET Age = @ChangeAge
                                        WHERE Name = @Name 
                                    ";
                scom.Parameters.Add("@Name", SqlDbType.NVarChar, 20);
                scom.Parameters["@Name"].Value = Name;
                scom.Parameters.Add("@ChangeAge", SqlDbType.Int, 4);
                scom.Parameters["@ChangeAge"].Value = ChangeAge;
                SqlDataReader sread = scom.ExecuteReader();
            }
        }

        public static void Delete(string Name)
        {
            List<CRUDModel> List = new List<CRUDModel>();
            using (SqlConnection conn = new SqlConnection(strConnString))
            {
                conn.Open();
                SqlCommand scom = new SqlCommand("", conn);
                scom.CommandText = @"
                                        DELETE FROM [dbo].[Member]
                                        WHERE Name = @Name 
                                    ";
                scom.Parameters.Add("@Name", SqlDbType.NVarChar, 20);
                scom.Parameters["@Name"].Value = Name;
                SqlDataReader sread = scom.ExecuteReader();
            }
        }
    }
}