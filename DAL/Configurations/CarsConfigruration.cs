using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;
using WEB_API.Entities;

namespace WEB_API.DAL.Configurations
{
    public class CarsConfigruration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(C => C.Description).IsRequired()
                .HasMaxLength(150)
                .HasColumnType(SqlDbType.NVarChar.ToString())
                .HasDefaultValue("xxx");

            builder.Property(c => c.DailyPrice).IsRequired().HasDefaultValue(0);

            builder.HasOne(c => c.Brand)
                .WithMany(b => b.Cars)
                .HasForeignKey(b => b.BrandId);
            builder.HasOne(C=>C.Color)
                .WithMany(o=>o.Cars)
                .HasForeignKey(b => b.ColorId);


        }
    }
}
