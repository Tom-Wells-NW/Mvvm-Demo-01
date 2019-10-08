namespace Fss.HumanCapitalManager.Core.Models.Interfaces
{
    public interface ISkillPickList
    {
        ISkill SelectedSkill { get; set; }
        SkillCollection Skills { get; }

        void AddSkill(ISkill skill);
        bool RemoveSkill(ISkill skill);
    }
}