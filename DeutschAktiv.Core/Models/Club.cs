namespace DeutschAktiv.Core.Models
{
    public class Club : BaseItem
    {
        public string Subtitle { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string LinkUrl { get; set; }
        public string ImageUrl { get; set; }
        public string IconClass { get; set; }
    }
}