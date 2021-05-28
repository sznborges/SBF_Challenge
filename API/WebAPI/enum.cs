using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public enum EnumMoeda
    {
        [Description("USD")]
        USD = 1,
        [Description("EUR")]
        EUR = 2,
        [Description("INR")]
        INR = 3
    }

}
