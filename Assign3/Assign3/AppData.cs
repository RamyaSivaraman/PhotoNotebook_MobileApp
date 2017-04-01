using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assign3
    {
    public class AppData
        {
        public AppData()
            {
            ImageCollection = new ObservableCollection<Image>();
            CurrentImageIndex = -1;
            }

        public ObservableCollection<Image> ImageCollection { private set; get; }
        [XmlIgnore]
        public Image CurrentIImage { set; get; }

        public int CurrentImageIndex { set; get; }

        public string Serialize()
            {
            // If the CurrentImage is valid, set the CurrentInfoIndex.
            if (CurrentIImage != null)
                {
                CurrentImageIndex = ImageCollection.IndexOf(CurrentIImage);
                }
            XmlSerializer serializer = new XmlSerializer(typeof(AppData));
            using (StringWriter stringWriter = new StringWriter())
                {
                serializer.Serialize(stringWriter, this);
                return stringWriter.GetStringBuilder().ToString();
                }
            }


        public static AppData Deserialize(string strAppData)
            {
            XmlSerializer serializer = new XmlSerializer(typeof(AppData));
            using (StringReader stringReader = new StringReader(strAppData))
                {
                AppData appData = (AppData)serializer.Deserialize(stringReader);

                // If the CurrentInfoIndex is valid, set the CurrentInfo.
                if (appData.CurrentImageIndex != -1)
                    {
                    appData.CurrentIImage = appData.ImageCollection[appData.CurrentImageIndex];
                    }
                return appData;
                }
            }

        }
    }
