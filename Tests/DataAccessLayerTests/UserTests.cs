using System;
using System.Text;
using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.UserIdentity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Helper;

namespace Tests.DataAccessLayerTests
{
    /// <summary>
    /// Summary description for UserTests
    /// </summary>
    [TestClass]
    public class UserTests
    {
        public UserTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void AddUserTest()
        {
            using (var dbContext = new PersonalManagerDbContext())
            {
                User user = new User()
                {
                    Email = "user1@example.com",
                    PasswordHash = "adfdagargfaxgfdbs754edfs54fsef",
                };
                dbContext.Users.Add(user);
                User storedUser = dbContext.Users.Find(user.Id);
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
                Assert.IsTrue(EntitiesComparator.CompareUsersIdMailPassword(storedUser, user));
            }
        }
    }
}
