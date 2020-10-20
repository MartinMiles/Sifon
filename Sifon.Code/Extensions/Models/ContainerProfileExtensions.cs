using System.Xml;
using System.Xml.Linq;
using Sifon.Abstractions.Profiles;
using Sifon.Code.Statics;

namespace Sifon.Code.Extensions.Models
{
    public static class ContainerProfileExtensions
    {
        public static void Parse(this IContainerProfile profile, XmlNode node)
        {
            profile.Selected = node.BoolAttribute(Xml.Attributes.Selected);

            profile.ProfileName = node.ChildNodes.GetTextValue(Xml.ContainerProfile.ProfileName, Xml.Attributes.Value);
            profile.Repository = node.ChildNodes.GetTextValue(Xml.ContainerProfile.Repository, Xml.Attributes.Value);
            profile.Folder = node.ChildNodes.GetTextValue(Xml.ContainerProfile.Folder, Xml.Attributes.Value);
            profile.AdminPassword = node.ChildNodes.GetTextValue(Xml.ContainerProfile.AdminPassword, Xml.Attributes.Value);
            profile.SaPassword = node.ChildNodes.GetTextValue(Xml.ContainerProfile.SaPassword, Xml.Attributes.Value);
        }

        public static XElement Save(this IContainerProfile profile)
        {
            var root = new XElement(Xml.ContainerProfile.NodeName);
            if (profile.Selected)
            {
                root.SetAttributeValue(Xml.Attributes.Selected, true);
            }

            var profileName = new XElement(Xml.ContainerProfile.ProfileName);
            profileName.SetAttributeValue(Xml.Attributes.Value, profile.ProfileName);
            root.Add(profileName);

            var repository = new XElement(Xml.ContainerProfile.Repository);
            repository.SetAttributeValue(Xml.Attributes.Value, profile.Repository);
            root.Add(repository);

            var folder = new XElement(Xml.ContainerProfile.Folder);
            folder.SetAttributeValue(Xml.Attributes.Value, profile.Folder);
            root.Add(folder);

            var adminPassword = new XElement(Xml.ContainerProfile.AdminPassword);
            adminPassword.SetAttributeValue(Xml.Attributes.Value, profile.AdminPassword);
            root.Add(adminPassword);

            var saPassword = new XElement(Xml.ContainerProfile.SaPassword);
            saPassword.SetAttributeValue(Xml.Attributes.Value, profile.SaPassword);
            root.Add(saPassword);

            return root;
        }
    }
}
