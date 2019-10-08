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
    public class SkillCollection_Tests
    {

        [Test]
        [Category("Integration")]
        [Description("Core.SkillCollection.Integration")]
        public void SkillCollection_can_construct_ctor0()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var sut = new SkillCollection();

            // Act

            // Assert
            Assert.That(sut, Is.Not.Null);
        }

        [Test]
        [Category("Integration")]
        [Description("Core.SkillCollection.Integration")]
        public void SkillCollection_can_construct_ctor1()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var list = new List<Skill>() { new Skill { SkillID = 101, Name = "PW7" },
                                           new Skill { SkillID = 102, Name = "Paws" },
                                           new Skill { SkillID = 103, Name = "Pies" }
                                         };
            
            // Act 
            var sut = new SkillCollection(list.AsEnumerable());

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut, Is.Not.Null);
                Assert.That(sut.Count, Is.EqualTo(3));
            });
        }

        [Test]
        [Category("Integration")]
        [Description("Core.SkillCollection.Integration")]
        public void SkillCollection_can_construct_ctor3()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var list = new List<Skill>() { new Skill { SkillID = 101, Name = "PW7" },
                                           new Skill { SkillID = 102, Name = "Paws" },
                                           new Skill { SkillID = 103, Name = "Pies" }
                                         };

            // Act 
            var sut = new SkillCollection(list);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut, Is.Not.Null);
                Assert.That(sut.Count, Is.EqualTo(3));
            });
        }


        [Test]
        [Category("Integration")]
        [Description("Core.SkillCollection.Integration")]
        public void SkillCollection_can_add_skill()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            var sut = new SkillCollection();
            ISkill s1 = new Skill { SkillID = 101, Name = "PW7" };

            // Act
            sut.Add(s1);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sut.Count, Is.EqualTo(1));
                Assert.That(sut[0].SkillID, Is.EqualTo(101));
                Assert.That(sut[0].Name, Is.EqualTo("PW7"));
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