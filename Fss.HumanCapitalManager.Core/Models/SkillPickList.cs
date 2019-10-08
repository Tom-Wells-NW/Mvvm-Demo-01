using Fss.HumanCapitalManager.Core.Models.Interfaces;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fss.HumanCapitalManager.Core.Models
{
    public class SkillPickList : ObservableObject, ISkillPickList
    {
        private Func<SkillCollection> _skillCollectionFactory;
        private Func<ISkill> _skillFactory;
        public SkillPickList(Func<SkillCollection> skillCollectionFactory, Func<ISkill> skillFactory)
        {
            _skillFactory = skillFactory;
            _skillCollectionFactory = skillCollectionFactory;
            Skills = _skillCollectionFactory.Invoke();
            Skills.Clear();
            _selectedSkill = null;
        }

        private ISkill _selectedSkill;
        public ISkill SelectedSkill
        {
            get { return _selectedSkill; }
            set
            {
                if (SkillExists(value))
                {
                    Set(ref _selectedSkill, value);
                }
            }
        }

        private bool SkillExists(ISkill skill)
        {
            return Skills.Where(s => s.SkillID == skill.SkillID 
                                  && s.Name    == skill.Name)
                         .Count() > 0;
        }

        private SkillCollection _skills;
        public SkillCollection Skills
        {
            get { return _skills; }
            private set { Set(ref _skills, value); }
        }

        public void AddSkill(ISkill newSkill)
        {
            var skill = _skillFactory.Invoke();
                skill.SkillID = newSkill.SkillID;
                skill.Name = newSkill.Name;

            Skills.Add(skill);
        }

        public bool RemoveSkill(ISkill skill)
        {
            ISkill obsoleteSkill = null;
            if (SkillExists(skill))
            {
                obsoleteSkill = Skills.Where(s => s.SkillID == skill.SkillID
                                               && s.Name    == skill.Name)
                                      .First();
            }
            return Skills.Remove(obsoleteSkill);
        }

        
    }
}
