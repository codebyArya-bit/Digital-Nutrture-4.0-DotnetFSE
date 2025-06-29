using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using MagicFilesLib;

namespace DirectoryExplorer.Tests
{
    [TestFixture]
    public class DirectoryExplorerTests
    {
        // Null-forgiving initializer to satisfy the compiler
        private Mock<IDirectoryExplorer> _directoryExplorerMock = null!;

        private readonly string _file1 = "file.txt";
        private readonly string _file2 = "file2.txt";

        [OneTimeSetUp]
        public void Setup()
        {
            _directoryExplorerMock = new Mock<IDirectoryExplorer>();
            _directoryExplorerMock
                .Setup(de => de.GetFiles(It.IsAny<string>()))
                .Returns(new List<string> { _file1, _file2 });
        }

        [Test]  // or [TestCase], either works here
        public void GetFiles_ShouldReturnMockedFiles()
        {
            var files = _directoryExplorerMock.Object.GetFiles("dummy_path");

            Assert.That(files, Is.Not.Null);
            Assert.That(files.Count, Is.EqualTo(2));
            Assert.That(files, Does.Contain(_file1));
        }
    }
}
