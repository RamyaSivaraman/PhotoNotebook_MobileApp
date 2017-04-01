using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Threading.Tasks;
using Windows.Storage;
[assembly: Dependency(typeof(Assign3.UWP.SaveAndLoad))]
namespace Assign3.UWP
    {

    public class SaveAndLoad : ISaveAndLoad
        {
        #region ISaveAndLoad implementation

        public async Task SaveXMLAsync(string filename, string text)
            {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await localFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(sampleFile, text);
            }

        public async Task<string> LoadXMLAsync(string filename)
            {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await storageFolder.GetFileAsync(filename);
            string text = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
            return text;
            }

        public bool FileExists(string filename)
            {
            var localFolder = ApplicationData.Current.LocalFolder;
            try
                {
                localFolder.GetFileAsync(filename).AsTask().Wait();
                return true;
                }
            catch
                {
                return false;
                }
            }

        #endregion
        }
    }
