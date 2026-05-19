using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_s34434.DTOs;

namespace PJATK_APBD_Cw7_s34434.Services;

public class PcService : IPcService
{
    private readonly AppDbContext _context;

    public PcService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<PcGetAllDto>> GetAllAsync()
    {
        return await _context.PCs
            .Select(p => new PcGetAllDto
            {
                Id = p.Id,
                Name = p.Name,
                Weight = p.Weight,
                Warranty = p.Warranty,
                CreatedAt = p.CreatedAt,
                Stock = p.Stock
            })
            .ToListAsync();
    }

    public async Task<PcGetComponentsDto?> GetComponentsAsync(int id)
    {
        var pc = await _context.PCs
            .Include(p => p.PCComponents)
            .ThenInclude(pc => pc.Component)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (pc == null) return null;

        return new PcGetComponentsDto
        {
            PCId = pc.Id,
            Components = pc.PCComponents.Select(pc => new ComponentItemDto
            {
                Code = pc.Component.Code,
                Name = pc.Component.Name,
                Description = pc.Component.Description,
                Amount = pc.Amount
            }).ToList()
        };
    }

    public async Task<PcGetAllDto> CreateAsync(PcCreateDto dto)
    {
        var pc = new PC
        {
            Name = dto.Name,
            Weight = dto.Weight,
            Warranty = dto.Warranty,
            CreatedAt = dto.CreatedAt,
            Stock = dto.Stock
        };

        _context.PCs.Add(pc);
        await _context.SaveChangesAsync();

        return new PcGetAllDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    public async Task<PcGetAllDto?> UpdateAsync(int id, PcUpdateDto dto)
    {
        var pc = await _context.PCs.FindAsync(id);
        if (pc == null) return null;

        pc.Name = dto.Name;
        pc.Weight = dto.Weight;
        pc.Warranty = dto.Warranty;
        pc.CreatedAt = dto.CreatedAt;
        pc.Stock = dto.Stock;

        await _context.SaveChangesAsync();

        return new PcGetAllDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var pc = await _context.PCs.FindAsync(id);
        if (pc == null) return false;

        _context.PCs.Remove(pc);
        await _context.SaveChangesAsync();
        return true;
    }
}