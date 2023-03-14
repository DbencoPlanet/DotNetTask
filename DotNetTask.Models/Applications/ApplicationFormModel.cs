using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTask.Models.Applications
{
    public class ApplicationFormModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("programid")]
        public string ProgramId { get; set; }

        [JsonProperty("coverphotourl")]
        public string CoverPhotoUrl { get; set; }

        [JsonProperty("personalinformation")]
        public List<PersonalInfo> PersonalInformation { get; set; }

        [JsonProperty("profile")]
        public List<ProfileInfo> Profile { get; set; }

        [JsonProperty("additionalquestion")]
        public List<AdditionalQuestion> AdditionalQuestion { get; set; }
    }

    public class PersonalInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("internal")]
        public bool Internal { get; set; }

        [JsonProperty("showhide")]
        public bool ShowHide { get; set; }
    }


    public class ProfileInfo
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("mandatory")]
        public bool Mandatory { get; set; }

        [JsonProperty("showhide")]
        public bool ShowHide { get; set; }
    }

    public class AdditionalQuestion
    {

        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("choice")]
        public List<QuestionChoice> Choice { get; set; }

    }

    public class QuestionChoice
    {

        [JsonProperty("type")]
        public string Type { get; set; }

       
    }
}
