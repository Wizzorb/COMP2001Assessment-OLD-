using NUnit.Framework;

namespace dBTest
{
    public class Tests
    {
        //private static connection;

        [SetUp]
        public void Setup()
        {
            //connection = "Something";   //Does the connecting to database
        }

        [Test]
        public void testSPUpdate()
        {
            int returnCODE = 0;
            //using connection; 
            {
                //Use connection to invoke stored procedure.
                //Check return code of the procedure
                Assert.IsTrue(returnCODE == 0, "");
            }
        }
    }
}