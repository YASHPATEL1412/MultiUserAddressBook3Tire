using MultiUserAddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserDAL
/// </summary>

namespace MultiUserAddressBook.DAL
{
    public class UserDAL : DatabaseConfig
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
        public UserDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Validate User
        public UserENT ValidateUser(SqlString UserName,SqlString Password)
        {
            #region Local Variable
            SqlConnection objConn = new SqlConnection(ConnectionString);
            #endregion Local Variable

            try
            {
                #region Set Connection & Command Object
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_User_SelectByNamePassword";

                objCmd.Parameters.AddWithValue("@UserName", UserName);
                objCmd.Parameters.AddWithValue("@Password", Password);

                SqlDataReader objSDR = objCmd.ExecuteReader();
                #endregion Set Connection & Command Object

                UserENT entUser = new UserENT();

                if (objSDR.HasRows)
                {
                    //Valid User
                    Message = "Valid User";

                    while (objSDR.Read())
                    {
                        if (!objSDR["UserID"].Equals(DBNull.Value))
                        {
                            //Session["UserID"] = objSDR["UserID"].ToString().Trim();
                            entUser.UserID = Convert.ToInt32(objSDR["UserID"].ToString().Trim());
                        }
                        if (!objSDR["DisplayName"].Equals(DBNull.Value))
                        {
                            //Session["DisplayName"] = objSDR["DisplayName"].ToString().Trim();
                            entUser.DisplayName = objSDR["DisplayName"].ToString().Trim();
                        }
                        break;
                    }
                    return entUser;
                }
                else
                {
                    Message = "Username or Password Invalid";
                    return null;
                }

                if (objConn.State != ConnectionState.Closed)
                    objConn.Close();
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return null;
            }
            finally
            {
                if (objConn.State != ConnectionState.Closed)
                    objConn.Close();
            }
        }
        #endregion Validate User

        #region Insert
        public Boolean Insert(UserENT entUser)
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(ConnectionString);
            #endregion Set Connection
            try
            {
                #region Set Connection & Command Object
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_User_Insert";

                objCmd.Parameters.AddWithValue("@UserName", entUser.UserName);
                objCmd.Parameters.AddWithValue("@Password", entUser.Password);
                objCmd.Parameters.AddWithValue("@DisplayName", entUser.DisplayName);
                objCmd.Parameters.AddWithValue("@MobileNo", entUser.MobileNo);
                objCmd.Parameters.AddWithValue("@Email", entUser.Email);

                objCmd.ExecuteNonQuery();
                #endregion Set Connection & Command Object

                /*lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = strUserName.ToString() + ": Register successfully";*/

                if (objConn.State != ConnectionState.Closed)
                    objConn.Close();

                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Violation of UNIQUE KEY constraint 'IX_User'"))
                {
                    Message = "User Already Exist";
                }
                else
                {
                    Message = ex.Message;
                }
                return false;
            }
            finally
            {
                if (objConn.State != ConnectionState.Closed)
                    objConn.Close();
            }
        }
        #endregion Insert
    }
}