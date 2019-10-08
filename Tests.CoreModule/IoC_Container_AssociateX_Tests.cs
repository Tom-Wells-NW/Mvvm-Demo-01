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
    public class IoC_Container_AssociateX_Tests
    {
        [Test]
        [Category("Integration")]
        [Description("Core.IoC.Core.Integration")]
        public void IoC_can_resolve_IAssociate()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var builder = new ContainerBuilder();
                builder.RegisterType<Role>().As<IRole>().AsSelf();
                builder.RegisterType<RoleCollection>().AsSelf();
                builder.RegisterType<RolePickList>().As<IRolePickList>().AsSelf();
                builder.RegisterType<Skill>().As<ISkill>().AsSelf();
                builder.RegisterType<SkillCollection>().AsSelf();
                builder.RegisterType<SkillPickList>().As<ISkillPickList>().AsSelf();
                builder.RegisterType<Associate>().As<IAssociate>().AsSelf();
            var sut = builder.Build();

            // Act
            var associate = sut.Resolve<IAssociate>();

            // Assert
            Assert.That(associate, Is.Not.Null);
        }

        [Test]
        [Category("Integration")]
        [Description("Core.IoC.Core.Integration")]
        public void IoC_can_resolve_AssociateCollection()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var builder = new ContainerBuilder();
                builder.RegisterType<Role>().As<IRole>().AsSelf();
                builder.RegisterType<RoleCollection>().AsSelf();
                builder.RegisterType<RolePickList>().As<IRolePickList>().AsSelf();
                builder.RegisterType<Skill>().As<ISkill>().AsSelf();
                builder.RegisterType<SkillCollection>().AsSelf();
                builder.RegisterType<SkillPickList>().As<ISkillPickList>().AsSelf();
                builder.RegisterType<Associate>().As<IAssociate>().AsSelf();
                builder.RegisterType<AssociateCollection>().AsSelf();
            var sut = builder.Build();

            // Act
            var associateCollection = sut.Resolve<AssociateCollection>();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(associateCollection, Is.Not.Null);
                Assert.That(associateCollection.Count, Is.EqualTo(1));
            });
        }

        [Test]
        [Category("Integration")]
        [Description("Core.IoC.Core.Integration")]
        public void IoC_can_resolve_IAssociatePickList()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var builder = new ContainerBuilder();
                builder.RegisterType<Role>().As<IRole>().AsSelf();
                builder.RegisterType<RoleCollection>().AsSelf();
                builder.RegisterType<RolePickList>().As<IRolePickList>().AsSelf();
                builder.RegisterType<Skill>().As<ISkill>().AsSelf();
                builder.RegisterType<SkillCollection>().AsSelf();
                builder.RegisterType<SkillPickList>().As<ISkillPickList>().AsSelf();
                builder.RegisterType<Associate>().As<IAssociate>().AsSelf();
                builder.RegisterType<AssociateCollection>().AsSelf();
                builder.RegisterType<AssociatePickList>().As<IAssociatePickList>().AsSelf();
            var sut = builder.Build();

            // Act
            var associateickList = sut.Resolve<IAssociatePickList>();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(associateickList, Is.Not.Null);
                Assert.That(associateickList.Associates.Count, Is.EqualTo(0));
            });
        }


        [Test]
        [Category("Integration")]
        [Description("Core.IoC.Core.Integration")]
        public void IoC_can_add_IAssociate_item_to_AssociateCollection()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var builder = new ContainerBuilder();
                builder.RegisterType<Role>().As<IRole>().AsSelf();
                builder.RegisterType<RoleCollection>().AsSelf();
                builder.RegisterType<RolePickList>().As<IRolePickList>().AsSelf();
                builder.RegisterType<Skill>().As<ISkill>().AsSelf();
                builder.RegisterType<SkillCollection>().AsSelf();
                builder.RegisterType<SkillPickList>().As<ISkillPickList>().AsSelf();
                builder.RegisterType<Associate>().As<IAssociate>().AsSelf();
                builder.RegisterType<AssociateCollection>().AsSelf();
            var sut = builder.Build();

            // Act
            var associateCollection = sut.Resolve<AssociateCollection>();
            var associate = sut.Resolve<IAssociate>();
            //{ AssociateID = 101, Name = "Aaron Schatzer", Tenure = 10, CurrentRoleID = 100 };
                associate.AssociateID = 101;
                associate.Name = "Aaron Schatzer";
                associate.Tenure = 10;
                associate.CurrentRoleID = 100;
            associateCollection.Add(associate);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(associateCollection, Is.Not.Null);
                Assert.That(associateCollection.Count, Is.EqualTo(2));
            });
        }

        [Test]
        [Category("Integration")]
        [Description("Core.IoC.Core.Integration")]
        public void IoC_can_add_IAssociate_item_to_IAssociatePickList()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var builder = new ContainerBuilder();
                builder.RegisterType<Role>().As<IRole>().AsSelf();
                builder.RegisterType<RoleCollection>().AsSelf();
                builder.RegisterType<RolePickList>().As<IRolePickList>().AsSelf();
                builder.RegisterType<Skill>().As<ISkill>().AsSelf();
                builder.RegisterType<SkillCollection>().AsSelf();
                builder.RegisterType<SkillPickList>().As<ISkillPickList>().AsSelf();
                builder.RegisterType<Associate>().As<IAssociate>().AsSelf();
                builder.RegisterType<AssociateCollection>().AsSelf();
                builder.RegisterType<AssociatePickList>().As<IAssociatePickList>().AsSelf();
            var sut = builder.Build();

            // Act
            var associatePickList = sut.Resolve<IAssociatePickList>();
            var associate = sut.Resolve<IAssociate>();
                //{ AssociateID = 101, Name = "Aaron Schatzer", Tenure = 10, CurrentRoleID = 100 };
                associate.AssociateID = 101;
                associate.Name = "Aaron Schatzer";
                associate.Tenure = 10;
                associate.CurrentRoleID = 100;
            associatePickList.AddAssociate(associate);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(associatePickList, Is.Not.Null);
                Assert.That(associatePickList.Associates.Count, Is.EqualTo(1));
            });
        }
    }
}





//var a1 = new Associate(() => new Role(),
//                       () => new RolePickList(() => new RoleCollection(),
//                                              () => new Role()),
//                       () => new Skill(),
//                       () => new SkillPickList(() => new SkillCollection(),
//                                               () => new Skill())
//                      )
//{ AssociateID = 101, Name = "Aaron Schatzer", Tenure = 10, CurrentRoleID = 100 };

//var a2 = new Associate(() => new Role(),
//                       () => new RolePickList(() => new RoleCollection(),
//                                              () => new Role()),
//                       () => new Skill(),
//                       () => new SkillPickList(() => new SkillCollection(),
//                                               () => new Skill())
//                      )
//{ AssociateID = 102, Name = "Alan Moses", Tenure = 3, CurrentRoleID = 100 };

//var a3 = new Associate(() => new Role(),
//                       () => new RolePickList(() => new RoleCollection(),
//                                              () => new Role()),
//                       () => new Skill(),
//                       () => new SkillPickList(() => new SkillCollection(),
//                                               () => new Skill())
//                      )
//{ AssociateID = 103, Name = "Alexander Chow", Tenure = -1, CurrentRoleID = 100 };
