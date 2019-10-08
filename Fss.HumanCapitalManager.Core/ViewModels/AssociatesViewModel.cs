using Fss.HumanCapitalManager.Core.Models.Interfaces;
using Fss.HumanCapitalManager.Core.Services.Interfaces;
using Fss.HumanCapitalManager.Core.ViewModels.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fss.HumanCapitalManager.Core.ViewModels
{

    public class AssociatesViewModel : ViewModelBase, IAssociatesViewModel
    {

        public AssociatesViewModel(Func<IDataService> dataServiceFactory)
        {
            DataServiceFactory = dataServiceFactory;
            DataService = DataServiceFactory.Invoke();
            PrintDate = $"{DateTime.Now:yyyy/MM/dd}";
            InitializeNewData();
            InitializeCommands();
            InitializeData();
        }

        private void InitializeCommands()
        {
            AddSelectedAvailableSkillCommand = new RelayCommand(() => AddSelectedAvailableSkillToAssociate());
            AddSelectedAvailableRoleCommand = new RelayCommand(() => AddSelectedAvailableRoleToAssociate());
            InitializeDataCommand = new RelayCommand(() => InitializeData(), () => !IsLoading, true);
        }

        private async void InitializeData()
        {
            IsLoading = true;
            var selectedAssociateID = -1;
            DataService.ResetDataService();
            if (AvailableAssociates?.SelectedAssociate != null) selectedAssociateID = AvailableAssociates.SelectedAssociate.AssociateID;
            InitializeDataCommand.RaiseCanExecuteChanged();
            

            AvailableSkills = await Task.Run(() => DataService.GetSkillPickList());
            AvailableRoles = await Task.Run(() => DataService.GetRolePickList());
            AvailableAssociates = await Task.Run(() => DataService.GetAssociatePickList());

            IsLoading = false;
            InitializeDataCommand.RaiseCanExecuteChanged();
            if (selectedAssociateID != -1)
            {
                for(int i = 0; i < AvailableAssociates.Associates.Count; i++)
                {
                    if (selectedAssociateID == AvailableAssociates.Associates[i].AssociateID)
                    {
                        AvailableAssociates.SelectedAssociate = AvailableAssociates.Associates[i];
                    }
                }
            }            

            return;
        }

        private void InitializeNewData()
        {
            //var name = "Test Associate";
            //DataService.AddAssociate(name, 10.0f, 101);

        }

        private Func<IDataService> DataServiceFactory { get; set; }
        private IDataService DataService { get; set; }


        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { Set(ref _isLoading, value); }
        }

        private bool IsLoadingData()
        {
            return IsLoading;
        }


        private IAssociatePickList _availableAssociates;
        public IAssociatePickList AvailableAssociates
        {
            get { return _availableAssociates; }
            set { Set(ref _availableAssociates, value); }
        }

        public string PrintDate { get; set; }

        private ISkillPickList _availableSkills;
        public ISkillPickList AvailableSkills
        {
            get { return _availableSkills; }
            set { Set(ref _availableSkills, value); }
        }

        private IRolePickList _availableRoles;
        public IRolePickList AvailableRoles
        {
            get { return _availableRoles; }
            set { Set(ref _availableRoles, value); }
        }

        public RelayCommand InitializeDataCommand { get; set; }

        public RelayCommand AddSelectedAvailableSkillCommand { get; set; }

        private void AddSelectedAvailableSkillToAssociate()
        {
            Console.WriteLine("Adding Skill to Associate..");
            var result = DataService.AddSkillToAssociate(AvailableAssociates.SelectedAssociate.AssociateID, AvailableSkills.SelectedSkill.SkillID);
            AvailableAssociates.SelectedAssociate.AddSkill(AvailableSkills.SelectedSkill);
        }

        public RelayCommand AddSelectedAvailableRoleCommand { get; set; }
        private void AddSelectedAvailableRoleToAssociate()
        {
            Console.WriteLine("Adding Role to Associate..");
            var result = DataService.AddRoleToAssociate(AvailableAssociates.SelectedAssociate.AssociateID, AvailableRoles.SelectedRole.RoleID);
            AvailableAssociates.SelectedAssociate.AddRoleCapability(AvailableRoles.SelectedRole);
        }
       
    }

}
