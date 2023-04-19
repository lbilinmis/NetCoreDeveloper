namespace AutoMapperApp.WebUI.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }


    public class CustomerDiferentPropertyDto
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Eposta { get; set; }
        public int Yas { get; set; }

        public string CustomerInfo { get; set; }
        public string CustomerEmailAndAge { get; set; }
    }
}
