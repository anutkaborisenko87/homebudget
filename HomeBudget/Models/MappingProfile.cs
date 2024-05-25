using AutoMapper;
using HomeBudget.Models.Entities.BLL;
using HomeBudget.Models.Entities.DAL;

namespace HomeBudget.Models;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserBLL>().ReverseMap();
        CreateMap<Transaction, TransactionBLL>().ReverseMap();
        CreateMap<Category, CategoryBLL>().ReverseMap();
    }
}