using System.Linq;
using Xunit;

namespace TestProject.Tests
{
    /// <summary>
    /// A class for unit testing
    /// </summary>
    public class TreeStructureVMTests
    {
        /// <summary>
        /// Tests folders adding functionality
        /// </summary>
        [Fact]
        public void AddingFolders()
        {
            // Arrange
            TreeStructureViewModel vm = new();

            // Act
            vm.AddFolderCommand.Execute(new object());

            // Assert
            var result = vm.Nodes.FirstOrDefault(n=> n.node.Name == "New Folder");

            // folder is created
            Assert.NotNull(result);
            // folders parent node is the node in which the folder was created
            Assert.Same(vm, result.ParentNode);
        }

        /// <summary>
        /// Tests records adding functionality
        /// </summary>
        [Fact]
        public void AddingRecords()
        {
            // Arrange
            TreeStructureViewModel vm = new();

            // Act
            vm.AddRecordCommand.Execute(new());

            // Assert
            var result = vm.Nodes.FirstOrDefault(n => n.node.Name == "");

            // record is created
            Assert.NotNull(result);
            // records parent node is the node in which the record was created
            Assert.Same(vm, result.ParentNode);
        }

        /// <summary>
        /// Tests node searching
        /// </summary>
        [Fact]
        public void Searching()
        {
            // Arrange
            TreeStructureViewModel vm = new();
            vm.AddRecordCommand.Execute(new());

            // Act
            vm.SearchText = " R: mS";
            vm.FindCommand.Execute(new());
            var foundWithFilters = vm.Selected;

            vm.SearchText = "Max Slobodianiuk";
            vm.FindCommand.Execute(new());
            var foundWithoutFilters = vm.Selected;

            // Assert

            // records are found
            Assert.NotNull(foundWithFilters);
            Assert.NotNull(foundWithoutFilters);
            // found records are the same
            Assert.Same(foundWithFilters, foundWithoutFilters);
            // selected record is really selected
            Assert.True(vm.Selected.IsSelected);
        }

        /// <summary>
        /// Tests changing selection
        /// </summary>
        [Fact]
        public void FindingSelectedNode()
        {
            // Arrange
            TreeStructureViewModel vm = new();

            // Act
            vm.SearchText = "r: ms";
            vm.FindCommand.Execute(new());
            var foundWithSearch = vm.Selected;

            vm.SelectionChangedCommand.Execute(new());
            var foundWithSelectionChangedCommand = vm.Selected;

            // Assert

            // selected records are the same
            Assert.Same(foundWithSearch, foundWithSelectionChangedCommand);
        }
    }
}
