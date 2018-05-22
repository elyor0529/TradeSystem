using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade.Data.Models.Enums
{
    public enum OrderStatus
    {
        [Description("DRAFT")]
        Draft = 1,

        [Description("PARTIALLY")]
        Partially = 2,

        [Description("PAID")]
        Paid = 3
    }
}
