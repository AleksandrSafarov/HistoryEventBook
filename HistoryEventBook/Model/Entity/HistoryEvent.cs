namespace HistoryEventBook.Model.Entity
{
    public class HistoryEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
        public string Result { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Date}";
        }
    }
}
