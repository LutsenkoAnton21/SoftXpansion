using SoftXpansion.Interfaces;
using System.Xml;

namespace SoftXpansion.Services
{
    public class XmlService : IXmlService
    {
        public XmlDocument LoadXml(string filePath)
        {
            var document = new XmlDocument();
            document.Load(filePath);
            return document;
        }
    }
}
