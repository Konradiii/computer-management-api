using PJATK_APBD_Cw7_s34434.DTOs;

namespace PJATK_APBD_Cw7_s34434.Services;

public interface IPcService
{
    Task<List<PcGetAllDto>> GetAllAsync();
    Task<PcGetComponentsDto?> GetComponentsAsync(int id);
    Task<PcGetAllDto> CreateAsync(PcCreateDto dto);
    Task<PcGetAllDto?> UpdateAsync(int id, PcUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}