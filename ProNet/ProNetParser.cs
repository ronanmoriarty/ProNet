using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace ProNet
{
    public class ProNetParser
    {
        private string _filename;

        public Network Parse(string filename)
        {
            EnsureFileExists(filename);
            _filename = filename;
            var xmlReaderSettings = GetXmlReaderSettings();
            var xmlReader = XmlReader.Create(filename, xmlReaderSettings);
            return AddProgrammers(xmlReader);
        }

        private Network AddProgrammers(XmlReader xmlReader)
        {
            var network = new Network();
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (xmlReader.Name == "Programmer")
                        {
                            var programmerName = xmlReader.GetAttribute("name");
                            Console.WriteLine($"Programmer name is : {programmerName}");
                            network.Programmers.Add(new Programmer(programmerName));
                        }
                        break;
                }
            }

            return network;
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
            xmlReaderSettings.Schemas.Add((string) null, (string) GetProNetSchemaPath());
            xmlReaderSettings.ValidationType = ValidationType.Schema;
            xmlReaderSettings.ValidationEventHandler += HandleValidationEvent;
            return xmlReaderSettings;
        }

        private static string GetProNetSchemaPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProNet.xsd");
        }

        private void HandleValidationEvent(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Error)
            {
                throw new ArgumentException($"File {_filename} is not a valid ProNet data file");
            }
        }
    }
}