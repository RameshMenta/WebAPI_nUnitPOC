using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_nUnitPOC.Data
{
    public class EmpsList
    {
        public List<Emp> GetDefaultEmpsList()
        {
            return new List<Emp>()
            {
                new Emp { id = 1, name = "Name1", age = 20, salary = 1000 },
                new Emp { id = 2, name = "Name2", age = 30, salary = 2000 },
                new Emp { id = 3, name = "Name3", age = 40, salary = 3000 }
            };
        }
    }
}
