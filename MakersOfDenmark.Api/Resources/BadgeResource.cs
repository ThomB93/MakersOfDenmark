namespace MakersOfDenmark.Api.Resources
{
    public class BadgeResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }
        
        public MakerspaceResource Issuer { get; set; }
    }
}