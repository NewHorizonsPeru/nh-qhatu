using System;
using System.Collections.Generic;

namespace nh.qhatu.common.domain.core.entities
{
    public partial class CreditCardType
    {
        public string Id { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
