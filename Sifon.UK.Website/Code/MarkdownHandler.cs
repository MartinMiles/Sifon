using System.IO;

namespace System.Web.Handlers
{
    public class MarkdownHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("<!DOCTYPE html>");
            context.Response.Write("<html>");
            context.Response.Write("<xmp theme=\"united\" style=\"display:none;\">");
            context.Response.Write(File.ReadAllText(context.Request.PhysicalPath));
            context.Response.Write("</xmp>");
            context.Response.Write("<script src=\"http://strapdownjs.com/v/0.2/strapdown.js\"></script>");
            context.Response.Write("</html>");
        }

        public bool IsReusable => true;
    }
}