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
            Assert.AreEqual("test", deletedemo.Name);

        }
        [TestMethod]
        public void EditDemoTest()
        {
            //arrange
            STUB stub = new STUB();
            DemoContainer demoContainer = new DemoContainer(stub);
            DemoObject demoObject = new DemoObject
            {
                Id = 1,
                //Accountid = 0, 
                Name = "Test14",
                Visibility = false,
            };
            //act
            var edited = demoContainer.EditDemo(demoObject);
            //assert
            Assert.AreEqual(2, stub.demos.Count);
            Assert.AreEqual(1 ,demoObject.Id);
            Assert.AreEqual("Test14",demoObject.Name);
            Assert.AreEqual(false ,demoObject.Visibility);
            Assert.AreNotEqual(2, demoObject.Id);
            Assert.AreNotEqual("Test13", demoObject.Name);
            Assert.AreNotEqual(true, demoObject.Visibility);

        }
        [TestMethod]
        public void SaveDemoTest()
        {
            //Arrange

            STUB stub = new STUB();

            DemoContainer democontainer = new DemoContainer(stub);
            DemoObject demoObject = new DemoObject
            {
                Id = 3,
                Name = "test4",
                Visibility = true
            };
            
            //Act
           var result=democontainer.SaveDemo(demoObject);

            //Assert
            Assert.AreEqual(3, stub.demos.Count);
            Assert.AreEqual(demoObject.Id, stub.demos.Last().Id);
            Assert.AreEqual(demoObject.Name, stub.demos.Last().Name);
            Assert.AreEqual(demoObject.Visibility, stub.demos.Last().Visibility);
        }
    }
}
