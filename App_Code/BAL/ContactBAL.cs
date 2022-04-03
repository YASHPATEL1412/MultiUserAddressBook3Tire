using MultiUserAddressBook.DAL;
using MultiUserAddressBook.ENT;
using System;
using System.Data;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for ContactBAL
/// </summary>

namespace MultiUserAddressBook.BAL
{
    public class ContactBAL
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
        public ContactBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert Operation
        public Boolean Insert(ContactENT entContact, SqlInt32 UserID)
        {
            ContactDAL dalContact = new ContactDAL();
            if (dalContact.Insert(entContact, UserID))
            {
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation

        #region UpdateContact
        public Boolean Update(ContactENT entContact, SqlInt32 UserID)
        {
            ContactDAL dalContact = new ContactDAL();
            if (dalContact.Update(entContact, UserID))
            {
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }
        }
        #endregion UpdateContact

        #region UpdateImage
        public Boolean UpdateImage(SqlInt32 ContactID, SqlString FilePath, SqlString FileExtention, SqlString Length, SqlInt32 UserID)
        {
            ContactDAL dalContact = new ContactDAL();
            if(dalContact.UpdateImage(ContactID, FilePath, FileExtention, Length, UserID))
            {
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }
        }
        #endregion UpdateImage

        #endregion Update Operation

        #region Delete Operation

        #region DeleteImage
        public Boolean DeleteImage(SqlInt32 ContactID, SqlInt32 UserID)
        {
            ContactDAL dalContact = new ContactDAL();
            if (dalContact.DeleteImage(ContactID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }
        }
        #endregion DeleteImage

        #region DeleteContactRecord
        public Boolean DeleteContactRecord(SqlInt32 ContactID, SqlInt32 UserID)
        {
            ContactDAL dalContact = new ContactDAL();
            if (dalContact.DeleteContactRecord(ContactID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }
        }
        #endregion DeleteContactRecord

        #endregion Delete Operation

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll(SqlInt32 UserID)
        {
            ContactDAL dalContact = new ContactDAL();
            return dalContact.SelectAll(UserID);
        }
        #endregion SelectAll

        #region SelectCountryByUserID
        public ContactENT SelectByUserID(SqlInt32 ContactID, SqlInt32 UserID)
        {
            ContactDAL dalContact = new ContactDAL();
            return dalContact.SelectByUserID(ContactID, UserID);
        }
        #endregion SelectCountryByUserID

        #endregion Select Operation
    }
}