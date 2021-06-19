using System;
using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using OKBlogODataService.Base;
using OKBlogODataService.Model;

namespace OKBlogODataService.Controllers
{
    [ServiceFilter(typeof(HttpBasicAuthorizeFilter))]
    public class TicketsController : ODataController
    {
        private readonly EventTicketDbContext _dbContext;

        public TicketsController(EventTicketDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [EnableQuery]
        public IQueryable<Ticket> Get()
        {
            return _dbContext.Ticket;
        }

        [EnableQuery]
        public Ticket Get([FromODataUri] Guid key)
        {
            return _dbContext.Ticket.Single(l => l.TicketId == key);
        }
    }
}
