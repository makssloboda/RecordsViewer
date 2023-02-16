﻿using System;
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
            Nodes = new ObservableCollection<NodeViewModel>();

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
            if (String.IsNullOrEmpty(SearchText))
                return;

            string searchText = SearchText.Trim();

            if (searchText.StartsWith("f:", true, null))
            {
                searchText = searchText.Substring(2).Trim();

                foreach (NodeViewModel node in Nodes)
                {
                    Selected = node.Search(searchText);

                    if (Selected != null)
                    {
                        if (Selected.Type == NodeType.Folder)
                        {
                            Expand();
                            Selected.IsSelected = true;
                            Selected = null;
                            break;
                        }
                    }
                }
            }
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
            if (Selected != null && Selected.Type == NodeType.Record)
            {
                if (String.IsNullOrEmpty(Selected.Name))
                    Selected.Name = "Unknown";
                if (String.IsNullOrEmpty(Selected.Country))
                    Selected.Country = "Unknown";
                if (String.IsNullOrEmpty(Selected.DateOfBirth))
                    Selected.DateOfBirth = "Unknown";

                Selected.IsEditingName = Selected.IsEditingCountry = Selected.IsEditingDateOfBirth = false;
            }

            foreach (NodeViewModel node in Nodes)
            {
                Selected = node.FindSelected();

                if (Selected != null)
                {
                    if (Selected.Type == NodeType.Folder)
                        Selected = null;
                    else if (Selected.Type == NodeType.Record)
                        break;
                    else
                        throw new NotSupportedException();
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
