using Fss.HumanCapitalManager.Core.Models;
using Fss.HumanCapitalManager.Core.Models.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Core
{
    [TestFixture]
    public class RoleCollection_Tests
    {

        [Test]
        [Category("Integration")]
        [Description("Core.RoleCollection.Integration")]
        public void RoleCollection_can_construct_ctor0()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var sut = new RoleCollection();

            // Act

            // Assert
            Assert.That(sut, Is.Not.Null);
        }

        [Test]
        [Category("Integration")]
        [Description("Core.RoleCollection.Integration")]
        public void RoleCollection_can_construct_ctor1()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var list = new List<Role>() { new Role() { RoleID = 101, Name = "DEV"},
                                          new Role() { RoleID = 102, Name = "SQA" },
                                          new Role() { RoleID = 103, Name = "PM" }
                                        };

            // Act 
            var sut = new RoleCollection(list.AsEnumerable());

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut, Is.Not.Null);
                Assert.That(sut.Count, Is.EqualTo(3));
            });
        }

        [Test]
        [Category("Integration")]
        [Description("Core.RoleCollection.Integration")]
        public void RoleCollection_can_construct_ctor3()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var list = new List<Role>() { new Role() { RoleID = 101, Name = "DEV"},
                                          new Role() { RoleID = 102, Name = "SQA" },
                                          new Role() { RoleID = 103, Name = "PM" }
                                        };

            // Act 
            var sut = new RoleCollection(list);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut, Is.Not.Null);
                Assert.That(sut.Count, Is.EqualTo(3));
            });
        }

        [Test]
        [Category("Integration")]
        [Description("Core.RoleCollection.Integration")]
        public void RoleCollection_can_add_skill()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var sut = new RoleCollection();
            IRole r1 = new Role { RoleID = 101, Name = "DEV" };

            // Act
            sut.Add(r1);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut.Count, Is.EqualTo(1));
                Assert.That(sut[0].RoleID, Is.EqualTo(101));
                Assert.That(sut[0].Name, Is.EqualTo("DEV"));
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
//var r7 = new Role() { RoleID = 107, Name = "SCRMM" };