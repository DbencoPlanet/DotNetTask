using AutoMapper;
using DotNetTask.Models.Applications;
using DotNetTask.Models.DTO.Applications;
using DotNetTask.Models.DTO.Programs;
using DotNetTask.Models.DTO.Workflows;
using DotNetTask.Models.Programs;
using DotNetTask.Models.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTask.Application.MapProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Program Mapping
            CreateMap<ProgramModel, ProgramDto>().ReverseMap();
            CreateMap<ProgramModel, ProgramCreateDto>().ReverseMap();
            CreateMap<Models.DTO.Programs.Skills, Models.Programs.Skills>().ReverseMap();
            #endregion Program Mapping

            #region Application Form Mapping
            CreateMap<ApplicationFormModel, ApplicationFormDto>().ReverseMap();
            CreateMap<PersonalInfo, PersonalInfoDto>().ReverseMap();
            CreateMap<ProfileInfo, ProfileInfoDto>().ReverseMap();
            CreateMap<AdditionalQuestion, AdditionalQuestionDto>().ReverseMap();
            CreateMap<QuestionChoice, QuestionChoiceDto>().ReverseMap();
            #endregion Appliaction Form Mapping


            #region Workflow Mapping
            CreateMap<WorkflowModel, WorkflowDto>().ReverseMap();
            CreateMap<VideoQuestion, VideoQuestionDto>().ReverseMap();
            #endregion Workflow Mapping

        }
    }
}
