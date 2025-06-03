using SingularHealthNotesAPI.Models;

namespace SingularHealthNotesAPI.Services
{
    public interface IScanService
    {
        void Save(Scan scan);
        List<Scan> GetAll();
        Note[] GetNotesByScanId(Guid scanId);
    }
}