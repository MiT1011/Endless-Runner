
using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

    public class Preference
    {
        private Preference()
        {
            this.LoadData();
        }

        public static Preference Instance
        {
            get
            {
                if (Preference._instance == null)
                {
                    Preference._instance = new Preference();
                }
                return Preference._instance;
            }
        }

        private void LoadData()
        {
            if (PlayerPrefs.HasKey(this.UserData))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(this.User.GetType());
                StringReader textReader = new StringReader(PlayerPrefs.GetString(this.UserData));
                this.User = (User)xmlSerializer.Deserialize(textReader);

            }
            else
            {
                this.SaveData();
            }
        }

        public void SaveData()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(this.User.GetType());
            Utf8StringWriter stringWriter = new Utf8StringWriter();
            xmlSerializer.Serialize(stringWriter, this.User);
            PlayerPrefs.SetString(this.UserData, stringWriter.ToString());
        }

        public void ClearData()
        {
            PlayerPrefs.DeleteAll();
        }
        
        public string UserData = "userdata";

        public User User = new User();

        private static Preference _instance;

        public sealed class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding
            {
                get
                {
                    return Encoding.UTF8;
                }
            }
        }

    }