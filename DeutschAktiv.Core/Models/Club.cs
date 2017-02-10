using DeutschAktiv.Core.Models.Abstract;

namespace DeutschAktiv.Core.Models
{
    public sealed class Club : BaseItem, IActionProvider
    {
        public string Subtitle { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string ImageUrl { get; set; }
        public string IconClass { get; set; }
    }
}