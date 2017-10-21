using System.Collections.Generic;

namespace ProNet
{
    public class Network
    {
        public Network()
        {
            Programmers = new List<Programmer>();
        }

        public IList<Programmer> Programmers { get; set; }
    }
}