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
        /// A list of subnodes
        /// </summary>
        public virtual ObservableCollection<Node> Nodes { get; set; }

        /// <summary>
        /// A parent of the current node
        /// </summary>
        public virtual Node ParentNode { get; set; }

        /// <summary>
        /// The type of node
        /// </summary>
        public virtual NodeType Type { get; set; }

        ///// <summary>
        ///// Gets the child on the corresponding index
        ///// </summary>
        ///// <param name="index"></param>
        ///// <returns></returns>
        //public virtual Node GetChild(int index) =>
        //    throw new NotSupportedException();

        /// <summary>
        /// The name of the current node
        /// </summary>
        /// <returns></returns>
        public virtual string Name { get; set; }

        /// <summary>
        /// Users country
        /// </summary>
        /// <returns></returns>
        public virtual string Country { get; set; }

        /// <summary>
        /// Users date of birth
        /// </summary>
        /// <returns></returns>
        public virtual string DateOfBirth { get; set; }
    }
}
