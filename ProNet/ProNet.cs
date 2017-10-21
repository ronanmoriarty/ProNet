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
            if (!File.Exists(filename))
            {
                throw new ArgumentException($"File {filename} was not found");
            }
            _filename = filename;

            var xmlReaderSettings = new XmlReaderSettings();
            var proNetSchemaPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProNet.xsd");
            xmlReaderSettings.Schemas.Add(null ,proNetSchemaPath);
            xmlReaderSettings.ValidationType = ValidationType.Schema;
            xmlReaderSettings.ValidationEventHandler += HandleValidationEvent;

            var xmlReader = XmlReader.Create(filename, xmlReaderSettings);

            while (xmlReader.Read()) { }
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