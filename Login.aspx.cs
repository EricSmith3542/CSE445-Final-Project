using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.IO;
using System.Xml;
using HashingDLL;

namespace CSE445Project5
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Label1"] = null;
            Session["Label2"] = null;
            //if (ViewState["keepLogged"] == null || ViewState["keepLogged"] == "False")
            //    FormsAuthentication.SignOut();
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            //Check to see if credentials are valid before redirecting the user
            if(myAuth(userTextBox.Text, passTextBox.Text))
            {
                /*if ((CheckBox1.Checked == true))
                {
                    /*HttpCookie mycookie = new HttpCookie("LoginDetail");
                    mycookie.Values.Set("Username", userTextBox.Text);
                    mycookie.Values.Set("Password", passTextBox.Text);
                    mycookie.Expires = System.DateTime.Now.AddDays(1);

                    Response.Cookies.Add(mycookie);*/

                    /*int timeout = CheckBox1.Checked ? 525600 : 1; // Timeout in minutes, 525600 = 365 days.
                    var ticket = new FormsAuthenticationTicket(userTextBox.Text, CheckBox1.Checked, timeout);
                    string encrypted = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                    cookie.Expires = System.DateTime.Now.AddMinutes(timeout);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);
                }*/
                FormsAuthentication.RedirectFromLoginPage(userTextBox.Text, false);
            }
            else
            {
                outputLabel.Text = "Invalid Username/Password";
                outputLabel.Text = Request.PhysicalApplicationPath;
            }
        }

        bool myAuth(string username, string password)
        {
            password = Hash.Hashing(password);
            //Determine which xml file to check for login information
            string fLocation;
            if (Request.QueryString["ReturnUrl"] == "/Member/Member.aspx")
            {
                fLocation = Path.Combine(Request.PhysicalApplicationPath, @"App_Data\Member.xml");
            }
            else
            {
                fLocation = Path.Combine(Request.PhysicalApplicationPath, @"App_Data\Staff.xml");
            }


            if (File.Exists(fLocation))
            {
                //Open the xml file
                FileStream FS = new FileStream(fLocation, FileMode.Open);
                XmlDocument xd = new XmlDocument();
                xd.Load(FS);
                XmlNode node = xd;
                XmlNodeList children = node.ChildNodes;
                foreach (XmlNode child in children)
                {
                    XmlNodeList users = child.ChildNodes;

                    //Search through the list of users for a username and password match, returning true if a match is found.
                    foreach(XmlNode user in users)
                    {
                        if(username == user.Attributes["name"].Value && password == user.Attributes["pass"].Value)
                        {
                            if(Request.QueryString["ReturnUrl"] == "/Member/Member.aspx")
                            {
                                FS.Close();
                                return true;
                            }
                            else if (Request.QueryString["ReturnUrl"] == "/Staff/Staff.aspx")
                            {
                                FS.Close();
                                return true;
                            }
                        }
                    }
                }
                FS.Close();
            }
            return false;
        }
    }
}