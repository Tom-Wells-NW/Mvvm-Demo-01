using Autofac;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fss.HumanCapitalManager.CoreModule;
using Fss.HumanCapitalManager.Core.Models.Interfaces;
using Fss.HumanCapitalManager.Core.Models;

namespace Tests.Core
{
    [TestFixture]
    public class IoC_Container_CoreModule_Tests
    {
        [Test]
        [Category("Integration")]
        [Description("Core.IoC.Core.Integration")]
        public void IoC_can_resolve_Core_models_and_interfaces_from_CoreModule()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var builder = new ContainerBuilder();
                builder.RegisterModule<CoreModule>();
            var sut = builder.Build();

            // Act
            var role = sut.Resolve<IRole>();
            var roleCollection = sut.Resolve<RoleCollection>();
            var rolePickList = sut.Resolve<IRolePickList>();

            var skill = sut.Resolve<ISkill>();
            var skillCollection = sut.Resolve<SkillCollection>();
            var skillPickList = sut.Resolve<ISkillPickList>();

            var associate = sut.Resolve<IAssociate>();
            var associateCollection = sut.Resolve<AssociateCollection>();
            var associatePickList = sut.Resolve<IAssociatePickList>();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(role, Is.Not.Null);
                Assert.That(roleCollection, Is.Not.Null);
                Assert.That(rolePickList, Is.Not.Null);

                Assert.That(skill, Is.Not.Null);
                Assert.That(skillCollection, Is.Not.Null);
                Assert.That(skillPickList, Is.Not.Null);

                Assert.That(associate, Is.Not.Null);
                Assert.That(associateCollection, Is.Not.Null);
                Assert.That(associatePickList, Is.Not.Null);
            });
        }
    }
}
