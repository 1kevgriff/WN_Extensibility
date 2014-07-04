using Extensibility.BasicDI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensibility.BasicDI.Contracts
{
    public interface IHelpTicketRepository
    {
        IEnumerable<HelpTicket> GetAllTickets();
        HelpTicket CreateTicket(HelpTicket newTicket);
    }
}
