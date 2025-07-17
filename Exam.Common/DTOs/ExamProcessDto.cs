using Exam.Common.Enums;


namespace Exam.Common.DTOs
{
    public class ExamProcessDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid LessonId { get; set; }
        public Guid StudentId { get; set; }
        public DateTime ExamDate { get; set; }
        public ExamGrade ExamGrade { get; set; }

    
    }
}
