using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Sifon.Abstractions.Profiles;
using Sifon.Shared.Statics;

namespace Sifon.Shared.Extensions.Models
{
    public static class ContainerProfileExtensions
    {
        public static void Parse(this IContainerProfile profile, XmlNode node)
        {
            profile.Selected = node.BoolAttribute(Settings.Xml.Attributes.Selected);

            profile.ProfileName = node.ChildNodes.GetTextValue(Settings.Xml.ContainerProfile.ProfileName, Settings.Xml.Attributes.Value);
            profile.Repository = node.ChildNodes.GetTextValue(Settings.Xml.ContainerProfile.Repository, Settings.Xml.Attributes.Value);
            profile.Folder = node.ChildNodes.GetTextValue(Settings.Xml.ContainerProfile.Folder, Settings.Xml.Attributes.Value);
            profile.AdminPassword = node.ChildNodes.GetTextValue(Settings.Xml.ContainerProfile.AdminPassword, Settings.Xml.Attributes.Value);
            profile.SaPassword = node.ChildNodes.GetTextValue(Settings.Xml.ContainerProfile.SaPassword, Settings.Xml.Attributes.Value);
        }

        public static XElement Save(this IContainerProfile profile)
        {
            var root = new XElement(Settings.Xml.ContainerProfile.NodeName);
            if (profile.Selected)
            {
                root.SetAttributeValue(Settings.Xml.Attributes.Selected, true);
            }

            var profileName = new XElement(Settings.Xml.ContainerProfile.ProfileName);
            profileName.SetAttributeValue(Settings.Xml.Attributes.Value, profile.ProfileName);
            root.Add(profileName);

            var repository = new XElement(Settings.Xml.ContainerProfile.Repository);
            repository.SetAttributeValue(Settings.Xml.Attributes.Value, profile.Repository);
            root.Add(repository);

            var folder = new XElement(Settings.Xml.ContainerProfile.Folder);
            folder.SetAttributeValue(Settings.Xml.Attributes.Value, profile.Folder);
            root.Add(folder);

            var adminPassword = new XElement(Settings.Xml.ContainerProfile.AdminPassword);
            adminPassword.SetAttributeValue(Settings.Xml.Attributes.Value, profile.AdminPassword);
            root.Add(adminPassword);

            var saPassword = new XElement(Settings.Xml.ContainerProfile.SaPassword);
            saPassword.SetAttributeValue(Settings.Xml.Attributes.Value, profile.SaPassword);
            root.Add(saPassword);

            return root;
        }
    }
}
