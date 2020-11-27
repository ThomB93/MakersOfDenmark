namespace MakersOfDenmark.Api.Resources
{
    public class SaveBadgeResource
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public MakerspaceResource Issuer { get; set; }
    }
}