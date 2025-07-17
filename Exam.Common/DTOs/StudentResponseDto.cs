using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Common.DTOs
{
    public class StudentResponseDto
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid ClassId { get; set; }
        public int ClassNumber { get; set; }
    }
}
