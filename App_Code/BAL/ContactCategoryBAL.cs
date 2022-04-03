using MultiUserAddressBook.DAL;
using MultiUserAddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactCategoryBAL
/// </summary>

namespace MultiUserAddressBook.BAL
{
    public class ContactCategoryBAL
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
        public ContactCategoryBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(ContactCategoryENT entContactCategory, SqlInt32 UserID)
        {
            ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();

            if(dalContactCategory.Insert(entContactCategory,UserID))
            {
                return true;
            }
            else
            {
                Message = dalContactCategory.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(ContactCategoryENT entContactCategory, SqlInt32 UserID)
        {
            ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
            if (dalContactCategory.Update(entContactCategory, UserID))
            {
                return true;
            }
            else
            {
                Message = dalContactCategory.Message;
                return false;
            }
        }
        #endregion Update Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 ContactCategoryID, SqlInt32 UserID)
        {
            ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
            return dalContactCategory.Delete(ContactCategoryID, UserID);
        }
        #endregion Delete Operation

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll(SqlInt32 UserID)
        {
            ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
            return dalContactCategory.SelectAll(UserID);
        }
        #endregion SelectAll

        #region SelectByUserID
        public ContactCategoryENT SelectByUserID(SqlInt32 ContactCategoryID, SqlInt32 UserID)
        {
            ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
            return dalContactCategory.SelectByUserID(ContactCategoryID, UserID);
        }
        #endregion SelectByUserID

        #region ContactCategory For CheckBoxList
        public DataTable SelectForDropDownList(SqlInt32 UserID)
        {
            ContactCategoryDAL dalContactCategory = new ContactCategoryDAL();
            return dalContactCategory.SelectForDropDownList(UserID);
        }
        #endregion ContactCategory For CheckBoxList

        #endregion Select Operation
    }
}