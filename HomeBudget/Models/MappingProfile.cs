using AutoMapper;
using HomeBudget.Models.Entities.Api;
using HomeBudget.Models.Entities.BLL;
using HomeBudget.Models.Entities.DAL;

namespace HomeBudget.Models;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserBLL>().ReverseMap();
        CreateMap<UserBLL, GetUserResponse>();
        CreateMap<PostUserRequest, UserBLL>();
        CreateMap<PutUserRequest, UserBLL>();
        CreateMap<Transaction, TransactionBLL>().ReverseMap();
        CreateMap<TransactionBLL, GetTransactionsResponse>();
        CreateMap<PutTransactionsRequest, TransactionBLL>();
        CreateMap<PostTransactionsRequest, TransactionBLL>();
        CreateMap<Category, CategoryBLL>().ReverseMap();
        CreateMap<CategoryBLL, GetCategoryResponse>();
        CreateMap<PostCategoryRequest, CategoryBLL>();
        CreateMap<PutCategoryRequest, CategoryBLL>();
    }
}