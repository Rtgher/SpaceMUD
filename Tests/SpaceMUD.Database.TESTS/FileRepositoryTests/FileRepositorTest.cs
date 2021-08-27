﻿using NUnit.Framework;
using SpaceMUD.Data.Base.Interface;
using SpaceMUD.Database.Repositor.Base.Interface;
using SpaceMUD.Database.Repositor.FileRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.Database.TESTS.FileRepositoryTests
{
    [TestFixture]
    public class FileRepositorTest
    {
        class MockGameObject : IDatabaseObject { };

        [Test]
        public static void TestGetAll_DoesntError()
        {
            IRepository<MockGameObject> repo = new FileRepository<MockGameObject>();
            var objects = repo.GetAll();
            Assert.IsNotNull(objects);
        }

        [Test]
        public static void TestFileRepository_CreatesFolders()
        {
            IRepository<MockGameObject> repo = new FileRepository<MockGameObject>();
            repo.GetAll();
            DirectoryInfo path = ((FileRepository<MockGameObject>)repo).RootDirectory;

            Assert.IsNotEmpty(path.GetDirectories());
            Assert.IsNotNull(path.GetDirectories("MockGameObject").First());
        }
    }
}
