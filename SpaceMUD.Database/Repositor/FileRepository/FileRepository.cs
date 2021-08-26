using Newtonsoft.Json;
using SpaceMUD.Common.Tools;
using SpaceMUD.Common.Tools.Extensions;
using SpaceMUD.Database.Repositor.Base.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.Database.Repositor.FileRepository
{
    /// <summary>
    /// A simple file repository system. Holds all entities in their own json file within the same folder. Thus the Folder acts as the table, and the files as a row/entry.
    /// </summary>
    /// <typeparam name="T">The Entity type</typeparam>
    public class FileRepository<T> : IRepository<T> where T : class
    {
        private readonly DirectoryInfo RootDirectory;
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
            }).Select(task=> task.ContinueWith(jsonContent => JsonConvert.DeserializeObject<T>(jsonContent.Result))).ToList();

            IEnumerable<T> returnList = (await Task.WhenAll(list));
            disposables.ForEach(disposable => disposable.Dispose());
            return returnList;
        }

        public T GetSingle(long id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetSingleAsync(long id)
        {
            throw new NotImplementedException();
        }

        public T Insert(T obj)
        {
            throw new NotImplementedException();
        }

        public Task<T> InsertAsync(T Obj)
        {
            throw new NotImplementedException();
        }

        public void Update(T obj)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
