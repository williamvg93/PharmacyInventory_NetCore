using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Management;

public class Invoice : BaseEntity
{
    public int InitialInvoice { get; set; }
    public int FinalInvoice { get; set; }
    public int CurrentInvoice { get; set; }
    public int ResolutionNumber { get; set; }

}
