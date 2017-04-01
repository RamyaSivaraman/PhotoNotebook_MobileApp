using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace Assign3
    {
    public class Image : ViewModelBase
        {
        string date = Convert.ToString(DateTime.Today), source, detail, title;
        ImageSource imgSource;

        App app;
        public Image()
            {
            app = Application.Current as App;
            MoveToTopCommand = new Command(() => MoveImageToTop(this));
            MoveToBottomCommand = new Command(() => MoveImageToBottom(this));
            RemoveCommand = new Command(() => RemoveImage(this));
            // EditCommand = new Command(() => App.Current.MainPage.Navigation.PushModalAsync(new Page2()));
            EditCommand = new Command(() => EditImage(this));
            }
        public void MoveImageToTop(Image image)
            {

            app.AppData.ImageCollection.Move(app.AppData.ImageCollection.IndexOf(image), 0);
            }

        public void EditImage(Image image)
            {

            app.AppData.ImageCollection.Move(app.AppData.ImageCollection.IndexOf(image), 0);
            }

        public void MoveImageToBottom(Image image)
            { app.AppData.ImageCollection.Move(app.AppData.ImageCollection.IndexOf(image), app.AppData.ImageCollection.Count - 1); }


        public void RemoveImage(Image image)
            {
            app.AppData.ImageCollection.Remove(image);
            }


        public string Date
            {
            set { SetProperty(ref date, value); }
            get { return date; }
            }

        public string Source
            {
            set { SetProperty(ref source, value); }
            get { return source; }
            }

        public string Detail
            {
            set { SetProperty(ref detail, value); }
            get { return detail; }
            }

        public string Title
            {
            set { SetProperty(ref title, value); }
            get { return title; }
            }

        public ImageSource ImgSource
            {
            set { SetProperty(ref imgSource, value); }
            get { return imgSource; }

            }
        public ImageSource ContextActions
            {
            set { SetProperty(ref imgSource, value); }
            get { return imgSource; }
            }
        [XmlIgnore]
        public ICommand MoveToTopCommand { private set; get; }

        [XmlIgnore]
        public ICommand MoveToBottomCommand { private set; get; }

        [XmlIgnore]
        public ICommand RemoveCommand { private set; get; }

        [XmlIgnore]
        public ICommand EditCommand { private set; get; }

        [XmlIgnore]
        public ImageList ImageList { set; get; }

        }

    }
