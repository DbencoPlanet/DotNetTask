using DotNetTask.Models.Programs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTask.Application.Services
{
    public interface IProgramService
    {
        Task<IEnumerable<ProgramModel>> GetMultipleAsync(string query);
        Task<ProgramModel> GetAsync(string id);
        Task AddAsync(ProgramModel item);
        Task UpdateAsync(string id, ProgramModel item);
        Task DeleteAsync(string id);
    }
}
