using Microsoft.VisualStudio.TestTools.UnitTesting;
using DB_Automation;

namespace DBAutomationTesting
{
    [TestClass]
    public class UnitTest1
    {
        DBOperations db;
        [TestInitialize]
        public void setup()
        {
            db = new DBOperations();
        }
        //checking whether all data is retrived

        [TestMethod]
        public void RetriveAllDetails()
        {
            //Assign
            int expected = 6;
            //Act
            int actual = db.ReadData();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void insertdata()
        {
            //Assign
            int expected = 1;
            //Act
            int actual = db.insertRecords();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Update()
        {
            //Assign
            int expected = 1;
            //Act
            int actual = db.Update();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void deleterecords()
        {
            //Assign
            int expected = 1;
            //Act
            int actual = db.Delete();
            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
