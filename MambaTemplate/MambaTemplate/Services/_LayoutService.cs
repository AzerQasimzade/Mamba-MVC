using MambaTemplate.DAL;
using Microsoft.EntityFrameworkCore;

namespace MambaTemplate.Services
{
    public class _LayoutService
    {
        private readonly AppDbContext _context;

        public _LayoutService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Dictionary<string, string>> GetSettingsAsync()
        {
            Dictionary<string, string> settings = await _context.Settings.ToDictionaryAsync(s=>s.Key,s=>s.Value);
            return settings;
        }


    }
}
