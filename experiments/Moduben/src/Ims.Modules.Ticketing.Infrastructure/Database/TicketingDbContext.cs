using System.Data.Common;
using Ims.Common.Infrastructure.Inbox;
using Ims.Common.Infrastructure.Outbox;
using Ims.Modules.Ticketing.Application.Abstractions.Data;
using Ims.Modules.Ticketing.Domain.Customers;
using Ims.Modules.Ticketing.Domain.Events;
using Ims.Modules.Ticketing.Domain.Orders;
using Ims.Modules.Ticketing.Domain.Payments;
using Ims.Modules.Ticketing.Domain.Tickets;
using Ims.Modules.Ticketing.Infrastructure.Customers;
using Ims.Modules.Ticketing.Infrastructure.Events;
using Ims.Modules.Ticketing.Infrastructure.Orders;
using Ims.Modules.Ticketing.Infrastructure.Payments;
using Ims.Modules.Ticketing.Infrastructure.Tickets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Ims.Modules.Ticketing.Infrastructure.Database;

public sealed class TicketingDbContext(DbContextOptions<TicketingDbContext> options)
    : DbContext(options), IUnitOfWork {
    internal DbSet<Customer> Customers { get; set; }

    internal DbSet<Event> Events { get; set; }

    internal DbSet<TicketType> TicketTypes { get; set; }

    internal DbSet<Order> Orders { get; set; }

    internal DbSet<OrderItem> OrderItems { get; set; }

    internal DbSet<Ticket> Tickets { get; set; }

    internal DbSet<Payment> Payments { get; set; }

    public async Task<DbTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default) {
        if (Database.CurrentTransaction is not null) {
            await Database.CurrentTransaction.DisposeAsync();
        }

        return (await Database.BeginTransactionAsync(cancellationToken)).GetDbTransaction();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.HasDefaultSchema(Schemas.Ticketing);

        modelBuilder.ApplyConfiguration(new OutboxMessageConfiguration());
        modelBuilder.ApplyConfiguration(new OutboxMessageConsumerConfiguration());
        modelBuilder.ApplyConfiguration(new InboxMessageConfiguration());
        modelBuilder.ApplyConfiguration(new InboxMessageConsumerConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new EventConfiguration());
        modelBuilder.ApplyConfiguration(new TicketTypeConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
        modelBuilder.ApplyConfiguration(new TicketConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());
    }
}
