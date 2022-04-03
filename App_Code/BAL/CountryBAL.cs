using MultiUserAddressBook.DAL;
using MultiUserAddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CountryBAL
/// </summary>

namespace MultiUserAddressBook.BAL
{
    public class CountryBAL
    {
        #region Local Variable
        protected string _Message;
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        #endregion Local Variable

        #region Constructor
        public CountryBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Delete Operation
        public Boolean DeleteCountry(SqlInt32 CountryID, SqlInt32 UserID)
        {
            CountryDAL dalCountry = new CountryDAL();
            return dalCountry.DeleteCountry(CountryID, UserID);
        }
        #endregion Delete Operation

        #region Update Operation
        public Boolean Update(CountryENT entCountry,SqlInt32 UserID)
        {
            CountryDAL dalCountry = new CountryDAL();

            if(dalCountry.Update(entCountry,UserID))
            {
                return true;
            }
            else
            {
                Message = dalCountry.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Insert Operation
        public Boolean Insert(CountryENT entCountry,SqlInt32 UserID)
        {
            CountryDAL dalCountry = new CountryDAL();

            if(dalCountry.Insert(entCountry,UserID))
            {
                return true;
            }
            else
            {
                Message = dalCountry.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll(SqlInt32 UserID)
        {
            CountryDAL balCountry = new CountryDAL();
            return balCountry.SelectAll(UserID);
        }
        #endregion SelectAll

        #region SelectByUserID
        public CountryENT SelectByUserID(SqlInt32 CountryID,SqlInt32 UserID)
        {
            CountryDAL dalCountry = new CountryDAL();
            return dalCountry.SelectByUserID(CountryID,UserID);            
        }
        #endregion SelectByUserID

        #region SelectForDropDownList
        public DataTable SelectForDropDownList(SqlInt32 userID)
        {
            CountryDAL dalCountry = new CountryDAL();
            return dalCountry.SelectForDropDownList(userID);
        }
        #endregion SelectForDropDownList

        #endregion Select Operation

    }
}