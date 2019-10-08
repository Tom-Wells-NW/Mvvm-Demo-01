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
    public class Skill_Tests
    {

        [Test]
        [Category("Integration")]
        [Description("Core.Skill.Integration")]
        public void Skill_can_construct()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var sut = new Skill();

            // Act

            // Assert
            Assert.That(sut, Is.Not.Null);
        }

        [Test]
        [Category("Integration")]
        [Description("Core.Skill.Integration")]
        public void Skill_can_set_properties()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var sut = new Skill();

            // Act
            sut.SkillID = 101;
            sut.Name = "PW7";

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut.SkillID, Is.EqualTo(101));
                Assert.That(sut.Name, Is.EqualTo("PW7"));
            });
        }
    }
}


//var s1 = new Skill { SkillID = 101, Name = "PW7" };
//var s2 = new Skill { SkillID = 102, Name = "Paws" };
//var s3 = new Skill { SkillID = 103, Name = "Pies" };
//var s4 = new Skill { SkillID = 104, Name = "ODS" };
//var s5 = new Skill { SkillID = 105, Name = "SSRS" };
//var s6 = new Skill { SkillID = 106, Name = "UWP" };
//var s7 = new Skill { SkillID = 107, Name = "WPF" };
//var s8 = new Skill { SkillID = 108, Name = "Angular" };