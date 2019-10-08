using Fss.HumanCapitalManager.Core.Models;
using Fss.HumanCapitalManager.Core.Models.Interfaces;
using Fss.HumanCapitalManager.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fss.HumanCapitalManager.DesignDataService
{
    public class DesignDataService : IDataService
    {
        public DesignDataService(Func<IRole> roleFactory,
                                 Func<RoleCollection> roleCollectionFactory,
                                 Func<IRolePickList> rolePickListFactory,
                                 Func<ISkill> skillFactory,
                                 Func<SkillCollection> skillCollectionFactory,
                                 Func<ISkillPickList> skillPickListFactory,
                                 Func<IAssociate> associateFactory,
                                 Func<AssociateCollection> associateCollectionFactory,
                                 Func<IAssociatePickList> associatePickListFactory) 
        {
            //Context = contextFactory.Invoke();
            ////Context.Database.Log = Console.Write;
            //Context.Configuration.AutoDetectChangesEnabled = false;


            RoleFactory = roleFactory;
            RoleCollectionFactory = roleCollectionFactory;
            RolePickListFactory = rolePickListFactory;
            SkillFactory = skillFactory;
            SkillCollectionFactory = skillCollectionFactory;
            SkillPickListFactory = skillPickListFactory;
            AssociateFactory = associateFactory;
            AssociateCollectionFactory = associateCollectionFactory;
            AssociatePickListFactory = associatePickListFactory;
            InitializeData();
        }

        #region private
        //private HcmEntities Context { get; set; }
        private Func<IRole> RoleFactory { get; set; }
        private Func<RoleCollection> RoleCollectionFactory { get; set; }
        private Func<IRolePickList> RolePickListFactory { get; set; }
        private Func<ISkill> SkillFactory { get; set; }
        private Func<SkillCollection> SkillCollectionFactory { get; set; }
        private Func<ISkillPickList> SkillPickListFactory { get; set; }
        private Func<IAssociate> AssociateFactory { get; set; }
        private Func<AssociateCollection> AssociateCollectionFactory { get; set; }
        private Func<IAssociatePickList> AssociatePickListFactory { get; set; }

        private IRole CreateNewRole()
        {
            return RoleFactory.Invoke();
        }
        private IRole CreateNewRole(int roleID, string name, int presentationOrder)
        {
            var result =  RoleFactory.Invoke();
                result.RoleID = roleID;
                result.Name = name;
                result.PresentationOrder = presentationOrder;
            return result;
        }

        private RoleCollection CreateNewRoleCollection()
        {
            var result = RoleCollectionFactory.Invoke();
            result.Clear();
            return result;
        }

        private IRolePickList CreateNewRolePickList()
        {
            var result = RolePickListFactory.Invoke();
            result.Roles.Clear();
            return result;
        }

        private ISkill CreateNewSkill()
        {
            return SkillFactory.Invoke();
        }

        private ISkill CreateNewSkill(int skillID, string name, int presentationOrder)
        {
            var result = SkillFactory.Invoke();
                result.SkillID = skillID;
                result.Name = name;
                result.PresentationOrder = presentationOrder;
            return result;
        }

        private SkillCollection CreateNewSkillCollection()
        {
            var result = SkillCollectionFactory.Invoke();
            result.Clear();
            return result;
        }

        private ISkillPickList CreateNewSkillPickList()
        {
            var result = SkillPickListFactory.Invoke();
            result.Skills.Clear();
            return result;
        }

        private IAssociate CreateNewAssociate()
        {
            return AssociateFactory.Invoke();
        }
        private IAssociate CreateNewAssociate(int associateID, string name, float tenure, IRole currentRole)
        {
            var result = AssociateFactory.Invoke();
                result.AssociateID = associateID;
                result.Name = name;
                result.Tenure = tenure;
                result.SetCurrentRole(currentRole);
            return result;
        }
        private AssociateCollection CreateNewAssociateCollection()
        {
            return AssociateCollectionFactory.Invoke();
        }

        private IAssociatePickList CreateNewAssociatePickList()
        {
            var result = AssociatePickListFactory.Invoke();
            result.Associates.Clear();
            return result;
        }
        #endregion private

        public void ResetDataService() { }

        public void InitializeData()
        {
            _allRoles = CreateNewRoleCollection();
                _allRoles.Add(CreateNewRole(101, "PM", 0));
                _allRoles.Add(CreateNewRole(102, "ARCH", 0));
                _allRoles.Add(CreateNewRole(103, "TM Lead", 0));
                _allRoles.Add(CreateNewRole(104, "DEV", 0));
                _allRoles.Add(CreateNewRole(105, "DBA", 0));
                _allRoles.Add(CreateNewRole(106, "SQA", 0));
                _allRoles.Add(CreateNewRole(107, "SCRUM", 0));

            _allSkills = CreateNewSkillCollection();
                _allSkills.Add(CreateNewSkill(101, "PRESENTATION", 0));
                _allSkills.Add(CreateNewSkill(102, "FRONT-END", 0));
                _allSkills.Add(CreateNewSkill(103, "BACK-END", 0));
                _allSkills.Add(CreateNewSkill(104, "PW7", 0));
                _allSkills.Add(CreateNewSkill(105, "PAWS", 0));

            _allAssociates = CreateNewAssociateCollection();
            _allAssociates.Clear();
            {
                var associate = CreateNewAssociate(100, "Aaron Schatzer", 10.0f, _allRoles[0]);

                    associate.AddRoleCapability(_allRoles[1]);
                    associate.AddRoleCapability(_allRoles[2]);
                    associate.AddRoleCapability(_allRoles[3]);
                    associate.AddRoleCapability(_allRoles[4]);

                    associate.AddSkill(_allSkills[0]);
                    associate.AddSkill(_allSkills[1]);
                    associate.AddSkill(_allSkills[2]);
                    associate.AddSkill(_allSkills[4]);

                _allAssociates.Add(associate);
            }
            {
                var associate = CreateNewAssociate(101, "Cyrus Moehl", 10.0f, _allRoles[0]);
                _allAssociates.Add(associate);
            }
            {
                var associate = CreateNewAssociate(102, "Tom Wells", 10.0f, _allRoles[0]);
                _allAssociates.Add(associate);
            }
        }

        private RoleCollection _allRoles;
        public RoleCollection GetAllRoles()
        {
            return _allRoles;
        }

        public IRole GetRoleByID(int? id)
        {
            IRole result = null;
            if (_allRoles.Where(e => e.RoleID == id).Count() > 0)
            {
                result = _allRoles.Where(e => e.RoleID == id).First();
            }
            return result;
        }

        public RoleCollection GetRolesByAssociateID(int? id)
        {
            return CreateNewRoleCollection();
        }

        public IRolePickList GetRolePickList()
        {
            var result = CreateNewRolePickList();
            var list = GetAllRoles();

            foreach(IRole role in list)
            {
                result.AddRole(role);
            }

            return result;
        }

        public ISkill GetSkillByID(int id)
        {
            ISkill result = null;
            if (_allSkills.Where(e => e.SkillID == id).Count() > 0)
            {
                result = _allSkills.Where(e => e.SkillID == id).First();
            }
            return result;
        }

        public SkillCollection GetSkillsByAssociateID(int? id)
        {
            return CreateNewSkillCollection();
        }

        private SkillCollection _allSkills;
        public SkillCollection GetAllSkills()
        {
            return _allSkills;
        }

        public ISkillPickList GetSkillPickList()
        {
            var result = CreateNewSkillPickList();
            var list = GetAllSkills();

            foreach (ISkill skill in list)
            {
                result.AddSkill(skill);
            }

            return result;
        }


        private AssociateCollection _allAssociates;
        public AssociateCollection GetAllAssociates()
        {
            return _allAssociates;
        }

        public IAssociatePickList GetAssociatePickList()
        {
            var result = CreateNewAssociatePickList();
            var list = GetAllAssociates();
            foreach(var associate in list)
            {
                result.AddAssociate(associate);
            }
            return result;
        }

        public int AddAssociate(string name, float tenure, int currentRoleID)
        {
            int result = -1;
            var newAssociate = CreateNewAssociate();
                newAssociate.Name = name;
                newAssociate.Tenure = tenure;
                newAssociate.CurrentRoleID = currentRoleID;
                newAssociate.AssociateID = _allAssociates.Max(a => a.AssociateID + 1);

            _allAssociates.Add(newAssociate);
            result = newAssociate.AssociateID;

            return result;
        }

        public bool AddRoleToAssociate(int associateID, int roleID)
        {
            var result = false;
            var associate = GetAssociateByID(associateID);
            if (associate != null)
            {
                var newRole = GetRoleByID(roleID);
                associate.AddRoleCapability(newRole);
                result = true;
            }
            return result;
        }

        private IAssociate GetAssociateByID(int associateID)
        {
            var associateMatches = _allAssociates.Where(a => a.AssociateID == associateID);
            var associateExists = associateMatches.Count() > 0;

                IAssociate result = null;
                if (associateExists) { result = associateMatches.First(); }

            return result;
        }

        public bool AddSkillToAssociate(int associateID, int skillID)
        {
            var result = false;
            var associate = GetAssociateByID(associateID);
            if (associate != null)
            {
                var newSkill = GetSkillByID(skillID);
                associate.AddSkill(newSkill);
                result = true;
            }
            return result;
        }
    }
}
