using DotNetTask.Models.Programs;
using DotNetTask.Models.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTask.Application.Services
{
    public interface IWorkflowService
    {
        Task<IEnumerable<WorkflowModel>> GetMultipleAsync(string query);
        Task<WorkflowModel> GetAsync(string id);
        Task AddAsync(WorkflowModel item);
        Task UpdateAsync(string id, WorkflowModel item);
        Task DeleteAsync(string id);
    }
}
