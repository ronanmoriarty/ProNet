using System;
using System.IO;
using System.Linq;
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
            Assert.That(_network.Programmers.Select(programmer => programmer.Name), Is.EquivalentTo(new[] { "Bill", "Dave", "Ed", "Frank", "Jason", "Jill", "Liz", "Nick", "Rick", "Stu" }));
        }

        private string GetFullPath(string filename)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
        }
    }
}