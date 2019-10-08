
namespace Fss.HumanCapitalManager.Core.Models.Interfaces
{
    public interface IRolePickList
    {
        RoleCollection Roles { get; }
        IRole SelectedRole { get; set; }

        void AddRole(IRole newRole);
        bool RemoveRole(IRole role);
    }
}