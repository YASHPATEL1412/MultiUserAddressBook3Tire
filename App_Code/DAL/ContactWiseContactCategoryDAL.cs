using MultiUserAddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for ContactWiseContactCategoryDAL
/// </summary>

namespace MultiUserAddressBook.DAL
{
    public class ContactWiseContactCategoryDAL : DatabaseConfig
    {
        #region Local Variables

        #region Message
        protected string _Message;
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        #endregion Message

        #endregion Local Variables

        #region Constructor
        public ContactWiseContactCategoryDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert ContactWiseContactCategory
        public Boolean Insert(List<ContactWiseContactCategoryENT> contactWiseContactCategories)
        {
            #region Set Connection 
            SqlConnection objConn = new SqlConnection(ConnectionString);
            #endregion Set Connection
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                foreach (var liContactCategoryID in contactWiseContactCategories)
                {
                    SqlCommand objCmdConactCategory = objConn.CreateCommand();
                    objCmdConactCategory.CommandType = CommandType.StoredProcedure;
                    objCmdConactCategory.CommandText = "[PR_ContactWiseContactCategory_Insert]";

                    objCmdConactCategory.Parameters.AddWithValue("@UserID", liContactCategoryID.UserID);
                    objCmdConactCategory.Parameters.AddWithValue("@ContactID", liContactCategoryID.ContactID);
                    objCmdConactCategory.Parameters.AddWithValue("@ContactCategoryID", liContactCategoryID.ContactCategoryID);
                    objCmdConactCategory.ExecuteNonQuery();
                }
                //lblMessage.Text = "Contact Added Successfully";

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
                return true;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return false;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
        #endregion Insert ContactWiseContactCategory

        #region Delete ContactWiseContactCategory
        public Boolean DeleteContactCategory(SqlInt32 ContactID, SqlInt32 UserID)
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(ConnectionString);
            #endregion Set Connection
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_ContactWiseContactCategory_DeleteByContactID";
                objCmd.Parameters.AddWithValue("@ContactId", ContactID);
                if (!UserID.IsNull)
                    objCmd.Parameters.AddWithValue("@UserID", UserID);

                objCmd.ExecuteNonQuery();

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
                return true;
            }
            catch (Exception ex)
            {
                Message = ex.Message + ex;
                return false;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
        #endregion Delete ContactWiseContactCategory

        #region FillContactCategory CheckBoxsList
        public List<ContactWiseContactCategoryENT> SelectOrNot(SqlInt32 ContactID, SqlInt32 UserID)
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(ConnectionString);
            #endregion Set Connection
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "[PR_ContactCategory_SelectOrNot]";
                if (!UserID.IsNull)
                    objCmd.Parameters.AddWithValue("@UserID", UserID);
                objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                SqlDataReader objSDR = objCmd.ExecuteReader();

                List<ContactWiseContactCategoryENT> contactWiseContactCategories = new List<ContactWiseContactCategoryENT>();

                if (objSDR.HasRows)
                {
                    while (objSDR.Read())
                    {
                        ContactWiseContactCategoryENT entContactWiseContactCategory = new ContactWiseContactCategoryENT();

                        if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                        {
                            entContactWiseContactCategory.ContactCategoryID = Convert.ToInt32(objSDR["ContactCategoryID"].ToString());
                        }
                        /*if (!objSDR["ContactCategoryName"].Equals(DBNull.Value))
                        {
                            entContactWiseContactCategory.ContactCategory.ContactCategoryName = objSDR["ContactCategoryName"].ToString();
                        }*/
                        if (!objSDR["SelectOrNot"].Equals(DBNull.Value))
                        {
                            entContactWiseContactCategory.SelectOrNot = objSDR["SelectOrNot"].ToString();
                        }
                        if (!objSDR["ContactWiseContactCategoryID"].Equals(DBNull.Value))
                        {
                            entContactWiseContactCategory.ContactWiseContactCategoryID = Convert.ToInt32(objSDR["ContactWiseContactCategoryID"].ToString());
                        }

                        contactWiseContactCategories.Add(entContactWiseContactCategory);

                        /*if (objSDR["SelectOrNot"].ToString() == "Selected")
                        {
                            cblContactCategoryID.Items.FindByValue(objSDR["ContactCategoryID"].ToString()).Selected = true;
                        }*/
                    }
                }
                return contactWiseContactCategories;

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return null;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
        #endregion FillContactCategory CheckBoxsList
    }
}