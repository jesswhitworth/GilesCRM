using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace GilesCRM.Giles.App
{
    class SettingsManager {
        SettingsData mySettings;
        public SettingsManager(string pathName) {
            // TO-DO: Error handling
            FileStream stream = new FileStream(pathName, FileMode.OpenOrCreate);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(SettingsData));
            mySettings = (SettingsData)ser.ReadObject(stream);
        }
        public SettingsManager(string viewsFolder, string defaultView, ConnectionData defaultConnection) {
            mySettings = new SettingsData();
            mySettings.viewsFolderPathname = viewsFolder;
            mySettings.defaultViewFilename = defaultView;
            mySettings.defaultConnection = defaultConnection;
        }

        public string getViewsFolder() {
            return mySettings.viewsFolderPathname;
        }
        
        public string getDefaultView() {
            return mySettings.viewsFolderPathname + mySettings.defaultViewFilename;
        }
        
        public ConnectionData getDefaultConnection() {
            return mySettings.defaultConnection;
        }
    }
    [DataContract]
    public class ConnectionData {
        [DataMember]
        public string databaseName;
        [DataMember]
        public string userName;
        [DataMember]
        public string password;
    }
    [DataContract]
    class SettingsData {
        [DataMember]
        public ConnectionData defaultConnection;
        [DataMember]
        public string viewsFolderPathname;
        [DataMember]
        public string defaultViewFilename;
    }
}
