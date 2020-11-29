namespace MakersOfDenmark.Api.Resources
{
    public class UserBadgeResource
    {
        public UserResource User { get; set; }
        public BadgeResource Badge { get; set; }
    }
}