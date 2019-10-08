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
    public class RolePickList_Tests
    {

        [Test]
        [Category("Integration")]
        [Description("Core.RolePickList.Integration")]
        public void RolePickList_can_construct()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var sut = new RolePickList(() => new RoleCollection(),
                                       () => new Role());

            // Act

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut.Roles, Is.Not.Null);
                Assert.That(sut.SelectedRole, Is.Null);
            });
        }


        [Test]
        [Category("Integration")]
        [Description("Core.RolePickList.Integration")]
        public void RolePickList_can_add_skill()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            RolePickList sut = new RolePickList(() => new RoleCollection(),
                                                () => new Role());

            var r1 = new Role() { RoleID = 101, Name = "DEV" };
            var r2 = new Role() { RoleID = 102, Name = "SQA" };
            var r3 = new Role() { RoleID = 103, Name = "PM" };

            // Act
            sut.AddRole(r1);
            sut.AddRole(r2);
            sut.AddRole(r3);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut.Roles, Is.Not.Null);
                Assert.That(sut.Roles.Count == 3);
                Assert.That(sut.SelectedRole, Is.Null);
            });
        }


        [Test]
        [Category("Integration")]
        [Description("Core.RolePickList.Integration")]
        public void RolePickList_can_remove_skill_by_reference()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            RolePickList sut = new RolePickList(() => new RoleCollection(),
                                                () => new Role());

            var r1 = new Role() { RoleID = 101, Name = "DEV" };
            var r2 = new Role() { RoleID = 102, Name = "SQA" };
            var r3 = new Role() { RoleID = 103, Name = "PM" };


            sut.AddRole(r1);
            sut.AddRole(r2);
            sut.AddRole(r3);

            // Act
            var firstRemove = sut.RemoveRole(r3);
            var secondRemove = sut.RemoveRole(r3);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut.Roles, Is.Not.Null);
                Assert.That(firstRemove, Is.True);
                Assert.That(secondRemove, Is.False);
                Assert.That(sut.Roles.Count == 2);
                Assert.That(sut.SelectedRole, Is.Null);
            });
        }


        [Test]
        [Category("Integration")]
        [Description("Core.RolePickList.Integration")]
        public void RolePickList_can_remove_skill_by_value()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            RolePickList sut = new RolePickList(() => new RoleCollection(),
                                                () => new Role());

            var r1 = new Role() { RoleID = 101, Name = "DEV" };
            var r2 = new Role() { RoleID = 102, Name = "SQA" };
            var r3 = new Role() { RoleID = 103, Name = "PM" };

            // Act
            sut.AddRole(r1);
            sut.AddRole(r2);
            sut.AddRole(r3);

            // Act
            var firstRemove = sut.RemoveRole(new Role { RoleID = 101, Name = "DEV" });

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut.Roles, Is.Not.Null);
                Assert.That(firstRemove, Is.True);
                Assert.That(sut.Roles.Count == 2);
                Assert.That(sut.SelectedRole, Is.Null);
            });
        }


        [Test]
        [Category("Integration")]
        [Description("Core.RolePickList.Integration")]
        public void RolePickList_can_select_existing_skill()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            RolePickList sut = new RolePickList(() => new RoleCollection(),
                                                () => new Role());

            var r1 = new Role() { RoleID = 101, Name = "DEV" };
            var r2 = new Role() { RoleID = 102, Name = "SQA" };
            var r3 = new Role() { RoleID = 103, Name = "PM" };

            sut.AddRole(r1);
            sut.AddRole(r2);
            sut.AddRole(r3);

            // Act
            sut.SelectedRole  = r3;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut.Roles, Is.Not.Null);
                Assert.That(sut.SelectedRole, Is.Not.Null);
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