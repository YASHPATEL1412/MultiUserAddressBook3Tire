using MultiUserAddressBook.ENT;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for StateDAL
/// </summary>

namespace MultiUserAddressBook.DAL
{
    public class StateDAL : DatabaseConfig
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
        public StateDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(StateENT entState, SqlInt32 UserID)
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
                objCmd.CommandText = "[dbo].[PR_State_Insert]";

                objCmd.Parameters.AddWithValue("@CountryID", entState.CountryID);
                objCmd.Parameters.AddWithValue("@StateName", entState.StateName);
                objCmd.Parameters.AddWithValue("@StateCode", entState.StateCode);

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
        public Boolean Update(StateENT entState, SqlInt32 UserID)
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
                objCmd.CommandText = "[dbo].[PR_State_UpdateByPK]";

                objCmd.Parameters.AddWithValue("@CountryID", entState.CountryID);
                objCmd.Parameters.AddWithValue("@StateName", entState.StateName);
                objCmd.Parameters.AddWithValue("@StateCode", entState.StateCode);
                if (!UserID.IsNull)
                    objCmd.Parameters.AddWithValue("@UserID", UserID);

                if (!entState.StateID.IsNull)
                {
                    objCmd.Parameters.AddWithValue("StateID", entState.StateID);
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
        public Boolean DeleteState(SqlInt32 StateID, SqlInt32 UserID)
        {
            SqlConnection objConn = new SqlConnection(ConnectionString);
            try
            {
                #region Set Connection & Command Object
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_State_DeleteByPK";

                objCmd.Parameters.AddWithValue("@StateID", StateID.ToString());

                if (!UserID.IsNull)
                    objCmd.Parameters.AddWithValue("@UserID", UserID);

                objCmd.ExecuteNonQuery();

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
                return true;
                #endregion
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

                objCmd.CommandText = "PR_State_SelectAllUserID";

                if (!userID.IsNull)
                    objCmd.Parameters.AddWithValue("@UserID", userID);

                DataTable dt = new DataTable();

                SqlDataReader objSDR = objCmd.ExecuteReader();

                dt.Load(objSDR);

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
                return dt;

                #endregion
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

        #region StateSelectByUserID
        public StateENT SelectByUserID(SqlInt32 StateID, SqlInt32 userID)
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
                objCmd.CommandText = "PR_State_SelectByUserID";

                objCmd.Parameters.AddWithValue("@StateID", StateID.ToString().Trim());

                if (!userID.IsNull)
                    objCmd.Parameters.AddWithValue("@UserID", userID);

                #endregion Set Connection & Command Object

                #region Read the value and set the controls
                StateENT entState = new StateENT();

                SqlDataReader objSDR = objCmd.ExecuteReader();

                if (objSDR.HasRows)
                {
                    while (objSDR.Read())
                    {
                        //if(objSDR["StateName"].Equals(DBNull.Value) != true)
                        if (!objSDR["StateName"].Equals(DBNull.Value))
                        {
                            entState.StateName = objSDR["StateName"].ToString().Trim();
                        }
                        if (!objSDR["CountryID"].Equals(DBNull.Value))
                        {
                            //ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                            entState.CountryID = Convert.ToInt32(objSDR["CountryID"].ToString().Trim());
                        }
                        if (!objSDR["StateCode"].Equals(DBNull.Value))
                        {
                            entState.StateCode = objSDR["StateCode"].ToString().Trim();
                        }
                        break;
                    }
                }
                else
                {
                    Message = "No Data Available for the StateID = " + StateID.ToString();
                }
                return entState;
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
        #endregion StateSelectByUserID

        #region SelectForDropDownList
        public DataTable SelectForDropDownList(SqlInt32 userID,SqlInt32 CountryID)
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

                if(!CountryID.IsNull)
                {
                    objCmd.CommandText = "[PR_State_SelectByCountryID]";
                    objCmd.Parameters.AddWithValue("@CountryID", CountryID);
                }
                else
                {
                    objCmd.CommandText = "[dbo].[PR_State_SelectForDropDownList]";
                }

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
        #endregion SelectForDropDownList

        #endregion Select Operation
    }
}