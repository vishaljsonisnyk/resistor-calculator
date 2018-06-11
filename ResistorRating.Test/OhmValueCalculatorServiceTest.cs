using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResistorRating.Library.Exceptions;
using ResistorRating.Library.Models;

namespace ResistorRating.Test
{
    [TestClass]
    public class OhmValueCalculatorServiceTest : TestBase
    {
        private IList<ElectronicColorRing> allRingTypes;

        public OhmValueCalculatorServiceTest() : base()
        {
            this.allRingTypes = LookupService.GetAllColorRingTypes().ToList();
        }

        [TestMethod]
        public void OhmValueCalculatorServiceExists()
        {
            Assert.IsNotNull(OhmValueCalculatorService);
        }

        [TestMethod]
        public void ShouldGetActualValueZero()
        {
            var blackRingCode = allRingTypes.First(rt => rt.RingName == RingName.Black).RingCode;
            var noneResistanceRingCode = allRingTypes.First(rt => rt.RingName == RingName.None).RingCode;
            Assert.IsTrue(OhmValueCalculatorService.CalculateOhmValue(blackRingCode, noneResistanceRingCode).ActualOhm == 0);
        }

        [TestMethod]
        public void ShouldGetActualValueTen()
        {
            var brownRingCode = allRingTypes.First(rt => rt.RingName == RingName.Brown).RingCode;
            var blackRingCode = allRingTypes.First(rt => rt.RingName == RingName.Black).RingCode;
            var noneResistanceRingCode = allRingTypes.First(rt => rt.RingName == RingName.None).RingCode;
            Assert.IsTrue(OhmValueCalculatorService.CalculateOhmValue(brownRingCode, noneResistanceRingCode, blackRingCode, blackRingCode).ActualOhm == 10);
        }

        [TestMethod]
        [ExpectedException(typeof(BandNotFoundException))]
        public void ShouldGetBandNotFoundException()
        {
            var brownRingCode = allRingTypes.First(rt => rt.RingName == RingName.Brown).RingCode;
            var blackRingCode = allRingTypes.First(rt => rt.RingName == RingName.Black).RingCode;
            var noneResistanceRingCode = allRingTypes.First(rt => rt.RingName == RingName.None).RingCode;
            Assert.IsTrue(OhmValueCalculatorService.CalculateOhmValue("DE", noneResistanceRingCode, blackRingCode, blackRingCode).ActualOhm == 10);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongColorBandSelectedException))]
        public void ShouldGetWrongColorBandSelectedException()
        {
            var pinkRingCode = allRingTypes.First(rt => rt.RingName == RingName.Pink).RingCode;
            var blackRingCode = allRingTypes.First(rt => rt.RingName == RingName.Black).RingCode;
            var noneResistanceRingCode = allRingTypes.First(rt => rt.RingName == RingName.None).RingCode;
            Assert.IsTrue(OhmValueCalculatorService.CalculateOhmValue(pinkRingCode, noneResistanceRingCode, blackRingCode, blackRingCode).ActualOhm == 10);
        }

        [TestMethod]
        public void ShouldGetActualValuePointTwoWithMinAndMax()
        {
            var redRingCode = allRingTypes.First(rt => rt.RingName == RingName.Red).RingCode;
            var blackRingCode = allRingTypes.First(rt => rt.RingName == RingName.Black).RingCode;
            var silverRingCode = allRingTypes.First(rt => rt.RingName == RingName.Silver).RingCode;
            var yellowResistanceRingCode = allRingTypes.First(rt => rt.RingName == RingName.Yellow).RingCode;

            var calculatedValue = OhmValueCalculatorService.CalculateOhmValue(redRingCode, yellowResistanceRingCode, blackRingCode, silverRingCode);
            Assert.IsTrue(calculatedValue.ActualOhm == 0.2);
            Assert.IsTrue(calculatedValue.MinimumOhm == 0.19);
            Assert.IsTrue(calculatedValue.MaximumOhm > 0.2 && calculatedValue.MaximumOhm < 0.22); // for double type, we need to add tolerance in assert.
        }
    }
}
