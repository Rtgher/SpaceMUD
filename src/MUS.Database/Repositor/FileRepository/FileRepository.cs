using MUS.Common.Interfaces;
using MUS.Database.Repositor.Base.Interface;
using Newtonsoft.Json;
using MUS.Common.Exceptions.Database;
using MUS.Common.Tools;
using MUS.Common.Tools.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUS.Database.Repositor.FileRepository
{
    /// <summary>
    /// A simple file repository system. Holds all entities in their own json file within the same folder. Thus the Folder acts as the table, and the files as a row/entry.
    /// Check IRepository for an overview of the methods functionality
    /// </summary>
    /// <typeparam name="T">The Entity type</typeparam>
    public class FileRepository<T> : IRepository<T> where T : IDatabaseObject
    {
        public readonly DirectoryInfo RootDirectory;
        private readonly DirectoryInfo EntityFolder;
        private readonly string EntityName = typeof(T).Name;
        private readonly string FileFormatEnding = "json";


        DirectoryInfo DirectoryFolderRootLocation()
        {
            var rootDirectory = DirectoryHelper.GetInstalationDirectoryRoot();
            string dbRootName = "FileDb";
            var dbDirectory = new DirectoryInfo($"{rootDirectory.FullName }\\{dbRootName}");

            return dbDirectory.CreateIfNotExist();
        }

        public FileRepository()
        {
            RootDirectory = DirectoryFolderRootLocation();
            EntityFolder = new DirectoryInfo($"{RootDirectory.FullName}\\{EntityName}").
                CreateIfNotExist();
        }

        public IEnumerable<T> GetAll()
        {
            List<T> list = new List<T>();
            foreach (var fileInfo in EntityFolder.GetFiles())
            {
                using (var fileReader = new StreamReader(fileInfo.FullName))
                {
                    var jsonContent = fileReader.ReadToEnd();
                    var entity = JsonConvert.DeserializeObject<T>(jsonContent);
                    list.Add(entity);
                }
            }
            return list;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            List<IDisposable> disposables = new List<IDisposable>();
            List<Task<T>> list = EntityFolder.GetFiles().Select(fileInfo =>
            {
                var fileReader = new StreamReader(fileInfo.FullName);
                disposables.Add(fileReader);
                var jsonContentReadTask = fileReader.ReadToEndAsync();
                return jsonContentReadTask;
            }).Select(task => task.ContinueWith(jsonContent => JsonConvert.DeserializeObject<T>(jsonContent.Result))).ToList();

            IEnumerable<T> returnList = await Task.WhenAll(list);
            disposables.ForEach(disposable => disposable.Dispose());
            return returnList;
        }

        public T GetSingle(long id)
        {
            var filePath = $"{EntityFolder.FullName}\\{id}.{FileFormatEnding}";
            FileInfo fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists) throw new MUDDatabaseNoDataException($"Could not find the requested data. Searched for obj id '{id}' in {EntityName} file database.");
            using (var fileReader = new StreamReader(filePath))
            {
                var deserialised = fileReader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(deserialised);
            }
        }

        public async Task<T> GetSingleAsync(long id)
        {
            var filePath = $"{EntityFolder.FullName}\\{id}.{FileFormatEnding}";
            FileInfo fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists) throw new MUDDatabaseNoDataException($"Could not find the requested data. Searched for obj id '{id}' in {EntityName} file database.");
            using (var fileReader = new StreamReader(filePath))
            {
                var deserialised = await fileReader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<T>(deserialised);
            }
        }

        public T Insert(T obj)
        {
            int objId = EntityFolder.GetFiles()?.Count() ?? 0;
            using (var fileWriter = new StreamWriter($"{EntityFolder.FullName}\\{objId}.{FileFormatEnding}", append: false, encoding: Encoding.UTF8))
            {
                var serialised = JsonConvert.SerializeObject(obj);
                fileWriter.WriteLine(serialised);
                fileWriter.Flush();
            }
            obj.Id = objId;
            return obj;
        }

        public async Task<T> InsertAsync(T obj)
        {
            int objId = EntityFolder.GetFiles()?.Count() ?? 0;
            using (var fileWriter = new StreamWriter($"{EntityFolder.FullName}\\{objId}.{FileFormatEnding}", append: false, encoding: Encoding.UTF8))
            {
                var serialised = JsonConvert.SerializeObject(obj);
                await fileWriter.WriteLineAsync(serialised);
                fileWriter.Flush();
            }
            obj.Id = objId;
            return obj;
        }

        public void Update(T obj)
        {
            using (var fileWriter = new StreamWriter($"{EntityFolder.FullName}\\{obj.Id}.{FileFormatEnding}", append: false, encoding: Encoding.UTF8))
            {
                var serialised = JsonConvert.SerializeObject(obj);
                fileWriter.WriteLine(serialised);
                fileWriter.Flush();
            }
        }

        public async Task UpdateAsync(T obj)
        {
            using (var fileWriter = new StreamWriter($"{EntityFolder.FullName}\\{obj.Id}.{FileFormatEnding}", append: false, encoding: Encoding.UTF8))
            {
                var serialised = JsonConvert.SerializeObject(obj);
                await fileWriter.WriteLineAsync(serialised);
                fileWriter.Flush();
            }
        }
    }
}
