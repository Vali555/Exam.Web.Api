using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Common.DTOs
{
    public class ClassDto
    {
        public Guid Id { get; set; }= Guid.NewGuid();
  
        public int Number { get; set; }
    }
}
