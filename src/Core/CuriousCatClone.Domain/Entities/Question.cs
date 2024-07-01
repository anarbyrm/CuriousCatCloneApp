namespace CuriousCatClone.Domain.Entities
{
    public class Question : BaseEntity
    {
        public string Text { get; set; }
        public Answer Answer { get; set; }
        public string AskByUserId { get; set; }
        public AppUser AskedBy { get; set; }
        public string AskedToUserId { get; set; }
        public AppUser AskedTo { get; set; }
        public bool Accepted { get; set; }
        public bool IsAnonymous { get; set; }
    }
}
