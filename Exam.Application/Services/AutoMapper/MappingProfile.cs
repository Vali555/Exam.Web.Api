using AutoMapper;
using Exam.Common.DTOs;
using Exam.Domain.Entities;


namespace Exam.Application.Services.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
           
            CreateMap<StudentDto, Student>();
            CreateMap<ClassDto, Class>();
            CreateMap<ExamProcessDto, ExamProcess>();
            CreateMap<LessonRequestDto, Lesson>();
            CreateMap<Lesson, LessonResponseDto>()
            .ForMember(dest => dest.ClassNumber, opt => opt.MapFrom(src => src.Class.Number))
            .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.Teacher.FirstName))
            .ForMember(dest => dest.TeacherSurname, opt => opt.MapFrom(src => src.Teacher.LastName));
            CreateMap<TeacherDto, Teacher>();
        }
    }
}
