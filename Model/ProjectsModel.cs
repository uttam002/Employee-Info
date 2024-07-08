using Employee_Info.Data;

namespace Employee_Info.Model
{
    public class ProjectsModel
    {
        public int P_Id { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string ProjectDescription { get; set; } = string.Empty;
        public bool Status { get; set; } = false;
        public int empId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
