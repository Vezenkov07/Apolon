using Apolon.Data.Models;

namespace Apolon.Data.Models.ViewModels;

public class AccountViewModel
{
    public IReadOnlyCollection<Session> Sessions { get; set; } = [];
    public IReadOnlyCollection<Card> Cards { get; set; } = [];
    public IReadOnlyCollection<SupplementPurchase> SupplementPurchases { get; set; } = [];
}
