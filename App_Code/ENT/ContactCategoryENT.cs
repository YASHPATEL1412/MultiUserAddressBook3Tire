﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactCategoryENT
/// </summary>

namespace MultiUserAddressBook.ENT
{
    public class ContactCategoryENT
    {
        #region Constructor
        public ContactCategoryENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region ContactCategoryID
        protected SqlInt32 _ContactCategoryID;
        public SqlInt32 ContactCategoryID
        {
            get { return _ContactCategoryID; }
            set { _ContactCategoryID = value; }
        }
        #endregion ContactCategoryID

        #region UserID
        protected SqlInt32 _UserID;
        public SqlInt32 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        #endregion UserID

        #region ContactCategoryName
        protected SqlString _ContactCategoryName;
        public SqlString ContactCategoryName
        {
            get { return _ContactCategoryName; }
            set { _ContactCategoryName = value; }
        }
        #endregion ContactCategoryName

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