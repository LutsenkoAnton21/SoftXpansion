using System.Collections.Generic;

namespace SoftXpansion.Models
{
    public class Unit
    {
        public string Id { get; set; }
        
        public string Title { get; set; }
        
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
