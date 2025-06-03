using Microsoft.Extensions.Options;
using SingularHealthNotesAPI.Models;
using SingularHealthNotesAPI.Repository;

namespace SingularHealthNotesAPI.Helpers
{
    public class ScanDataSeeder(IOptions<AppSettings> settings)
    {
        private readonly AppSettings _settings = settings.Value;

        public void SeedScans(ScanRepository repo)
        {
            var baseUrl = $"{_settings.BaseUrl}/assets";

            var scans = new[]
            {
                new Scan
                {
                    Id = Guid.Parse("090ffb9f-8ede-4975-a6f3-cef6b4e5341a"),
                    Name = "CT Scan",
                    Date = DateTime.UtcNow.AddDays(-1),
                    Notes =
                    [
                        new Note { Title = "Note A", Content = "Content for note A" },
                        new Note { Title = "Note B", Content = "Content for note B" }
                    ],
                    ImageUrl = $"{baseUrl}/ctscan.jpg"
                },
                new Scan
                {
                    Id = Guid.Parse("7a4574e9-6346-4b2c-bd69-a99f7a8c535e"),
                    Name = "MRI Scan",
                    Date = DateTime.UtcNow.AddDays(-5),
                    Notes = null,
                    ImageUrl = $"{baseUrl}/mriscan.jpg"
                },
                new Scan
                {
                    Id = Guid.Parse("16f3589c-f6e0-4f49-b9c1-c3ec330c03e3"),
                    Name = "X-Ray Scan",
                    Date = DateTime.UtcNow,
                    Notes = [],
                    ImageUrl = $"{baseUrl}/xrayscan.jpg"
                }
            };

            foreach (var scan in scans)
            {
                repo.Save(scan);
            }
        }
    }
}
