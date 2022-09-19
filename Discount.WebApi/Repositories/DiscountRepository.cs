using Dapper;
using Discount.WebApi.Entities;
using Npgsql;

namespace Discount.WebApi.Repositories;

public class DiscountRepository : IDiscountRepository
{
    private readonly NpgsqlConnection _connection;

    public DiscountRepository(IConfiguration configuration)
    {
        _connection = new NpgsqlConnection(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
    }

    public async Task<Coupon> GetDiscount(string productName)
    {
        var query = "SELECT * FROM Coupon WHERE ProductName = @ProductName";

        var coupon = await _connection.QueryFirstOrDefaultAsync<Coupon>(query, new { ProductName = productName });

        return coupon ?? new Coupon() { ProductName = "No Discount", Description = "No Discount Desc" };
    }

    public async Task<bool> CreateDiscount(Coupon coupon)
    {
        var query = "INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)";

        var affected = await _connection.ExecuteAsync(query, coupon);

        return affected > 0;
    }

    public async Task<bool> UpdateDiscount(Coupon coupon)
    {
        var query = "UPDATE Coupon SET ProductName = @ProductName, Description = @Description, Amount = @Amount WHERE Id = @Id";

        var affected = await _connection.ExecuteAsync(query, coupon);

        return affected > 0;
    }

    public async Task<bool> DeleteDiscount(string productName)
    {
        var query = "DELETE FROM Coupon WHERE ProductName = @ProductName";

        var affected = await _connection.ExecuteAsync(query, new { ProductName = productName });

        return affected > 0;
    }
}