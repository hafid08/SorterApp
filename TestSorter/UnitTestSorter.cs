using Moq;
using NUnit.Framework;
using SorterApp;
using System.Collections.Generic;
using System.IO;

namespace TestSorter
{
    public class Tests
    {
        string _path  = Path.Combine(Directory.GetCurrentDirectory(), "Files");
        [Test]
        public void TestCreateFiles()
        {
            if(File.Exists(_path)){
                File.Create(_path);
            }
            Assert.Pass();
        }
        [Test]
        public void TestReadFile()
        {
            var expectedListNames = new List<string>() {"Orson Milka Iddins",
                "Erna Dorey Battelle",
                "Flori Chaunce Franzel",
                "Odetta Sue Kaspar",
                "Roy Ketti Kopfen",
                "Madel Bordie Mapplebeck",
                "Selle Bellison",
                "Leonerd Adda Mitchell Monaghan",
                "Debra Micheli",
                "Heiley Avie Annakin" };
            var expectedPath = Path.Combine(_path, "unsorted-names-list.txt");
            var serviceMock = new Mock<IFileService>();
            serviceMock
                .Setup(m => m.Read(expectedPath))
                .Returns(expectedListNames)
                .Verifiable();
            var sut = new MockFile(expectedPath, serviceMock.Object);
            sut.RefreshRead(); 
            serviceMock.Verify(); 
            Assert.AreEqual(expectedListNames, sut.ListNames);
        }
        [Test]
        public void TestSorting()
        {
            var pathUnsorted = Path.Combine(_path, "unsorted-names-list.txt");
            var pathSorted = Path.Combine(_path, "sorted-names-list.txt");
            IFileService fileService = new FileService();

            var sorting = new SortingService(fileService.Read(pathUnsorted));
            var sortedListNames = sorting.GetAscByLastName();
            fileService.Create(pathSorted, sortedListNames);
            Assert.Pass();
        }
    }
}