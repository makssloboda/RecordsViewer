using System.Windows.Input;

namespace TestProject
{
    /// <summary>
    /// A view model representing a record
    /// </summary>
    public class RecordViewModel : NodeViewModel
    {
        /// <summary>
        /// The type of node
        /// </summary>
        public override NodeType Type => NodeType.Record;

        /// <summary>
        /// The parent node
        /// </summary>
        public override NodeViewModel ParentNode { get; set; }

        /// <summary>
        /// Users name
        /// </summary>
        public override string Name { get; set; }

        public override bool IsSelected { get; set; } = false;
        public override bool IsEditingName { get; set; } = false;
        public override bool IsEditingCountry { get; set; } = false;
        public override bool IsEditingDateOfBirth { get; set; } = false;

        /// <summary>
        /// Users date of birth
        /// </summary>
        public override string DateOfBirth { get; set; }

        /// <summary>
        /// Users country
        /// </summary>
        public override string Country { get; set; }

        public override ICommand DeleteCommand { get; set; }
        public override ICommand EditNameCommand { get; set; }
        public override ICommand EditCountryCommand { get; set; }
        public override ICommand EditDateOfBirthCommand { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="country"></param>
        public RecordViewModel(NodeViewModel parent, string name, string dateOfBirth, string country)
        {
            // field initializations
            Name = name;
            DateOfBirth = dateOfBirth;
            Country = country;
            ParentNode = parent;

            // commands initialization
            DeleteCommand = new RelayCommand(() => ParentNode.Nodes.Remove(this));
            EditNameCommand = new RelayCommand(() => IsEditingName = !IsEditingName);
            EditCountryCommand = new RelayCommand(() => IsEditingCountry = !IsEditingCountry);
            EditDateOfBirthCommand = new RelayCommand(() => IsEditingDateOfBirth = !IsEditingDateOfBirth);
        }

        /// <summary>
        /// Finds out whether this node is selected
        /// </summary>
        /// <returns></returns>
        public override NodeViewModel FindSelected() =>
            IsSelected ? this : null;

        /// <summary>
        /// Finds out whether this node is being searched for
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public override NodeViewModel Search(string searchText)
        {
            // if search text and this node's name are equal - return this node
            if (searchText == Name)
                return this;

            // take the first letters of the words
            string pattern = "";
            foreach (string word in Name.Split(' '))
                pattern += word[0];

            // if pattern and searched text are equal - return this node
            if (searchText.ToLower() == pattern.ToLower())
                return this;

            // return null if it's not the node user searched for
            return null;
        }
    }
}