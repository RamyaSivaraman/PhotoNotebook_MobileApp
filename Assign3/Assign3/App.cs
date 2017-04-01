using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Assign3
    {
    public class App : Application
        {
        const string timerValue = "timerValue";
        const string imageIndex = "imageIndex";

        public App()
            {
            if (Properties.ContainsKey(timerValue))
                {
                timerCountValue = (string)Properties[timerValue];
                }

            if (Properties.ContainsKey(imageIndex))
                {
                imageIndexValue = (string)Properties[imageIndex];
                }

            AppData = new AppData();
            /*  if (Properties.ContainsKey("appData"))
                  {
                  AppData = AppData.Deserialize((string)Properties["appData"]);
                  }
              else
                  {
                  ;
                  }   */
            Page page = new Assign3.Page();
            MainPage = new NavigationPage(page);

            /* if (Properties.ContainsKey("isImageDetailPageActive") &&
               (bool)Properties["isImageDetailPageActive"])
                 {
                 page.Navigation.PushAsync(new Page2(), false);
                 }*/

            }
        public AppData AppData { private set; get; }

        public string imageIndexValue { set; get; }

        public string timerCountValue { set; get; }

        protected override void OnStart()
            {
            // Handle when your app starts
            }

        protected override void OnSleep()
            {
            /* Handle when your app sleeps
               Save AppData serialized into string.
               Properties["appData"] = AppData.Serialize();
               Save Boolean for info page active.
               Properties["isImageDetailPageActive"] = MainPage.Navigation.NavigationStack.Last() is Page2;*/

            Properties[timerValue] = timerCountValue;

            Properties[imageIndex] = imageIndexValue;
            }

        protected override void OnResume()
            {
            // Handle when your app resumes
            }
        }
    }
