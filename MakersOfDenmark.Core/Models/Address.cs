using System.ComponentModel.DataAnnotations;

namespace MakersOfDenmark.Core.Models
{
    public class Address
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string StreetName { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(4)]
        public string Zipcode { get; set; }
        [MaxLength(2)]
        public string CountryCode { get; set; }
        
        //TODO: Add properties  for user collection
    }
}