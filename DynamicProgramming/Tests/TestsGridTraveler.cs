using NUnit.Framework;

namespace TestProject1 {
    public class TestsGridTraveler {
        
        [Test]
        public void test01GridTravelerMemoize() {
            Assert.AreEqual(1, GridTraveler.Memoize(1,1));
            Assert.AreEqual(1, GridTraveler.Memoize(1,2));
            Assert.AreEqual(2, GridTraveler.Memoize(2,2));
            Assert.AreEqual(3, GridTraveler.Memoize(3,2));
            Assert.AreEqual(2333606220, GridTraveler.Memoize(18,18));
        }
    
        [Test]
        public void test02GridTravelerTabulation() {
            Assert.AreEqual(1, GridTraveler.Tabulation(1,1));
            Assert.AreEqual(1, GridTraveler.Tabulation(1,2));
            Assert.AreEqual(2, GridTraveler.Tabulation(2,2));
            Assert.AreEqual(3, GridTraveler.Tabulation(3,2));
            Assert.AreEqual(2333606220, GridTraveler.Tabulation(18,18));
        }
    }
}