using MediatR;

namespace FluentVal_Task.Application.UseCases.Merchant.Queries.GetMerchant
{
    public class GetMerchantQuery : IRequest<GetMerchantDto>
    {
        public int Id { get; set; }
    }
}