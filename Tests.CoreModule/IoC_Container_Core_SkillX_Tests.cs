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
    public class IoC_Container_Core_SkillX_Tests
    {

        [Test]
        [Category("Integration")]
        [Description("Core.IoC.Core.Integration")]
        public void IoC_can_resolve_ISkill()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var builder = new ContainerBuilder();
                builder.RegisterType<Skill>().As<ISkill>().AsSelf();
            var sut = builder.Build();

            // Act
            var skill = sut.Resolve<ISkill>();

            // Assert
            Assert.That(skill, Is.Not.Null);
        }

        [Test]
        [Category("Integration")]
        [Description("Core.IoC.Core.Integration")]
        public void IoC_can_resolve_SkillCollection()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var builder = new ContainerBuilder();
                builder.RegisterType<Skill>().As<ISkill>().AsSelf();
                builder.RegisterType<SkillCollection>().AsSelf();
            var sut = builder.Build();

            // Act
            var skillCollection = sut.Resolve<SkillCollection>();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(skillCollection, Is.Not.Null);
                Assert.That(skillCollection.Count, Is.EqualTo(1));
            });
        }

        [Test]
        [Category("Integration")]
        [Description("Core.IoC.Core.Integration")]
        public void IoC_can_resolve_ISkillPickList()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var builder = new ContainerBuilder();
                builder.RegisterType<Skill>().As<ISkill>().AsSelf(); ;
                builder.RegisterType<SkillCollection>().AsSelf();
                builder.RegisterType<SkillPickList>().As<ISkillPickList>().AsSelf();
            var sut = builder.Build();

            // Act
            var skillPickList = sut.Resolve<ISkillPickList>();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(skillPickList, Is.Not.Null);
                Assert.That(skillPickList.Skills.Count, Is.EqualTo(0));
            });
        }

        [Test]
        [Category("Integration")]
        [Description("Core.IoC.Core.Integration")]
        public void IoC_can_add_ISkill_item_to_SkillCollection()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var builder = new ContainerBuilder();
                builder.RegisterType<Skill>().As<ISkill>().AsSelf();
                builder.RegisterType<SkillCollection>().AsSelf();
            var sut = builder.Build();

            // Act
            var skillCollection = sut.Resolve<SkillCollection>();
            var skill = sut.Resolve<ISkill>();
                skill.SkillID = 101;
                skill.Name = "PW7";
            skillCollection.Add(skill);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(skillCollection, Is.Not.Null);
                Assert.That(skillCollection.Count, Is.EqualTo(2));
            });
        }

        [Test]
        [Category("Integration")]
        [Description("Core.IoC.Core.Integration")]
        public void IoC_can_add_ISkill_item_to_ISkillPickList()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var builder = new ContainerBuilder();
                builder.RegisterType<Skill>().As<ISkill>().AsSelf();
                builder.RegisterType<SkillCollection>().AsSelf();
                builder.RegisterType<SkillPickList>().As<ISkillPickList>().AsSelf();
            var sut = builder.Build();

            // Act
            var skillPickList = sut.Resolve<ISkillPickList>();
            var skill = sut.Resolve<ISkill>();
                skill.SkillID = 101;
                skill.Name = "PW7";
            skillPickList.AddSkill(skill);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(skillPickList, Is.Not.Null);
                Assert.That(skillPickList.Skills.Count, Is.EqualTo(1));
            });
        }
    }
}
