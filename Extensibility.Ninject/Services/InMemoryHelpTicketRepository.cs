using Extensibility.BasicDI.Contracts;
using Extensibility.BasicDI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Extensibility.BasicDI.Services
{
    public class InMemoryHelpTicketRepository : IHelpTicketRepository
    {
        private static List<HelpTicket> _helpTicketList;
        static InMemoryHelpTicketRepository()
        {
            _helpTicketList = new List<HelpTicket>();
        }

        public IEnumerable<Models.HelpTicket> GetAllTickets()
        {
            return _helpTicketList.ToList();
        }

        public Models.HelpTicket CreateTicket(Models.HelpTicket newTicket)
        {
            _helpTicketList.Add(newTicket);
            return newTicket;
        }
    }
}