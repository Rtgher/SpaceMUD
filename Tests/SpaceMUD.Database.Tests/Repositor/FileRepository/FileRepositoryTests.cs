using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceMUD.Database.Repositor.Base.Interface;
using SpaceMUD.Database.Repositor.FileRepository;
using SpaceMUD.Data.Base.Interface;
using System.IO;
using System.Linq;

namespace SpaceMUD.Database.Tests.Repositor.FileRepository
{
    [TestClass]
    public class FileRepositoryTests
    {
        class MockGameObject : IDatabaseObject { }
        [TestMethod]
        public void TestGetAll_DoesntError()
        {
            IRepository<MockGameObject> repo = new FileRepository<MockGameObject>();
            var objects = repo.GetAll();
            Assert.IsNotNull(objects);
        }

        [TestMethod]
        public void TestFileRepository_CreatesFolders()
        {
            IRepository<MockGameObject> repo = new FileRepository<MockGameObject>();
            repo.GetAll();
            DirectoryInfo path = ((FileRepository<MockGameObject>)repo).RootDirectory;

            Assert.IsFalse(path.GetDirectories()?.Count() == 0);
            Assert.IsNotNull(path.GetDirectories("MockGameObject").First());
        }

        [TestMethod]
        public void TestFileRepository_InsertCreatesFile()
        {
            IRepository<MockGameObject> repo = new FileRepository<MockGameObject>();
            var obj = new MockGameObject();
            obj = repo.Insert(obj);

            Assert.IsTrue(((FileRepository<MockGameObject>)repo).RootDirectory.GetDirectories("MockGameObject").First().GetFiles($"{obj.Id}.json").Count()==1);
        }

        [TestMethod]
        public void TestFileRepository_GetAllReturnsallFiles()
        {
            IRepository<MockGameObject> repo = new FileRepository<MockGameObject>();
            int countOfFiles = ((FileRepository<MockGameObject>)repo).RootDirectory.GetDirectories("MockGameObject").First().GetFiles().Count();

            var allMockObj = repo.GetAll();

            Assert.AreEqual(countOfFiles, allMockObj.Count());
        }
    }
}
