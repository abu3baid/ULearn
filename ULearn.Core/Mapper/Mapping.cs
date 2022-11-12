using AutoMapper;
using ULearn.DbModel.Models.DB;
using ULearn.ModelView.ModelView;

namespace LMS.Core.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UserModel, User>().ReverseMap();
        }
    }
}
