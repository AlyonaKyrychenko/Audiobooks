using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Audiobooks.Models
{
    public class GetPurchaseViewModel
    {
        public IReadOnlyCollection<PurchaseViewModel> Purchases { get; set; }
    }
}