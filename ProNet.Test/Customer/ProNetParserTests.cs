using System;
using System.IO;
using NUnit.Framework;

namespace ProNet.Test.Customer
{
    [TestFixture]
    public class ProNetParserTests
    {
        private Network _network;
        private const string FileName = "ProNet.xml";

        [Test]
        public void Parses_all_programmers()
        {
            _network = new ProNetParser().Parse(GetFullPath(FileName));
            Assert.That(_network.Programmers.Count, Is.EqualTo(10));
        }

        private string GetFullPath(string filename)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
        }
    }
}