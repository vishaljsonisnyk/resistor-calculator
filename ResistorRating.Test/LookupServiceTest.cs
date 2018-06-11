using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ResistorRating.Test
{
    [TestClass]
    public class LookupServiceTest : TestBase
    {
        [TestMethod]
        public void LookupServiceExists()
        {
            Assert.IsNotNull(LookupService);
        }

        [TestMethod]
        public void LookupServiceHasData()
        {
            Assert.IsTrue(LookupService.GetAllColorRingTypes().ToList().Count > 0);
        }
    }
}
