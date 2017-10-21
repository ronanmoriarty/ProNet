using NUnit.Framework;

namespace ProNet.Test.Customer
{
    [TestFixture]
    public class CustomerTestsImpl : AbstractCustomerTests
    {
        protected override IProNet LoadProNet(string filename)
        {
            new ProNetParser().Parse(filename);
            return new ProNet();
        }
    }
}
