using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductQuery
{
    public partial class QueryPage : System.Web.UI.Page
    {
        private static bool IsHiddenPerform = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsHiddenPerform)
                return;

            HiddenControls();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (!div2.Visible)
            {
                div2.Visible = true;
                TextBox2.Visible = true;
                return;
            }
            if (!div3.Visible)
            {
                div3.Visible = true;
                TextBox3.Visible = true;
                return;
            }
            if (!div4.Visible)
            {
                div4.Visible = true;
                TextBox4.Visible = true;
                return;
            }
            if (!div5.Visible)
            {
                div5.Visible = true;
                TextBox5.Visible = true;
                return;
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (div5.Visible)
            {
                div5.Visible = false;
                TextBox5.Visible = false;
                return;
            }
            if (div4.Visible)
            {
                div4.Visible = false;
                TextBox4.Visible = false;
                return;
            }
            if (div3.Visible)
            {
                div3.Visible = false;
                TextBox3.Visible = false;
                return;
            }
            if (div2.Visible)
            {
                div2.Visible = false;
                TextBox2.Visible = false;
                return;
            }
        }

        private void HiddenControls()
        {
            div2.Visible = false;
            div3.Visible = false;
            div4.Visible = false;
            div5.Visible = false;
            TextBox2.Visible = false;
            TextBox3.Visible = false;
            TextBox4.Visible = false;
            TextBox5.Visible = false;
            IsHiddenPerform = true;
        }
    }
}