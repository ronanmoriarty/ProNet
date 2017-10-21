using System;
using System.IO;

namespace ProNet
{
    public class ProNet : IProNet
    {
        public ProNet(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new ArgumentException($"File {filename} was not found");
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