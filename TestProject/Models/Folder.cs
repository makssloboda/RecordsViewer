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
        /// Folders name
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="name">Name of the folder</param>
        public Folder(string name) 
        {
            Name = name;
        }
    }
}
