using Autofac;
using Fss.HumanCapitalManager.Core.Models.Interfaces;
using Fss.HumanCapitalManager.Core.Services.Interfaces;
using Fss.HumanCapitalManager.CoreModule;
using Fss.HumanCapitalManager.DataService;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Data
{
    [TestFixture]
    public class DataService_query_Integration_Tests
    {
        [Test]
        [Category("Integration")]
        [Description("Services.Data.EF.Integration")]
        public void IoC_can_resolve_Ioc_Container()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var builder = new ContainerBuilder();
                builder.RegisterModule<CoreModule>();
                builder.RegisterModule<DataServiceModule>();
            
            var sut = builder.Build();

            // Act


            // Assert
            Assert.That(sut, Is.Not.Null);
        }

        [Test]
        [Category("Integration")]
        [Description("Services.Data.EF.Integration")]
        public void IoC_can_resolve_call_GetAllRoles()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var builder = new ContainerBuilder();
                    builder.RegisterModule<CoreModule>();
                    builder.RegisterModule<DataServiceModule>();

            var container = builder.Build();

            // Act
            var sut = container.Resolve<IDataService>();
            var allRoles = sut.GetAllRoles();
            
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut, Is.Not.Null);
                Assert.That(allRoles, Has.Count.GreaterThan(1));
                Assert.That(allRoles, Is.All.Not.Null);
                Assert.That(allRoles, Is.All.InstanceOf<IRole>());
            });
        }

        [Test]
        [Category("Integration")]
        [Description("Services.Data.EF.Integration")]
        public void IoC_can_resolve_call_GetRolePickList()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var builder = new ContainerBuilder();
                builder.RegisterModule<CoreModule>();
                builder.RegisterModule<DataServiceModule>();

            var container = builder.Build();

            // Act
            var sut = container.Resolve<IDataService>();
            var rolePickList = sut.GetRolePickList();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut, Is.Not.Null);
                Assert.That(rolePickList.Roles, Has.Count.GreaterThan(1));
                Assert.That(rolePickList.Roles, Is.All.Not.Null);
                Assert.That(rolePickList.Roles, Is.All.InstanceOf<IRole>());
            });
        }

        [Test]
        [Category("Integration")]
        [Description("Services.Data.EF.Integration")]
        public void IoC_can_resolve_call_GetAllSkills()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var builder = new ContainerBuilder();
                builder.RegisterModule<CoreModule>();
                builder.RegisterModule<DataServiceModule>();

            var container = builder.Build();

            // Act
            var sut = container.Resolve<IDataService>();
            var allSkills = sut.GetAllSkills();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut, Is.Not.Null);
                Assert.That(allSkills, Has.Count.GreaterThan(1));
                Assert.That(allSkills, Is.All.Not.Null);
                Assert.That(allSkills, Is.All.InstanceOf<ISkill>());
            });
        }

        [Test]
        [Category("Integration")]
        [Description("Services.Data.EF.Integration")]
        public void IoC_can_resolve_call_GetSkillPickList()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var builder = new ContainerBuilder();
                builder.RegisterModule<CoreModule>();
                builder.RegisterModule<DataServiceModule>();

            var container = builder.Build();

            // Act
            var sut = container.Resolve<IDataService>();
            var skillPickList = sut.GetSkillPickList();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut, Is.Not.Null);
                Assert.That(skillPickList.Skills, Has.Count.GreaterThan(1));
                Assert.That(skillPickList.Skills, Is.All.Not.Null);
                Assert.That(skillPickList.Skills, Is.All.InstanceOf<ISkill>());
            });
        }

        [Test]
        [Category("Integration")]
        [Description("Services.Data.EF.Integration")]
        public void IoC_can_resolve_call_GetAllAssociates()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var builder = new ContainerBuilder();
                builder.RegisterModule<CoreModule>();
                builder.RegisterModule<DataServiceModule>();

            var container = builder.Build();

            // Act
            var sut = container.Resolve<IDataService>();
            var allAssociates = sut.GetAllAssociates();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut, Is.Not.Null);
                Assert.That(allAssociates, Has.Count.GreaterThan(1));
                Assert.That(allAssociates, Is.All.Not.Null);
                Assert.That(allAssociates, Is.All.InstanceOf<IAssociate>());
            });
        }

        [Test]
        [Category("Integration")]
        [Description("Services.Data.EF.Integration")]
        public void IoC_can_resolve_call_GetAssociatePickList()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var builder = new ContainerBuilder();
                builder.RegisterModule<CoreModule>();
                builder.RegisterModule<DataServiceModule>();

            var container = builder.Build();

            // Act
            var sut = container.Resolve<IDataService>();
            var associatePickList = sut.GetAssociatePickList();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut, Is.Not.Null);
                Assert.That(associatePickList.Associates, Has.Count.GreaterThan(1));
                Assert.That(associatePickList.Associates, Is.All.Not.Null);
                Assert.That(associatePickList.Associates, Is.All.InstanceOf<IAssociate>());
            });
        }
    }
}
