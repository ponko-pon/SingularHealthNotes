using Microsoft.Extensions.Caching.Distributed;
using SingularHealthNotesAPI.Models;
using Microsoft.Extensions.Caching.Memory;

namespace SingularHealthNotesAPI.Repository
{
    public class ScanRepository(IMemoryCache cache)
    {
        private const string ScanKey = "Scan-Key";
        private readonly object _lock = new();

        public void Save(Scan scan)
        {
            cache.Set(scan.Id, scan);

            lock (_lock)
            {
                var idList = cache.Get<List<Guid>>(ScanKey) ?? [];
                if (!idList.Contains(scan.Id))
                {
                    idList.Add(scan.Id);
                    cache.Set(ScanKey, idList);
                }
            }
        }

        public Scan? GetById(Guid id)
        {
            cache.TryGetValue(id, out Scan? scan);
            return scan;
        }

        public List<Scan> GetAll()
        {
            var idList = cache.Get<List<Guid>>(ScanKey) ?? [];
            var scans = new List<Scan>();

            foreach (var id in idList)
            {
                if (cache.TryGetValue(id, out Scan? scan))
                    scans.Add(scan!);
            }

            return scans;
        }
    }
}

