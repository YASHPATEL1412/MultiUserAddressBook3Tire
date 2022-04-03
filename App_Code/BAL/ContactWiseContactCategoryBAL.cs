using MultiUserAddressBook.DAL;
using MultiUserAddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactWiseContactCategoryBAL
/// </summary>

namespace MultiUserAddressBook.BAL
{
    public class ContactWiseContactCategoryBAL
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
        public ContactWiseContactCategoryBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Insert ContactWiseContactCategory
        public Boolean Insert(List<ContactWiseContactCategoryENT> contactWiseContactCategories)
        {
            ContactWiseContactCategoryDAL dalContactWiseContactCategory = new ContactWiseContactCategoryDAL();
            if(dalContactWiseContactCategory.Insert(contactWiseContactCategories))
            {
                return true;
            }
            else
            {
                Message = dalContactWiseContactCategory.Message;
                return false;
            }
        }
        #endregion Insert ContactWiseContactCategory

        #region Delete ContactWiseContactCategory
        public Boolean DeleteContactCategory(SqlInt32 ContactID, SqlInt32 UserID)
        {
            ContactWiseContactCategoryDAL dalContactWiseContactCategory = new ContactWiseContactCategoryDAL();
            if (dalContactWiseContactCategory.DeleteContactCategory(ContactID, UserID))
            {
                return true;
            }
            else
            {
                Message = dalContactWiseContactCategory.Message;
                return false;
            }
        }
        #endregion Delete ContactWiseContactCategory

        #region SelectOrNot
        public List<ContactWiseContactCategoryENT> SelectOrNot(SqlInt32 ContactId, SqlInt32 UserId)
        {
            ContactWiseContactCategoryDAL contactWiseContactCategoryDAL = new ContactWiseContactCategoryDAL();
            List<ContactWiseContactCategoryENT> contactWiseContactCategories = contactWiseContactCategoryDAL.SelectOrNot(ContactId, UserId);

            if (contactWiseContactCategories != null)
            {
                return contactWiseContactCategories;
            }
            else
            {
                _Message = Message;
                return null;
            }
        }
        #endregion SelectOrNot
    }
}