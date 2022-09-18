using Discount.WebApi.Entities;

namespace Discount.WebApi.Repositories;

public interface IDiscountRepository
{
    Task<Coupon> GetDiscount(string productName);

    Task<bool> CreateDiscount(Coupon coupon);

    Task<bool> UpdateDiscount(Coupon coupon);

    Task<bool> DeleteDiscount(string coupon);
}