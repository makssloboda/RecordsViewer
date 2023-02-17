using System;
using System.Collections.ObjectModel;

namespace TestProject
{
    /// <summary>
    /// A record
    /// </summary>
    public class Record : Node
    {
        public Record(string name, string dateOfBirth, string country)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Country = country;

            Type = NodeType.Record;
        }
    }
}
