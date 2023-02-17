using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;

namespace TestProject.Models
{
    public class DBManager
    {
        private void DeleteRecord(Context db, Node node)
        {
            db.Nodes.Remove(node);
        }

        private void DeleteFolder(Context db, Node node)
        {
            db.Nodes.Remove(node);
            db.Nodes.Where(n => n.ParentNodeID == node.NodeID).ToList().ForEach(n => DeleteNode(n));
        }

        public void InsertNode(Node node)
        {
            using (var db = new Context())
            {
                db.Nodes.Add(node);
                db.SaveChanges();
            }
        }

        public void UpdateNode(Node node)
        {
            using (var db = new Context())
            {
                db.Nodes.Update(node);
                db.SaveChanges();
            }
        }

        public void DeleteNode(Node node)
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

                db.SaveChanges();
            }
        }
    }
}
