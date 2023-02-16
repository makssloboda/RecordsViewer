using System.Collections.ObjectModel;
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
    }
}
