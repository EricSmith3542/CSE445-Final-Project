using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;
using System.Drawing;
using HashingDLL;


namespace CSE445Project5.Staff
{
    public partial class StaffRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
                if (passBox.Text == repassBox.Text)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(Path.Combine(Request.PhysicalApplicationPath, @"App_Data\Staff.xml"));

                    XmlElement usersList = doc.DocumentElement;
                    foreach (XmlNode user in usersList.ChildNodes)
                    {
                        if (user.Attributes["name"].Value == userBox.Text)
                        {
                            output.Text = "That username already exists, please try another.";
                            return;
                        }
                    }

                    XmlElement newUser = doc.CreateElement("user");
                    newUser.SetAttribute("name", userBox.Text);
                    //newUser.SetAttribute("pass", passBox.Text);
                    newUser.SetAttribute("pass", Hash.Hashing(passBox.Text));

                    usersList.AppendChild(newUser);
                    doc.Save(Path.Combine(Request.PhysicalApplicationPath, @"App_Data\Staff.xml"));
                }
                else
                {
                    output.Text = "Passwords do not match";
                    return;
                }
            output.Text = "Registration Complete";
        }
    }
}