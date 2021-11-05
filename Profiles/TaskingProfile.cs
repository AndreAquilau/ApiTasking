using ApiTasking.Data.DTOs;
using ApiTasking.Models;
using AutoMapper;

namespace ApiTasking.Profiles
{
    public class TaskingProfile : Profile
    {
        public TaskingProfile()
        {
            CreateMap<TaskingCreateDto, Tasking>();
            CreateMap<TaskingUpdateDto, Tasking>();
        }
    }
}
