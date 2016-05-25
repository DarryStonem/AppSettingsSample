using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;

namespace LocalStorageSample
{
    public class LocalStorageService
    {
        ApplicationDataContainer AppSettings = ApplicationData.Current.LocalSettings;

        /// <summary>
        /// Store information to the ApplicationData in the Local Settings.
        /// You can use this method to retrieve the information.
        /// </summary>
        /// <typeparam name="ListType"></typeparam>
        /// <param name="list"></param>
        /// <param name="key"></param>
        public void SaveList<ListType>(List<ListType> list, string key)
        {
            // Serialize the list to a json
            var json = JsonConvert.SerializeObject(list);

            // Save the json to the app settings with the key we want
            AppSettings.Values[key] = json;
        }

        /// <summary>
        /// Retrieve the information from the Local Settings using the Application Data. 
        /// </summary>
        /// <typeparam name="ListType"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<ListType> RetrieveList<ListType>(string key)
        {
            // Search if there is the Setting with the desired key
            if (AppSettings.Values.ContainsKey(key))
            {
                // Retrive the value from the App Settings.
                var value = AppSettings.Values[key].ToString();

                // Deserialize the Object from the List. 
                var list = JsonConvert.DeserializeObject<List<ListType>>(value);

                // And we return the list.
                return list;
            }

            // If there is no value stored, we return null.
            return null;
        }
    }
}
