using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTask.Models.Workflows
{

    public class WorkflowModel
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("programid")]
        public string ProgramId { get; set; }

        [JsonProperty("stagename")]
        public string StageName { get; set; }

        [JsonProperty("showhide")]
        public bool ShowHide { get; set; }

        [JsonProperty("videointerview")]
        public List<VideoQuestion> VideoInterview { get; set; }
    }


    public class VideoQuestion
    {

        [JsonProperty("videourl")]
        public string VideoUrl { get; set; }

        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("additionalinfo")]
        public string AdditionalInfo { get; set; }


        [JsonProperty("maxduration")]
        public string MaxDuration { get; set; }


        [JsonProperty("inminsecs")]
        public string InMinSecs { get; set; }

        [JsonProperty("submissiondeadline")]
        public int SubmissionDeadline { get; set; }
    }
}
