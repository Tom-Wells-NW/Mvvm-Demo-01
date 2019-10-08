using System.Windows.Input;
using Fss.HumanCapitalManager.Core.Models.Interfaces;

namespace Fss.HumanCapitalManager.Core.ViewModels.Interfaces
{
    public interface ISkillsViewModel
    {
        ICommand AddNewSkillCommand { get; set; }
        ISkillPickList AvailableSkills { get; set; }
    }
}