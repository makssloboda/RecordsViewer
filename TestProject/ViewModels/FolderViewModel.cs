using System.Collections.ObjectModel;
using System.Windows.Input;

namespace TestProject
{
    /// <summary>
    /// A view model representing a folder. Can contain other folders or records
    /// </summary>
    public class FolderViewModel : NodeViewModel
    {
        /// <summary>
        /// The type of node
        /// </summary>
        public override NodeType Type => NodeType.Folder;

        /// <summary>
        /// A list for subnodes
        /// </summary>
        public override ObservableCollection<NodeViewModel> Nodes { get; set; } = new();

        /// <summary>
        /// The parent node
        /// </summary>
        public override NodeViewModel ParentNode { get; set; }

        /// <summary>
        /// Determins if a node is in renaming mode
        /// </summary>
        public override bool IsRenaming { get; set; } = false;

        /// <summary>
        /// Determins if a node is selected
        /// </summary>
        public override bool IsSelected { get; set; } = false;

        /// <summary>
        /// Folders name
        /// </summary>
        public override string Name { get; set; }

        public override ICommand DeleteCommand { get; set; }

        public override ICommand RenameCommand { get; set; }

        public override ICommand EndRenameCommand { get; set; }

        public override ICommand AddFolderCommand { get; set; }

        public override ICommand AddRecordCommand { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="name"></param>
        public FolderViewModel(NodeViewModel parent, string name)
        {
            // Fields initialization
            Name = name;
            ParentNode = parent;

            // Commands initialization
            DeleteCommand = new RelayCommand(() => ParentNode.Nodes.Remove(this));
            RenameCommand = new RelayCommand(() => IsRenaming = true);
            EndRenameCommand = new RelayCommand(() => IsRenaming = false);
            AddFolderCommand = new RelayCommand(() =>
            {
                Expand();
                Nodes.Add(new FolderViewModel(this, "New Folder") { IsRenaming = true });
            });
            AddRecordCommand = new RelayCommand(() => 
            {
                Expand();

                Nodes.Add(new RecordViewModel(this, "", "", "")
                {
                    IsSelected = true,
                    IsEditingName = true,
                    IsEditingCountry = true,
                    IsEditingDateOfBirth = true
                });
            });
        }

        /// <summary>
        /// Finds out if this node or one of its subnodes is selected
        /// </summary>
        /// <returns>Selected node</returns>
        public override NodeViewModel FindSelected()
        {
            // if this node is selected - return this node
            if (IsSelected)
                return this;

            // iterate through all subnodes and return searched node if found
            foreach (NodeViewModel node in Nodes)
            {
                NodeViewModel selected = node.FindSelected();
                if (selected != null)
                    return selected;
            }

            // return null if searched node wasn't found
            return null;
        }

        /// <summary>
        /// Finds out if this node or one of its subnodes is searched for
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns>Searched node</returns>
        public override NodeViewModel Search(string searchText)
        {
            // if search text and this node's name are equal - return this node
            if (searchText == Name)
                return this;

            // take the first latters of the words
            string pattern = "";
            foreach (string word in Name.Split(' '))
                pattern += word[0];

            // if pattern and searched text are equal - return this node
            if (searchText.ToLower() == pattern.ToLower())
                return this;

            // iterate through all subnodes and return searched node if found
            foreach (NodeViewModel node in Nodes)
            {
                NodeViewModel searchResult = node.Search(searchText);
                if (searchResult != null)
                    return searchResult;
            }

            // return null if seached node wasn't found
            return null;
        }

        /// <summary>
        /// Expands this node and all subnodes
        /// </summary>
        public override void Expand()
        {
            // Expand this node
            IsExpanded = true;

            // Expand subnodes
            foreach (NodeViewModel node in Nodes)
                node.Expand();
        }
    }
}
