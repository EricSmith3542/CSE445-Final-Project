using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;
using System.Drawing;
using System.Web.Security;
using HashingDLL;

namespace CSE445Project5
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // if (ViewState["keepLogged"] == null || ViewState["keepLogged"] == "false")
           //     FormsAuthentication.SignOut();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string url = "http://neptune.fulton.ad.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/";
            if (TextBox1.Text == Image1.ImageUrl.Substring(url.Length))
            {
                if (passBox.Text == repassBox.Text)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(Path.Combine(Request.PhysicalApplicationPath, @"App_Data\Member.xml"));

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
                    doc.Save(Path.Combine(Request.PhysicalApplicationPath, @"App_Data\Member.xml"));
                }
                else
                {
                    output.Text = "Passwords do not match";
                    return;
                }
            }
            else
            {
                output.Text = "Your WRONG!!  >:( Try again!";
                return;
            }
            output.Text = "Registration Complete";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ImageReference.ServiceClient prxy = new ImageReference.ServiceClient();
            string verify = prxy.GetVerifierString("5");
            /*Stream imgStr = prxy.GetImage(verify);
            StreamReader reader = new StreamReader(imgStr, true);
            string url = reader.ReadToEnd();
            output.Text = url;*/
            Image1.ImageUrl = "http://neptune.fulton.ad.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/" + verify;


            /*var drawImg = System.Drawing.Image.FromStream(imgStr);
            drawImg.Save("img.jpg");
            Image1.Attributes.Add("src", "img.jpg");*/
        }
    }
}