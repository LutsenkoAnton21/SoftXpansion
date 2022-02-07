using System.Xml;

namespace SoftXpansion.Interfaces
{
    public interface IXmlService
    {
        XmlDocument LoadXml(string filePath);
    }
}