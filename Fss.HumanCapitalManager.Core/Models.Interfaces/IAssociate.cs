

namespace Fss.HumanCapitalManager.Core.Models.Interfaces
{
    public interface IAssociate
    {
        int AssociateID { get; set; }
        string Name { get; set; }
        float Tenure { get; set; }
        int? CurrentRoleID { get; set; }
        IRole CurrentRole { get; }
        void SetCurrentRole(int roleID, string roleName);
        void SetCurrentRole(IRole role);
        IRolePickList RoleCapabilities { get; }
        void AddRoleCapability(IRole role);
        void RemoveRoleCapability(IRole role);
        bool CanAddRoleCapability(IRole role);
        bool HasRoleCapability(IRole role);
        ISkillPickList SkillList { get; }
        void AddSkill(ISkill skill);
        void RemoveSkill(ISkill skill);
        bool CanAddSkill(ISkill skill);
        bool HasSkill(ISkill skill);
        string ToDebugString();
    }
}