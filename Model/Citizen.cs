using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Citizen
    {
        [Key]
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }   

        public string Country { get; set; }



    }
}
