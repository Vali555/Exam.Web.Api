using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Common.DTOs
{
    public class LessonRequestDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string LessonCode { get; set; }
        public string LessonName { get; set; }
        public Guid ClassId { get; set; }
        public Guid TeacherId { get; set; }
    }
}
