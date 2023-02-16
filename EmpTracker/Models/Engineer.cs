using System.ComponentModel.DataAnnotations;

namespace EmpTracker.Models
{
    public class Engineer
    {
        [Key]
        public Guid EngineerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsWorking { get; set; }
        public WorkLocation? WorkingLocation { get; set; }

        public Engineer()
        {
            EngineerId = Guid.NewGuid();
            FirstName = "";
            LastName = "";
            IsWorking = true;
        }

    }
}
