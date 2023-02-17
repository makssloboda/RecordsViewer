using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TestProject.Models;

namespace TestProject
{
    /// <summary>
    /// A view model representing a node of the tree
    /// </summary>
    public abstract class NodeViewModel : BaseViewModel
    {
        protected DBManager db = new DBManager();

        /// <summary>
        /// The wrapped node
        /// </summary>
        public Node node { get; set; }

        /// <summary>
        /// A list of subnodes
        /// </summary>
        public ObservableCollection<NodeViewModel> Nodes { get; set; } = new();

        /// <summary>
        /// The type of node
        /// </summary>
        public NodeType Type { 
            get 
            {
                return node.Type;
            }
            set 
            {
                node.Type = value;
            } 
        }

        /// <summary>
        /// Users name
        /// </summary>
        public string Name
        {
            get
            {
                return node.Name;
            }
            set
            {
                node.Name = value;
                db.UpdateNode(node);
            }
        }

        /// <summary>
        /// Users date of birth
        /// </summary>
        public string DateOfBirth
        {
            get
            {
                return node.DateOfBirth;
            }
            set
            {
                node.DateOfBirth = value;
                db.UpdateNode(node);
            }
        }

        /// <summary>
        /// Users country
        /// </summary>
        public string Country
        {
            get
            {
                return node.Country;
            }
            set
            {
                node.Country = value;
                db.UpdateNode(node);
            }
        }

        /// <summary>
        /// The parent of the current node
        /// </summary>
        public NodeViewModel ParentNode { get; set; }

        /// <summary>
        /// Determins if a node is in renaming mode
        /// </summary>
        public bool IsRenaming { get; set; }

        /// <summary>
        /// Determins if a records name is being edited
        /// </summary>
        public bool IsEditingName { get; set; }

        /// <summary>
        /// Determins if a records country is being edited
        /// </summary>
        public bool IsEditingCountry { get; set; }

        /// <summary>
        /// Determins if a records date of birth is being edited
        /// </summary>
        public bool IsEditingDateOfBirth { get; set; }
        
        /// <summary>
        /// Determins if a node is selected
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// Determins if a node is selected
        /// </summary>
        public bool IsExpanded { get; set; } = false;

        /// <summary>
        /// Command to delete a node
        /// </summary>
        public ICommand DeleteCommand { get; set; }

        /// <summary>
        /// Command to rename a node
        /// </summary>
        public ICommand RenameCommand { get; set; }

        /// <summary>
        /// Command to end renaming a node
        /// </summary>
        public ICommand EndRenameCommand { get; set; }

        /// <summary>
        /// Command to add a folder to a node
        /// </summary>
        public ICommand AddFolderCommand { get; set; }

        /// <summary>
        /// Command to add a record to a node
        /// </summary>
        public ICommand AddRecordCommand { get; set; }

        /// <summary>
        /// Command to edit records name
        /// </summary>
        public ICommand EditNameCommand { get; set; }

        /// <summary>
        /// Command to edit records country
        /// </summary>
        public ICommand EditCountryCommand { get; set; }

        /// <summary>
        /// Command to edit records date of birth
        /// </summary>
        public ICommand EditDateOfBirthCommand { get; set; }

        /// <summary>
        /// Finds out if this node or one of its subnodes is selected
        /// </summary>
        /// <returns>Selected node</returns>
        public virtual NodeViewModel FindSelected() =>
            throw new NotImplementedException();

        /// <summary>
        /// Finds out if this node or one of its subnodes is searched for
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns>Searched node</returns>
        public virtual NodeViewModel Search(string searchText) =>
            throw new NotImplementedException();

        /// <summary>
        /// Expands the node
        /// </summary>
        public abstract void Expand();

        /// <summary>
        /// Populates folder with children
        /// </summary>
        public virtual void PopulateChildren() =>
            throw new NotImplementedException();

        /// <summary>
        /// Wraps a Node into NodeViewModel
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public NodeViewModel Wrap(Node node)
        {
            switch (node.Type)
            {
                case NodeType.Folder:
                    FolderViewModel wrappedFolder = new FolderViewModel(this, node.Name);
                    wrappedFolder.node.NodeID = node.NodeID;
                    wrappedFolder.node.ParentNodeID = node.ParentNodeID;
                    return wrappedFolder;
                case NodeType.Record:
                    RecordViewModel wrappedRecord = new RecordViewModel(this, node.Name, node.DateOfBirth, node.Country);
                    wrappedRecord.node.NodeID = node.NodeID;
                    wrappedRecord.node.ParentNodeID = node.ParentNodeID;
                    return wrappedRecord;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
