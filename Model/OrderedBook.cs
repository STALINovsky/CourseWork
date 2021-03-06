namespace Model
{
    public class OrderedBook : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public Order? Order { get; set; }

        public override string ToString()
        {
            return Id + ": " + Name + " " + Author;
        }
    }
}
