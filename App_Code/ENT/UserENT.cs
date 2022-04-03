using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserENT
/// </summary>

namespace MultiUserAddressBook.ENT
{
    public class UserENT
    {
        #region Constructor
        public UserENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region UserID
        protected SqlInt32 _UserID;
        public SqlInt32 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        #endregion UserID

        #region UserName
        protected SqlString _UserName;
        public SqlString UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        #endregion UserName

        #region Password
        protected SqlString _Password;
        public SqlString Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        #endregion Password

        #region DisplayName
        protected SqlString _DisplayName;
        public SqlString DisplayName
        {
            get { return _DisplayName; }
            set { _DisplayName = value; }
        }
        #endregion DisplayName

        #region MobileNo
        protected SqlString _MobileNo;
        public SqlString MobileNo
        {
            get { return _MobileNo; }
            set { _MobileNo = value; }
        }
        #endregion MobileNo

        #region Email
        protected SqlString _Email;
        public SqlString Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        #endregion Email

        #region CreationDate
        protected SqlDateTime _CreactionDate;
        public SqlDateTime CreactionDate
        {
            get { return _CreactionDate; }
            set { _CreactionDate = value; }
        }
        #endregion CreationDate

        #region ModificationDate
        protected SqlDateTime _ModificationDate;
        public SqlDateTime ModificationDate
        {
            get { return _ModificationDate; }
            set { _ModificationDate = value; }
        }
        #endregion CreationDate
    }
}