//namespace WonderlandBooks.Data.Configurations
//{
//    using System;
//
//    using Microsoft.EntityFrameworkCore;
//    using Microsoft.EntityFrameworkCore.Metadata.Builders;
//    using WonderlandBooks.Data.Models;
//
//    public class StoriesConfiguration : IEntityTypeConfiguration<Story>
//    {
//        public void Configure(EntityTypeBuilder<Story> builder)
//        {
//            builder
//                .HasOne(x => x.id)
//                .WithOne(x => x.Id)
//                .OnDelete(DeleteBehavior.Restrict);
//        }
//    }
//}
