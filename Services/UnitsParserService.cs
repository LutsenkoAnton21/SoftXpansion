using SoftXpansion.Interfaces;
using SoftXpansion.Models;
using System;
using System.Collections.Generic;
using System.Xml;

namespace SoftXpansion.Services
{
    public class UnitsParserService : IUnitsParserService
    {
        public List<Unit> ParseUnits(XmlDocument document)
        {
            var units = new List<Unit>();

            XmlElement? xRoot = document.DocumentElement;
            var unitNodes = xRoot.ChildNodes;

            foreach (XmlNode unitNode in unitNodes)
            {
                units.Add(ParseUnit(unitNode));
            }

            return units;
        }

        public Unit ParseUnit(XmlNode unitNodeode)
        {
            var unitName = unitNodeode.Attributes["Title"].Value;
            var employeeNodes = unitNodeode.ChildNodes;

            var employees = new List<Employee>();

            foreach (XmlNode employeeNode in employeeNodes)
            {
                employees.Add(ParseEmployee(employeeNode));
            }

            return new Unit
            {
                Id = Guid.NewGuid().ToString(),
                Title = unitName,
                Employees = employees
            };
        }

        public Employee ParseEmployee(XmlNode employeeNode)
        {
            return new Employee
            {
                Id = Guid.NewGuid().ToString(),
                Name = employeeNode.Attributes["Name"].Value,
                Position = employeeNode.Attributes["Position"].Value,
                HireDate = employeeNode.Attributes["HireDate"].Value
            };
        }
    }
}
