using MultiUserAddressBook.DAL;
using MultiUserAddressBook.ENT;
using System;
using System.Data.SqlTypes;
/// <summary>
/// Summary description for UserBAL
/// </summary>
public class UserBAL
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
    public UserBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion Constructor

    #region Validate User
    public UserENT ValidateUser(SqlString UserName, SqlString Password)
    {
        UserDAL dalUser = new UserDAL();
        UserENT entUser = dalUser.ValidateUser(UserName, Password);
        if (entUser != null)
        {
            return entUser;
        }
        else
        {
            Message = dalUser.Message;
            return null;
        }
    }
    #endregion Validate User

    #region Insert
    public Boolean Insert(UserENT entUser)
    {
        UserDAL dalUser = new UserDAL();
        if (dalUser.Insert(entUser))
        {
            return true;
        }
        else
        {
            Message = dalUser.Message;
            return false;
        }
    }
    #endregion Insert
}