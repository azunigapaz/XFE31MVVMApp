using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XFE31MVVMApp.Models;

namespace XFE31MVVMApp.Services
{
    public interface IEmpleadoRepository
    {
        Task<bool> AddEmpleadoAsync(EmpleadoInfo empledoInfo);
        Task<bool> UpdateEmpleadoAsync(EmpleadoInfo empledoInfo);
        Task<bool> DeteleEmpleadoAsync(int id);
        Task<EmpleadoInfo> GetEmpleadoAsync(int id);
        Task<IEnumerable<EmpleadoInfo>> GetEmpleadosAsync();
    }
}
