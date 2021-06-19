using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using OKBlogODataService.Model;

namespace OKBlogDataGenerator
{
    public class Program
    {
        private static readonly Random Random = new();

        public static readonly List<Guid> ContactIds = new()
        {
            Guid.Parse("37064213-CEC7-EB11-BACC-000D3ADB1846"),
            Guid.Parse("1F872C39-D1C7-EB11-BACC-000D3ADB1846"),
            Guid.Parse("CA90EB49-D1C7-EB11-BACC-000D3ADB1846"),
            Guid.Parse("BFCBA558-D1C7-EB11-BACC-000D3ADB1846"),
            Guid.Parse("C263BC65-D1C7-EB11-BACC-000D3ADB1846"),
            Guid.Parse("44470B72-D1C7-EB11-BACC-000D3ADB1846")
        };

        public static readonly List<Guid> EventIds = new()
        {
            Guid.Parse("2D751CF3-CDC7-EB11-BACC-000D3ADB1846"),
            Guid.Parse("2EA1340C-D1C7-EB11-BACC-000D3ADB1846"),
            Guid.Parse("26DA5218-D1C7-EB11-BACC-000D3ADB1846")
        };

        public static void Main(string[] args)
        {
            var dbContext = new EventTicketDbContext();
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    dbContext.Ticket.Add(new Ticket()
                    {
                        TicketId = Guid.NewGuid(),
                        EventId = GetEventId(),
                        KontaktId = GetContactId(),
                        Ticketnummer = $"TI-{Random.Next():D10}",
                        Einzelpreis = Decimal.Parse($"{Random.Next(10, 160) + Random.Next(0, 100) / 100.0:F2}", NumberStyles.Currency)
                    });
                }

                dbContext.SaveChanges();
            }
        }

        private static Guid GetContactId()
        {
            var index = Random.Next(0, ContactIds.Count);
            return ContactIds[index];
        }

        private static Guid GetEventId()
        {
            var index = Random.Next(0, EventIds.Count);
            return EventIds[index];
        }
    }
}
