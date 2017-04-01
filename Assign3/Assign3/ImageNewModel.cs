using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Xml.Serialization;
using Xamarin.Forms;
using System.Reflection;

namespace Assign3
    {

    public class ImageNewModel : ViewModelBase
        {

        ImageList imagelist;


        public ImageNewModel() : this(null)
            {
            }


        public ImageNewModel(IDictionary<string, object> properties)
            {
            ImageList = new ImageList();
            string uri = "XMLFile1.xml";
            var assembly = typeof(Page1).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("Assign3.XMLFile1.xml");
            StreamReader reader = new StreamReader(stream);
            XmlSerializer xml = new XmlSerializer(typeof(ImageList));
            ImageList = xml.Deserialize(reader) as ImageList;

            foreach (Image image in ImageList.Images)
                {
                if (image.Title == "ImageFromFile")
                    {
                    image.ImgSource = "Res2.jpg";
                    }
                else if (image.Title == "ImageFromResource")
                    {
                    image.ImgSource = ImageSource.FromResource("Assign3.resourcepic.jpg");
                    }
                else if (image.Title == "ImageFromStream")
                    {
                    image.ImgSource = ImageSource.FromStream(() =>
                    {
                        Assembly assembly1 = GetType().GetTypeInfo().Assembly;
                        Stream stream1 = assembly1.GetManifestResourceStream("Assign3.streampic.jpg");
                        return stream1;
                    });
                    }
                else
                    {
                    // image.ImgSource = ImageSource.FromUri(new Uri(image.Source));
                    image.ImgSource = image.Source;
                    }
                // Set StudentBody property in each Student object.
                image.ImageList = ImageList;

                }

            ImageList.AddImage = new Command(() => AddImageToList());


            }
        public ImageList ImageList
            {
            protected set { SetProperty(ref imagelist, value); }
            get { return imagelist; }
            }

        public void AddImageToList()
            {
            Image image = new Image();
            image.ImgSource = ImageSource.FromUri(new Uri(ImageList.UrlSource + "?width=40"));
            image.Detail = ImageList.UrlSource;
            image.Date = Convert.ToString(ImageList.ImageDate);
            image.Title = ImageList.Title;
            image.ImageList = ImageList;
            ImageList.images.Add(image);
            }

        }
    }
