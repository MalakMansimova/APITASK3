using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;
using WEB_API.Entities;

namespace WEB_API.DAL.Configurations
{
    public class BrandsConfigruration:IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(c => c.Name)
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType(SqlDbType.NVarChar.ToString());

        }
    }
}
