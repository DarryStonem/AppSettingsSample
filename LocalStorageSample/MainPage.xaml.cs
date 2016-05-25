using LocalStorageSample.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LocalStorageSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            btnSave.Tapped += BtnSave_Tapped;
        }

        private void BtnSave_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var service = new LocalStorageService();
            var key = "personList";

            List<Person> personList = new List<Person>();
            personList.Add(new Person() { Name = "Cristian", Email = "cristian@microsoft.com" });
            personList.Add(new Person() { Name = "Prannav", Email = "prannav@microsoft.com" });

            // Here is where I save the list to the Application Settings
            service.SaveList<Person>(personList, key);

            // To retrieve the information stored in the App Settings:
            var list = service.RetrieveList<Person>(key);
        }
    }
}
