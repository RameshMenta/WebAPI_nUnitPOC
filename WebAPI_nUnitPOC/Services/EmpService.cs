using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_nUnitPOC.Data;

namespace WebAPI_nUnitPOC.Services
{
    public class EmpService
    {
        private List<Emp> Emps = new();

        public EmpService()
        {
            EmpsList empsList = new();
            Emps = empsList.GetDefaultEmpsList();
        }

        public List<Emp> GetEmps()
        {
            return Emps;
        }

        public int GetCountOfEmps()
        {
            return Emps.Count();
        }

        public List<Emp> GetEmpsBySalaryGT(decimal salary)
        {
            return Emps.Where(w => w.salary >= salary).ToList();
        }

        public Emp GetEmp(int id)
        {
            return Emps.Where(w => w.id == id).FirstOrDefault();
        }

        public async Task<List<Emp>> PutEmp(int id, Emp e)
        {
            Emps = Emps.Where(w => w.id != id).ToList();
            Emps.Add(e);

            await Task.CompletedTask;
            return Emps;
        }

        public async Task<int> PostEmp(Emp e)
        {
            int NextID = Emps.Max(m => m.id) + 1;
            e.id = NextID;
            Emps.Add(e);

            await Task.CompletedTask;
            return NextID;
        }

        public async Task<List<Emp>> DeleteEmp(int id)
        {
            var e = Emps.Where(w => w.id == id).FirstOrDefault();

            await Task.CompletedTask;
            return Emps;
        }
    }
}
