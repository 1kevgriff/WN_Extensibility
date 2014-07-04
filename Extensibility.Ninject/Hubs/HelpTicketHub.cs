using Extensibility.BasicDI.Contracts;
using Extensibility.BasicDI.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Extensibility.BasicDI.Hubs
{
    public class HelpTicketHub : Hub
    {
        private IHelpTicketRepository _helpTicketRepository;
        public HelpTicketHub(IHelpTicketRepository helpTicketRepository)
        {
            _helpTicketRepository = helpTicketRepository;
        }

        public void AddHelpTicket(HelpTicket ticket)
        {
            _helpTicketRepository.CreateTicket(ticket);
            Clients.Others.IssueNewTicket(ticket);
        }
    }
}