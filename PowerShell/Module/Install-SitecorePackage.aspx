<%@ Assembly Name="Sitecore.Client" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Text.RegularExpressions" %>
<%@ Import Namespace="System.Configuration" %>
<%@ Import Namespace="log4net" %>
<%@ Import Namespace="Sitecore.Data.Engines" %>
<%@ Import Namespace="Sitecore.Data.Proxies" %>
<%@ Import Namespace="Sitecore.Install.Files" %>
<%@ Import Namespace="Sitecore.Install.Utils" %>
<%@ Import Namespace="Sitecore.SecurityModel" %>
<%@ Import Namespace="Sitecore.Web" %>
<%@ Import Namespace="Sitecore.Install.Framework" %>
<%@ Import Namespace="Sitecore.Install.Items" %>
<%@ Import Namespace="Sitecore.Install" %>


<%@  Language="C#" Debug="true" %>
<html>
<script runat="server" language="C#">
    public void Page_Load(object s, EventArgs e)
    {
        var files = WebUtil.GetQueryString("modules").Split('|');
        if (files.Length == 0)
        {
            Response.Write("No Modules specified");
            return;
        }
        Sitecore.Context.SetActiveSite("shell");
        using (new SecurityDisabler())
        {
            using (new SyncOperationContext())
            {
                foreach (var file in files)
                {
                    Install(Path.Combine(Sitecore.Shell.Applications.Install.ApplicationContext.PackagePath, file));
                    Response.Write("Installed Package: " + file);
                }
            }
        }
    }

    protected static void Install(string package)
    {
        var log = LogManager.GetLogger("LogFileAppender");
        string result = string.Empty;

        IProcessingContext context = new SimpleProcessingContext();
        IItemInstallerEvents instance = new DefaultItemInstallerEvents(new BehaviourOptions(InstallMode.Merge, MergeMode.Merge));
        context.AddAspect<IItemInstallerEvents>(instance);
        IFileInstallerEvents events = new DefaultFileInstallerEvents(true);
        context.AddAspect<IFileInstallerEvents>(events);

        new Installer().InstallPackage(package, context);
        
        // TODO: Investigate why these two below lines do not work with 10.3 XP
        // The second line responds as: Exception Details: Sitecore.Jobs.AsyncUI.InvalidContextException: Current context is not a job

        // string action = Installer.GetPostStep(context);
        // new Installer().ExecutePostStep(action, context);
    }
</script>
<body>
    <form id="MyForm" runat="server">
    </form>
</body>
</html>
