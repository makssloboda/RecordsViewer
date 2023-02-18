using System.Collections.Generic;
using System.Linq;

namespace RecordsViewerAPI.Models
{
    public class DBManager
    {
        private RecordsViewerContext context = new RecordsViewerContext();

        public IEnumerable<Node> GetAll()
        {
            return context.Nodes.ToList();
        }

        public Node Get(int ID)
        {
            return context.Nodes.Single(n => n.NodeId == ID);
        }

        public void Add(Node node)
        {
            context.Nodes.Add(node);
            context.SaveChanges();
        }

        public void Update(Node nodeToUpdate, Node node)
        {
            nodeToUpdate = context.Nodes.Single(n => n.NodeId == nodeToUpdate.NodeId);
            nodeToUpdate.ParentNodeId = node.ParentNodeId;
            nodeToUpdate.Type = node.Type;
            nodeToUpdate.Name = node.Name;
            nodeToUpdate.Country = node.Country;
            nodeToUpdate.DateOfBirth = node.DateOfBirth;
            context.SaveChanges();
        }

        public void Delete(Node node)
        {
            context.Nodes.Remove(node);
            context.SaveChanges();
        }
    }
}
