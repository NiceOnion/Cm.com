using BusinessLayer;
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
            //act
            //assert
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
