using System;
using System.Collections.ObjectModel;

namespace TestProject
{
    /// <summary>
    /// A record
    /// </summary>
    public class Record : Node
    {
        /// <summary>
        /// The type of node
        /// </summary>
        public override NodeType Type => NodeType.Record;

        /// <summary>
        /// Users name
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// Users date of birth
        /// </summary>
        public override string DateOfBirth { get; set; }

        /// <summary>
        /// Users country
        /// </summary>
        public override string Country { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="country"></param>
        public Record(string name, string dateOfBirth, string country)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Country = country;
        }
    }
}
