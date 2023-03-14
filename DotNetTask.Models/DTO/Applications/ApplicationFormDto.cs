using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTask.Models.DTO.Applications
{
    public class ApplicationFormDto
    {
        public string Id { get; set; }

        public string ProgramId { get; set; }

        public string CoverPhotoBase64String { get; set; }

        public List<PersonalInfoDto> PersonalInformation { get; set; }

        public List<ProfileInfoDto> Profile { get; set; }

        public List<AdditionalQuestionDto> AdditionalQuestion { get; set; }
    }

    public class PersonalInfoDto
    {
        public string Name { get; set; }

        public bool Internal { get; set; }

        public bool ShowHide { get; set; }
    }


    public class ProfileInfoDto
    {

        public string Name { get; set; }

        public bool Mandatory { get; set; }

        public bool ShowHide { get; set; }
    }

    public class AdditionalQuestionDto
    {

        public string Question { get; set; }

        public List<QuestionChoiceDto> Choice { get; set; }

    }

    public class QuestionChoiceDto
    {
        public string Type { get; set; }


    }
}
