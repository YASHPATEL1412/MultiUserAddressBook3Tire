using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactENT
/// </summary>

namespace MultiUserAddressBook.ENT
{
    public class ContactENT
    {
        #region Constructor
        public ContactENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region ContactID
        protected SqlInt32 _ContactID;
        public SqlInt32 ContactID
        {
            get { return _ContactID; }
            set { _ContactID = value; }
        }
        #endregion ContactID

        #region CountryID
        protected SqlInt32 _CountryID;
        public SqlInt32 CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }
        #endregion ContactID

        #region StateID
        protected SqlInt32 _StateID;
        public SqlInt32 StateID
        {
            get { return _StateID; }
            set { _StateID = value; }
        }
        #endregion StateID

        #region CityID
        protected SqlInt32 _CityID;
        public SqlInt32 CityID
        {
            get { return _CityID; }
            set { _CityID = value; }
        }
        #endregion ContactID

        #region ContactCategoryID
        protected SqlInt32 _ContactCategoryID;
        public SqlInt32 ContactCategoryID
        {
            get { return _ContactCategoryID; }
            set { _ContactCategoryID = value; }
        }
        #endregion ContactID

        #region UserID
        protected SqlInt32 _UserID;
        public SqlInt32 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        #endregion ContactID

        #region ContactName
        protected SqlString _ContactName;
        public SqlString ContactName
        {
            get { return _ContactName; }
            set { _ContactName = value; }
        }
        #endregion ContactID

        #region ContactNo
        protected SqlString _ContactNo;
        public SqlString ContactNo
        {
            get { return _ContactNo; }
            set { _ContactNo = value; }
        }
        #endregion ContactID

        #region WhatsAppNo
        protected SqlString _WhatsAppNo;
        public SqlString WhatsAppNo
        {
            get { return _WhatsAppNo; }
            set { _WhatsAppNo = value; }
        }
        #endregion ContactID

        #region BirthDate
        protected SqlDateTime _BirthDate;
        public SqlDateTime BirthDate
        {
            get { return _BirthDate; }
            set { _BirthDate = value; }
        }
        #endregion ContactID

        #region Email
        protected SqlString _Email;
        public SqlString Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        #endregion ContactID

        #region Age
        protected SqlInt32 _Age;
        public SqlInt32 Age
        {
            get { return _Age; }
            set { _Age = value; }
        }
        #endregion ContactID

        #region Address
        protected SqlString _Address;
        public SqlString Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        #endregion ContactID

        #region BloodGroup
        protected SqlString _BloodGroup;
        public SqlString BloodGroup
        {
            get { return _BloodGroup; }
            set { _BloodGroup = value; }
        }
        #endregion ContactID

        #region FacebookID
        protected SqlString _FacebookID;
        public SqlString FacebookID
        {
            get { return _FacebookID; }
            set { _FacebookID = value; }
        }
        #endregion ContactID

        #region LinkedInID
        protected SqlString _LinkedInID;
        public SqlString LinkedInID
        {
            get { return _LinkedInID; }
            set { _LinkedInID = value; }
        }
        #endregion ContactID

        #region ContactPhotoPath
        protected SqlString _ContactPhotoPath;
        public SqlString ContactPhotoPath
        {
            get { return _ContactPhotoPath; }
            set { _ContactPhotoPath = value; }
        }
        #endregion ContactID

        #region FileSize
        protected SqlInt32 _FileSize;
        public SqlInt32 FileSize
        {
            get { return _FileSize; }
            set { _FileSize = value; }
        }
        #endregion ContactID

        #region FileType
        protected SqlString _FileType;
        public SqlString FileType
        {
            get { return _FileType; }
            set { _FileType = value; }
        }
        #endregion ContactID

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