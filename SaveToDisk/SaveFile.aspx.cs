using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Playground
{
    public partial class SaveFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            string msg = "Hello";
            ms.Write(Encoding.UTF8.GetBytes(msg), 0, msg.Length);
            SaveAsPopup(ms, "text/plain", "Hello.txt");
        }

        internal void SaveAsPopup(MemoryStream stm, string mimeType, string fileName)
        {
            this.Response.Buffer = true;
            this.Response.Clear();
            this.Response.ContentType = mimeType;
            this.Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
            stm.WriteTo(this.Response.OutputStream);
            this.Response.Flush();
            this.Response.End();
        }
    }
}