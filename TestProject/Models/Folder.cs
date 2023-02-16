using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TestProject
{
    /// <summary>
    /// A folder. Can contain other folders or records
    /// </summary>
    public class Folder : Node
    {
        public override NodeType Type => NodeType.Folder;

        public Folder(string name) 
        {
            Name = name;
        }
    }
}
