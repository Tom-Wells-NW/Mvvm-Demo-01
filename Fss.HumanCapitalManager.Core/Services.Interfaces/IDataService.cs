using Fss.HumanCapitalManager.Core.Models;
using Fss.HumanCapitalManager.Core.Models.Interfaces;

namespace Fss.HumanCapitalManager.Core.Services.Interfaces
{
    public interface IDataService
    {
        void ResetDataService();
        RoleCollection GetAllRoles();
        IRole GetRoleByID(int? id);
        RoleCollection GetRolesByAssociateID(int? id);
        IRolePickList GetRolePickList();

        ISkill GetSkillByID(int id);
        SkillCollection GetSkillsByAssociateID(int? id);
        SkillCollection GetAllSkills();
        ISkillPickList GetSkillPickList();

        AssociateCollection GetAllAssociates();
        IAssociatePickList GetAssociatePickList();
        int AddAssociate(string name, float tenure, int currentRoleID);
        bool AddRoleToAssociate(int associateID, int roleID);
        bool AddSkillToAssociate(int associateID, int skillID);

    }
}