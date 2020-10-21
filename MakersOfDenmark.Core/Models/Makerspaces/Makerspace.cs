using System;
using System.ComponentModel.DataAnnotations.Schema;
using MakersOfDenmark.Core.Models.Auth;

namespace MakersOfDenmark.Core.Models.Makerspaces
{
    public class Makerspace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Space_Type { get; set; }
        public string Access_Type { get; set; }
        public string CVR { get; set; }
        public string Logo_Url { get; set; }
        [ForeignKey("UserId")]
        public Guid userFK { get; set; }
    }
}