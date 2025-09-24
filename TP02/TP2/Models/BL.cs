namespace TP2.Models
{
    public class BL
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Consignee { get; set; }
        public string Navio { get; set; }

        public ICollection<Container> Containers { get; set; }
    }
}
