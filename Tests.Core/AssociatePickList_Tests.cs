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
    public class AssociatePickList_Tests
    {
        [Test]
        [Category("Integration")]
        [Description("Core.AssociatePickList.Integration")]
        public void AssociatePickList_can_construct()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var sut = new AssociatePickList(() => new AssociateCollection(),
                                            () => new Associate(() => new Role(),
                                                                () => new RolePickList(() => new RoleCollection(),
                                                                                       () => new Role()),
                                                                () => new Skill(),
                                                                () => new SkillPickList(() => new SkillCollection(),
                                                                                        () => new Skill())
                                           ));

            // Act

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut.Associates, Is.Not.Null);
                Assert.That(sut.SelectedAssociate, Is.Null);
            });
        }


        [Test]
        [Category("Integration")]
        [Description("Core.AssociatePickList.Integration")]
        public void AssociatePickList_can_add_skill()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            IAssociatePickList sut = new AssociatePickList(() => new AssociateCollection(),
                                                           () => new Associate(() => new Role(),
                                                                               () => new RolePickList(() => new RoleCollection(),
                                                                                                      () => new Role()),
                                                                               () => new Skill(),
                                                                               () => new SkillPickList(() => new SkillCollection(),
                                                                               () => new Skill())
                                                          ));

            var a1 = new Associate(() => new Role(),
                                   () => new RolePickList(() => new RoleCollection(),
                                                          () => new Role()),
                                   () => new Skill(),
                                   () => new SkillPickList(() => new SkillCollection(),
                                                           () => new Skill())
                                  ) { AssociateID = 101, Name = "Aaron Schatzer", Tenure = 10, CurrentRoleID = 100 };

            var a2 = new Associate(() => new Role(),
                                   () => new RolePickList(() => new RoleCollection(),
                                                          () => new Role()),
                                   () => new Skill(),
                                   () => new SkillPickList(() => new SkillCollection(),
                                                           () => new Skill())
                                  ) { AssociateID = 102, Name = "Alan Moses", Tenure = 3, CurrentRoleID = 100 };

            var a3 = new Associate(() => new Role(),
                                   () => new RolePickList(() => new RoleCollection(),
                                                          () => new Role()),
                                   () => new Skill(),
                                   () => new SkillPickList(() => new SkillCollection(),
                                                           () => new Skill())
                                  ) { AssociateID = 103, Name = "Alexander Chow", Tenure = -1, CurrentRoleID = 100 };

            // Act
            sut.AddAssociate(a1);
            sut.AddAssociate(a2);
            sut.AddAssociate(a3);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut.Associates, Is.Not.Null);
                Assert.That(sut.Associates.Count == 3);
                Assert.That(sut.SelectedAssociate, Is.Null);
            });
        }


        [Test]
        [Category("Integration")]
        [Description("Core.AssociatePickList.Integration")]
        public void AssociatePickList_can_remove_skill_by_reference()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            IAssociatePickList sut = new AssociatePickList(() => new AssociateCollection(),
                                                           () => new Associate(() => new Role(),
                                                                               () => new RolePickList(() => new RoleCollection(),
                                                                                                      () => new Role()),
                                                                               () => new Skill(),
                                                                               () => new SkillPickList(() => new SkillCollection(),
                                                                               () => new Skill())
                                                          ));

            var a1 = new Associate(() => new Role(),
                                   () => new RolePickList(() => new RoleCollection(),
                                                          () => new Role()),
                                   () => new Skill(),
                                   () => new SkillPickList(() => new SkillCollection(),
                                                           () => new Skill())
                                  ) { AssociateID = 101, Name = "Aaron Schatzer", Tenure = 10, CurrentRoleID = 100 };

            var a2 = new Associate(() => new Role(),
                                   () => new RolePickList(() => new RoleCollection(),
                                                          () => new Role()),
                                   () => new Skill(),
                                   () => new SkillPickList(() => new SkillCollection(),
                                                           () => new Skill())
                                  ) { AssociateID = 102, Name = "Alan Moses", Tenure = 3, CurrentRoleID = 100 };

            var a3 = new Associate(() => new Role(),
                                   () => new RolePickList(() => new RoleCollection(),
                                                          () => new Role()),
                                   () => new Skill(),
                                   () => new SkillPickList(() => new SkillCollection(),
                                                           () => new Skill())
                                  ) { AssociateID = 103, Name = "Alexander Chow", Tenure = -1, CurrentRoleID = 100 };

            // Act
            sut.AddAssociate(a1);
            sut.AddAssociate(a2);
            sut.AddAssociate(a3);

            // Act
            var firstRemove = sut.RemoveAssociate(a3);
            var secondRemove = sut.RemoveAssociate(a3);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut.Associates, Is.Not.Null);
                Assert.That(firstRemove, Is.True);
                Assert.That(secondRemove, Is.False);
                Assert.That(sut.Associates.Count == 2);
                Assert.That(sut.SelectedAssociate, Is.Null);
            });
        }


        [Test]
        [Category("Integration")]
        [Description("Core.AssociatePickList.Integration")]
        public void AssociatePickList_can_remove_skill_by_value()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            IAssociatePickList sut = new AssociatePickList(() => new AssociateCollection(),
                                                           () => new Associate(() => new Role(),
                                                                               () => new RolePickList(() => new RoleCollection(),
                                                                                                      () => new Role()),
                                                                               () => new Skill(),
                                                                               () => new SkillPickList(() => new SkillCollection(),
                                                                               () => new Skill())
                                                          ));

            var a1 = new Associate(() => new Role(),
                                   () => new RolePickList(() => new RoleCollection(),
                                                          () => new Role()),
                                   () => new Skill(),
                                   () => new SkillPickList(() => new SkillCollection(),
                                                           () => new Skill())
                                  ) { AssociateID = 101, Name = "Aaron Schatzer", Tenure = 10, CurrentRoleID = 100 };

            var a2 = new Associate(() => new Role(),
                                   () => new RolePickList(() => new RoleCollection(),
                                                          () => new Role()),
                                   () => new Skill(),
                                   () => new SkillPickList(() => new SkillCollection(),
                                                           () => new Skill())
                                  ) { AssociateID = 102, Name = "Alan Moses", Tenure = 3, CurrentRoleID = 100 };

            var a3 = new Associate(() => new Role(),
                                   () => new RolePickList(() => new RoleCollection(),
                                                          () => new Role()),
                                   () => new Skill(),
                                   () => new SkillPickList(() => new SkillCollection(),
                                                           () => new Skill())
                                  ) { AssociateID = 103, Name = "Alexander Chow", Tenure = -1, CurrentRoleID = 100 };

            // Act
            sut.AddAssociate(a1);
            sut.AddAssociate(a2);
            sut.AddAssociate(a3);

            var a4 = new Associate(() => new Role(),
                                   () => new RolePickList(() => new RoleCollection(),
                                                          () => new Role()),
                                   () => new Skill(),
                                   () => new SkillPickList(() => new SkillCollection(),
                                                           () => new Skill())
                                  ) { AssociateID = 101, Name = "Aaron Schatzer", Tenure = 10, CurrentRoleID = 100 };
            // Act
            var firstRemove = sut.RemoveAssociate(a4);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut.Associates, Is.Not.Null);
                Assert.That(firstRemove, Is.True);
                Assert.That(sut.Associates.Count == 2);
                Assert.That(sut.SelectedAssociate, Is.Null);
            });
        }


        [Test]
        [Category("Integration")]
        [Description("Core.AssociatePickList.Integration")]
        public void AssociatePickList_can_select_existing_skill()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            IAssociatePickList sut = new AssociatePickList(() => new AssociateCollection(),
                                                           () => new Associate(() => new Role(),
                                                                               () => new RolePickList(() => new RoleCollection(),
                                                                                                      () => new Role()),
                                                                               () => new Skill(),
                                                                               () => new SkillPickList(() => new SkillCollection(),
                                                                               () => new Skill())
                                                          ));

            var a1 = new Associate(() => new Role(),
                                   () => new RolePickList(() => new RoleCollection(),
                                                          () => new Role()),
                                   () => new Skill(),
                                   () => new SkillPickList(() => new SkillCollection(),
                                                           () => new Skill())
                                  ) { AssociateID = 101, Name = "Aaron Schatzer", Tenure = 10, CurrentRoleID = 100 };

            var a2 = new Associate(() => new Role(),
                                   () => new RolePickList(() => new RoleCollection(),
                                                          () => new Role()),
                                   () => new Skill(),
                                   () => new SkillPickList(() => new SkillCollection(),
                                                           () => new Skill())
                                  ) { AssociateID = 102, Name = "Alan Moses", Tenure = 3, CurrentRoleID = 100 };

            var a3 = new Associate(() => new Role(),
                                   () => new RolePickList(() => new RoleCollection(),
                                                          () => new Role()),
                                   () => new Skill(),
                                   () => new SkillPickList(() => new SkillCollection(),
                                                           () => new Skill())
                                  ) { AssociateID = 103, Name = "Alexander Chow", Tenure = -1, CurrentRoleID = 100 };

            // Act
            sut.AddAssociate(a1);
            sut.AddAssociate(a2);
            sut.AddAssociate(a3);

            // Act
            sut.SelectedAssociate = a3;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut.Associates, Is.Not.Null);
                Assert.That(sut.SelectedAssociate, Is.Not.Null);
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
