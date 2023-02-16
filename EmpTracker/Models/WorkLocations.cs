using System.ComponentModel.DataAnnotations;

namespace EmpTracker.Models
{
    public class WorkLocation
    {
        [Key]
        public Guid WorkLocationId { get; set; }
        public string Name { get; set; }
        public List<Engineer> Engineers { get; set; }
        
        public WorkLocation()
        {
            WorkLocationId = Guid.NewGuid();
            Name = "";
            Engineers = new List<Engineer>();
        }

    }
}
