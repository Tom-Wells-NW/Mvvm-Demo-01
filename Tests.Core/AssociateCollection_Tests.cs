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
    public class AssociateCollection_Tests
    {
        [Test]
        [Category("Integration")]
        [Description("Core.AssociateCollection.Integration")]
        public void AssociateCollection_can_construct_ctor0()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var sut = new AssociateCollection();

            // Act

            // Assert
            Assert.That(sut, Is.Not.Null);
            Assert.That(sut.Count, Is.EqualTo(0));
        }

        [Test]
        [Category("Integration")]
        [Description("Core.AssociateCollection.Integration")]
        public void AssociateCollection_can_construct_ctor1()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var list = new List<Associate>() { new Associate(() => new Role(),
                                                             () => new RolePickList(() => new RoleCollection(),
                                                                                    () => new Role()),
                                                             () => new Skill(),
                                                             () => new SkillPickList(() => new SkillCollection(),
                                                                                     () => new Skill())
                                                            ) { AssociateID = 101, Name = "Aaron Schatzer", Tenure = 10, CurrentRoleID = 100},
                                               new Associate(() => new Role(),
                                                             () => new RolePickList(() => new RoleCollection(),
                                                                                    () => new Role()),
                                                             () => new Skill(),
                                                             () => new SkillPickList(() => new SkillCollection(),
                                                                                     () => new Skill())
                                                            ) { AssociateID = 102, Name = "Alan Moses", Tenure = 3, CurrentRoleID = 100},
                                               new Associate(() => new Role(),
                                                             () => new RolePickList(() => new RoleCollection(),
                                                                                    () => new Role()),
                                                             () => new Skill(),
                                                             () => new SkillPickList(() => new SkillCollection(),
                                                                                     () => new Skill())
                                                            ) { AssociateID = 103, Name = "Alexander Chow", Tenure = -1, CurrentRoleID = 100}
                                             };

            // Act 
            var sut = new AssociateCollection(list.AsEnumerable());

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut, Is.Not.Null);
                Assert.That(sut.Count, Is.EqualTo(3));
            });
        }

        [Test]
        [Category("Integration")]
        [Description("Core.AssociateCollection.Integration")]
        public void AssociateCollection_can_construct_ctor3()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var list = new List<Associate>() { new Associate(() => new Role(),
                                                             () => new RolePickList(() => new RoleCollection(),
                                                                                    () => new Role()),
                                                             () => new Skill(),
                                                             () => new SkillPickList(() => new SkillCollection(),
                                                                                     () => new Skill())
                                                            ) { AssociateID = 101, Name = "Aaron Schatzer", Tenure = 10, CurrentRoleID = 100},
                                               new Associate(() => new Role(),
                                                             () => new RolePickList(() => new RoleCollection(),
                                                                                    () => new Role()),
                                                             () => new Skill(),
                                                             () => new SkillPickList(() => new SkillCollection(),
                                                                                     () => new Skill())
                                                            ) { AssociateID = 102, Name = "Alan Moses", Tenure = 3, CurrentRoleID = 100},
                                               new Associate(() => new Role(),
                                                             () => new RolePickList(() => new RoleCollection(),
                                                                                    () => new Role()),
                                                             () => new Skill(),
                                                             () => new SkillPickList(() => new SkillCollection(),
                                                                                     () => new Skill())
                                                            ) { AssociateID = 103, Name = "Alexander Chow", Tenure = -1, CurrentRoleID = 100}
                                             };

            // Act 
            var sut = new AssociateCollection(list);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut, Is.Not.Null);
                Assert.That(sut.Count, Is.EqualTo(3));
            });
        }

        [Test]
        [Category("Integration")]
        [Description("Core.AssociateCollection.Integration")]
        public void AssociateCollection_can_add_skill()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var sut = new AssociateCollection();
            IAssociate a1 = new Associate(() => new Role(),
                                          () => new RolePickList(() => new RoleCollection(),
                                                                 () => new Role()),
                                          () => new Skill(),
                                          () => new SkillPickList(() => new SkillCollection(),
                                                                  () => new Skill())
                                         )
                                         { AssociateID = 101, Name = "Aaron Schatzer", Tenure = 10, CurrentRoleID = 100 };

            // Act
            sut.Add(a1);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut.Count, Is.EqualTo(1));
                Assert.That(sut[0].AssociateID, Is.EqualTo(101));
                Assert.That(sut[0].Name, Is.EqualTo("Aaron Schatzer"));
            });
        }

    }
}


//var list = new List<Associate>() { new Associate(() => new Role(),
//                                                 () => new RolePickList(() => new RoleCollection(),
//                                                                        () => new Role()),
//                                                 () => new Skill(),
//                                                 () => new SkillPickList(() => new SkillCollection(),
//                                                                         () => new Skill())
//                                                ) { AssociateID = 101, Name = "Aaron Schatzer", Tenure = 10, CurrentRoleID = 100},
//                                   new Associate(() => new Role(),
//                                                 () => new RolePickList(() => new RoleCollection(),
//                                                                        () => new Role()),
//                                                 () => new Skill(),
//                                                 () => new SkillPickList(() => new SkillCollection(),
//                                                                         () => new Skill())
//                                                ) { AssociateID = 102, Name = "Alan Moses", Tenure = 3, CurrentRoleID = 100},
//                                   new Associate(() => new Role(),
//                                                 () => new RolePickList(() => new RoleCollection(),
//                                                                        () => new Role()),
//                                                 () => new Skill(),
//                                                 () => new SkillPickList(() => new SkillCollection(),
//                                                                         () => new Skill())
//                                                ) { AssociateID = 103, Name = "Alexander Chow", Tenure = -1, CurrentRoleID = 100}
//                                 };