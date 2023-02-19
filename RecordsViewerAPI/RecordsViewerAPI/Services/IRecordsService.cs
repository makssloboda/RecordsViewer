using RecordsViewerAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecordsViewerAPI.Services
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
