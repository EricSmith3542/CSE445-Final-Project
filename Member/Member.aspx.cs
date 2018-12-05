using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSE445Project5.Member
{
    public partial class Member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Label1"] != null)
                this.Label1.Text = Session["Label1"].ToString();

            if(Session["Label2"] != null)
                this.Label2.Text = Session["Label2"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //stemming service functionality
            StemmingReference.Service1Client stemmref = new StemmingReference.Service1Client();
            string val = this.TextBox1.Text;
            string result = stemmref.Stemming(val);
            this.Label1.Text = result;
            Session["Label1"] = result;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //num2words service functionality
            WordsReference.Service1Client wordsref = new WordsReference.Service1Client();
            string val = this.TextBox2.Text;
            string result = wordsref.define(val);
            this.Label2.Text = result;
            Session["Label2"] = result;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //stemming service functionality
            StemmingReference.Service1Client stemmref = new StemmingReference.Service1Client();
            string val = this.TextBox1.Text;
            string result = stemmref.Stemming(val);
            this.Label1.Text = result;
            Session["Label1"] = result;
        }
    }
}