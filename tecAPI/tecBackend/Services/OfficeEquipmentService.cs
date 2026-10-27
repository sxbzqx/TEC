using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using tecBackend.Models;

namespace tecBackend.Services;

public class OfficeEquipmentService(SiteContext db, IMemoryCache cache)
{
    public async Task<List<OfficeEquipment>> GetByTypeAsync(string type, CancellationToken ct)
    {
        string cacheKey = $"office-equipment-db-{type}";

        return await cache.GetOrCreateAsync(cacheKey, async e =>
        {
            e.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);

            return await db.OfficeEquipments
                .AsNoTracking()
                .Where(x => x.Type == type)
                .ToListAsync(ct);
        }) ?? [];
    }

    public async Task<OfficeEquipment?> GetByIdAsync(int id, CancellationToken ct)
    {
        return await db.OfficeEquipments.FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public async Task<OfficeEquipment> CreateAsync(OfficeEquipment entity, CancellationToken ct)
    {
        db.OfficeEquipments.Add(entity);
        await db.SaveChangesAsync(ct);
        cache.Remove($"office-equipment-db-{entity.Type}");
        return entity;
    }

    public async Task<OfficeEquipment?> UpdateAsync(int id, OfficeEquipment dto, CancellationToken ct)
    {
        var existing = await db.OfficeEquipments.FirstOrDefaultAsync(x => x.Id == id, ct);
        if (existing == null) return null;

        existing.InvNum = dto.InvNum;
        existing.Name = dto.Name;
        existing.NetworkName = dto.NetworkName;
        existing.Phone = dto.Phone;
        existing.Department = dto.Department;
        existing.UserDep = dto.UserDep;
        existing.UserFio = dto.UserFio;
        existing.Cpu = dto.Cpu;
        existing.Ram1 = dto.Ram1;
        existing.Ram2 = dto.Ram2;
        existing.Hdd1 = dto.Hdd1;
        existing.Hdd2 = dto.Hdd2;
        existing.Video = dto.Video;
        existing.Monitor = dto.Monitor;
        existing.Optical = dto.Optical;
        existing.Audio = dto.Audio;
        existing.Speakers = dto.Speakers;
        existing.SerialNumber = dto.SerialNumber;
        existing.TypeCartr = dto.TypeCartr;
        existing.NumZapr = dto.NumZapr;
        existing.TypeSelen = dto.TypeSelen;
        existing.ReplaceSelen = dto.ReplaceSelen;
        existing.TypeToner = dto.TypeToner;
        existing.KolToner = dto.KolToner;
        existing.InputMonth = dto.InputMonth;
        existing.InputYear = dto.InputYear;

        await db.SaveChangesAsync(ct);
        cache.Remove($"office-equipment-db-{existing.Type}");
        return existing;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct)
    {
        var entity = await db.OfficeEquipments.FirstOrDefaultAsync(x => x.Id == id, ct);
        if (entity == null) return false;

        db.OfficeEquipments.Remove(entity);
        await db.SaveChangesAsync(ct);
        cache.Remove($"office-equipment-db-{entity.Type}");
        return true;
    }
}