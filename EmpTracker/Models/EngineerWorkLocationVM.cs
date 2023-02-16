namespace EmpTracker.Models
{
    public class EngineerWorkLocationVM
    {
        public Guid? EngineerId { get; set; }
        public List<WorkLocation>? WorkLocations { get; set; }
        public Guid? WorkLocationId { get; set; }
    }
}
