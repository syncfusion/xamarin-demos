using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syncfusion.ZugFerd
{
    /// <summary>
    /// Invoice Type
    /// </summary>
    public enum InvoiceType
    {
        Unknown = 0,
        Invoice = 380,
        Correction = 1380,
        CreditNote = 381,
        DebitNote = 383,
        SelfBilledInvoice = 389
    }
}
