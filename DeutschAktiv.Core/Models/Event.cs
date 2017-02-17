using DeutschAktiv.Core.Models.Abstract;

namespace DeutschAktiv.Core.Models
{
    public class Event : BaseItem, IPurchaseable
    {
        public string Subtitle { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public int Price { get; set; }
    }
}