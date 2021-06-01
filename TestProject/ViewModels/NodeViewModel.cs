using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace TestProject
{
    /// <summary>
    /// A view model representing a node of the tree
    /// </summary>
    public class NodeViewModel : BaseViewModel
    {
        /// <summary>
        /// A list for subnodes
        /// </summary>
        public virtual ObservableCollection<NodeViewModel> Nodes { get; set; }

        /// <summary>
        /// A parent of the current node
        /// </summary>
        public virtual NodeViewModel ParentNode { get; set; }

        /// <summary>
        /// The type of node
        /// </summary>
        public virtual NodeType Type { get; set; }

        /// <summary>
        /// The name of the current node
        /// </summary>
        /// <returns></returns>
        public virtual string Name { get; set; }

        /// <summary>
        /// Users country
        /// </summary>
        /// <returns></returns>
        public virtual string Country { get; set; }

        /// <summary>
        /// Determins if a node is in renaming mode
        /// </summary>
        public virtual bool IsRenaming { get; set; }

        /// <summary>
        /// Determins if a records name is being edited
        /// </summary>
        public virtual bool IsEditingName { get; set; }

        /// <summary>
        /// Determins if a records country is being edited
        /// </summary>
        public virtual bool IsEditingCountry { get; set; }

        /// <summary>
        /// Determins if a records date of birth is being edited
        /// </summary>
        public virtual bool IsEditingDateOfBirth { get; set; }
        
        /// <summary>
        /// Determins if a node is selected
        /// </summary>
        public virtual bool IsSelected { get; set; }

        /// <summary>
        /// Determins if a node is selected
        /// </summary>
        public virtual bool IsExpanded { get; set; } = false;

        /// <summary>
        /// Users date of birth
        /// </summary>
        /// <returns></returns>
        public virtual string DateOfBirth { get; set; }

        /// <summary>
        /// Command to delete a node
        /// </summary>
        public virtual ICommand DeleteCommand { get; set; }

        /// <summary>
        /// Command to rename a node
        /// </summary>
        public virtual ICommand RenameCommand { get; set; }

        /// <summary>
        /// Command to end renaming a node
        /// </summary>
        public virtual ICommand EndRenameCommand { get; set; }

        /// <summary>
        /// Command to add a folder to a node
        /// </summary>
        public virtual ICommand AddFolderCommand { get; set; }

        /// <summary>
        /// Command to add a record to a node
        /// </summary>
        public virtual ICommand AddRecordCommand { get; set; }

        /// <summary>
        /// Command to edit records name
        /// </summary>
        public virtual ICommand EditNameCommand { get; set; }

        /// <summary>
        /// Command to edit records country
        /// </summary>
        public virtual ICommand EditCountryCommand { get; set; }

        /// <summary>
        /// Command to edit records date of birth
        /// </summary>
        public virtual ICommand EditDateOfBirthCommand { get; set; }

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
        /// Expands this node
        /// NOTE: Doesn't work for records
        /// </summary>
        public virtual void Expand() =>
            IsExpanded = true;
    }
}
