using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Entities
{
    public class Lesson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [MaxLength(3)]
        [Column(TypeName = "char(3)")]
        public string LessonCode { get; set; }
        [StringLength(30)]
        public string LessonName { get; set; }
        public Guid ClassId { get; set; }
        public Guid TeacherId { get; set; }

        [ForeignKey(nameof(ClassId))]
        public Class Class { get; set; }
        [ForeignKey(nameof(TeacherId))]
        public Teacher Teacher { get; set; }


        public ICollection<ExamProcess> ExamProcesses { get; set; }
    }
}
