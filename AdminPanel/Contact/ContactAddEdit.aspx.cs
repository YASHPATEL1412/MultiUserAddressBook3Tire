using MultiUserAddressBook.BAL;
using MultiUserAddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Contact_ContactAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownCountryList();
            FillCBLContactCategoryID();
            /*FillDropDownContactCategoryList();*/
            if (RouteData.Values["ContactID"] != null)
            {
                lblAddEdit.Text = "Edit Contact";

                FillControls(Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["ContactID"].ToString().Trim())));
                FillDropDownStateList();
                FillDropDownCityList();
            }
            else
            {
                lblAddEdit.Text = "Add Contact";
            }
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variables

        SqlInt32 ContactID = SqlInt32.Null;
        SqlInt32 strCountryID = SqlInt32.Null;
        SqlInt32 strStateID = SqlInt32.Null;
        SqlInt32 strCityID = SqlInt32.Null;
        SqlInt32 strContactCategoryID = SqlInt32.Null;
        SqlString strContactName = SqlString.Null;
        SqlString strContactNo = SqlString.Null;
        SqlString strWhatsAppNo = SqlString.Null;
        SqlDateTime strBirthDate = SqlDateTime.Null;
        SqlString strEmail = SqlString.Null;
        SqlInt32 strAge = SqlInt32.Null;
        SqlString strAddress = SqlString.Null;
        SqlString strBloodGroup = SqlString.Null;
        SqlString strFacebookID = SqlString.Null;
        SqlString strLinkedInID = SqlString.Null;

        #endregion Local Variables

        #region Server Side Validation
        //Server Side Validation
        String strErrorMessage = "";

        if (ddlCountryID.SelectedIndex == 0)
            strErrorMessage += "Select Country <br />";

        if (ddlStateID.SelectedIndex == 0)
            strErrorMessage += "Select State <br />";

        if (ddlCityID.SelectedIndex == 0)
            strErrorMessage += "Select City <br />";

        if (cblContactCategoryID.SelectedValue == "")
            strErrorMessage += "Select ContactCategory <br />";

        if (txtContactName.Text.Trim() == "")
            strErrorMessage += "Enter ConatctName <br />";

        if (txtContactNo.Text.Trim() == "")
            strErrorMessage += "Enter ConatctNo <br />";

        if (txtWhatsAppNo.Text.Trim() == "")
            strErrorMessage += "Enter WhatsAppNo <br />";

        if (txtBirthDate.Text.Trim() == "")
            strErrorMessage += "Enter BirthDate <br />";

        if (txtEmail.Text.Trim() == "")
            strErrorMessage += "Enter Email <br />";

        if (txtAge.Text.Trim() == "")
            strErrorMessage += "Enter Age <br />";

        if (txtAddress.Text.Trim() == "")
            strErrorMessage += "Enter Address <br />";

        if (txtBloodGroup.Text.Trim() == "")
            strErrorMessage += "Enter BloodGroup <br />";

        if (txtFacebookID.Text.Trim() == "")
            strErrorMessage += "Enter FacebookID <br />";

        if (txtLinkedInID.Text.Trim() == "")
            strErrorMessage += "Enter LinkedInID <br />";

        if (!fuFile.HasFile)
            strErrorMessage += "You have not selected a File ";

        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Gather Information
        //Gather the Information
        if (ddlCountryID.SelectedIndex > 0)
            strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);

        if (ddlStateID.SelectedIndex > 0)
            strStateID = Convert.ToInt32(ddlStateID.SelectedValue);

        if (ddlCityID.SelectedIndex > 0)
            strCityID = Convert.ToInt32(ddlCityID.SelectedValue);

        /*if (ddlContactCategoryID.SelectedIndex > 0)
            strContactCategoryID = Convert.ToInt32(ddlContactCategoryID.SelectedValue);*/

        if (cblContactCategoryID.SelectedValue != "-1")
            strContactCategoryID = Convert.ToInt32(cblContactCategoryID.SelectedValue);

        if (txtContactName.Text.Trim() != "")
            strContactName = txtContactName.Text.Trim();

        if (txtContactNo.Text.Trim() != "")
            strContactNo = txtContactNo.Text.Trim();

        if (txtWhatsAppNo.Text.Trim() != "")
            strWhatsAppNo = txtWhatsAppNo.Text.Trim();

        if (txtBirthDate.Text.Trim() != "")
            strBirthDate = Convert.ToDateTime(txtBirthDate.Text.Trim());

        if (txtEmail.Text.Trim() != "")
            strEmail = txtEmail.Text.Trim();

        if (txtAge.Text.Trim() != "")
            strAge = Convert.ToInt32(txtAge.Text.Trim());

        if (txtAddress.Text.Trim() != "")
            strAddress = txtAddress.Text.Trim();

        if (txtBloodGroup.Text.Trim() != "")
            strBloodGroup = txtBloodGroup.Text.Trim();

        if (txtFacebookID.Text.Trim() != "")
            strFacebookID = txtFacebookID.Text.Trim();

        if (txtLinkedInID.Text.Trim() != "")
            strLinkedInID = txtLinkedInID.Text.Trim();

        #endregion Gather Information

        ContactBAL balContact = new ContactBAL();
        ContactENT entContact = new ContactENT()
        {
            ContactName = strContactName,
            CountryID = strCountryID,
            StateID = strStateID,
            CityID = strCityID,
            ContactNo = strContactNo,
            WhatsAppNo = strWhatsAppNo,
            BirthDate = strBirthDate,
            Email = strEmail,
            Age = strAge,
            BloodGroup = strBloodGroup,
            FacebookID = strFacebookID,
            LinkedInID = strLinkedInID,
            Address = strAddress,
            UserID = Convert.ToInt32(Session["UserID"])
        };

        if (RouteData.Values["ContactID"] != null)
        {
            #region Update Record               
            entContact.ContactID = Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["ContactID"].ToString().Trim()));
            //objCmd.Parameters.AddWithValue("@ContactID", (Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["ContactID"].ToString().Trim()))));

            string FileType = Path.GetExtension(fuFile.FileName).ToLower();

            if (balContact.Update(entContact, Convert.ToInt32(Session["UserID"])))
            {
                if (fuFile.HasFile)
                {
                    if (FileType == ".jpge" || FileType == ".jpg" || FileType == ".png" || FileType == ".gif")
                    {
                        UploadImage(Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["ContactID"].ToString())), "Image");
                    }
                    else
                    {
                        lblMessage.Text = "Please Upload Valid File(File must have .jpg or .jpge or .png or .gif extention).";
                        return;
                    }
                }
                DeleteContactCategory(Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["ContactID"].ToString())));
                AddContactCategory(Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["ContactID"].ToString())));
                Response.Redirect("~/AdminPanel/Contact/List", true);
            }
            else
            {
                lblMessage.Text = balContact.Message;
            }
            #endregion Update Record
        }
        else
        {
            #region Insert Record
            if (balContact.Insert(entContact, Convert.ToInt32(Session["UserID"])))
            {
                //ContactID = balContact.Insert(entContact);
                string FileType = Path.GetExtension(fuFile.FileName).ToLower();

                if (fuFile.HasFile)
                {
                    if (FileType == ".jpge" || FileType == ".jpg" || FileType == ".png" || FileType == ".gif")
                    {
                        UploadImage(entContact.ContactID, "Image");
                    }
                    else
                    {
                        lblMessage.Text = "Please Upload Valid File(File must have .jpg or .jpge or .png or .gif extention).";
                        return;
                    }
                }
                AddContactCategory(entContact.ContactID);
                ClearControls();
            }
            else
            {
                lblMessage.Text = balContact.Message;
            }
            #endregion Insert Record
        }
    }
    #endregion Button : Save

    #region Add ContactCategory
    private void AddContactCategory(SqlInt32 ID)
    {
        ContactWiseContactCategoryBAL balContactWiseContactCategory = new ContactWiseContactCategoryBAL();
        List<ContactWiseContactCategoryENT> contactWiseContactCategories = new List<ContactWiseContactCategoryENT>();

        foreach (ListItem item in cblContactCategoryID.Items)
        {
            if (item.Selected)
            {
                ContactWiseContactCategoryENT entContactWiseContactCategory = new ContactWiseContactCategoryENT()
                {
                    ContactID = ID,
                    ContactCategoryID = Convert.ToInt32(item.Value),
                    UserID = Convert.ToInt32(Session["UserID"])
                };
                contactWiseContactCategories.Add(entContactWiseContactCategory);
            }
        }
        if (!balContactWiseContactCategory.Insert(contactWiseContactCategories))
        {
            lblMessage.Text = balContactWiseContactCategory.Message;
        }
    }
    #endregion Add ContactCategory

    #region Delete Contact Category
    private void DeleteContactCategory(SqlInt32 ContactID)
    {
        ContactWiseContactCategoryBAL balContactWiseContactCategory = new ContactWiseContactCategoryBAL();
        if (!balContactWiseContactCategory.DeleteContactCategory(ContactID, Convert.ToInt32(Session["UserID"])))
        {
            lblMessage.Text = balContactWiseContactCategory.Message;
        }
    }
    #endregion Delete Contact Category

    #region Fill ContactCategory CheckBoxsList
    private void FillContactCategoryCheckBoxs(SqlInt32 ContactId)
    {
        ContactWiseContactCategoryBAL contactWiseContactCategoryBAL = new ContactWiseContactCategoryBAL();
        List<ContactWiseContactCategoryENT> contactWiseContactCategories = contactWiseContactCategoryBAL.SelectOrNot(ContactId, Convert.ToInt32(Session["UserID"]));

        if (contactWiseContactCategories != null)
        {
            foreach (var contactWiseContactCategory in contactWiseContactCategories)
            {
                if (contactWiseContactCategory.SelectOrNot.Value.ToString() == "Selected")
                {
                    cblContactCategoryID.Items.FindByValue(contactWiseContactCategory.ContactCategoryID.ToString()).Selected = true;
                }
            }
        }
        else
        {
            lblMessage.Text = contactWiseContactCategoryBAL.Message;
        }
    }
    #endregion Fill ContactCategory CheckBoxsList

    #region Upload Image
    private void UploadImage(SqlInt32 ID, string FileExtention)
    {
        SqlString strFilePath = SqlString.Null;

        #region Image Upload
        strFilePath = "~/Content/UserPhoto/" + ID + ".jpg";

        if (!Directory.Exists(Server.MapPath("~/Content/UserPhoto/")))
        {
            Directory.CreateDirectory(Server.MapPath("~/Content/UserPhoto/"));
        }

        fuFile.SaveAs(Server.MapPath("~/Content/UserPhoto/" + ID + ".jpg"));
        long length = new FileInfo(Server.MapPath(strFilePath.ToString())).Length;
        #endregion Image Upload

        ContactBAL balContact = new ContactBAL();
        if (!balContact.UpdateImage(ID, strFilePath, FileExtention, length.ToString(), Convert.ToInt32(Session["UserID"])))
        {
            lblMessage.Text = balContact.Message;
        }
    }
    #endregion Upload Image

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Contact/List", true);
    }
    #endregion Button : Cancel

    #region Fill DropDownCountryList
    private void FillDropDownCountryList()
    {
        CommonDropDownFillMethods.FillDropDownListCountry(ddlCountryID, Convert.ToInt32(Session["UserId"]));
    }
    #endregion Fill DropDownCountryList

    #region Fill DropDownStateList
    private void FillDropDownStateList()
    {
        CommonDropDownFillMethods.FillDropDownListStateByCountryID(ddlStateID, Convert.ToInt32(ddlCountryID.SelectedValue), Convert.ToInt32(Session["UserId"]));
    }
    #endregion Fill DropDownStateList

    #region Fill DropDownCityList
    private void FillDropDownCityList()
    {
        CommonDropDownFillMethods.FillDropDownListCitySelectByStateID(ddlCityID, Convert.ToInt32(Session["UserId"]), Convert.ToInt32(ddlStateID.SelectedValue));
    }
    #endregion Fill DropDownCityList

    #region Fill CBLContactCategoryList
    private void FillCBLContactCategoryID()
    {
        CommonDropDownFillMethods.FillCBLContactCategoryList(cblContactCategoryID, Convert.ToInt32(Session["UserId"]));
    }
    #endregion Fill CBLContactCategoryList

    #region FillControl
    private void FillControls(SqlInt32 ContactID)
    {
        ContactBAL balContact = new ContactBAL();
        ContactENT entContact = balContact.SelectByUserID(ContactID, Convert.ToInt32(Session["UserID"]));

        if (entContact != null)
        {
            if (!entContact.CountryID.IsNull)
            {
                ddlCountryID.SelectedValue = entContact.CountryID.Value.ToString();
            }
            if (!entContact.StateID.IsNull)
            {
                ddlStateID.SelectedValue = entContact.StateID.Value.ToString();
            }
            if (!entContact.CityID.IsNull)
            {
                ddlCityID.SelectedValue = entContact.CityID.Value.ToString();
            }
            if (!entContact.ContactName.IsNull)
            {
                txtContactName.Text = entContact.ContactName.Value.ToString();
            }
            if (!entContact.ContactNo.IsNull)
            {
                txtContactNo.Text = entContact.ContactNo.Value.ToString();
            }
            if (!entContact.WhatsAppNo.IsNull)
            {
                txtWhatsAppNo.Text = entContact.WhatsAppNo.Value.ToString();
            }
            if (!entContact.BirthDate.IsNull)
            {
                DateTime dt = entContact.BirthDate.Value;
                txtBirthDate.Text = dt.ToString("yyyy-MM-dd");
            }
            if (!entContact.Email.IsNull)
            {
                txtEmail.Text = entContact.Email.Value.ToString();
            }
            if (!entContact.Age.IsNull)
            {
                txtAge.Text = entContact.Age.Value.ToString();
            }
            if (!entContact.Address.IsNull)
            {
                txtAddress.Text = entContact.Address.Value.ToString();
            }
            if (!entContact.BloodGroup.IsNull)
            {
                txtBloodGroup.Text = entContact.BloodGroup.Value.ToString();
            }
            if (!entContact.FacebookID.IsNull)
            {
                txtFacebookID.Text = entContact.FacebookID.Value.ToString();
            }
            if (!entContact.LinkedInID.IsNull)
            {
                txtLinkedInID.Text = entContact.LinkedInID.Value.ToString();
            }
            if (!entContact.ContactPhotoPath.IsNull)
            {
                imgImage.ImageUrl = entContact.ContactPhotoPath.Value.ToString();
                imgImage.Visible = true;
                //btnDeleteImage.Visible = true;
            }
            FillContactCategoryCheckBoxs(ContactID);
        }
        else
        {
            lblMessage.Text = balContact.Message;
        }
    }
    #endregion FillControls

    #region Country SelectedIndexChanged
    protected void ddlCountryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCountryID.SelectedIndex != -1)
        {
            /*ddlStateID.Items.Clear();
            FillDropDownStateList();*/

            ddlCityID.Items.Clear();
            ddlStateID.Items.Clear();
            FillDropDownStateList();
        }
        else
        {
            /*ddlStateID.Items.Clear();*/

            ddlStateID.Items.Clear();
            ddlCityID.Items.Clear();
        }
    }
    #endregion Country SelectedIndexChanged

    #region State SelectedIndexChanged
    protected void ddlStateID_SelectedIndexChanged(object sender, EventArgs e)
    {
        /*ddlCityID.Items.Clear();
        FillDropDownCityList();*/
        if (ddlStateID.SelectedIndex != -1)
        {
            ddlCityID.Items.Clear();
            FillDropDownCityList();
        }
        else
        {
            ddlCityID.Items.Clear();
        }
    }
    #endregion State SelectedIndexChanged

    #region ClearControls
    private void ClearControls()
    {
        txtContactName.Text = "";
        txtContactNo.Text = "";
        txtWhatsAppNo.Text = "";
        txtBirthDate.Text = "";
        txtEmail.Text = "";
        txtAge.Text = "";
        txtAddress.Text = "";
        txtBloodGroup.Text = "";
        txtFacebookID.Text = "";
        txtLinkedInID.Text = "";
        ddlCountryID.SelectedIndex = 0;
        ddlStateID.SelectedIndex = 0;
        ddlCityID.SelectedIndex = 0;
        //ddlContactCategoryID.SelectedIndex = 0;
        cblContactCategoryID.ClearSelection();
        ddlCountryID.Focus();
        lblMessage.ForeColor = System.Drawing.Color.Green;
        lblMessage.Text = "Data Inserted Successfully";
    }
    #endregion

    /*#region FillDropDownContactCategoryList
    private void FillDropDownContactCategoryList()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        try
        {

            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            //strContactCategoryID = Convert.ToInt32(ddlContactCategoryID.SelectedValue);

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);

            objCmd.CommandText = "PR_ContactCategory_SelectForDropDownList";

            //objCmd.Parameters.AddWithValue("@ContactCategoryID", strContactCategoryID);

            #endregion Set Connection & Command Object
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                ddlContactCategoryID.DataSource = objSDR;
                ddlContactCategoryID.DataValueField = "ContactCategoryID";
                ddlContactCategoryID.DataTextField = "ContactCategoryName";
                ddlContactCategoryID.DataBind();
            }

            ddlContactCategoryID.Items.Insert(0, new ListItem("Select ContactCategory", "-1"));

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion FillDropDownContactCategoryList*/
}