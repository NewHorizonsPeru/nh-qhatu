using System;
using System.Collections.Generic;

namespace nh.qhatu.common.domain.core.entities
{
    public partial class CreditCardType
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
