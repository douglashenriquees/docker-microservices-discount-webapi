using Discount.WebApi.Entities;
using Discount.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Discount.WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DiscountController : ControllerBase
{
    private readonly IDiscountRepository _discountRepository;

    public DiscountController(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository ?? throw new ArgumentNullException(nameof(discountRepository));
    }

    [HttpGet("{productName}")]
    public async Task<IActionResult> GetDiscount(string productName)
    {
        var coupon = await _discountRepository.GetDiscount(productName);

        return Ok(coupon);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDiscount([FromBody] Coupon coupon)
    {
        await _discountRepository.CreateDiscount(coupon);

        return Created("", new { productName = coupon.ProductName });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDiscount([FromBody] Coupon coupon)
    {
        return Ok(await _discountRepository.UpdateDiscount(coupon));
    }

    [HttpDelete("{productName}")]
    public async Task<IActionResult> DeleteDiscount(string productName)
    {
        return Ok(await _discountRepository.DeleteDiscount(productName));
    }
}