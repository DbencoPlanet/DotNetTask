using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTask.Models.Programs
{
    public class ProgramModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }


        [JsonProperty("skills")]
        //public string[] Skills { get; set; }

        //[NotMapped]
        public List<Skills> Skills { get; set; }

        [JsonProperty("benefits")]
        public string Benefits { get; set; }


        [JsonProperty("criteria")]
        public string Criteria { get; set; }

        [JsonProperty("programtype")]
        public string ProgramType { get; set; }


        [JsonProperty("programstart")]
        public DateTime? ProgramStart { get; set; }


        [JsonProperty("applicationopen")]
        public DateTime ApplicationOpen { get; set; }


        [JsonProperty("applicationclose")]
        public DateTime ApplicationClose { get; set; }


        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }


        [JsonProperty("minqulaification")]
        public string MinQualification { get; set; }


        [JsonProperty("maxapplication")]
        public int MaxApplication { get; set; }
    }

    public class Skills
    {
        public string Skill { get; set; }
    }
}
