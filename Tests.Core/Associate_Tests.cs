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
    public class Associate_Tests
    {

        [Test]
        [Category("Integration")]
        [Description("Core.Associate.Integration")]
        public void Associate_can_construct()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            IAssociate sut = new Associate(() => new Role(),
                                           () => new RolePickList(() => new RoleCollection(),
                                                                  () => new Role()),
                                           () => new Skill(),
                                           () => new SkillPickList(() => new SkillCollection(),
                                                                   () => new Skill()));

            // Act

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut, Is.Not.Null);
                Assert.That(sut.CurrentRole, Is.Not.Null);
                Assert.That(sut.RoleCapabilities, Is.Not.Null);
                Assert.That(sut.RoleCapabilities.Roles, Is.Not.Null);
                Assert.That(sut.SkillList, Is.Not.Null);
                Assert.That(sut.SkillList.Skills, Is.Not.Null);
            });
        }


        [Test]
        [Category("Integration")]
        [Description("Core.Associate.Integration")]
        public void Associate_can_set_properties()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            IAssociate sut = new Associate(() => new Role(),
                                           () => new RolePickList(() => new RoleCollection(),
                                                                  () => new Role()),
                                           () => new Skill(),
                                           () => new SkillPickList(() => new SkillCollection(),
                                                                   () => new Skill()));


            var currentRole = new Role() { RoleID = 101, Name = "DEV" };
            var newRoleCapability = new Role() { RoleID = 102, Name = "SQA" };
            var newSkill = new Skill { SkillID = 101, Name = "PW7" };

            // Act
            sut.AssociateID = 101;
            sut.Name = "Tom Wells";
            sut.SetCurrentRole(currentRole.RoleID, currentRole.Name);
            sut.AddRoleCapability(newRoleCapability);
            sut.AddSkill(newSkill);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut, Is.Not.Null);
                Assert.That(sut.AssociateID, Is.EqualTo(101));
                Assert.That(sut.Name, Is.EqualTo("Tom Wells"));
                Assert.That(sut.CurrentRole.RoleID, Is.EqualTo(101));
                Assert.That(sut.CurrentRole.Name, Is.EqualTo("DEV"));
                Assert.That(sut.RoleCapabilities.Roles.Count, Is.EqualTo(1));
                Assert.That(sut.RoleCapabilities.Roles[0].RoleID, Is.EqualTo(102));
                Assert.That(sut.RoleCapabilities.Roles[0].Name, Is.EqualTo("SQA"));
                Assert.That(sut.SkillList.Skills.Count, Is.EqualTo(1));
                Assert.That(sut.SkillList.Skills[0].SkillID, Is.EqualTo(101));
                Assert.That(sut.SkillList.Skills[0].Name, Is.EqualTo("PW7"));
            });
        }
    }
}


//var a1 = new Associate(() => new Role(),
//                       () => new RoleCollection(),
//                       () => new SkillCollection())
//            { AssociateID = 101, Name = "Tom Wells", Tenure = 10f };
//var a2 = new Associate(() => new Role(),
//                       () => new RoleCollection(),
//                       () => new SkillCollection())
//            { AssociateID = 102, Name = "Partick Tolentino", Tenure = 12f };
//var a3 = new Associate(() => new Role(),
//                       () => new RoleCollection(),
//                       () => new SkillCollection())
//            { AssociateID = 103, Name = "Ron Robertson", Tenure = 8f };
//var a4 = new Associate(() => new Role(),
//                       () => new RoleCollection(),
//                       () => new SkillCollection())
//            { AssociateID = 104, Name = "Max Subramin", Tenure = 1f };

//var r1 = new Role() { RoleID = 101, Name = "DEV"};
//var r2 = new Role() { RoleID = 102, Name = "SQA" };
//var r3 = new Role() { RoleID = 103, Name = "PM" };
//var r4 = new Role() { RoleID = 104, Name = "BLD" };
//var r5 = new Role() { RoleID = 105, Name = "SCCM" };
//var r6 = new Role() { RoleID = 106, Name = "DEV Lead" };
//var r7 = new Role() { RoleID = 107, Name = "SCRUM" };

//var s1 = new Skill { SkillID = 101, Name = "PW7" };
//var s2 = new Skill { SkillID = 102, Name = "Paws" };
//var s3 = new Skill { SkillID = 103, Name = "Pies" };
//var s4 = new Skill { SkillID = 104, Name = "ODS" };
//var s5 = new Skill { SkillID = 105, Name = "SSRS" };
//var s6 = new Skill { SkillID = 106, Name = "UWP" };
//var s7 = new Skill { SkillID = 107, Name = "WPF" };
//var s8 = new Skill { SkillID = 108, Name = "Angular" };