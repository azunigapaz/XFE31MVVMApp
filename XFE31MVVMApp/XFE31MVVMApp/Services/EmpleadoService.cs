using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XFE31MVVMApp.Models;

namespace XFE31MVVMApp.Services
{
    public class EmpleadoService : IEmpleadoRepository
    {
        public SQLiteAsyncConnection _database;
        public EmpleadoService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<EmpleadoInfo>().Wait();

        }
        public async Task<bool> AddEmpleadoAsync(EmpleadoInfo empledoInfo)
        {
            if(empledoInfo.EmpledoId > 0)
            {
                await _database.UpdateAsync(empledoInfo);
            }
            else
            {
                await _database.InsertAsync(empledoInfo);
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeteleEmpleadoAsync(int id)
        {
            await _database.DeleteAsync<EmpleadoInfo>(id);
            return await Task.FromResult(true);
        }

        public async Task<EmpleadoInfo> GetEmpleadoAsync(int id)
        {
            return await _database.Table<EmpleadoInfo>().Where(e => e.EmpledoId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<EmpleadoInfo>> GetEmpleadosAsync()
        {
            return await Task.FromResult(await _database.Table<EmpleadoInfo>().ToListAsync());
        }

        public Task<bool> UpdateEmpleadoAsync(EmpleadoInfo empledoInfo)
        {
            throw new NotImplementedException();
        }
    }
}
