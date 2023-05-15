using WeaterLibrary;
namespace WeatherTestt
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestConstructor()
        {
            SunshineMeasurement sm;
            sm = new SunshineMeasurement("Eindhoven");

            Assert.AreEqual("Eindhoven", sm.CityName);
        }

        [TestMethod]
        public void TestAdding1DaysOfSunshine()
        {
            SunshineMeasurement sm;
            sm = new SunshineMeasurement("Eindhoven");

            sm.AddSunshineOfLastDay(100);

            Assert.AreEqual("Eindhoven", sm.CityName);
            Assert.AreEqual(100, sm.GetAverageSunshine());
        }

        [TestMethod]
        public void TestAdding2DaysOfSunshine()
        {
            SunshineMeasurement sm;
            sm = new SunshineMeasurement("Eindhoven");

            sm.AddSunshineOfLastDay(100);
            sm.AddSunshineOfLastDay(200);

            Assert.AreEqual("Eindhoven", sm.CityName);
            Assert.AreEqual(150, sm.GetAverageSunshine());
        }

        [TestMethod]
        public void TestAddingManyDaysOfSunshine()
        {
            SunshineMeasurement sm;
            sm = new SunshineMeasurement("Eindhoven");

            sm.AddSunshineOfLastDay(10);
            sm.AddSunshineOfLastDay(10);
            sm.AddSunshineOfLastDay(10);

            sm.AddSunshineOfLastDay(200);
            sm.AddSunshineOfLastDay(200);
            sm.AddSunshineOfLastDay(200);
            sm.AddSunshineOfLastDay(200);
            sm.AddSunshineOfLastDay(200);
            sm.AddSunshineOfLastDay(200);
            sm.AddSunshineOfLastDay(200);
            sm.AddSunshineOfLastDay(200);
            sm.AddSunshineOfLastDay(200);
            sm.AddSunshineOfLastDay(200);

            Assert.AreEqual("Eindhoven", sm.CityName);
            Assert.AreEqual(200, sm.GetAverageSunshine());
        }

        [TestMethod]
        [ExpectedException(typeof(System.DivideByZeroException))]
        public void TestAdding0DaysOfSunshine()
        {
            SunshineMeasurement sm;
            sm = new SunshineMeasurement("Eindhoven");

            int bla = sm.GetAverageSunshine();  // Now an exception should be thrown since a division by zero must happen.
        }

    }
}