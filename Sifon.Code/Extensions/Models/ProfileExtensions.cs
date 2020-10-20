using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Sifon.Abstractions.Encryption;
using Sifon.Abstractions.Profiles;
using Sifon.Code.Providers.Profile;
using Sifon.Code.Statics;

namespace Sifon.Code.Extensions.Models
{
    public static class ProfileExtensions
    {
        public static ISqlServerRecord GetSqlProfile(this IProfile profile)
        {
            return new SqlServerRecordProvider().GetByName(profile.SqlServer);
        }

        public static void Parse(this IProfile profile, XmlNode node, IEncryptor encryptor)
        {
            profile.Selected = node.BoolAttribute(Xml.Attributes.Selected);
            profile.Empty = node.BoolAttribute(Xml.Attributes.Empty);

            profile.RemotingEnabled = node.BoolAttribute(Xml.Attributes.RemotingEnabled);
            profile.RemoteHost = node.ChildNodes.GetTextValue(Xml.Profile.RemoteExecutionHost, Xml.Attributes.Value);
            profile.RemoteUsername = node.ChildNodes.GetTextValue(Xml.Profile.RemoteUsername, Xml.Attributes.Value);
            profile.RemotePassword = encryptor.Decrypt(node.ChildNodes.GetTextValue(Xml.Profile.RemotePassword, Xml.Attributes.Value));
            profile.RemoteFolder = node.ChildNodes.GetTextValue(Xml.Profile.RemoteFolder, Xml.Attributes.Value);
            profile.ProfileName = node.ChildNodes.GetTextValue(Xml.Profile.Name, Xml.Attributes.Value);
            profile.Prefix = node.ChildNodes.GetTextValue(Xml.Profile.Prefix, Xml.Attributes.Value);
            profile.AdminUsername = node.ChildNodes.GetTextValue(Xml.Profile.AdminUsername, Xml.Attributes.Value);
            profile.AdminPassword = encryptor.Decrypt(node.ChildNodes.GetTextValue(Xml.Profile.AdminPassword, Xml.Attributes.Value));
            profile.Webroot = node.ChildNodes.GetTextValue(Xml.Profile.Webroot, Xml.Attributes.Value);
            profile.Website = node.ChildNodes.GetTextValue(Xml.Profile.Website, Xml.Attributes.Value);
            profile.Solr = node.ChildNodes.GetTextValue(Xml.Profile.Solr, Xml.Attributes.Value);
            profile.SqlServer = node.ChildNodes.GetTextValue(Xml.Profile.SqlServer, Xml.Attributes.Value);
            profile.Parameters = ReadParameters(node.ChildNodes);
        }
        
        private static Dictionary<string, string> ReadParameters(XmlNodeList childNodes)
        {
            var parameters = new Dictionary<string, string>();
            var parametersNode = childNodes.Cast<XmlNode>().FirstOrDefault(n => n.Name == Xml.Profile.Parameters);
            if (parametersNode != null)
            {
                foreach (var xmlNode in parametersNode.ChildNodes.Cast<XmlNode>())
                {
                    parameters.Add(xmlNode.Attributes[Xml.Attributes.Name].Value, xmlNode.FirstChild.Value);
                }
            }

            return parameters;
        }

        public static XElement Save(this IProfile profile, IEncryptor encryptor)
        {
            var root = new XElement(Xml.Profile.NodeName);
            if (profile.Selected)
            {
                root.SetAttributeValue(Xml.Attributes.Selected, true);
            }

            if (profile.Empty)
            {
                root.SetAttributeValue(Xml.Attributes.Empty, true);
            }

            if (profile.RemotingEnabled)
            {
                root.SetAttributeValue(Xml.Attributes.RemotingEnabled, profile.RemotingEnabled);
            }

            var remoteHost = new XElement(Xml.Profile.RemoteExecutionHost);
            remoteHost.SetAttributeValue(Xml.Attributes.Value, profile.RemoteHost);
            root.Add(remoteHost);

            var remoteUsername = new XElement(Xml.Profile.RemoteUsername);
            remoteUsername.SetAttributeValue(Xml.Attributes.Value, profile.RemoteUsername);
            root.Add(remoteUsername);

            var remotePassword = new XElement(Xml.Profile.RemotePassword);
            remotePassword.SetAttributeValue(Xml.Attributes.Value, encryptor.Encrypt(profile.RemotePassword));
            root.Add(remotePassword);

            var remoteFolder = new XElement(Xml.Profile.RemoteFolder);
            remoteFolder.SetAttributeValue(Xml.Attributes.Value, profile.RemoteFolder);
            root.Add(remoteFolder);

            var name = new XElement(Xml.Profile.Name);
            name.SetAttributeValue(Xml.Attributes.Value, profile.ProfileName);
            root.Add(name);

            var prefix = new XElement(Xml.Profile.Prefix);
            prefix.SetAttributeValue(Xml.Attributes.Value, profile.Prefix);
            root.Add(prefix);

            var adminUsername = new XElement(Xml.Profile.AdminUsername);
            adminUsername.SetAttributeValue(Xml.Attributes.Value, profile.AdminUsername);
            root.Add(adminUsername);

            var adminPassword = new XElement(Xml.Profile.AdminPassword);
            adminPassword.SetAttributeValue(Xml.Attributes.Value, encryptor.Encrypt(profile.AdminPassword));
            root.Add(adminPassword);

            var website = new XElement(Xml.Profile.Website);
            website.SetAttributeValue(Xml.Attributes.Value, profile.Website);
            root.Add(website);

            var webroot = new XElement(Xml.Profile.Webroot);
            webroot.SetAttributeValue(Xml.Attributes.Value, profile.Webroot);
            root.Add(webroot);

            var solr = new XElement(Xml.Profile.Solr);
            solr.SetAttributeValue(Xml.Attributes.Value, profile.Solr);
            root.Add(solr);

            var sqlServer = new XElement(Xml.Profile.SqlServer);
            sqlServer.SetAttributeValue(Xml.Attributes.Value, profile.SqlServer);
            root.Add(sqlServer);

            var parameters = new XElement(Xml.Profile.Parameters);
            foreach (var item in profile.Parameters ?? new Dictionary<string, string>())
            {
                var parameter = new XElement(Xml.Profile.Parameter);
                parameter.SetAttributeValue(Xml.Attributes.Name, item.Key);
                parameter.SetValue(item.Value);
                parameters.Add(parameter);
            }
            root.Add(parameters);

            return root;
        }
    }
}
