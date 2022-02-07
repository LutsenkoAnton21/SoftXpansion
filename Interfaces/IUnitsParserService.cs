using SoftXpansion.Models;
using System.Collections.Generic;
using System.Xml;

namespace SoftXpansion.Interfaces
{
    public interface IUnitsParserService
    {
        List<Unit> ParseUnits(XmlDocument document);
        
        Unit ParseUnit(XmlNode unitNodeode);

        Employee ParseEmployee(XmlNode employeeNode);
    }
}