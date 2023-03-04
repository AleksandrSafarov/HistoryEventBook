namespace HistoryEventBook.Model.Entity
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string BirthDay { get; set; }
        public override string ToString()
        {
            return $"{Id} - {Name} - {BirthDay}";
        }
    }
}
