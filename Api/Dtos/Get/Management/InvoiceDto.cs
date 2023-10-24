using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Get.Management;

public class InvoiceDto
{
    public int Id { get; set; }
    public int InitialInvoice { get; set; }
    public int FinalInvoice { get; set; }
    public int CurrentInvoice { get; set; }
    public int ResolutionNumber { get; set; }
}
