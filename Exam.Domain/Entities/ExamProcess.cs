using Exam.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Entities
{
    public class ExamProcess
    {
        [Key]
        public Guid Id { get; set; }
        public Guid LessonId { get; set; }
        public Guid StudentId { get; set; }
        public DateTime ExamDate { get; set; }
        public ExamGrade ExamGrade { get; set; }

        [ForeignKey(nameof(LessonId))]
        public Lesson Lesson { get; set; }
        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; }

        public ExamProcess(Guid id, Guid lessonId, Guid studentId, DateTime examDate, ExamGrade examGrade)
        {
            if (!Enum.IsDefined(typeof(ExamGrade), examGrade) || examGrade == ExamGrade.None)
                throw new ArgumentException("Invalid grade.");
            Id = id;
            LessonId = lessonId;
            StudentId = studentId;
            ExamDate = examDate;
            ExamGrade=examGrade;

        }
    }
}
