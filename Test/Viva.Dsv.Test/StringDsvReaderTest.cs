using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;

namespace Viva.Dsv.Test
{
    [TestClass]
    public class StringDsvReaderTest
    {
        [TestMethod]
        public void TestRead()
        {
            string delimiter = ",";
            string content = "a,b\nc,d\ne,f";

            string[] expectedFirst = new string[] { "a", "b" };
            string[] expectedSecond = new string[] { "c", "d" };
            string[] expectedThird = new string[] { "e", "f" };

            List<string[]> records = new List<string[]>();

            using (StringReader textReader = new StringReader(content))
            {
                StringDsvReader dsvReader = new StringDsvReader(textReader, delimiter);

                string[] actualFirst = dsvReader.Read();
                Assert.IsNotNull(actualFirst);
                CollectionAssert.AreEqual(expectedFirst, actualFirst);

                string[] actualSecond = dsvReader.Read();
                Assert.IsNotNull(actualSecond);
                CollectionAssert.AreEqual(expectedSecond, actualSecond);

                string[] actualThird = dsvReader.Read();
                Assert.IsNotNull(actualThird);
                CollectionAssert.AreEqual(expectedThird, actualThird);

                string[] actualFourth = dsvReader.Read();
                Assert.IsNull(actualFourth);
            }

        }

        [TestMethod]
        public void TestReadToEnd()
        {
            string delimiter = ",";
            string content = "a,b\nc,d\ne,f";

            string[] expectedFirst = new string[] { "a", "b" };
            string[] expectedSecond = new string[] { "c", "d" };
            string[] expectedThird = new string[] { "e", "f" };

            int expectedLength = 3;

            using (StringReader textReader = new StringReader(content))
            {
                StringDsvReader dsvReader = new StringDsvReader(textReader, delimiter);

                List<string[]> records = dsvReader.ReadToEnd();
                Assert.AreEqual(expectedLength, records.Count);

                string[] actualFirst = records[0];
                Assert.IsNotNull(actualFirst);
                CollectionAssert.AreEqual(expectedFirst, actualFirst);

                string[] actualSecond = records[1];
                Assert.IsNotNull(actualSecond);
                CollectionAssert.AreEqual(expectedSecond, actualSecond);

                string[] actualThird = records[2];
                Assert.IsNotNull(actualThird);
                CollectionAssert.AreEqual(expectedThird, actualThird);
            }
        }

    }
}
