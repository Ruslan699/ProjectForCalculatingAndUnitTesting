using AteshgahApp.Core.Models;
using AteshgahApp.UI.Models;
using AutoMapper;

namespace AteshgahApp.UI.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            AllowNullCollections = true;
            AllowNullDestinationValues = true;

            CreateMap<Client, ClientViewModel>().ReverseMap();
            CreateMap<Loan, LoanViewModel>().ReverseMap();
            CreateMap<Loan, LoanDetailsViewModel>().ReverseMap();
            CreateMap<Invoice, InvoiceViewModel>().ReverseMap();

            CreateMap<EstimateViewModel, Loan>()
                .ForMember(m => m.Amount, x => x.MapFrom(m => m.LoanAmount))
                .ForMember(m => m.ClientId, x => x.MapFrom(m => m.ClientId))
                .ForMember(m => m.InterestRate, x => x.MapFrom(m => m.MonthlyRate))
                .ForMember(m => m.LoanPeriod, x => x.MapFrom(m => m.LoanPeriod))
                .ForMember(m => m.PayoutDate, x => x.MapFrom(m => m.PayDate));
        }
    }
}