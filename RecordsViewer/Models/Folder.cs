using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TestProject
{
    /// <summary>
    /// A folder. Can contain other folders or records
    /// </summary>
    public class Folder : Node
    {
        public Folder(string name) 
        {
            Name = name;

            Type = NodeType.Folder;
        }
    }
}
