using BusinessLayer;
using InterfaceLayer;

namespace Unit_Tests
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void ConstructAccount()
        {
            //Arrange
            int expectedID = 4;
            string expectedName = "TestName";
            string expectedPassword = "TestPassword";

            //Act
            Account result = new(expectedID, expectedName, expectedPassword);

            //Assert
            int actualID = result.ID;
            string actualName = result.Name;

            Assert.AreEqual(expectedID, actualID);
            Assert.AreEqual(expectedName, actualName);
        }

        [TestMethod]
        public void ConstructAccountFromDTO()
        {
            //Arrange
            int expectedID = 4;
            string expectedName = "TestName";
            string expectedPassword = "TestPassword";

            AccountDTO accountDTO = new(expectedID, expectedName, expectedPassword);

            //Act
            Account result = new(accountDTO);

            //Assert
            int actualID = result.ID;
            string actualName = result.Name;

            Assert.AreEqual(expectedID, actualID);
            Assert.AreEqual(expectedName, actualName);
        }

        [TestMethod]
        public void ToAccountDTO()
        {
            //Arrange
            int expectedID = 4;
            string expectedName = "TestName";
            string expectedPassword = "TestPassword";

            Account account = new(expectedID, expectedName, expectedPassword);

            //Act
            AccountDTO result = account.ToAccountDTO();

            //Assert
            int actualID = result.ID;
            string actualName = result.Name;
            string actualPassword = result.Password;

            Assert.AreEqual(expectedID, actualID);
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedPassword, actualPassword);
        }

        [TestMethod]
        public void Create()
        {
            //Arrange
            int expectedID = 4;
            string expectedName = "TestName4";
            string expectedPassword = "TestPassword4";

            int expectedCount = 4;

            Account account = new(expectedID, expectedName, expectedPassword);

            Account_Test_DAL stub = new();
            AccountContainer container = new(stub);

            //Act
            bool result = container.Create(account);

            //Assert
            int actualID = stub.Accounts[3].ID;
            string actualName = stub.Accounts[3].Name;
            string actualPassword = stub.Accounts[3].Password;

            int actualNewID = stub.newAccountDTO.ID;
            string actualNewName = stub.newAccountDTO.Name;
            string actualNewPassword = stub.newAccountDTO.Password;

            int actualCount = stub.Accounts.Count;

            Assert.IsTrue(result);

            Assert.AreEqual(expectedID, actualID);
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedPassword, actualPassword);

            Assert.AreEqual(expectedID, actualNewID);
            Assert.AreEqual(expectedName, actualNewName);
            Assert.AreEqual(expectedPassword, actualNewPassword);

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void GetByIDSuccess()
        {
            //Arrange
            int expectedID = 3;
            string expectedName = "TestName3";
            string expectedPassword = "TestPassword3";

            Account_Test_DAL stub = new();
            AccountContainer container = new(stub);

            //Act
            Account result = container.GetByID(expectedID);

            //Assert
            int actualNewID = stub.newID;

            int resultID = result.ID;
            string resultName = result.Name;

            int actualID = stub.Accounts[2].ID;
            string actualName = stub.Accounts[2].Name;
            string actualPassword = stub.Accounts[2].Password;

            Assert.AreEqual(expectedID, actualNewID);

            Assert.AreEqual(expectedID, resultID);
            Assert.AreEqual(expectedName, resultName);

            Assert.AreEqual(expectedID, actualID);
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedPassword, actualPassword);
        }

        [TestMethod]
        public void GetByIDFail()
        {
            //Arrange
            int expectedID = 4;

            Account_Test_DAL stub = new();
            AccountContainer container = new(stub);

            //Act
            Account result = container.GetByID(expectedID);

            //Assert
            int actualNewID = stub.newID;

            Assert.IsNull(result);
            Assert.AreEqual(expectedID, actualNewID);
        }

        [TestMethod]
        public void GetByLoginSuccess()
        {
            //Arrange
            int expectedID = 3;
            string expectedName = "TestName3";
            string expectedPassword = "TestPassword3";

            Account_Test_DAL stub = new();
            AccountContainer container = new(stub);

            //Act
            Account result = container.GetByLogin(expectedName, expectedPassword);

            //Assert
            string actualNewName = stub.newName;
            string actualNewPassword = stub.newPassword;

            int resultID = result.ID;
            string resultName = result.Name;

            int actualID = stub.Accounts[2].ID;
            string actualName = stub.Accounts[2].Name;
            string actualPassword = stub.Accounts[2].Password;

            Assert.AreEqual(expectedName, actualNewName);
            Assert.AreEqual(expectedPassword, actualNewPassword);

            Assert.AreEqual(expectedID, resultID);
            Assert.AreEqual(expectedName, resultName);

            Assert.AreEqual(expectedID, actualID);
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedPassword, actualPassword);
        }

        [TestMethod]
        public void GetByLoginFail()
        {
            //Arrange
            string expectedName = "Wrong";
            string expectedPassword = "Wrong";

            Account_Test_DAL stub = new();
            AccountContainer container = new(stub);

            //Act
            Account result = container.GetByLogin(expectedName, expectedPassword);

            //Assert
            string actualNewName = stub.newName;
            string actualNewPassword = stub.newPassword;

            Assert.IsNull(result);

            Assert.AreEqual(expectedName, actualNewName);
            Assert.AreEqual(expectedPassword, actualNewPassword);
        }
    }
}