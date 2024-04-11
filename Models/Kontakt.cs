using System.ComponentModel.DataAnnotations;

namespace kontakty.Models
{
    public class Kontakt
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Surname{ get; set; }

        [RegularExpression(@"^[!#$%&'*+\-\/=?^_`{|}~a-zA-Z0-9\.]+@[a-zA-Z0-9-\.]+[a-zA-Z]{2,}$")]
        public string? Email { get; set; }

        // simple check for CZ numbers (at least 9 characters (digits)), optional +420 in the beggining, spaces and - are allowed
        [RegularExpression(@"^(\+[0-9])?[0-9\s-]{9,}$")]
        public string? Phone { get; set; }       

    }
}
