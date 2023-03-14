using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTask.Models.DTO.Programs
{

    public class ProgramCreateDto
    {

        [Required]
        public string Title { get; set; }

        public string Summary { get; set; }

        [Required]
        public string Description { get; set; }

        [NotMapped]
        public List<Skills> Skills { get; set; }

        //public string[] Skills { get; set; }


        public string Benefits { get; set; }

        public string Criteria { get; set; }

        [Required]
        public string ProgramType { get; set; }

        public DateTime? ProgramStart { get; set; }

        [Required]
        public DateTime ApplicationOpen { get; set; }

        [Required]
        public DateTime ApplicationClose { get; set; }

        public string Duration { get; set; }

        [Required]
        public string Location { get; set; }

        public string MinQualification { get; set; }

        public int MaxApplication { get; set; }
    }

    public class ProgramDto
    {
        public string? Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Summary { get; set; }

        [Required]
        public string Description { get; set; }

        //[NotMapped]
        public List<Skills> Skills { get; set; }
        //public string[] Skills { get; set; }

        public string Benefits { get; set; }

        public string Criteria { get; set; }

        [Required]
        public string ProgramType { get; set; }

        public DateTime? ProgramStart { get; set; }

        [Required]
        public DateTime ApplicationOpen { get; set; }

        [Required]
        public DateTime ApplicationClose { get; set; }

        public string Duration { get; set; }

        [Required]
        public string Location { get; set; }

        public string MinQualification { get; set; }

        public int MaxApplication { get; set; }
    }

    public class Skills
    {
        public string Skill { get; set; }
    }
}
