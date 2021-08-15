using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Models
{
    public enum WorkerStatus
    {
        Unsigned,
        Working,
        Fired,
        TemprorayNotWorking
    }

    public enum EducationType
    {
        Unsigned,
        HighSchool,
        UniversityBachalor,
        UniversityMaster,
        UniversityPhd,
        UniversityHigherThanPhd
    }

    public class Worker
    {
        //[Key()]
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First name can not be empty"), MinLength(length: 3, ErrorMessage = "First name must be at least 3 symbols"), MaxLength(length: 20, ErrorMessage = "First name must be at most 20 symbols")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name can not be empty"), MinLength(length: 3, ErrorMessage = "Last name must be at least 3 symbols"), MaxLength(length: 20, ErrorMessage = "Last name must be at most 20 symbols")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Full Name")]
        public string FullName { get => string.Concat(FirstName, " ", LastName); }

        [DataType(DataType.Date, ErrorMessage = "Birth date can not be empty")]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Position can not be empty"), MinLength(length: 3, ErrorMessage = "Position must be at least 3 symbols"), MaxLength(length: 20, ErrorMessage = "Position must be at most 20 symbols")]
        [DisplayName("Position")]
        public string Position { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Hire date can not be empty")]
        [DisplayName("Hire Date")]
        public DateTime HireDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Fire Date")]
        public DateTime? FireDate { get; set; }

        [Required]
        [DisplayName("Worker Status")]
        public WorkerStatus WorkerStatus { get; set; }

        [Required]
        [DisplayName("Education Type")]
        public EducationType EducationType { get; set; }

        public Worker()
        {

        }
    }
}
