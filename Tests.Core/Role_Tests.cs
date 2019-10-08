using Fss.HumanCapitalManager.Core.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Core
{
    [TestFixture]
    public class Role_Tests
    {

        [Test]
        [Category("Integration")]
        [Description("Core.Role.Integration")]
        public void Role_can_construct()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var sut = new Role();

            // Act

            // Assert
            Assert.That(sut, Is.Not.Null);
        }

        [Test]
        [Category("Integration")]
        [Description("Core.Role.Integration")]
        public void Role_can_set_properties()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var sut = new Role();
            
            // Act
            sut.RoleID = 101;
            sut.Name = "DEV";

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut.RoleID, Is.EqualTo(101));
                Assert.That(sut.Name, Is.EqualTo("DEV"));
            });
        }

    }
}


//var r1 = new Role() { RoleID = 101, Name = "DEV"};
//var r2 = new Role() { RoleID = 102, Name = "SQA" };
//var r3 = new Role() { RoleID = 103, Name = "PM" };
//var r4 = new Role() { RoleID = 104, Name = "BLD" };
//var r5 = new Role() { RoleID = 105, Name = "SCCM" };
//var r6 = new Role() { RoleID = 106, Name = "DEV Lead" };
//var r7 = new Role() { RoleID = 107, Name = "SCRUM" };