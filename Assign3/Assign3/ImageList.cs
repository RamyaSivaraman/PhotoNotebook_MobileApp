using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace Assign3
    {
    public class ImageList : ViewModelBase
        {
        string imageschool;
        String imgTitle;
        DateTime imgDate;
        String imgUrlSource;
        String editimgTitle;
        DateTime editimgDate;
        String editimgUrlSource;


        public string Title
            {
            set { SetProperty(ref imgTitle, value); }
            get { return imgTitle; }
            }

        public DateTime ImageDate
            {
            set { SetProperty(ref imgDate, value); }
            get { return imgDate; }
            }
        public String UrlSource
            {
            set { SetProperty(ref imgUrlSource, value); }
            get { return imgUrlSource; }
            }

        public string EditimgTitle
            {
            set { SetProperty(ref editimgTitle, value); }
            get { return editimgTitle; }
            }

        public DateTime EditimgDate
            {
            set { SetProperty(ref editimgDate, value); }
            get { return editimgDate; }
            }
        public String EditimgUrlSource
            {
            set { SetProperty(ref editimgUrlSource, value); }
            get { return editimgUrlSource; }
            }
        public static ObservableCollection<Image> images = new ObservableCollection<Image>();

        public string ImageSchool { set { SetProperty(ref imageschool, value); } get { return imageschool; } }
        public ObservableCollection<Image> Images
            {
            set { SetProperty(ref images, value); }
            get { return images; }
            }

        public void MoveImageToTop(Image image)
            {
            Images.Move(Images.IndexOf(image), 0);
            }

        public void MoveImageToBottom(Image image)
            { Images.Move(Images.IndexOf(image), Images.Count - 1); }


        public void RemoveImage(Image image)
            {
            Images.Remove(image);
            }
        public void EditImage(Image image)
            {
            //   SaveImage = new Command(() => EditImageinList(image));
            //    EditimgUrlSource = image.Source;
            //    EditimgTitle = image.Title;
            //  EditimgDate = Convert.ToDateTime(image.Date);
            //   App.Current.MainPage.Navigation.PushModalAsync(new Page2(image));         
            }
        [XmlIgnore]
        public ICommand AddImage { set; get; }


        [XmlIgnore]
        public ICommand SaveImage { set; get; }

        public void EditImageinList(Image img)
            {

            img.ImgSource = ImageSource.FromUri(new Uri(EditimgUrlSource + "?width=40"));

            img.Date = Convert.ToString(EditimgDate);
            img.Detail = EditimgUrlSource;
            img.Title = EditimgTitle;
            }
        }
    }
