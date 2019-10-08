using System.Windows.Input;
using Fss.HumanCapitalManager.Core.Models.Interfaces;
using GalaSoft.MvvmLight.Command;

namespace Fss.HumanCapitalManager.Core.ViewModels.Interfaces
{
    public interface IAssociatesViewModel
    {
        RelayCommand InitializeDataCommand { get; set; }
        RelayCommand AddSelectedAvailableRoleCommand { get; set; }
        RelayCommand AddSelectedAvailableSkillCommand { get; set; }
        IAssociatePickList AvailableAssociates { get; set; }
        IRolePickList AvailableRoles { get; set; }
        ISkillPickList AvailableSkills { get; set; }
        string PrintDate { get; set; }
    }
}