using System.Windows.Input;

namespace TestProject
{
    /// <summary>
    /// A view model representing a record
    /// </summary>
    public class RecordViewModel : NodeViewModel
    {
        public RecordViewModel(NodeViewModel parent, string name, string dateOfBirth, string country)
        {
            node = new Record(name, dateOfBirth, country);
            ParentNode = parent;

            DeleteCommand = new RelayCommand(() =>
            {
                IsSelected = false;
                ParentNode.Nodes.Remove(this);
                db.DeleteNode(this.node);
            });
            EditNameCommand = new RelayCommand(() => IsEditingName = !IsEditingName);
            EditCountryCommand = new RelayCommand(() => IsEditingCountry = !IsEditingCountry);
            EditDateOfBirthCommand = new RelayCommand(() => IsEditingDateOfBirth = !IsEditingDateOfBirth);
        }

        public override NodeViewModel FindSelected() =>
            IsSelected ? this : null;

        public override NodeViewModel Search(string searchText)
        {
            if (searchText == node.Name)
                return this;

            string pattern = "";
            foreach (string word in node.Name.Split(' '))
                pattern += word[0];

            if (searchText.ToLower() == pattern.ToLower())
                return this;

            return null;
        }

        public override void Expand()
        {
            IsExpanded = true;
        }
    }
}