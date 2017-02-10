namespace DeutschAktiv.Core.Models
{
    public class Event : BaseItem
    {
        public string Subtitle { get; set; }
        public int Price { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
    }
}