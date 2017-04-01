using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Assign3
    {
    class SaveAndLoadImageXML
        {


        const string fileName = "images.xml";
        public SaveAndLoadImageXML ()
            {            

            }


         public async void SaveXMLToFile (String xmlAsString)
            {
            var fileService = DependencyService.Get<ISaveAndLoad>();
            await Task.FromResult<Task>(fileService.SaveXMLAsync(fileName, xmlAsString));
           
          //  await fileService.SaveXMLAsync(fileName, xmlAsString);
            }

         public string LoadXMLFromFile()
            {
            var fileService = DependencyService.Get<ISaveAndLoad>();
            Task<string> loadedXMLStr = Task.Run(async () =>
            {
                string msg = await  fileService.LoadXMLAsync(fileName);
                return msg;
            });
          
            return loadedXMLStr.Result;
            }


        }
    }
