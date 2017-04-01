using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign3
    {
   public interface ISaveAndLoad
        {
      
            Task SaveXMLAsync(string filename, string text);
            Task<string> LoadXMLAsync(string filename);
            bool FileExists(string filename);
            }
    }
