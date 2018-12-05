using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace CSE445Project5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(ViewState["keepLogged"] == null || ViewState["keepLogged"] == "false")
            //    FormsAuthentication.SignOut();
        }


        //All simple redirection to show functionality of implemented components.
        //For member or staff page, the user will be sent to Login.aspx if they are not already signed in
        protected void MemPageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Member/Member.aspx");
        }

        protected void StaffPageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Staff/Staff.aspx");
        }

        protected void MemRegButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }
    }
}