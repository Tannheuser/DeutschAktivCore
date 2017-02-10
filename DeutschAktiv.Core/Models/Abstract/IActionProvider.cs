namespace DeutschAktiv.Core.Models.Abstract
{
    public interface IActionProvider
    {
        string Controller { get; set; }
        string Action { get; set; }
    }
}