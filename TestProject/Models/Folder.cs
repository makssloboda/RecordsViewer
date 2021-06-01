using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TestProject
{
    /// <summary>
    /// A folder. Can contain other folders or records
    /// </summary>
    public class Folder : Node
    {
        /// <summary>
        /// The type of node
        /// </summary>
        public override NodeType Type => NodeType.Folder;

        /// <summary>
        /// A list of subnodes
        /// </summary>
        public override ObservableCollection<Node> Nodes { get; set; } = new();

        /// <summary>
        /// The parent node
        /// </summary>
        public override Node ParentNode { get; set; }

        /// <summary>
        /// Folders name
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="name">Name of the folder</param>
        public Folder(string name) =>
            Name = name;
    }
}
