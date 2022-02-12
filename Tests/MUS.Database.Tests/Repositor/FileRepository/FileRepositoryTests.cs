using MUS.Database.Repositor.Base.Interface;
using MUS.Database.Repositor.FileRepository;
using System.IO;
using NUnit.Framework;
using System.Linq;
using MUS.Common.Interfaces;

namespace MUS.Database.Tests.Repositor.FileRepository
{
    [TestFixture]
    public class FileRepositoryTests
    {
        class MockGameObject : IDatabaseObject { public long Id { get; set; } }
        [Test]
        public void TestGetAll_DoesntError()
        {
            IRepository<MockGameObject> repo = new FileRepository<MockGameObject>();
            var objects = repo.GetAll();
            Assert.IsNotNull(objects);
        }

        [Test]
        public void TestFileRepository_CreatesFolders()
        {
            IRepository<MockGameObject> repo = new FileRepository<MockGameObject>();
            repo.GetAll();
            DirectoryInfo path = ((FileRepository<MockGameObject>)repo).RootDirectory;

            Assert.IsFalse(path.GetDirectories()?.Count() == 0);
            Assert.IsNotNull(path.GetDirectories("MockGameObject").First());
        }

        [Test]
        public void TestFileRepository_InsertCreatesFile()
        {
            IRepository<MockGameObject> repo = new FileRepository<MockGameObject>();
            var obj = new MockGameObject();
            obj = repo.Insert(obj);

            Assert.IsTrue(((FileRepository<MockGameObject>)repo).RootDirectory.GetDirectories("MockGameObject").First().GetFiles($"{obj.Id}.json").Count()==1);
        }

        [Test]
        public void TestFileRepository_GetAllReturnsallFiles()
        {
            IRepository<MockGameObject> repo = new FileRepository<MockGameObject>();
            int countOfFiles = ((FileRepository<MockGameObject>)repo).RootDirectory.GetDirectories("MockGameObject").First().GetFiles().Count();

            var allMockObj = repo.GetAll();

            Assert.AreEqual(countOfFiles, allMockObj.Count());
        }
    }
}
