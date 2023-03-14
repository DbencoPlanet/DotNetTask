using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTask.Models.DTO.Workflows
{
    public class WorkflowDto
    {
        public string Id { get; set; }
        public string ProgramId { get; set; }
        public string StageName { get; set; }

        public bool ShowHide { get; set; }

        public List<VideoQuestionDto> VideoInterview { get; set; }
    }


    public class VideoQuestionDto
    {

        public string VideoBase64String { get; set; }
        public string? VideoUrl { get; set; }
        public string Question { get; set; }
        public string AdditionalInfo { get; set; }
        public string MaxDuration { get; set; }
        public string InMinSecs { get; set; }
        public int SubmissionDeadline { get; set; }
    }
}
