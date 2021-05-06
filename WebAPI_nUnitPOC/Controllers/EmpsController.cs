using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_nUnitPOC.Data;
using WebAPI_nUnitPOC.Services;

namespace WebAPI_nUnitPOC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmpsController : ControllerBase
    {
        EmpService empService = new();
        public EmpsController() { }

        [HttpGet]
        public List<Emp> GetEmps()
        {
            return empService.GetEmps();
        }

        [HttpGet]
        public int GetCountOfEmps()
        {
            return empService.GetCountOfEmps();
        }

        [HttpGet("{id}")]
        public Emp GetEmp(int id)
        {
            return empService.GetEmp(id);
        }

        [HttpPut("{id}")]
        public async Task<List<Emp>> PutEmp(int id, Emp e)
        {
            if (id != e.id)
                return null;

            return await empService.PutEmp(id, e);
        }

        [HttpPost]
        public async Task<int> PostEmp(Emp e)
        {
            return await empService.PostEmp(e);
        }

        [HttpDelete("{id}")]
        public async Task<List<Emp>> DeleteEmp(int id)
        {
            return await empService.DeleteEmp(id);
        }
    }
}
