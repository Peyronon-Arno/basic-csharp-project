using Bibliotheque.entity;
using System.Linq;

namespace WebApplication.Models
{
    public class EmployeeDetails
    {
        public EmployeeDetails() { }
        public EmployeeDetails(Employe employe, IQueryable experiences) {
            Employe = employe;
            Experiences = experiences;
        }

        public Employe Employe { get; set; }
        public IQueryable Experiences { get; set; }
    }
}