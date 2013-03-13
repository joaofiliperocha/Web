

	internal static void SaveAsPopup(MemoryStream stm, string mimeType, string fileName)
	{
		this.Response.Buffer = true;
        this.Response.Clear();
        this.Response.ContentType = mimeType;
        this.Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
		stm.WriteTo(this.Response.OutputStream);
        this.Response.Flush();
        this.Response.End();
	}
