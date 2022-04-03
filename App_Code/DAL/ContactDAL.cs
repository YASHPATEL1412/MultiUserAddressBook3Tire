using MultiUserAddressBook.ENT;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for ContactDAL
/// </summary>

namespace MultiUserAddressBook.DAL
{
    public class ContactDAL : DatabaseConfig
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
        public ContactDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(ContactENT entContact, SqlInt32 UserID)
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
                objCmd.CommandText = "[PR_Contact_Insert]";

                objCmd.Parameters.AddWithValue("@CountryID", entContact.CountryID);
                objCmd.Parameters.AddWithValue("@StateID", entContact.StateID);
                objCmd.Parameters.AddWithValue("@CityID", entContact.CityID);
                objCmd.Parameters.AddWithValue("@ContactName", entContact.ContactName);
                objCmd.Parameters.AddWithValue("@ContactNo", entContact.ContactNo);
                objCmd.Parameters.AddWithValue("@WhatsappNo", entContact.WhatsAppNo);
                objCmd.Parameters.AddWithValue("@BirthDate", entContact.BirthDate);
                objCmd.Parameters.AddWithValue("@Email", entContact.Email);
                objCmd.Parameters.AddWithValue("@Age", entContact.Age);
                objCmd.Parameters.AddWithValue("@Address", entContact.Address);
                objCmd.Parameters.AddWithValue("@BloodGroup", entContact.BloodGroup);
                objCmd.Parameters.AddWithValue("@FacebookID", entContact.FacebookID);
                objCmd.Parameters.AddWithValue("@LinkedINID", entContact.LinkedInID);
                if (!UserID.IsNull)
                    objCmd.Parameters.AddWithValue("@UserID", UserID);

                //Out Parameter
                objCmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                objCmd.ExecuteNonQuery();
                entContact.ContactID = Convert.ToInt32(objCmd.Parameters["@ContactID"].Value);

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

        #region UpdateContact
        public Boolean Update(ContactENT entContact, SqlInt32 UserID)
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
                objCmd.CommandText = "[dbo].[PR_Contact_UpdateByPK]";

                objCmd.Parameters.AddWithValue("@ContactID", entContact.ContactID);
                objCmd.Parameters.AddWithValue("@CountryID", entContact.CountryID);
                objCmd.Parameters.AddWithValue("@StateID", entContact.StateID);
                objCmd.Parameters.AddWithValue("@CityID", entContact.CityID);
                objCmd.Parameters.AddWithValue("@ContactName", entContact.ContactName);
                objCmd.Parameters.AddWithValue("@ContactNo", entContact.ContactNo);
                objCmd.Parameters.AddWithValue("@WhatsappNo", entContact.WhatsAppNo);
                objCmd.Parameters.AddWithValue("@BirthDate", entContact.BirthDate);
                objCmd.Parameters.AddWithValue("@Email", entContact.Email);
                objCmd.Parameters.AddWithValue("@Age", entContact.Age);
                objCmd.Parameters.AddWithValue("@Address", entContact.Address);
                objCmd.Parameters.AddWithValue("@BloodGroup", entContact.BloodGroup);
                objCmd.Parameters.AddWithValue("@FacebookID", entContact.FacebookID);
                objCmd.Parameters.AddWithValue("@LinkedINID", entContact.LinkedInID);
                if (!UserID.IsNull)
                    objCmd.Parameters.AddWithValue("@UserID", UserID);

                if (!entContact.ContactID.IsNull)
                {
                    objCmd.Parameters.AddWithValue("@ContactCategoryID", entContact.ContactCategoryID);
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
        #endregion UpdateContact

        #region UpdateImage
        public Boolean UpdateImage(SqlInt32 ContactID, SqlString FilePath, SqlString FileExtention, SqlString Length, SqlInt32 UserID)
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(ConnectionString);
            #endregion Set Connection
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                #region Create Command and Set Parameters
                SqlCommand objCmd = objConn.CreateCommand();
                //SqlCommand objCmd = new SqlCommand("PR_Contact_UpdateImagePathByPKUserID", objConn);
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Contact_UpdateImagePathByPKUserID";

                objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                objCmd.Parameters.AddWithValue("@ContactPhotoPath", FilePath);
                objCmd.Parameters.AddWithValue("@FileType", FileExtention);
                objCmd.Parameters.AddWithValue("@FileSize", Length);
                if (!UserID.IsNull)
                    objCmd.Parameters.AddWithValue("@UserID", UserID);

                objCmd.ExecuteNonQuery();

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
                return true;

                #endregion Create Command and Set Parameters
            }
            catch (Exception ex)
            {
                Message = ex.Message.ToString();
                return false;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
        #endregion UpdateImage

        #endregion Update Operation

        #region Delete Operation

        #region DeleteImage
        public Boolean DeleteImage(SqlInt32 ContactID, SqlInt32 UserID)
        {
            #region Set Connection
            SqlConnection objConn = new SqlConnection(ConnectionString);
            #endregion Set Connection
            try
            {
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                #region Create Command and Set Parameters
                SqlCommand objCmd = new SqlCommand("PR_Contact_DeleteImageByPKUserID", objConn);

                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.AddWithValue("@ContactID", ContactID);

                if (!UserID.IsNull)
                    objCmd.Parameters.AddWithValue("@UserID", UserID);
                //objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(UserID));

                objCmd.ExecuteNonQuery();

                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
                return true;
                #endregion Create Command and Set Parameters
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
        #endregion DeleteImage

        #region DeleteContactRecord
        public Boolean DeleteContactRecord(SqlInt32 ContactID, SqlInt32 UserID)
        {
            SqlConnection objConn = new SqlConnection(ConnectionString);
            try
            {

                if (objConn.State != ConnectionState.Open)
                    objConn.Open();

                #region Set Connection & Command Object
                SqlCommand objCmd = objConn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Contact_DeleteByPK";
                objCmd.Parameters.AddWithValue("ContactID", ContactID.ToString());

                /*DeletePhoto(FilePath);*/

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
        #endregion DeleteContactRecord

        #endregion Delete Operation

        #region Select Operation

        #region SelectAll
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
                objCmd.CommandText = "[PR_Contact_SelectAllByPK_UserID]";

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
                Message = ex.Message + ex;
                return null;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }
        #endregion SelectAll

        #region SelectCountryByUserID
        public ContactENT SelectByUserID(SqlInt32 ContactID, SqlInt32 UserID)
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
                //SqlCommand objCmd = new SqlCommand("PR_Contact_SelectByUserID", objConn);
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_Contact_SelectByUserID";

                objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                if (!UserID.IsNull)
                    objCmd.Parameters.AddWithValue("@UserID", UserID);

                #endregion Set Connection & Command Object

                #region Read the value and set the controls
                ContactENT entContact = new ContactENT();

                SqlDataReader objSDR = objCmd.ExecuteReader();

                if (objSDR.HasRows)
                {
                    while (objSDR.Read())
                    {
                        if (!objSDR["CountryID"].Equals(DBNull.Value))
                        {
                            string CountryID = objSDR["CountryID"].ToString();
                            entContact.CountryID = Convert.ToInt32(CountryID);
                        }
                        if (!objSDR["StateID"].Equals(DBNull.Value))
                        {
                            string StateID = objSDR["StateID"].ToString();
                            entContact.StateID = Convert.ToInt32(StateID);
                        }
                        if (!objSDR["CityID"].Equals(DBNull.Value))
                        {
                            string CityID = objSDR["CityID"].ToString();
                            entContact.CityID = Convert.ToInt32(CityID);
                        }

                        /*if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                        {
                            cblContactCategoryID.SelectedValue = objSDR["ContactCategoryID"].ToString().Trim();
                            //ddlContactCategoryID.SelectedValue = objSDR["ContactCategoryID"].ToString().Trim();
                        }*/

                        if (!objSDR["ContactName"].Equals(DBNull.Value))
                        {
                            entContact.ContactName = objSDR["ContactName"].ToString().Trim();
                        }
                        if (!objSDR["ContactNo"].Equals(DBNull.Value))
                        {
                            entContact.ContactNo = objSDR["ContactNo"].ToString().Trim();
                        }
                        if (!objSDR["WhatsAppNo"].Equals(DBNull.Value))
                        {
                            entContact.WhatsAppNo = objSDR["WhatsAppNo"].ToString().Trim();
                        }
                        if (!objSDR["BirthDate"].Equals(DBNull.Value))
                        {
                            //txtBirthDate.Text = Convert.ToDateTime(objSDR["BirthDate"].ToString().Trim()).ToString("yyyy/MM/dd");
                            entContact.BirthDate = Convert.ToDateTime(objSDR["BirthDate"].ToString().Trim());
                        }
                        if (!objSDR["Email"].Equals(DBNull.Value))
                        {
                            entContact.Email = objSDR["Email"].ToString().Trim();
                        }
                        if (!objSDR["Age"].Equals(DBNull.Value))
                        {
                            //txtAge.Text = objSDR["Age"].ToString().Trim();
                            string Age = objSDR["Age"].ToString();
                            entContact.Age = Convert.ToInt32(Age);
                        }
                        if (!objSDR["Address"].Equals(DBNull.Value))
                        {
                            entContact.Address = objSDR["Address"].ToString().Trim();
                        }
                        if (!objSDR["BloodGroup"].Equals(DBNull.Value))
                        {
                            entContact.BloodGroup = objSDR["BloodGroup"].ToString().Trim();
                        }
                        if (!objSDR["FacebookID"].Equals(DBNull.Value))
                        {
                            entContact.FacebookID = objSDR["FacebookID"].ToString().Trim();
                        }
                        if (!objSDR["LinkedInID"].Equals(DBNull.Value))
                        {
                            entContact.LinkedInID = objSDR["LinkedInID"].ToString().Trim();
                        }
                        if (!objSDR["ContactPhotoPath"].Equals(DBNull.Value))
                        {
                            //imgImage.ImageUrl = objSDR["ContactPhotoPath"].ToString().Trim();
                            entContact.ContactPhotoPath = objSDR["ContactPhotoPath"].ToString().Trim();
                        }
                        break;
                    }
                }
                else
                {
                    Message = "No Data Available for the ContactID = " + ContactID.ToString();
                }
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
                return entContact;

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
        #endregion SelectCountryByUserID

        #endregion Select Operation
    }
}