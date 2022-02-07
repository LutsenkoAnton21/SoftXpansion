using SoftXpansion.Interfaces;
using SoftXpansion.Models;
using System.Collections.Generic;
using System.Xml;

namespace SoftXpansion.Services
{
    public class UnitsLoaderService : IUnitsLoaderService
    {
        private readonly IXmlService xmlService;
        private readonly IUnitsParserService unitsParserService;

        public UnitsLoaderService(IXmlService xmlService, IUnitsParserService unitsParserService)
        {
            this.xmlService = xmlService;
            this.unitsParserService = unitsParserService;
        }

        public List<Unit> LoadUnits(string filePath)
        {
            XmlDocument document = xmlService.LoadXml(filePath);
            return unitsParserService.ParseUnits(document);
        }
    }
}
