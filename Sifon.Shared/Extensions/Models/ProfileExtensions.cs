using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Sifon.Abstractions.Profiles;
using Sifon.Shared.Providers.Profile;
using Sifon.Shared.Statics;

namespace Sifon.Shared.Extensions.Models
{
    public static class ProfileExtensions
    {
        //public static void SetSqlProfile(this IProfile profile, ISqlServerRecord sqlServerRecord)
        //{
        //    var provider = new SqlServerRecordProvider();
        //    provider.Add(sqlServerRecord);
        //    provider.Save();
        //}

        public static ISqlServerRecord GetSqlProfile(this IProfile profile)
        {
            return new SqlServerRecordProvider().GetByName(profile.SqlServer);
        }

        public static void Parse(this IProfile profile, XmlNode node)
        {
            profile.Selected = node.BoolAttribute(Settings.Xml.Attributes.Selected);
            profile.Empty = node.BoolAttribute(Settings.Xml.Attributes.Empty);

            profile.RemotingEnabled = node.BoolAttribute(Settings.Xml.Attributes.RemotingEnabled);
            profile.RemoteExecutionHost = node.ChildNodes.GetTextValue(Settings.Xml.Profile.RemoteExecutionHost, Settings.Xml.Attributes.Value);
            profile.RemoteUsername = node.ChildNodes.GetTextValue(Settings.Xml.Profile.RemoteUsername, Settings.Xml.Attributes.Value);
            profile.RemotePassword = node.ChildNodes.GetTextValue(Settings.Xml.Profile.RemotePassword, Settings.Xml.Attributes.Value);
            profile.RemoteFolder = node.ChildNodes.GetTextValue(Settings.Xml.Profile.RemoteFolder, Settings.Xml.Attributes.Value);
            profile.ProfileName = node.ChildNodes.GetTextValue(Settings.Xml.Profile.Name, Settings.Xml.Attributes.Value);
            profile.Prefix = node.ChildNodes.GetTextValue(Settings.Xml.Profile.Prefix, Settings.Xml.Attributes.Value);
            profile.AdminUsername = node.ChildNodes.GetTextValue(Settings.Xml.Profile.AdminUsername, Settings.Xml.Attributes.Value);
            profile.AdminPassword = node.ChildNodes.GetTextValue(Settings.Xml.Profile.AdminPassword, Settings.Xml.Attributes.Value);
            profile.Webroot = node.ChildNodes.GetTextValue(Settings.Xml.Profile.Webroot, Settings.Xml.Attributes.Value);
            profile.Website = node.ChildNodes.GetTextValue(Settings.Xml.Profile.Website, Settings.Xml.Attributes.Value);
            profile.Solr = node.ChildNodes.GetTextValue(Settings.Xml.Profile.Solr, Settings.Xml.Attributes.Value);
            profile.SqlServer = node.ChildNodes.GetTextValue(Settings.Xml.Profile.SqlServer, Settings.Xml.Attributes.Value);
            profile.Parameters = ReadParameters(node.ChildNodes);
        }
        
        private static Dictionary<string, string> ReadParameters(XmlNodeList childNodes)
        {
            var parameters = new Dictionary<string, string>();
            var parametersNode = childNodes.Cast<XmlNode>().FirstOrDefault(n => n.Name == Settings.Xml.Profile.Parameters);
            if (parametersNode != null)
            {
                foreach (var xmlNode in parametersNode.ChildNodes.Cast<XmlNode>())
                {
                    parameters.Add(xmlNode.Attributes[Settings.Xml.Attributes.Name].Value, xmlNode.FirstChild.Value);
                }
            }

            return parameters;
        }

        public static XElement Save(this IProfile profile)
        {
            var root = new XElement(Settings.Xml.Profile.NodeName);
            if (profile.Selected)
            {
                root.SetAttributeValue(Settings.Xml.Attributes.Selected, true);
            }

            if (profile.Empty)
            {
                root.SetAttributeValue(Settings.Xml.Attributes.Empty, true);
            }

            if (profile.RemotingEnabled)
            {
                root.SetAttributeValue(Settings.Xml.Attributes.RemotingEnabled, profile.RemotingEnabled);
            }

            var remoteHost = new XElement(Settings.Xml.Profile.RemoteExecutionHost);
            remoteHost.SetAttributeValue(Settings.Xml.Attributes.Value, profile.RemoteExecutionHost);
            root.Add(remoteHost);

            var remoteUsername = new XElement(Settings.Xml.Profile.RemoteUsername);
            remoteUsername.SetAttributeValue(Settings.Xml.Attributes.Value, profile.RemoteUsername);
            root.Add(remoteUsername);

            var remotePassword = new XElement(Settings.Xml.Profile.RemotePassword);
            remotePassword.SetAttributeValue(Settings.Xml.Attributes.Value, profile.RemotePassword);
            root.Add(remotePassword);

            var remoteFolder = new XElement(Settings.Xml.Profile.RemoteFolder);
            remoteFolder.SetAttributeValue(Settings.Xml.Attributes.Value, profile.RemoteFolder);
            root.Add(remoteFolder);

            var name = new XElement(Settings.Xml.Profile.Name);
            name.SetAttributeValue(Settings.Xml.Attributes.Value, profile.ProfileName);
            root.Add(name);

            var prefix = new XElement(Settings.Xml.Profile.Prefix);
            prefix.SetAttributeValue(Settings.Xml.Attributes.Value, profile.Prefix);
            root.Add(prefix);

            var adminUsername = new XElement(Settings.Xml.Profile.AdminUsername);
            adminUsername.SetAttributeValue(Settings.Xml.Attributes.Value, profile.AdminUsername);
            root.Add(adminUsername);

            var adminPassword = new XElement(Settings.Xml.Profile.AdminPassword);
            adminPassword.SetAttributeValue(Settings.Xml.Attributes.Value, profile.AdminPassword);
            root.Add(adminPassword);

            var website = new XElement(Settings.Xml.Profile.Website);
            website.SetAttributeValue(Settings.Xml.Attributes.Value, profile.Website);
            root.Add(website);

            var webroot = new XElement(Settings.Xml.Profile.Webroot);
            webroot.SetAttributeValue(Settings.Xml.Attributes.Value, profile.Webroot);
            root.Add(webroot);

            var solr = new XElement(Settings.Xml.Profile.Solr);
            solr.SetAttributeValue(Settings.Xml.Attributes.Value, profile.Solr);
            root.Add(solr);

            var sqlServer = new XElement(Settings.Xml.Profile.SqlServer);
            sqlServer.SetAttributeValue(Settings.Xml.Attributes.Value, profile.SqlServer);
            root.Add(sqlServer);

            var parameters = new XElement(Settings.Xml.Profile.Parameters);
            foreach (var item in profile.Parameters ?? new Dictionary<string, string>())
            {
                var parameter = new XElement(Settings.Xml.Profile.Parameter);
                parameter.SetAttributeValue(Settings.Xml.Attributes.Name, item.Key);
                parameter.SetValue(item.Value);
                parameters.Add(parameter);
            }
            root.Add(parameters);

            return root;
        }
    }
}
