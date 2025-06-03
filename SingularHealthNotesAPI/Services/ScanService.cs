using SingularHealthNotesAPI.Models;
using SingularHealthNotesAPI.Repository;

namespace SingularHealthNotesAPI.Services
{
    public class ScanService(ScanRepository repository) : IScanService
    {
        private readonly ScanRepository _repository = repository;

        public void Save(Scan scan)
        {
            _repository.Save(scan);
        }

        public List<Scan> GetAll() => _repository.GetAll();
        
        public Note[] GetNotesByScanId(Guid scanId) => _repository.GetById(scanId)?.Notes ?? [];
    }
}
