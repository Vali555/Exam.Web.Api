using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Common.DTOs
{
    public class LessonResponseDto
    {
        public Guid Id { get; set; }
        public string LessonCode { get; set; }
        public string LessonName { get; set; }
        public Guid ClassId { get; set; }
        public string ClassNumber { get; set; }
        public Guid TeacherId { get; set; }

        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
    }
}
