namespace Fss.HumanCapitalManager.Core.Models.Interfaces
{
    public interface IRole
    {
        string Name { get; set; }
        int RoleID { get; set; }
        int PresentationOrder { get; set; }
        string ToDebugString();
    }
}