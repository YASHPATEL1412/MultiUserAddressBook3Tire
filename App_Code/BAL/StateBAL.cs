using MultiUserAddressBook.DAL;
using MultiUserAddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StateBAL
/// </summary>

namespace MultiUserAddressBook.BAL
{
    public class StateBAL
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
        public StateBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(StateENT entState,SqlInt32 UserID)
        {
            StateDAL dalState = new StateDAL();

            if(dalState.Insert(entState,UserID))
            {
                return true;
            }
            else
            {
                Message = dalState.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(StateENT entState, SqlInt32 UserID)
        {
            StateDAL dalState = new StateDAL();

            if(dalState.Update(entState,UserID))
            {
                return true;
            }
            else
            {
                Message = dalState.Message;
                return false ;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean DeleteState(SqlInt32 StateID, SqlInt32 UserID)
        {
            StateDAL dalState = new StateDAL();
            if(dalState.DeleteState(StateID,UserID))
            {
                return true ;
            }
            else
            {
                Message = dalState.Message;
                return false ;
            }
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll(SqlInt32 userID)
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectAll(userID);
        }
        #endregion SelectAll

        #region CountrySelectByUserID
        public StateENT SelectByUserID(SqlInt32 StateID, SqlInt32 userID)
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectByUserID(StateID,userID);
        }
        #endregion CountrySelectByUserID

        #region SelectForDropDownList
        public DataTable SelectForDropDownListByCountryID(SqlInt32 userID,SqlInt32 CountryID)
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectForDropDownList(userID,CountryID);
        }

        public DataTable SelectForDropDownList(SqlInt32 userID)
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectForDropDownList(userID,SqlInt32.Null);
        }
        #endregion SelectForDropDownList

        #endregion Select Operation

    }
}