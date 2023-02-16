using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TestProject
{
    /// <summary>
    /// Abstract class representing a node of the tree
    /// </summary>
    public abstract class Node
    {
        /// <summary>
        /// The ID of the node
        /// </summary>
        public int NodeID { get; set; }

        /// <summary>
        /// The ID of the parent node
        /// </summary>
        public int ParentNodeID { get; set; }

        /// <summary>
        /// The type of node
        /// </summary>
        public virtual NodeType Type { get; set; }

        /// <summary>
        /// The name of the current node
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }

        /// <summary>
        /// Users country
        /// </summary>
        /// <returns></returns>
        public string Country { get; set; }

        /// <summary>
        /// Users date of birth
        /// </summary>
        /// <returns></returns>
        public string DateOfBirth { get; set; }
    }
}
