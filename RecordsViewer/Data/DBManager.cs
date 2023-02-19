using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject;

namespace RecordsViewer.Data
{
    public class DBManager
    {
        private void DeleteRecord(Context db, Node node)
        {
            db.Nodes.Remove(node);
        }

        private async void DeleteFolder(Context db, Node node)
        {
            db.Nodes.Remove(node);
            (await db.Nodes.Where(n => n.ParentNodeID == node.NodeID).ToListAsync()).ForEach(n => DeleteNode(n));
        }

        public async void InsertNode(Node node)
        {
            using (var db = new Context())
            {
                await db.Nodes.AddAsync(node);
                await db.SaveChangesAsync();
            }
        }

        public async void UpdateNode(Node node)
        {
            using (var db = new Context())
            {
                db.Nodes.Update(node);
                await db.SaveChangesAsync();
            }
        }

        public async void DeleteNode(Node node)
        {
            using (var db = new Context())
            {
                switch (node.Type)
                {
                    case NodeType.Folder:
                        DeleteFolder(db, node);
                        break;
                    case NodeType.Record:
                        DeleteRecord(db, node);
                        break;
                    default:
                        throw new NotImplementedException();
                }

                await db.SaveChangesAsync();
            }
        }

        public async Task<List<Node>> GetNodes()
        {
            using (var db = new Context())
            {
                return await db.Nodes.ToListAsync();
            }
        }
    }
}
