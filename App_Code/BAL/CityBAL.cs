using MultiUserAddressBook.DAL;
using MultiUserAddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CityBAL
/// </summary>

namespace MultiUserAddressBook.BAL
{
    public class CityBAL
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
        public CityBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(CityENT entCity, SqlInt32 userID)
        {
            CityDAL dalCity = new CityDAL();

            if(dalCity.Insert(entCity, userID))
            {
                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(CityENT entCity,SqlInt32 userID)
        {
            CityDAL dalCity = new CityDAL();

            if(dalCity.Update(entCity,userID))
            {
                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean DeleteCity(SqlInt32 CityID,SqlInt32 userID)
        {
            CityDAL dalCity = new CityDAL();

            if(dalCity.DeleteCity(CityID,userID))
            {
                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll(SqlInt32 userID)
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectAll(userID);
        }
        #endregion SelectAll

        #region SelectByUserID
        public CityENT SelectByUserID(SqlInt32 CityID, SqlInt32 userID)
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectByUserID(CityID, userID);
        }
        #endregion SelectByUserID

        #region SelectForDropDownList
        public DataTable SelectForDropDownByStateID(SqlInt32 UserID, SqlInt32 StateID)
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectForDropDownList(UserID, StateID);
        }

        /*public DataTable SelectForDropDownList(SqlInt32 UserID)
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectForDropDownList(UserID, SqlInt32.Null);
        }*/
        #endregion SelectForDropDownList

        #endregion Select Operation
    }
}