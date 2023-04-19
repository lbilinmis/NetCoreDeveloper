namespace AutoMapperApp.WebUI.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Provience { get; set; }
        public string PstCode { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
