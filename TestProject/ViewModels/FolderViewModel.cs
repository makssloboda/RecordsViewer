using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;

namespace TestProject
{
    /// <summary>
    /// A view model representing a folder. Can contain other folders or records
    /// </summary>
    public class FolderViewModel : NodeViewModel
    {
        public FolderViewModel(NodeViewModel parent, string name)
        {
            node = new Folder(name);
            ParentNode = parent;

            DeleteCommand = new RelayCommand(() => 
            {
                IsSelected = false;
                ParentNode.Nodes.Remove(this);
                db.DeleteNode(this.node);
            });
            RenameCommand = new RelayCommand(() => IsRenaming = true);
            EndRenameCommand = new RelayCommand(() => IsRenaming = false);
            AddFolderCommand = new RelayCommand(() =>
            {
                Expand();
                FolderViewModel newFolder = new FolderViewModel(this, "New Folder") { IsRenaming = true };
                newFolder.node.ParentNodeID = this.node.NodeID;
                Nodes.Add(newFolder);
                db.InsertNode(newFolder.node);
            });
            AddRecordCommand = new RelayCommand(() =>
            {
                Expand();
                RecordViewModel newRecord = new RecordViewModel(this, "", "", "")
                {
                    IsSelected = true,
                    IsEditingName = true,
                    IsEditingCountry = true,
                    IsEditingDateOfBirth = true
                };
                newRecord.node.ParentNodeID = this.node.NodeID;
                Nodes.Add(newRecord);
                db.InsertNode(newRecord.node);
            });
        }

        public override NodeViewModel FindSelected()
        {
            if (IsSelected)
                return this;

            foreach (NodeViewModel node in Nodes)
            {
                NodeViewModel selected = node.FindSelected();
                if (selected != null)
                    return selected;
            }

            return null;
        }

        public override NodeViewModel Search(string searchText)
        {
            if (searchText == node.Name)
                return this;

            string pattern = "";
            foreach (string word in node.Name.Split(' '))
                pattern += word[0];

            if (searchText.ToLower() == pattern.ToLower())
                return this;

            foreach (NodeViewModel node in Nodes)
            {
                NodeViewModel searchResult = node.Search(searchText);
                if (searchResult != null)
                    return searchResult;
            }

            return null;
        }

        public override void Expand()
        {
            IsExpanded = true;

            foreach (NodeViewModel node in Nodes)
                node.Expand();
        }

        public override void PopulateChildren()
        {
            List<Node> childNodes = db.GetNodes().Where(n => n.ParentNodeID == this.node.NodeID).ToList();
            childNodes.ForEach(n => Nodes.Add(Wrap(n)));

            foreach (NodeViewModel node in Nodes)
            {
                if (node.Type == NodeType.Folder)
                    node.PopulateChildren();
            }
        }
    }
}
