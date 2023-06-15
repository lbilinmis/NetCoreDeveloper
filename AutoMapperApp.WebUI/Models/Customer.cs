using AutoMapperApp.WebUI.Enums;

namespace AutoMapperApp.WebUI.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public DateTime? BirthDay { get; set; }
        public IList<Address> Addresses { get; set; }
        public EN_Gender En_Gender { get; set; }

        public CreditCard CreditCard { get; set; }

        public string GetCustomerInfo()
        {

            return $"Adı : {Name} EMail : {Email} Yaşı :{Age}";
        }

        public string CustomerEmailAndAgeNotSameProperty()
        {

            return $"EMail : {Email} Yaşı :{Age}";
        }
    }
}
