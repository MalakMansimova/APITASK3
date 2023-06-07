using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;
using WEB_API.Entities;

namespace WEB_API.DAL.Configurations
{
    public class ColorsConfigruration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.Property(c=>c.Name)
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType(SqlDbType.NVarChar.ToString());

        }
    }
}
