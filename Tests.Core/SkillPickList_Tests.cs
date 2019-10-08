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
    public class SkillPickList_Tests
    {
        [Test]
        [Category("Integration")]
        [Description("Core.SkillPickList.Integration")]
        public void SkillPickList_can_construct()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var sut = new SkillPickList(() => new SkillCollection(), 
                                        () => new Skill());

            // Act

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut.Skills, Is.Not.Null);
                Assert.That(sut.SelectedSkill, Is.Null);
            });
        }


        [Test]
        [Category("Integration")]
        [Description("Core.SkillPickList.Integration")]
        public void SkillPickList_can_add_skill()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            ISkillPickList sut = new SkillPickList(() => new SkillCollection(),
                                                   () => new Skill());
            var s1 = new Skill { SkillID = 101, Name = "PW7" };
            var s2 = new Skill { SkillID = 102, Name = "Paws" };
            var s3 = new Skill { SkillID = 103, Name = "Pies" };
            
            // Act
            sut.AddSkill(s1);
            sut.AddSkill(s2);
            sut.AddSkill(s3);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut.Skills, Is.Not.Null);
                Assert.That(sut.Skills.Count == 3);
                Assert.That(sut.SelectedSkill, Is.Null);
            });
        }


        [Test]
        [Category("Integration")]
        [Description("Core.SkillPickList.Integration")]
        public void SkillPickList_can_remove_skill_by_reference()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            ISkillPickList sut = new SkillPickList(() => new SkillCollection(),
                                                   () => new Skill());

            var s1 = new Skill { SkillID = 101, Name = "PW7" };
            var s2 = new Skill { SkillID = 102, Name = "Paws" };
            var s3 = new Skill { SkillID = 103, Name = "Pies" };

            sut.AddSkill(s1);
            sut.AddSkill(s2);
            sut.AddSkill(s3);

            // Act
            var firstRemove = sut.RemoveSkill(s3);
            var secondRemove = sut.RemoveSkill(s3);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut.Skills, Is.Not.Null);
                Assert.That(firstRemove, Is.True);
                Assert.That(secondRemove, Is.False);
                Assert.That(sut.Skills.Count == 2);
                Assert.That(sut.SelectedSkill, Is.Null);
            });
        }


        [Test]
        [Category("Integration")]
        [Description("Core.SkillPickList.Integration")]
        public void SkillPickList_can_remove_skill_by_value()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            ISkillPickList sut = new SkillPickList(() => new SkillCollection(),
                                                   () => new Skill());

            var s1 = new Skill { SkillID = 101, Name = "PW7" };
            var s2 = new Skill { SkillID = 102, Name = "Paws" };
            var s3 = new Skill { SkillID = 103, Name = "Pies" };

            sut.AddSkill(s1);
            sut.AddSkill(s2);
            sut.AddSkill(s3);

            // Act
            var firstRemove = sut.RemoveSkill(new Skill { SkillID = 101, Name = "PW7" });

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut.Skills, Is.Not.Null);
                Assert.That(firstRemove, Is.True);
                Assert.That(sut.Skills.Count == 2);
                Assert.That(sut.SelectedSkill, Is.Null);
            });
        }

        [Test]
        [Category("Integration")]
        [Description("Core.SkillPickList.Integration")]
        public void SkillPickList_can_select_existing_skill()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            ISkillPickList sut = new SkillPickList(() => new SkillCollection(),
                                                   () => new Skill());

            var s1 = new Skill { SkillID = 101, Name = "PW7" };
            var s2 = new Skill { SkillID = 102, Name = "Paws" };
            var s3 = new Skill { SkillID = 103, Name = "Pies" };

            sut.AddSkill(s1);
            sut.AddSkill(s2);
            sut.AddSkill(s3);

            // Act
            sut.SelectedSkill = s3;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut.Skills, Is.Not.Null);
                Assert.That(sut.SelectedSkill, Is.Not.Null);
            });
        }
    }
}


//var sut = new SkillPickList(() => new SkillCollection());
//var s1 = new Skill { SkillID = 101, Name = "PW7" };
//var s2 = new Skill { SkillID = 102, Name = "Paws" };
//var s3 = new Skill { SkillID = 103, Name = "Pies" };
//var s4 = new Skill { SkillID = 104, Name = "ODS" };
//var s5 = new Skill { SkillID = 105, Name = "SSRS" };
//var s6 = new Skill { SkillID = 106, Name = "UWP" };
//var s7 = new Skill { SkillID = 107, Name = "WPF" };
//var s8 = new Skill { SkillID = 108, Name = "Angular" };