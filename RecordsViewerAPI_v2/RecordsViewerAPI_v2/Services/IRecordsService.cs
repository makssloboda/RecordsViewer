using RecordsViewerAPI_v2.Models;

namespace RecordsViewerAPI_v2.Services
{
    public interface IRecordsService
    {
        Task<IEnumerable<Node>> GetAll();
        Task<Node> Get(int ID);
        void Add(Node node);
        void Update(Node nodeToUpdate, Node node);
        void Delete(Node node);
    }
}
