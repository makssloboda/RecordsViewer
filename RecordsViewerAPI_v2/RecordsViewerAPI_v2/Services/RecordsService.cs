using Microsoft.EntityFrameworkCore;
using RecordsViewerAPI_v2.Models;

namespace RecordsViewerAPI_v2.Services
{
    public class RecordsService : IRecordsService
    {
        private RecordsViewerContext context = new RecordsViewerContext();

        public async Task<IEnumerable<Node>> GetAll()
        {
            return await context.Nodes.ToListAsync();
        }

        public async Task<Node> Get(int ID)
        {
            return await context.Nodes.SingleAsync(n => n.NodeId == ID);
        }

        public async void Add(Node node)
        {
            context.Nodes.Add(node);
            await context.SaveChangesAsync();
        }

        public async void Update(Node nodeToUpdate, Node node)
        {
            nodeToUpdate = await context.Nodes.SingleAsync(n => n.NodeId == nodeToUpdate.NodeId);
            nodeToUpdate.ParentNodeId = node.ParentNodeId;
            nodeToUpdate.Type = node.Type;
            nodeToUpdate.Name = node.Name;
            nodeToUpdate.Country = node.Country;
            nodeToUpdate.DateOfBirth = node.DateOfBirth;
            await context.SaveChangesAsync();
        }

        public async void Delete(Node node)
        {
            context.Nodes.Remove(node);
            await context.SaveChangesAsync();
        }
    }
}
