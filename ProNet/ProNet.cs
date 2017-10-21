using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace ProNet
{
    public class ProNet : IProNet
    {
        private readonly string _filename;

        public ProNet(string filename)
        {
            EnsureFileExists(filename);
            _filename = filename;
            var xmlReaderSettings = GetXmlReaderSettings();
            var xmlReader = XmlReader.Create(filename, xmlReaderSettings);
            while (xmlReader.Read()) { }
        }

        private static void EnsureFileExists(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new ArgumentException($"File {filename} was not found");
            }
        }

        private XmlReaderSettings GetXmlReaderSettings()
        {
            var xmlReaderSettings = new XmlReaderSettings();
            xmlReaderSettings.Schemas.Add(null, GetProNetSchemaPath());
            xmlReaderSettings.ValidationType = ValidationType.Schema;
            xmlReaderSettings.ValidationEventHandler += HandleValidationEvent;
            return xmlReaderSettings;
        }

        private static string GetProNetSchemaPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProNet.xsd");
        }

        void HandleValidationEvent(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Error)
            {
                throw new ArgumentException($"File {_filename} is not a valid ProNet data file");
            }
        }

        public string[] Skills(string programmer)
        {
            throw new System.NotImplementedException();
        }

        public string[] Recommendations(string programmer)
        {
            throw new System.NotImplementedException();
        }

        public double Rank(string programmer)
        {
            throw new System.NotImplementedException();
        }

        public int DegreesOfSeparation(string programmer1, string programmer2)
        {
            throw new System.NotImplementedException();
        }

        public double TeamStrength(string language, string[] team)
        {
            throw new System.NotImplementedException();
        }

        public string[] FindStrongestTeam(string language, int teamSize)
        {
            throw new System.NotImplementedException();
        }
    }
}