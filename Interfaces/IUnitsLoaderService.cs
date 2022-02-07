using SoftXpansion.Models;
using System.Collections.Generic;

namespace SoftXpansion.Interfaces
{
    public interface IUnitsLoaderService
    {
        List<Unit> LoadUnits(string filePath);
    }
}