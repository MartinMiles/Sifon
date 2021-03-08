using System.Windows.Forms;

namespace Sifon.Forms.Install
{
    partial class Install
    {
        protected override void SetTooltips()
        {
            new ToolTip().SetToolTip(buttonSetDefaults, "This will set default settings for a local Sitecore XP0 installation. However, please check carefully before clicking 'Install'");
            new ToolTip().SetToolTip(buttonInstall, "This button will validate your settings and process with the local or remoted installation, as configured. This will take around 12 minutes.");

            new ToolTip().SetToolTip(comboVersions, "These are versions of Sitecore available for the download and installation");
            new ToolTip().SetToolTip(installPrerequisites, "Check this to ensure all the prerequisites for Sitecore get installed. \nYou may uncheck it if that has been already done, i.e. for a repetative installation");
            new ToolTip().SetToolTip(createSifonProfile, "Check this to automatically create a profile in Sifon so that you don't need configuring it manually");

            new ToolTip().SetToolTip(createSifonProfile, "Remote machine hostname or IP address where you want to install Sitecore. It uses WinRM and you may need enable prior to using it");
            new ToolTip().SetToolTip(buttonTestRemoting, "An immediate test if your remote machine hostname / IP address and credentials are valid");

            new ToolTip().SetToolTip(prefixText, "This is you instance prefix. It will also prefix databases and Solr cores");
            new ToolTip().SetToolTip(sitecoreSiteText, "The hostname to be used for Sitecore site");

            new ToolTip().SetToolTip(sqlServerText, "SQL Server instance as it is accessible from local or remote machine (depending on what is set in the Remoting section");
            new ToolTip().SetToolTip(solrUrlText, "Solr server as it is accessible from local or remote machine (depending on what is set in the Remoting section)");

            new ToolTip().SetToolTip(buttonTestSQL, "An immediate test if SQL Server is available from local or remote machine (depending on what is set in the Remoting section)");
            new ToolTip().SetToolTip(buttonTestSolr, "An immediate test if Solr server is available from local or remote machine (depending on what is set in the Remoting section)");

            new ToolTip().SetToolTip(linkRevealRemoting, "Reveal the hidden password in this field");
            new ToolTip().SetToolTip(revealSitecoreAdminPassword, "Reveal the hidden password in this field");
            new ToolTip().SetToolTip(linkRevealSqlPassword, "Reveal the hidden password in this field");
        }
    }
}
