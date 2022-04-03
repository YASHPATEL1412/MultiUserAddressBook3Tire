using MultiUserAddressBook.ENT;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for ContactCategoryDAL
/// </summary>

namespace MultiUserAddressBook.DAL
{
    public class ContactCategoryDAL : DatabaseConfig
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
        public ContactCategoryDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(ContactCategoryENT entContactCategory,SqlInt32 UserID)
        {
            #region Local Variables
            SqlConnection objConn = new SqlConnection(ConnectionString);
            #endregion Local Variables
            try
            {
                #region Set Connection & Command Object
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "[dbo].[PR_ContactCategory_Insert]";
                objCmd.Parameters.AddWithValue("@ContactCategoryName", entContactCategory.ContactCategoryName);

                if (!UserID.IsNull)
                    objCmd.Parameters.AddWithValue("@UserID", UserID);

                objCmd.ExecuteNonQuery();
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
                return true;
                #endregion Set Connection & Command Object
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
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(ContactCategoryENT entContactCategory, SqlInt32 UserID)
        {
            #region Local Variables
            SqlConnection objConn = new SqlConnection(ConnectionString);
            #endregion Local Variables
            try
            {
                #region Set Connection & Command Object
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@ContactCategoryName", entContactCategory.ContactCategoryName);
                if (!UserID.IsNull)
                    objCmd.Parameters.AddWithValue("@UserID", UserID);

                if (!entContactCategory.ContactCategoryID.IsNull)
                {
                    objCmd.Parameters.AddWithValue("@ContactCategoryID", entContactCategory.ContactCategoryID);
                    objCmd.CommandText = "[dbo].[PR_ContactCategory_UpdateByPK]";
                    objCmd.ExecuteNonQuery();
                }
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
                return true;
                #endregion Set Connection & Command Object
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
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 ContactCategoryID, SqlInt32 UserID)
        {
            SqlConnection objConn = new SqlConnection(ConnectionString);
            try
            {
                #region Set Connection & Command Object

                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_ContactCategory_DeleteByPK";

                objCmd.Parameters.AddWithValue("ContactCategoryID", ContactCategoryID.ToString());

                if (!UserID.IsNull)
                    objCmd.Parameters.AddWithValue("@UserID", UserID);

                objCmd.ExecuteNonQuery();

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
                return true;
                #endregion Set Connection & Command Object

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
        #endregion Delete Operation

        #region Select Operation

        #region SelectALl
        public DataTable SelectAll(SqlInt32 UserID)
        {
            #region Local Variables
            SqlConnection objConn = new SqlConnection(ConnectionString);
            #endregion Local Variables

            try
            {
                #region Set Connection & Command Object

                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                SqlCommand objCmd = new SqlCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_ContactCategory_SelectAllUserID";

                if (!UserID.IsNull)
                    objCmd.Parameters.AddWithValue("@UserID", UserID);

                SqlDataReader objSDR = objCmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(objSDR);

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
                return dt;
                #endregion Set Connection & Command Object

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
        #endregion SelectALl

        #region SelectByUserID
        public ContactCategoryENT SelectByUserID(SqlInt32 ContactCategoryID,SqlInt32 UserID)
        {
            SqlConnection objConn = new SqlConnection(ConnectionString);
            try
            {
                #region Set Connection & Command Object
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_ContactCategory_SelectByUserID";

                objCmd.Parameters.AddWithValue("ContactCategoryID", ContactCategoryID.ToString().Trim());

                if (!UserID.IsNull)
                    objCmd.Parameters.AddWithValue("@UserID", UserID);

                #endregion Set Connection & Command Object

                #region Read the value and set the controls
                SqlDataReader objSDR = objCmd.ExecuteReader();

                ContactCategoryENT entContactCategory = new ContactCategoryENT();

                if (objSDR.HasRows)
                {
                    while (objSDR.Read())
                    {
                        if (!objSDR["ContactCategoryName"].Equals(DBNull.Value))
                        {
                            entContactCategory.ContactCategoryName = objSDR["ContactCategoryName"].ToString().Trim();
                        }
                        break;
                    }
                }
                else
                {
                    Message = "No Data Available";
                }
                return entContactCategory;
                #endregion Read the value and set the controls
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
        #endregion SelectByUserID

        #region ContactCategory For CheckBoxList
        public DataTable SelectForDropDownList(SqlInt32 UserID)
        {
            SqlConnection objConn = new SqlConnection(ConnectionString);
            try
            {
                #region Set Connection & Command Object
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "[PR_ContactCategory_SelectForDropDownList]";

                if (!UserID.IsNull)
                    objCmd.Parameters.AddWithValue("@UserID", UserID);

                SqlDataReader objSDR = objCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(objSDR);

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
                return dt;
                #endregion Set Connection & Command Object
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return null ;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
        #endregion ContactCategory For CheckBoxList

        #endregion Select Operation
    }
}