using EmployeeRegister_K53_2022.IO;

namespace EmployeeRegister_K53_2022.Models
{
    [Serializable]
    public class Address
    {
        private static int UniqueId = 0;

        public Address()

        {
            EmployeeId = ++UniqueId;
        }

        public int EmployeeId { get; set; }
        [PropertyLabel(Label = "postal code", Priority = 1)]
        public string PostalCode { get; set; }
        [PropertyLabel(Label = "city", Priority = 2)]
        public string City { get; set; }
        [PropertyLabel(Label = "street", Priority = 3)]
        public string Street { get; set; }
        [PropertyLabel(Label = "home no", Priority = 4)]
        public string HomeNo { get; set; }
    }
}
