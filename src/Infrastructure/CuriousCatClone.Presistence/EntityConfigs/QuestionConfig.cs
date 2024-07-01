using CuriousCatClone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CuriousCatClone.Presistence.EntityConfigs
{
    public class QuestionConfig : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder
                .HasOne(q => q.Answer)
                .WithOne(a => a.Question)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(q => q.AskedTo)
                .WithMany()
                .HasForeignKey(q => q.AskedToUserId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasOne(q => q.AskedBy)
                .WithMany()
                .HasForeignKey(q => q.AskByUserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
