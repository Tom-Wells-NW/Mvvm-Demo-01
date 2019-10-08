using Fss.HumanCapitalManager.Core.Models;
using Fss.HumanCapitalManager.Core.Models.Interfaces;
using Fss.HumanCapitalManager.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fss.HumanCapitalManager.DataService
{
    public class DataService : IDataService
    {
        public DataService(Func<HcmEntities> contextFactory,
                           Func<IRole> roleFactory,
                           Func<RoleCollection> roleCollectionFactory,
                           Func<IRolePickList> rolePickListFactory,
                           Func<ISkill> skillFactory,
                           Func<SkillCollection> skillCollectionFactory,
                           Func<ISkillPickList> skillPickListFactory,
                           Func<IAssociate> associateFactory,
                           Func<AssociateCollection> associateCollectionFactory,
                           Func<IAssociatePickList> associatePickListFactory)
        {
            ContextFactory = contextFactory;
            Context = ContextFactory.Invoke();
            
            //Context.Database.Log = Console.Write;
            Context.Configuration.AutoDetectChangesEnabled = false;


            RoleFactory = roleFactory;
            RoleCollectionFactory = roleCollectionFactory;
            RolePickListFactory = rolePickListFactory;
            SkillFactory = skillFactory;
            SkillCollectionFactory = skillCollectionFactory;
            SkillPickListFactory = skillPickListFactory;
            AssociateFactory = associateFactory;
            AssociateCollectionFactory = associateCollectionFactory;
            AssociatePickListFactory = associatePickListFactory;
        }

        private HcmEntities Context { get; set; }
        private Func<HcmEntities> ContextFactory { get; set; }
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

        private SkillCollection CreateNewSkillCollection()
        {
            var result = SkillCollectionFactory.Invoke();
                result.Clear();
            return result;
        }

        private ISkillPickList CreateNewSkillPickList()
        {
            var result =  SkillPickListFactory.Invoke();
                result.Skills.Clear();
            return result;
        }

        private IAssociate CreateNewAssociate()
        {
            return AssociateFactory.Invoke();
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
        public IRole GetRoleByID(int? id)
        {
            IRole result = null;
            if (id.HasValue && id >= 100)
            {
                var foundRole = Context.Roles
                                       .Where(e => e.RoleID == id)
                                       .FirstOrDefault();

                result = CreateNewRole();
                result.RoleID = foundRole.RoleID;
                result.Name = foundRole.Name;
                result.PresentationOrder = (foundRole.PresentationOrder.HasValue ? foundRole.PresentationOrder.Value : 999);
            }
            return result;
        }

        public void ResetDataService()
        {
            var oldContext = Context;
            Context = ContextFactory.Invoke();
            oldContext.Dispose();
        }

        public RoleCollection GetRolesByAssociateID(int? id)
        {
            RoleCollection result = CreateNewRoleCollection();

            if (id.HasValue && id >= 100)
            {
                var foundAssociateRoleIds = Context.AssociateRoleLinks
                                                   .Where(e => e.AssociateID == id)
                                                   .Select(e => e.RoleID);

                var foundAssociateRoles = Context.Roles
                                                 .Where(e => foundAssociateRoleIds.Contains(e.RoleID))
                                                 .OrderBy(e => e.PresentationOrder)
                                                 .ThenBy(e => e.Name);

                foreach (var foundRole in foundAssociateRoles)
                {
                    result.Add(GetRoleByID(foundRole.RoleID));
                }
            }
            return result;
        }

        public RoleCollection GetAllRoles()
        {
            var list = Context.Roles
                              .OrderBy(r => r.PresentationOrder)
                              .ThenBy(r => r.Name)
                              .ToList();

            var result = CreateNewRoleCollection();
                result.Clear();

            foreach (var role in list)
            {
                var item = CreateNewRole();
                    item.RoleID = role.RoleID;
                    item.Name = role.Name;
                    item.PresentationOrder = (role.PresentationOrder.HasValue ? role.PresentationOrder.Value : 1000);
                result.Add(item);
            }

            return result;
        }

        public IRolePickList GetRolePickList()
        {
            var list = GetAllRoles();

            var result = CreateNewRolePickList();

            foreach (var role in list)
            {
                var item = CreateNewRole();
                    item.RoleID = role.RoleID;
                    item.Name = role.Name;
                result.AddRole(item);
            }

            return result;
        }

        public ISkill GetSkillByID(int id)
        {
            var foundSkill = Context.Skills
                                    .Where(e => e.SkillID == id)
                                    .FirstOrDefault();

            var result = CreateNewSkill();
                result.SkillID = foundSkill.SkillID;
                result.Name = foundSkill.Name;
                result.PresentationOrder = (foundSkill.PresentationOrder.HasValue ? foundSkill.PresentationOrder.Value : 999);

            return result;
        }

        public SkillCollection GetSkillsByAssociateID(int? id)
        {
            SkillCollection result = CreateNewSkillCollection();
            if (id.HasValue && id >= 100)
            {
                var foundAssociateSkillIds = Context.AssociateSkillLinks
                                                    .Where(e => e.AssociateID == id)
                                                    .Select(e => e.SkillID);
                var foundAssociateSkills = Context.Skills
                                                  .Where(e => foundAssociateSkillIds.Contains(e.SkillID))
                                                  .OrderBy(e => e.PresentationOrder)
                                                  .ThenBy(e => e.Name);

                foreach (var foundSkill in foundAssociateSkills)
                {
                    result.Add(GetSkillByID(foundSkill.SkillID));
                }
            }

            /*
                         if (id.HasValue && id >= 100)
            {
                var foundAssociateRoleIds = Context.AssociateRoleLinks
                                                   .Where(e => e.AssociateID == id)
                                                   .Select(r => r.RoleID);

                var foundAssociateRoles = Context.Roles
                                                 .Where(r => foundAssociateRoleIds.Contains(r.RoleID))
                                                 .OrderBy(r => r.PresentationOrder)
                                                 .ThenBy(r => r.Name);

                foreach (var foundRole in foundAssociateRoles)
                {
                    result.Add(GetRoleByID(foundRole.RoleID));
                }
            }
             * */
            return result;
        }

        public SkillCollection GetAllSkills()
        {
            var list = Context.Skills
                              .OrderBy(s => s.PresentationOrder)
                              .ThenBy(s => s.Name)
                              .ToList();

            var result = CreateNewSkillCollection();
                result.Clear();

            foreach (var skill in list)
            {
                var item = CreateNewSkill();
                    item.SkillID = skill.SkillID;
                    item.Name = skill.Name;
                    item.PresentationOrder = (skill.PresentationOrder.HasValue ? skill.PresentationOrder.Value : 1000);
                result.Add(item);
            }

            return result;
        }

        public ISkillPickList GetSkillPickList()
        {
            var list = GetAllSkills();

            var result = CreateNewSkillPickList();

            foreach (var skill in list)
            {
                var item = CreateNewSkill();
                    item.SkillID = skill.SkillID;
                    item.Name = skill.Name;
                    item.PresentationOrder = skill.PresentationOrder;
                result.AddSkill(item);
            }

            return result;
        }

        public IAssociatePickList GetAssociatePickList()
        {
            var list = GetAllAssociates();

            var result = CreateNewAssociatePickList();

            foreach (var associate in list)
            {
                result.AddAssociate(associate);
            }

            return result;
        }

        public AssociateCollection GetAllAssociates()
        {
            var associateEntityList = Context.Associates
                                             .OrderBy(a => a.Name)
                                             .ThenBy(a => a.AssociateID)
                                             .ToList();

            var associateModels = new List<IAssociate>();

            foreach (var associate in associateEntityList)
            {
                IAssociate model = MapAssociateEntityToAssociateModel(associate);
                associateModels.Add(model);
            }

            var result = GetOrderedAssociateCollection(associateModels.OrderBy(e => e.Name)
                                                                      .ThenBy(e => e.CurrentRole.Name));

            return result;
        }

        private IAssociate MapAssociateEntityToAssociateModel(Associate associate)
        {
            var item = CreateNewAssociate();
                item.AssociateID = associate.AssociateID;
                item.Name = associate.Name;
                item.Tenure = (associate.Tenure.HasValue ? (float)associate.Tenure.Value : -1f);
                item.SetCurrentRole(GetRoleByID(associate.CurrentRoleID));

            var associateRoles = GetRolesByAssociateID(associate.AssociateID);
            foreach(var role in associateRoles)
            {
                item.AddRoleCapability(role);
            }

            var associateSkills = GetSkillsByAssociateID(associate.AssociateID);
            foreach(var skill in associateSkills)
            {
                item.AddSkill(skill);
            }

            return item;
        }

        public AssociateCollection GetOrderedAssociateCollection(IOrderedEnumerable<IAssociate> list)
        {
            var result = CreateNewAssociateCollection();
                result.Clear();

            foreach (IAssociate associate in list)
            {
                result.Add(associate);
            }

            return result;
        }

        public int AddAssociate(string name, float tenure, int currentRoleID)
        {
            int result = -1;
            var associate = new Associate();
                associate.Name = name;
                associate.Tenure = tenure;
                associate.CurrentRoleID = currentRoleID;

                try
                {
                    Context.Associates.Add(associate);
                    Context.SaveChanges();
                    result = associate.AssociateID;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            return result;
        }

        public bool AddRoleToAssociate(int associateID, int roleID)
        {
            bool result = false;
            var link = new AssociateRoleLink();
                link.AssociateID = associateID;
                link.RoleID = roleID;

                try
                { 
                    Context.AssociateRoleLinks.Add(link);
                    Context.SaveChanges();
                    result = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            return result;
        }

        public bool AddSkillToAssociate(int associateID, int skillID)
        {
            bool result = false;
            var link = Context.AssociateSkillLinks.Create();
                link.AssociateID = associateID;
                link.SkillID = skillID;

                try
                {

                    Context.AssociateSkillLinks.Add(link);
                    Context.SaveChanges();
                    result = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            return result;
        }
    }
}
