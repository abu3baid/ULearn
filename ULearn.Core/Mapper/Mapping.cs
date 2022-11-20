using AutoMapper;
using ULearn.Common.Extensions;
using ULearn.DbModel.Models.DB;
using ULearn.ModelView.ModelView;
using ULearn.ModelView.ModelView.Response;

namespace LMS.Core.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {

            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<User, LoginUserResponse>().ReverseMap();
            CreateMap<UserResult, User>().ReverseMap();

            CreateMap<CourseModel, Course>().ReverseMap();
            CreateMap<PagedResult<CourseModel>, PagedResult<Course>>().ReverseMap();
        }
    }
}
