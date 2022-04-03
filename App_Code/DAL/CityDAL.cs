using MultiUserAddressBook.ENT;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.Routing;

/// <summary>
/// Summary description for CityDAL
/// </summary>

namespace MultiUserAddressBook.DAL
{
    public class CityDAL : DatabaseConfig
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
        public CityDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(CityENT entCity, SqlInt32 userID)
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
                objCmd.CommandText = "[dbo].[PR_City_Insert]";

                objCmd.Parameters.AddWithValue("@StateID", entCity.StateID);
                objCmd.Parameters.AddWithValue("@CityName", entCity.CityName);
                objCmd.Parameters.AddWithValue("@STDCode", entCity.STDCode);
                objCmd.Parameters.AddWithValue("@PinCode", entCity.PinCode);
                if (!userID.IsNull)
                    objCmd.Parameters.AddWithValue("@UserID", userID);
                #endregion Set Connection & Command Object


                objCmd.ExecuteNonQuery();

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
        public Boolean Update(CityENT entCity, SqlInt32 userID)
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

                objCmd.Parameters.AddWithValue("@StateID", entCity.StateID);
                objCmd.Parameters.AddWithValue("@CityName", entCity.CityName);
                objCmd.Parameters.AddWithValue("@STDCode", entCity.STDCode);
                objCmd.Parameters.AddWithValue("@PinCode", entCity.PinCode);
                if (!userID.IsNull)
                    objCmd.Parameters.AddWithValue("@UserID", userID);
                /*if (!entCity.UserID.IsNull)
                    objCmd.Parameters.AddWithValue("@UserID", entCity.UserID);*/
                #endregion Set Connection & Command Object

                if (!entCity.CityID.IsNull)
                {
                    #region Update Record
                    //Edit Mode
                    //objCmd.Parameters.AddWithValue("CityID", (EncryptDecrypt.Base64Decode(RouteData.Values["CityID"].ToString().Trim())));
                    objCmd.Parameters.AddWithValue("CityID", entCity.CityID);
                    objCmd.CommandText = "[dbo].[PR_City_UpdateByPK]";
                    
                    objCmd.ExecuteNonQuery();
                    //Response.Redirect("~/AdminPanel/City/CityList.aspx", true);
                    #endregion Update Record
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
        public Boolean DeleteCity(SqlInt32 CityID,SqlInt32 userID)
        {
            SqlConnection objConn = new SqlConnection(ConnectionString);
            try
            {
                #region Set Connection & Command Object

                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_City_DeleteByPK";
                objCmd.Parameters.AddWithValue("@CityID", CityID.ToString());

                if (!userID.IsNull)
                    objCmd.Parameters.AddWithValue("@UserID", userID);

                objCmd.ExecuteNonQuery();

                /* lblMessage.ForeColor = Color.Green;
                 lblMessage.Text = "Data Delete Successfully!";*/

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
                return true;

                /*FillGridView();*/
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

        #region SelectAll
        public DataTable SelectAll(SqlInt32 userID)
        {
            SqlConnection objConn = new SqlConnection(ConnectionString);

            try
            {
                #region Set Connection & Command Object

                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                SqlCommand objCmd = new SqlCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_City_SelectAllUserID";

                if (!userID.IsNull)
                    objCmd.Parameters.AddWithValue("@UserID", userID);

                DataTable dt = new DataTable();

                SqlDataReader objSDR = objCmd.ExecuteReader();

                dt.Load(objSDR);

                //gvCity.DataSource = objSDR;
                //gvCity.DataBind();

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
                #endregion Set Connection & Command Object
                return dt;

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
        #endregion SelectAll

        #region SelectByUserID
        public CityENT SelectByUserID(SqlInt32 CityID, SqlInt32 userID)
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
                objCmd.CommandText = "PR_City_SelectByUserID";
                objCmd.Parameters.AddWithValue("@CityID", CityID.ToString().Trim());

                if (!userID.IsNull)
                    objCmd.Parameters.AddWithValue("@UserID", userID);

                #endregion Set Connection & Command Object

                #region Read the value and set the controls
                CityENT entCity = new CityENT();

                SqlDataReader objSDR = objCmd.ExecuteReader();

                if (objSDR.HasRows)
                {
                    while (objSDR.Read())
                    {
                        if (!objSDR["CityName"].Equals(DBNull.Value))
                        {
                            //txtCityName.Text = objSDR["CityName"].ToString().Trim();
                            entCity.CityName = objSDR["CityName"].ToString().Trim();
                        }
                        if (!objSDR["STDCode"].Equals(DBNull.Value))
                        {
                            //txtSTDCode.Text = objSDR["STDCode"].ToString().Trim();
                            entCity.STDCode = objSDR["STDCode"].ToString().Trim();
                        }
                        if (!objSDR["PinCode"].Equals(DBNull.Value))
                        {
                            //txtPinCode.Text = objSDR["PinCode"].ToString().Trim();
                            entCity.PinCode = objSDR["PinCode"].ToString().Trim();
                        }
                        if (!objSDR["StateID"].Equals(DBNull.Value))
                        {
                            //ddlStateID.SelectedValue = objSDR["StateID"].ToString().Trim();
                            entCity.StateID = Convert.ToInt32(objSDR["StateID"].ToString().Trim());
                        }
                        break;
                    }
                }
                else
                {
                    Message = "No Data Available for the CityID = " + CityID.ToString();
                }
                return entCity;
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
        public DataTable SelectForDropDownList(SqlInt32 UserID,SqlInt32 StateID)
        {
            SqlConnection objConn = new SqlConnection(ConnectionString);
            try
            {
                //SqlInt32 strStateID = SqlInt32.Null;

                #region Set Connection & Command Object
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                if (!UserID.IsNull)
                    objCmd.Parameters.AddWithValue("@UserID", UserID);

                DataTable dt = new DataTable();

                if(!StateID.IsNull)
                {
                    objCmd.CommandText = "PR_City_SelectByStateID";
                    objCmd.Parameters.AddWithValue("@StateID", StateID);
                }

                //strStateID = Convert.ToInt32(ddlStateID.SelectedValue);
                SqlDataReader objSDR = objCmd.ExecuteReader();
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
        #endregion SelectForDropDownList

        #endregion Select Operation
    }
}