using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject
{
    /// <summary>
    /// Abstract class representing a node of the tree
    /// </summary>
    public class Node
    {
        /// <summary>
        /// The ID of the node
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NodeID { get; set; }

        /// <summary>
        /// The ID of the parent node
        /// </summary>
        [Required]
        public int ParentNodeID { get; set; }

        /// <summary>
        /// The type of node
        /// </summary>
        [Required]
        public NodeType Type { get; set; }

        /// <summary>
        /// The name of the current node
        /// </summary>
        /// <returns></returns>
        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        /// <summary>
        /// Users country
        /// </summary>
        /// <returns></returns>
        [StringLength(250)]
        public string Country { get; set; }

        /// <summary>
        /// Users date of birth
        /// </summary>
        /// <returns></returns>
        [StringLength(250)]
        public string DateOfBirth { get; set; }
    }
}
