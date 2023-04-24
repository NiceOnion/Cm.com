using BusinessLayer;
using DataAccessLayer;
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
            Assert.AreEqual(2, stub.demos.First().id);
            Assert.AreEqual("test2", stub.demos[0].name);
            Assert.IsTrue(demo);
            Assert.AreEqual("test", deletedemo.name);

        }

        [TestMethod]
        public void AddDemo()
        {
            //Arrange
            STUB stub = new STUB();
            DemoContainer demoContainer = new DemoContainer(stub);
            DemoDTO newDemo = new DemoDTO("Boterkoek");

            //Act
            bool succes = demoContainer.NewDemoObject(newDemo);

            //Assert
            Assert.IsTrue(succes);
            Assert.AreEqual("Boterkoek",stub.demos[2].name);
        }
    }
}
