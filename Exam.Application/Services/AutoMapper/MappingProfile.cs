using AutoMapper;
using Exam.Common.DTOs;
using Exam.Common.Results;
using Exam.Domain.Entities;


namespace Exam.Application.Services.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
           
            CreateMap<StudentRequestDto, Student>();

            CreateMap<Student, StudentResponseDto>()
           .ForMember(dest => dest.ClassNumber, opt => opt.MapFrom(src => src.Class.Number));

            CreateMap<ListResult<Student>, ListResult<StudentResponseDto>>()
             .ForMember(dest => dest.List, opt => opt.MapFrom(src => src.List))
             .ForMember(dest => dest.TotalCount, opt => opt.MapFrom(src => src.TotalCount));

            CreateMap<ClassrequestDto, Class>();

            CreateMap<Class, ClassResponseDto>();

            CreateMap<ListResult<Class>, ListResult<ClassResponseDto>>()
             .ForMember(dest => dest.List, opt => opt.MapFrom(src => src.List))
             .ForMember(dest => dest.TotalCount, opt => opt.MapFrom(src => src.TotalCount));

            CreateMap<ExamProcessRequestDto, ExamProcess>()
                .ConstructUsing(dto => new ExamProcess(dto.Id, dto.LessonId,dto.StudentId,dto.ExamDate,dto.ExamGrade));

            CreateMap<ExamProcess, ExamProcessResponseDto>()
           .ForMember(dest => dest.StudentNumber, opt => opt.MapFrom(src => src.Student.Number))
           .ForMember(dest => dest.LessonCode, opt => opt.MapFrom(src => src.Lesson.LessonCode));

            CreateMap<ListResult<ExamProcess>, ListResult<ExamProcessResponseDto>>()
             .ForMember(dest => dest.List, opt => opt.MapFrom(src => src.List))
             .ForMember(dest => dest.TotalCount, opt => opt.MapFrom(src => src.TotalCount));

            CreateMap<LessonRequestDto, Lesson>();

            CreateMap<Lesson, LessonResponseDto>()
            .ForMember(dest => dest.ClassNumber, opt => opt.MapFrom(src => src.Class.Number))
            .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.Teacher.FirstName))
            .ForMember(dest => dest.TeacherSurname, opt => opt.MapFrom(src => src.Teacher.LastName));
            CreateMap<ListResult<Lesson>, ListResult<LessonResponseDto>>()
             .ForMember(dest => dest.List, opt => opt.MapFrom(src => src.List))
             .ForMember(dest => dest.TotalCount, opt => opt.MapFrom(src => src.TotalCount));

            CreateMap<TeacherDto, Teacher>();
        }
    }
}
