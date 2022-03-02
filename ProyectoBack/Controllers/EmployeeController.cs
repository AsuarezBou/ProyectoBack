using Microsoft.AspNetCore.Mvc;
using ProyectoBack.Domain.Models;
using ProyectoBack.Infrastructure.Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        db dbop = new db();
        string msg = string.Empty;
        // GET: api/<EmployeeController>
        [HttpGet]
        public List<Employee> Get()
        {
            Employee emp = new Employee();
            emp.TYPE = "get";
            DataSet ds = dbop.EmployeeGet(emp, out msg);
            List<Employee> list = new List<Employee>();
            foreach (DataRow dr in ds.Tables[0].Rows) 
            {
                list.Add(new Employee
                {
                    ID = Convert.ToInt32(dr["ID"]),
                    EMAIL = dr["EMAIL"].ToString(),
                    EMP_NAME = dr["EMP_NAME"].ToString(),
                    DESIGNATION = dr["DESIGNATION"].ToString()
                });
            }

            return list;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public List<Employee> Get(int id)
        {
            Employee emp = new Employee();
            emp.ID = id;
            emp.TYPE = "getid";
            DataSet ds = dbop.EmployeeGet(emp, out msg);
            List<Employee> list = new List<Employee>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Employee
                {
                    ID = Convert.ToInt32(dr["ID"]),
                    EMAIL = dr["EMAIL"].ToString(),
                    EMP_NAME = dr["EMP_NAME"].ToString(),
                    DESIGNATION = dr["DESIGNATION"].ToString()
                });
            }

            return list;
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public string Post([FromBody] Employee emp)
        {
            string msg = string.Empty;

            try
            {
                msg = dbop.EmployeeOpt(emp);
            }
            catch (Exception ex)
            {

                msg = ex.Message;
            }

            return msg;
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public string Update(int id,[FromBody] Employee emp)
        {
            string msg = string.Empty;
            emp.ID = id;

            try
            {
                msg = dbop.EmployeeOpt(emp);
            }
            catch (Exception ex)
            {

                msg = ex.Message;
            }

            return msg;
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            string msg = string.Empty;

            try
            {
                Employee emp = new Employee();
                emp.ID = id;
                emp.TYPE = "delete";
                msg = dbop.EmployeeOpt(emp);
            }
            catch (Exception ex)
            {

                msg = ex.Message;
            }

            return msg;
        }
    }
}
