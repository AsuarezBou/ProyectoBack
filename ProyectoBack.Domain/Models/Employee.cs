using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Domain.Models
{
    public class Employee
    {
        public int ID { get; set; } = 0;
        public string EMAIL { get; set; } = "";
        public string EMP_NAME { get; set; } = "";
        public string DESIGNATION { get; set; } = "";
        public string TYPE { get; set; } = "";
        public DateTime CREATED_DATE { get; set; }
    }
}
