using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace Assign3
    {
    public partial class Page1 : ContentPage
        {
        public Page1()
            {
            InitializeComponent();
            AppData appData = (AppData)BindingContext;
            if (appData != null && appData.ImageCollection.Count < 1)
                {
                ImageList defaultimgListFromXML = new ImageList();
                var assembly = typeof(Page1).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("Assign3.XMLFile1.xml");
                StreamReader reader = new StreamReader(stream);
                XmlSerializer xml = new XmlSerializer(typeof(ImageList));
                defaultimgListFromXML = xml.Deserialize(reader) as ImageList;
                foreach (Image image in defaultimgListFromXML.Images)
                    {
                    if (image.Title == "ImageFromFile")
                        {
                        image.ImgSource = "Res2.jpg";
                        image.Source = "Res2.jpg";
                        }
                    else if (image.Title == "ImageFromResource")
                        {
                        image.ImgSource = ImageSource.FromResource("Assign3.resourcepic.jpg");
                        image.Source = "Assign3.resourcepic.jpg";
                        }
                    else if (image.Title == "ImageFromStream")
                        {
                        image.ImgSource = ImageSource.FromStream(() =>
                        {
                            Assembly assembly1 = GetType().GetTypeInfo().Assembly;
                            Stream stream1 = assembly1.GetManifestResourceStream("Assign3.streampic.jpg");
                            return stream1;
                        });
                        image.Source = "Assign3.streampic.jpg";
                        }
                    else
                        {
                        image.ImgSource = ImageSource.FromUri(new Uri(image.Source + "?width=50"));
                        //image.ImgSource = image.Source+"?width=50";

                        }
                    appData.ImageCollection.Add(image);
                    }
                }
            SaveAndLoadImageXML util = new SaveAndLoadImageXML();
            //   String afterSaveStr = util.LoadXMLFromFile();
            //   afterSaveStr = afterSaveStr + "";
            }

        public void MoveImageToTop(object sender, EventArgs e)
            {
            AppData appData = (AppData)BindingContext;
            var mi = ((MenuItem)sender);
            Image image = (Image)mi.CommandParameter;
            appData.ImageCollection.Move(appData.ImageCollection.IndexOf(image), 0);
            }

        public void EditImage(object sender, EventArgs e)
            {

            AppData appData = (AppData)BindingContext;
            var mi = ((MenuItem)sender);
            Image image = (Image)mi.CommandParameter;
          /*  if (image.Title == "ImageFromFile" || image.Title == "ImageFromResource" || image.Title == "ImageFromStream" || image.Title == "National Forest")
                {
                DisplayAlert("Alert", "Cannot edit default images", "OK");
                }*/               
                // Navigate to the info page.
                GoToImageDetailPage(image, false);
                
            }

        public void AddImage(object sender, EventArgs e)
            {
            Image image = new Image();
            // Navigate to the info page.
            GoToImageDetailPage(image, true);

            }

        public void MoveImageToBottom(object sender, EventArgs e)
            {
            AppData appData = (AppData)BindingContext;
            var mi = ((MenuItem)sender);
            Image image = (Image)mi.CommandParameter;
            appData.ImageCollection.Move(appData.ImageCollection.IndexOf(image), appData.ImageCollection.Count - 1);
            }


        public void RemoveImage(object sender, EventArgs e)
            {
            AppData appData = (AppData)BindingContext;
            var mi = ((MenuItem)sender);
            Image image = (Image)mi.CommandParameter;
            if (image.Title == "ImageFromFile" || image.Title == "ImageFromResource" || image.Title == "ImageFromStream" || image.Title == "National Forest")
                {
                DisplayAlert("Alert", "Cannot delete default images", "OK");
                }


            else
                {
                appData.ImageCollection.Remove(image);
                }
                
            }


        async void GoToImageDetailPage(Image img, Boolean isNewImage)
            {
            AppData appData = (AppData)BindingContext;

            // Set info item to CurrentInfo property of AppData.
            appData.CurrentIImage = img;

            // Navigate to the info page.
            await Navigation.PushModalAsync(new Page2());

            // Add new info item to the collection.
            if (isNewImage)
                {
                appData.ImageCollection.Add(img);
                }
            }
        }
    }
