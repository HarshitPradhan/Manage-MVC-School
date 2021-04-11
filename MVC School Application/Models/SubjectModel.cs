using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_School_Application.Models
{
    public class SubjectModel
    {
        [Required]
        public string id { get; set; }
        public string subname { get; set; }
    }
}
