using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Windows.Storage;

namespace CcontreC.Repositories
{
    class LocalRepository : IRepository
    {
        private string _filename;
        StorageFolder _folder = ApplicationData.Current.LocalFolder;

        public LocalRepository()
        {

            _filename = DateTime.Now.Date.Year.ToString() +
                        DateTime.Now.Date.Month.ToString() +
                        DateTime.Now.Date.Day.ToString() +
                        DateTime.Now.TimeOfDay.Hours.ToString() +
                        DateTime.Now.TimeOfDay.Minutes.ToString() +
                        DateTime.Now.TimeOfDay.Seconds.ToString() + 
                        "_ccontrecData.json";
        }

        public Task Save(object obj)
        {
            return Task.Run(async () => {
                string JSON = JsonConvert.SerializeObject(obj);
                var file = await OpenFileAsync();
                await FileIO.WriteTextAsync(file, JSON);
            });
        }

        private async Task<StorageFile> OpenFileAsync()
        {
            return await _folder.CreateFileAsync(_filename, CreationCollisionOption.ReplaceExisting);
        }
    }
}
