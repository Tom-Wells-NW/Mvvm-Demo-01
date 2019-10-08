namespace Fss.HumanCapitalManager.Core.Models.Interfaces
{
    public interface ISkill
    {
        string Name { get; set; }
        int SkillID { get; set; }
        int PresentationOrder { get; set; }
        string ToDebugString();
    }
}