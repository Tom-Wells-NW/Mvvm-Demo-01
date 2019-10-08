using Fss.HumanCapitalManager.Core.Models.Interfaces;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fss.HumanCapitalManager.Core.Models
{
    [DebuggerDisplay("SkillID: {SkillID}  Name: {Name}")]
    public class Skill : ObservableObject, ISkill
    {

        private int _skillID;
        public int SkillID
        {
            get { return _skillID; }
            set { Set(ref _skillID, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }

        private int _presentationOrder;
        public int PresentationOrder
        {
            get { return _presentationOrder; }
            set { Set(ref _presentationOrder, value); }
        }

        public override string ToString()
        {
            return $"{Name}";
        }
        public string ToDebugString()
        {
            return $"SkillID: {SkillID}  Name: {Name}";
        }
    }
}
