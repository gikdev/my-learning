using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Admins;
using GymManagement.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Infrastructure.Admins.Persistence;

public class AdminsRepository(GymManagementDbContext db) : IAdminsRepository {
    public Task<Admin?> GetByIdAsync(Guid adminId) {
        return db.Admins.FirstOrDefaultAsync(a => a.Id == adminId);
    }

    public Task UpdateAsync(Admin admin) {
        db.Admins.Update(admin);

        return Task.CompletedTask;
    }
}
