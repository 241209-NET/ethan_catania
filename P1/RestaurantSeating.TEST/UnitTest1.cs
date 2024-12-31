namespace RestaurantSeating.TEST;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using RestaurantSeating.API.Model;
using RestaurantSeating.API.Service;

public class UnitTest1
{
    private readonly  TableService _tableService;
    [Fact]
    public void CreateNewTable()
    {
        // Arrange
        Table table = new (1, ["OPEN"], 4);

        // Act
        _tableService.CreateNewTable(table);

        // Assert
        Assert.Equal(table, _tableService.GetTableById(1));
    }
}