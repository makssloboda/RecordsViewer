using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace TestProject
{
    /// <summary>
    /// Main application's view model
    /// </summary>
    public class TreeStructureViewModel : NodeViewModel
    {
        /// <summary>
        /// Tree items
        /// </summary>
        public override ObservableCollection<NodeViewModel> Nodes { get; set; }

        /// <summary>
        /// The selected node
        /// </summary>
        public NodeViewModel Selected { get; set; }

        /// <summary>
        /// Determins whether details needed to be shown
        /// </summary>
        public bool ShowDetails => Selected != null;

        /// <summary>
        /// The name of the node that is being searched for
        /// </summary>
        public string SearchText { get; set; } = "";

        /// <summary>
        /// Fires when user selects another node
        /// </summary>
        public ICommand SelectionChangedCommand { get; set; }

        /// <summary>
        /// Fires when user clicks the search button
        /// </summary>
        public ICommand FindCommand { get; set; }

        /// <summary>
        /// Adds a folder to root catalog
        /// </summary>
        public override ICommand AddFolderCommand { get; set; }

        /// <summary>
        /// Adds a record to root catalog
        /// </summary>
        public override ICommand AddRecordCommand { get; set; }

        /// <summary>
        /// Constructor, initializes test data
        /// </summary>
        public TreeStructureViewModel()
        {
            // test data
            Nodes = new ObservableCollection<NodeViewModel>();
            NodeViewModel managersFolder = new FolderViewModel(this, "Managers");
            NodeViewModel engineersFolder = new FolderViewModel(this, "Engineers");
            NodeViewModel designersFolder = new FolderViewModel(this, "Designers");

            managersFolder.Nodes.Add(new RecordViewModel(managersFolder, "Joe Markov", "1998/12/3", "USA"));
            managersFolder.Nodes.Add(new RecordViewModel(managersFolder, "Vika Petrova", "1995/1/8", "Russia"));
            NodeViewModel bestEngineersFolder = new FolderViewModel(null, "Best Engineers");
            bestEngineersFolder.Nodes.Add(new RecordViewModel(bestEngineersFolder, "Max Slobodianiuk", "2000/7/27", "Ukraine"));
            engineersFolder.Nodes.Add(bestEngineersFolder);
            bestEngineersFolder.ParentNode = engineersFolder;
            designersFolder.Nodes.Add(new RecordViewModel(designersFolder, "Kristin Stuart", "1987/2/3", "Canada"));
            designersFolder.Nodes.Add(new RecordViewModel(designersFolder, "Alexander Marcelias", "2001/6/5", "Italy"));

            Nodes.Add(managersFolder);
            Nodes.Add(engineersFolder);
            Nodes.Add(designersFolder);

            // commands initialization
            SelectionChangedCommand = new RelayCommand(SelectionChanged);
            FindCommand = new RelayCommand(Find);
            AddFolderCommand = new RelayCommand(() => Nodes.Add(new FolderViewModel(this, "New Folder") { IsRenaming = true }));
            AddRecordCommand = new RelayCommand(() => Nodes.Add(new RecordViewModel(this, "", "", "")
            {
                IsSelected = true,
                IsEditingName = true,
                IsEditingCountry = true,
                IsEditingDateOfBirth = true
            }));
        }

        /// <summary>
        /// Finds searched node
        /// </summary>
        private void Find()
        {
            // if search text is empty - return
            if (String.IsNullOrEmpty(SearchText))
                return;

            // triming white spaces
            string searchText = SearchText.Trim();

            // if filtering folders..
            if (searchText.StartsWith("f:", true, null))
            {
                // remove filter pattern and white spaces
                searchText = searchText.Substring(2).Trim();

                // iterate through subnodes
                foreach (NodeViewModel node in Nodes)
                {
                    Selected = node.Search(searchText);

                    // if searched node is found..
                    if (Selected != null)
                    {
                        // determin if it's a folder
                        if (Selected.Type == NodeType.Folder)
                        {
                            // expand all nodes
                            Expand();
                            // select found node
                            Selected.IsSelected = true;
                            // set Selected to null since we don't need to show details about folders
                            Selected = null;
                            // get out of foreach cycle
                            break;
                        }
                    }
                }
            }
            // if filtering records.. (the process is similar to the folders filtering)
            else if (searchText.StartsWith("r:", true, null))
            {
                searchText = searchText.Substring(2).Trim();

                foreach (NodeViewModel node in Nodes)
                {
                    Selected = node.Search(searchText);
                    if (Selected != null)
                    {
                        if (Selected.Type == NodeType.Record)
                        {
                            Expand();
                            Selected.IsSelected = true;
                            break;
                        }
                    }
                }
            }
            // if filters not found..
            else
            {
                foreach (NodeViewModel node in Nodes)
                {
                    Selected = node.Search(SearchText);
                    if (Selected != null)
                    {
                        Expand();
                        if (Selected.Type == NodeType.Folder)
                        {
                            Selected.IsSelected = true;
                            Selected = null;
                        }
                        else
                            Selected.IsSelected = true;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Gets called when user selects another node
        /// </summary>
        private void SelectionChanged()
        {
            // if current node fields are not filled with data, fill them with the word "Unknown"
            if (Selected != null && Selected.Type == NodeType.Record)
            {
                if (String.IsNullOrEmpty(Selected.Name))
                    Selected.Name = "Unknown";
                if (String.IsNullOrEmpty(Selected.Country))
                    Selected.Country = "Unknown";
                if (String.IsNullOrEmpty(Selected.DateOfBirth))
                    Selected.DateOfBirth = "Unknown";

                // end editing
                Selected.IsEditingName = Selected.IsEditingCountry = Selected.IsEditingDateOfBirth = false;
            }

            // iterate through all nodes
            foreach (NodeViewModel node in Nodes)
            {
                // find selected node
                Selected = node.FindSelected();

                // if the node is found..
                if (Selected != null)
                {
                    // if it is folder - don't select it
                    if (Selected.Type == NodeType.Folder)
                        Selected = null;
                    else
                        // it's record, so selected node is found and we can get out of cycle
                        break;
                }    
            }
        }

        /// <summary>
        /// Expands all subnodes
        /// </summary>
        public override void Expand()
        {
            foreach (NodeViewModel node in Nodes)
                node.Expand();
        }
    }
}
