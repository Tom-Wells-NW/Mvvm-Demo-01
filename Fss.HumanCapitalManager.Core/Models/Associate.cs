using Fss.HumanCapitalManager.Core.Models.Interfaces;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fss.HumanCapitalManager.Core.Models
{
    public class Associate : ObservableObject, IAssociate
    {
        private Func<IRole> _roleFactory;
        private Func<IRolePickList> _rolePickListFactory;
        private Func<ISkill> _skillFactory;
        private Func<ISkillPickList> _skillPickListFactory;

        public Associate(Func<IRole> roleFactory,
                         Func<IRolePickList> rolePickListFactory,
                         Func<ISkill> skillFactory,
                         Func<ISkillPickList> skillPickListFactory)
        {
            _roleFactory = roleFactory;
            CurrentRole = _roleFactory.Invoke();

            _rolePickListFactory = rolePickListFactory;
            RoleCapabilities = _rolePickListFactory.Invoke();
            RoleCapabilities.Roles.Clear();

            _skillFactory = skillFactory;
            _skillPickListFactory = skillPickListFactory;
            SkillList = _skillPickListFactory.Invoke();
            SkillList.Skills.Clear();

        }

        private static int __testSkillID = 100;
        private ISkill GetNextTestSkill()
        {
            var result = _skillFactory.Invoke();
                result.SkillID = __testSkillID++;
                result.Name = $"Skill-{__testSkillID}";
            return result;
        }

        private static int __testRoleID = 100;
        private IRole GetNextTestRoleCapability()
        {
            var result = _roleFactory.Invoke();
                result.RoleID = __testRoleID++;
                result.Name = $"Role-{__testRoleID}";
            return result;
        }

        private int _associateID;
        public int AssociateID
        {
            get { return _associateID; }
            set { Set(ref _associateID, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }

        private float _tenure;
        public float Tenure
        {
            get { return _tenure; }
            set { Set(ref _tenure, value); }
        }

        private int? _roleID;
        public int? CurrentRoleID
        {
            get { return _roleID; }
            set { Set(ref _roleID, value); }
        }

        private IRole _currentRole;
        public IRole CurrentRole
        {
            get { return _currentRole; }
            private set { Set(ref _currentRole, value); }
        }

        public void SetCurrentRole(int roleID, string roleName)
        {
            var role = _roleFactory.Invoke();
                role.RoleID = roleID;
                role.Name = roleName;
            SetCurrentRole(role);
        }
        public void SetCurrentRole(IRole role)
        {
            CurrentRole = role;
            CurrentRoleID = role.RoleID;
        }


        private IRolePickList _roleCapabilities;
        public IRolePickList RoleCapabilities
        {
            get { return _roleCapabilities; }
            private set { Set(ref _roleCapabilities, value); }
        }

        public void AddRoleCapability(IRole role)
        {
            if (CanAddRoleCapability(role)) { RoleCapabilities.Roles.Add(role); }
        }

        public void RemoveRoleCapability(IRole role)
        {
            if (HasRoleCapability(role)) { RoleCapabilities.Roles.Remove(role); }
        }

        public bool CanAddRoleCapability(IRole role)
        {
            return !HasRoleCapability(role);
        }

        public bool HasRoleCapability(IRole role)
        {
            return RoleCapabilities.Roles.Where(s => s.RoleID == role.RoleID
                                            && s.Name == role.Name)
                                   .Count() > 0;
        }

        private ISkillPickList _skillList;
        public ISkillPickList SkillList
        {
            get { return _skillList; }
            private set { Set(ref _skillList, value); }
        }

        public void AddSkill(ISkill skill)
        {
            if (CanAddSkill(skill)) { SkillList.Skills.Add(skill); }
        }

        public void RemoveSkill(ISkill skill)
        {
            if (HasSkill(skill)) { SkillList.Skills.Remove(skill); }
        }

        public bool CanAddSkill(ISkill skill)
        {
            return !HasSkill(skill);
        }

        public bool HasSkill(ISkill skill)
        {
            return SkillList.Skills.Where(s => s.SkillID == skill.SkillID 
                                            && s.Name    == skill.Name)
                                   .Count() > 0;
        }

        public string ToDebugString()
        {
            return $"{Name} {Tenure} {CurrentRole?.Name}";
        }
    }
}
