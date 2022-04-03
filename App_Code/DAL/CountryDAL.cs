using MultiUserAddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CountryDAL
/// </summary>

namespace MultiUserAddressBook.DAL
{
    public class CountryDAL : DatabaseConfig
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
        public CountryDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(CountryENT entCountry,SqlInt32 UserID)
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
                objCmd.CommandText = "[dbo].[PR_Country_Insert]";
                objCmd.Parameters.AddWithValue("@CountryName", entCountry.CountryName);
                objCmd.Parameters.AddWithValue("@CountryCode", entCountry.CountryCode);

                if (!UserID.IsNull)
                    objCmd.Parameters.AddWithValue("@UserID",UserID);

                objCmd.ExecuteNonQuery();
                #endregion Set Connection & Command Object

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
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(CountryENT entCountry,SqlInt32 UserID)
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

                objCmd.Parameters.AddWithValue("@CountryName", entCountry.CountryName);
                objCmd.Parameters.AddWithValue("@CountryCode", entCountry.CountryCode);
                if (!UserID.IsNull)
                    objCmd.Parameters.AddWithValue("@UserID", UserID);                
                #endregion Set Connection & Command Object

                if (!entCountry.CountryID.IsNull)
                {
                    objCmd.Parameters.AddWithValue("CountryID", entCountry.CountryID);
                    objCmd.CommandText = "[dbo].[PR_Country_UpdateByPK]";

                    objCmd.ExecuteNonQuery();
                }
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
        #endregion Update Operation

        #region Delete Operation
        public Boolean DeleteCountry(SqlInt32 CountryID, SqlInt32 UserID)
        {
            SqlConnection objConn = new SqlConnection(ConnectionString);
            try
            {
                #region Set Connection & Command Object

                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Country_DeleteByPK";

                objCmd.Parameters.AddWithValue("CountryID", CountryID.ToString());
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

                objCmd.CommandText = "PR_Country_SelectAllUserID";

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
        public CountryENT SelectByUserID(SqlInt32 CountryID,SqlInt32 UserID)
        {
            SqlConnection objConn = new SqlConnection(ConnectionString);
            try
            {
                #region Set Connection & Command Object
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Country_SelectByUserID";

                objCmd.Parameters.AddWithValue("@CountryID", CountryID.ToString().Trim());

                if (!UserID.IsNull)
                    objCmd.Parameters.AddWithValue("@UserID", UserID);

                #endregion Set Connection & Command Object

                #region Read the value and set the controls
                SqlDataReader objSDR = objCmd.ExecuteReader();

                CountryENT entCountry = new CountryENT();

                if (objSDR.HasRows)
                {
                    while (objSDR.Read())
                    {
                        if (!objSDR["CountryName"].Equals(DBNull.Value))
                        {
                            entCountry.CountryName = objSDR["CountryName"].ToString().Trim();
                        }
                        if (!objSDR["CountryCode"].Equals(DBNull.Value))
                        {
                            entCountry.CountryCode = objSDR["CountryCode"].ToString().Trim();
                        }
                        break;
                    }
                }
                else
                {
                    Message = "No Data Available for the CountryID = " + CountryID.ToString();
                }
                return entCountry;
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

        #region SelectForDropDownList
        public DataTable SelectForDropDownList(SqlInt32 userID)
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
                if (!userID.IsNull)
                    objCmd.Parameters.AddWithValue("@UserID", userID);
                //objCmd.Parameters.AddWithValue("@CountryID", CountryID);

                objCmd.CommandText = "[dbo].[PR_Country_SelectForDropDownList]";


                DataTable dt = new DataTable();

                SqlDataReader objSDR = objCmd.ExecuteReader();

                dt.Load(objSDR);
                return dt;
                #endregion Set Connection & Command Object

                /*if (objSDR.HasRows == true)
                {
                    *//*ddlCountryID*//*
                    ddlCountry.DataSource = objSDR;
                    ddlCountry.DataValueField = "CountryID";
                    ddlCountry.DataTextField = "CountryName";
                    ddlCountry.DataBind();
                }

                ddlCountry.Items.Insert(0, new ListItem("Select Country", "-1"));*/

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
        #endregion SelectForDropDownList

        #endregion Select Operation
    }
}