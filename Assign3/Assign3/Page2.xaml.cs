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
    public partial class Page2 : ContentPage
        {
        App app;
        AppData appData;
        public Page2()
            {

            InitializeComponent();
            Image currentImage = (Image)BindingContext;
            if (currentImage.Title == "ImageFromFile" || currentImage.Title == "ImageFromResource" || currentImage.Title == "ImageFromStream" || currentImage.Title == "National Forest")
                {
                EditUrlentry.IsEnabled = false;
                EditTitle.IsEnabled = false;
                EditPictakenon.IsEnabled = false;
                return;
                }
            else
                {
                EditUrlentry.IsEnabled = true;
                EditTitle.IsEnabled = true;
                EditPictakenon.IsEnabled = true;
                }

               app = Application.Current as App;
               appData = (AppData)app.AppData;
            }

        public void SaveImage(object sender, EventArgs e)
            {
            SaveImageAndNavigateBack();
            }

        async void SaveImageAndNavigateBack()
            {
            Image currentImage = (Image)BindingContext;
         /*   if (currentImage.Title == "ImageFromFile" || currentImage.Title == "ImageFromResource" || currentImage.Title == "ImageFromStream" || currentImage.Title == "National Forest")
                {
                EditUrlentry.IsEnabled = false;
                EditTitle.IsEnabled = false;
                EditPictakenon.IsEnabled = false;
                return;
                }
            else
                {
                EditUrlentry.IsEnabled = true;
                EditTitle.IsEnabled = true;
                EditPictakenon.IsEnabled = true;
                }
                */
                if (currentImage.Source == null || currentImage.Title == null || currentImage.Source == "" || currentImage.Title == "")
                {
                await DisplayAlert("Alert", "Url entry and Title must be valid", "OK");
                return;
                }
            try
                {
                if (currentImage != null && currentImage.Source != null && currentImage.Source != " " && currentImage.Title != " ")
                    {
                    String currSource = currentImage.Source;
                    String currTitle = currentImage.Title;
                    if (currSource != null && currTitle != null && !(currTitle == "ImageFromFile" || currTitle == "ImageFromResource" || currTitle == "ImageFromStream"))
                        {
                        currentImage.ImgSource = ImageSource.FromUri(new Uri(currSource + "?width=50"));
                        }
                    }
                }
            catch (Exception e)
                {
                await DisplayAlert("Alert", "Url entry and Title must be valid", "OK");
                return;
                }




           // SaveTextAsync();

         /*   ImageList afterSavingList = new ImageList();
            afterSavingList.Images.Clear();
            var assembly = typeof(Page).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("Assign3.XMLFile1.xml");
            StreamReader reader = new StreamReader(stream);
            XmlSerializer xml = new XmlSerializer(typeof(ImageList));
            afterSavingList = xml.Deserialize(reader) as ImageList;*/
            // Navigate to the info page.
            await Navigation.PopModalAsync();

            }

        public async Task SaveTextAsync()
            {
            ImageList defaultimgListFromXML = new ImageList();
            defaultimgListFromXML.Images.Clear();
            var assembly = typeof(Page).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("Assign3.XMLFile1.xml");
            StreamReader reader = new StreamReader(stream);
            XmlSerializer xml = new XmlSerializer(typeof(ImageList));
            defaultimgListFromXML = xml.Deserialize(reader) as ImageList;


            ImageList imageListTobeSaved = new ImageList();
            imageListTobeSaved.Images.Clear();
            foreach (Image img in appData.ImageCollection)
                {
                imageListTobeSaved.Images.Add(img);
                }
            assembly = typeof(Page2).GetTypeInfo().Assembly;
            Stream ostream = assembly.GetManifestResourceStream("Assign3.XMLFile1.xml");
            XmlSerializer writer = new XmlSerializer(typeof(ImageList));
            writer.Serialize(ostream, imageListTobeSaved);


            }
        }
    }
