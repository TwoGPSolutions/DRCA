using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DropBox
{
    public partial class Messages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s;
            try
            {
                s = Request.QueryString["msg"];
            }
            catch (Exception ex)
            {
                s = null;
            }

            if (s != null)
            {
                DataAccess.SaveData("insert into msgdb(MAC_ID, mTime, mContent) values('" + System.Net.IPAddress.Any.ToString() + "','" + DateTime.Now.ToShortTimeString() + "','" + s + "')");
                GridView1.DataBind();
            }
        }
        
    }
}