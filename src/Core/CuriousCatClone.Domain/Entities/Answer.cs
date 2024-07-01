using CuriousCatClone.Domain.Enums;

namespace CuriousCatClone.Domain.Entities
{
    public class Answer : BaseEntity
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public string Text { get; set; }
        public Reaction Reaction { get; set; } = Reaction.Empty;
    }
}
