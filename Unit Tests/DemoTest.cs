using BusinessLayer;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Tests
{
    [TestClass]
    public class DemoTest
    {
        [TestMethod]
        public void DeleteDemo()
        {

            //Arrange

            STUB stub = new STUB();

            DemoContainer democontainer = new DemoContainer(stub);
            var demolist = democontainer.GetDemoList();
            var deletedemo = demolist[0];

            //Act
            var demo = democontainer.DeleteDemo(1);



            //Assert
            Assert.AreEqual(1, stub.demos.Count);
            Assert.AreEqual(2, stub.demos.First().Id);
            Assert.AreEqual("test2", stub.demos[0].Name);
            Assert.IsTrue(demo);
            Assert.AreEqual("test", deletedemo.name);

        }
        [TestMethod]
        public void EditDemoTest()
        {
            //arrange
            STUB stub = new STUB();
            DemoContainer demoContainer = new DemoContainer(stub);
            DemoObject demoObject = new DemoObject
            {
                id = 1,
                accountId = 0,
                name = "Test14",
                visibility = false,
            };
            //act
            var edited = demoContainer.EditDemo(demoObject);
            //assert
            Assert.AreEqual(2, stub.demos.Count);
            Assert.AreEqual(1 ,demoObject.id);
            Assert.AreEqual("Test14",demoObject.name);
            Assert.AreEqual(false ,demoObject.visibility);
            Assert.AreNotEqual(2, demoObject.id);
            Assert.AreNotEqual("Test13", demoObject.name);
            Assert.AreNotEqual(true, demoObject.visibility);

        }
        [TestMethod]
        public void SaveDemoTest()
        {
            //Arrange

            STUB stub = new STUB();

            DemoContainer democontainer = new DemoContainer(stub);
            DemoObject demoObject = new DemoObject
            {
                id = 3,
                name = "test4",
                visibility = true
            };
            
            //Act
           var result=democontainer.SaveDemo(demoObject);

            //Assert
            Assert.AreEqual(3, stub.demos.Count);
            Assert.AreEqual(demoObject.id, stub.demos.Last().id);
            Assert.AreEqual(demoObject.name, stub.demos.Last().name);
            Assert.AreEqual(demoObject.visibility, stub.demos.Last().visibility);

        }
    }
}
