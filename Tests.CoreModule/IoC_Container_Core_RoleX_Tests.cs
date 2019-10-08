using Autofac;
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
    public class IoC_Container_Core_RoleX_Tests
    {

        [Test]
        [Category("Integration")]
        [Description("Core.IoC.Core.Integration")]
        public void IoC_can_resolve_IRole()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var builder = new ContainerBuilder();
                builder.RegisterType<Role>().As<IRole>().AsSelf();
            var sut = builder.Build();

            // Act
            var role = sut.Resolve<IRole>();

            // Assert
            Assert.That(role, Is.Not.Null);
        }

        [Test]
        [Category("Integration")]
        [Description("Core.IoC.Core.Integration")]
        public void IoC_can_resolve_RoleCollection()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var builder = new ContainerBuilder();
                builder.RegisterType<Role>().As<IRole>().AsSelf(); 
                builder.RegisterType<RoleCollection>().AsSelf();
            var sut = builder.Build();

            // Act
            var roleCollection = sut.Resolve<RoleCollection>();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(roleCollection, Is.Not.Null);
                Assert.That(roleCollection.Count, Is.EqualTo(1));
            });
        }

        [Test]
        [Category("Integration")]
        [Description("Core.IoC.Core.Integration")]
        public void IoC_can_resolve_IRolePickList()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var builder = new ContainerBuilder();
                builder.RegisterType<Role>().As<IRole>().AsSelf(); ;
                builder.RegisterType<RoleCollection>().AsSelf();
                builder.RegisterType<RolePickList>().As<IRolePickList>().AsSelf();
            var sut = builder.Build();

            // Act
            var rolePickList = sut.Resolve<IRolePickList>();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(rolePickList, Is.Not.Null);
                Assert.That(rolePickList.Roles.Count, Is.EqualTo(0));
            });
        }


        [Test]
        [Category("Integration")]
        [Description("Core.IoC.Core.Integration")]
        public void IoC_can_add_IRole_item_to_RoleCollection()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var builder = new ContainerBuilder();
                builder.RegisterType<Role>().As<IRole>().AsSelf();
                builder.RegisterType<RoleCollection>().AsSelf();
            var sut = builder.Build();

            // Act
            var roleCollection = sut.Resolve<RoleCollection>();
            var role = sut.Resolve<IRole>();
                role.RoleID = 101;
                role.Name = "DEV";
            roleCollection.Add(role);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(roleCollection, Is.Not.Null);
                Assert.That(roleCollection.Count, Is.EqualTo(2));
            });
        }

        [Test]
        [Category("Integration")]
        [Description("Core.IoC.Core.Integration")]
        public void IoC_can_add_IRole_item_to_IRolePickList()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var builder = new ContainerBuilder();
                builder.RegisterType<Role>().As<IRole>().AsSelf();
                builder.RegisterType<RoleCollection>().AsSelf();
                builder.RegisterType<RolePickList>().As<IRolePickList>().AsSelf();
            var sut = builder.Build();

            // Act
            var rolePickList = sut.Resolve<IRolePickList>();
            var role = sut.Resolve<IRole>();
                role.RoleID = 101;
                role.Name = "DEV";
            rolePickList.AddRole(role);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(rolePickList, Is.Not.Null);
                Assert.That(rolePickList.Roles.Count, Is.EqualTo(1));
            });
        }

    }
}
