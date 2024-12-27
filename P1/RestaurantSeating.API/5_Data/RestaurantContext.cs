using Microsoft.EntityFrameworkCore;
using RestaurantSeating.API.Model;

namespace RestaurantSeating.API.Data;

public partial class RestaurantContext : DbContext{
    public RestaurantContext(){}

    public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options){}

    public virtual DbSet<Table> Tables {get; set; }
    public virtual DbSet<Section> Sections {get; set; }
    public virtual DbSet<Server> Servers {get; set; }
}