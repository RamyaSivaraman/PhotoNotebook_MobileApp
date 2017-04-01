using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;
using System.ComponentModel;
using System.Xml;

namespace Assign3
    {
    public partial class Page : ContentPage
        {
        public int index = 0;
        ImageList disimglist = new ImageList();

        AppData appData;
        double globaltimervalue;
        int counttime = 0;
        double a;
        Boolean stoptimer = true;
        App app = Application.Current as App;
        public Page()
            {
            // Persistence logic
            if (app.imageIndexValue != null && app.imageIndexValue.Length > 0)
                {
                index = Int32.Parse(app.imageIndexValue);

                }
            if (app.timerCountValue != null && app.timerCountValue.Length > 0)
                {

                globaltimervalue = Double.Parse(app.timerCountValue);

                }
            InitializeComponent();

            appData = (AppData)app.AppData;
            if (appData != null && appData.ImageCollection.Count < 1)
                {
                ImageList defaultimgListFromXML = new ImageList();
                var assembly = typeof(Page).GetTypeInfo().Assembly;
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



            FetchPhoto();
            Timer();
            // saveAndTesttoXML();
            }

        void OnEntryCompleted(object sender, TextChangedEventArgs args)
            {
            if (entry.Text.Length > 0 && entry.Text != " " && entry.Text != ".")
                {
                if (Convert.ToDouble(entry.Text) >= 1 && Convert.ToDouble(entry.Text) <= 60)
                    {
                    globaltimervalue = Convert.ToDouble(entry.Text);
                    a = globaltimervalue;
                    app.timerCountValue = globaltimervalue + "";
                    counttime = 0;

                    }
                else { DisplayAlert("Alert", "The timer value must be within the the range 1 sec to 60 secs ", "OK"); }
                }
            }



        void Timer()
            {
            a = globaltimervalue;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (stoptimer)
                    {
                    ;
                    }

                else
                    {

                    if (counttime >= globaltimervalue)
                        {
                        a = globaltimervalue;

                        index++;
                        app.imageIndexValue = index + "";
                        FetchPhoto();
                        counttime = 0;

                        }
                    else
                        {
                        counttime++;
                        a--;
                        label1.Text = String.Format("Time Remaining {0}", a);
                        }

                    }
                return true;
            });
            }


        void OnOffSwitchToggled(object sender, ToggledEventArgs args)
            {

            if (!args.Value)
                {
                stoptimer = true;

                }
            else
                {
                if (stoptimer)
                    {
                    stoptimer = false;

                    }
                }

            }

        void FetchPhoto()
            {
            if (appData.ImageCollection.Count <= index)
                {
                index = 0;
                app.imageIndexValue = index + "";
                }
            //  appData.CurrentIImage = appData.ImageCollection.ElementAt(index);
            image.Source = appData.ImageCollection.ElementAt(index).ImgSource;

            }

        void OnImagePropertyChanged(object sender, PropertyChangedEventArgs args)
            {
            if (args.PropertyName == "IsLoading")
                {
                activityIndicator.IsRunning = ((Xamarin.Forms.Image)sender).IsLoading;
                }
            }
        void OnButtonClicked(object sender, EventArgs args)
            {
            timerToggle.IsToggled = false;

            Navigation.PushAsync(new Page1());



            }

        void saveAndTesttoXML()
            {
            ImageList defaultimgListFromXML = new ImageList();
            var assembly = typeof(Page).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("Assign3.XMLFile1.xml");

            String imageXMLDocAsStr = System.Xml.Linq.XDocument.Load(stream).ToString();

            SaveAndLoadImageXML util = new SaveAndLoadImageXML();
            util.SaveXMLToFile(imageXMLDocAsStr);


            }

        }
    }