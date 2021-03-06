using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_School_Application.Models
{
    public class ClassModel
    {
        [Required]
        public string id { get; set; }
        public string cls { get; set; }

        public string section { get; set; }

        public DateTime starttime { get; set; }
        public DateTime endtime { get; set; }
    }
}
