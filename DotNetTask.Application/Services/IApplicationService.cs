using DotNetTask.Models.Applications;
using DotNetTask.Models.Programs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTask.Application.Services
{
    public interface IApplicationService
    {
        Task<IEnumerable<ApplicationFormModel>> GetMultipleAsync(string query);
        Task<ApplicationFormModel> GetAsync(string id);
        Task AddAsync(ApplicationFormModel item);
        Task UpdateAsync(string id, ApplicationFormModel item);
        Task DeleteAsync(string id);
    }
}
