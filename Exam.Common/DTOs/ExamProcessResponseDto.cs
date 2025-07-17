using Exam.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Common.DTOs
{
    public class ExamProcessResponseDto
    {
        public Guid Id { get; set; }
        public Guid LessonId { get; set; }
        public string LessonCode { get; set; }
        public Guid StudentId { get; set; }
        public int StudentNumber { get; set; }
        public DateTime ExamDate { get; set; }
        public ExamGrade ExamGrade { get; set; }
    }
}
