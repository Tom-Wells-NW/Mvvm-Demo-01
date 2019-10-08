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
    public class SkillsViewModel : ViewModelBase, ISkillsViewModel
    {
        public SkillsViewModel(Func<IDataService> dataServiceFactory)
        {
            DataServiceFactory = dataServiceFactory;
            DataService = DataServiceFactory.Invoke();
            InitializeCommands();
            InitializeData();
        }

        private void InitializeCommands()
        {
            AddNewSkillCommand = new RelayCommand(() => AddNewSkillToSkillPickList());
        }

        private async void InitializeData()
        {
            AvailableSkills = await Task.Run(() => DataService.GetSkillPickList());
            return;
        }
        private Func<IDataService> DataServiceFactory { get; set; }
        private IDataService DataService { get; set; }

        private ISkillPickList _availableSkills;
        public ISkillPickList AvailableSkills
        {
            get { return _availableSkills; }
            set { Set(ref _availableSkills, value); }
        }

        public ICommand AddNewSkillCommand { get; set; }

        private void AddNewSkillToSkillPickList()
        {
            Console.WriteLine("Adding new Skill to SkillPickList...");
            //var result = DataService.AddSkillToAssociate(AvailableAssociates.SelectedAssociate.AssociateID, AvailableSkills.SelectedSkill.SkillID);
            //AvailableAssociates.SelectedAssociate.AddSkill(AvailableSkills.SelectedSkill);
        }


        private string _newSkill;
        public string NewSkill
        {
            get { return _newSkill; }
            set { Set(ref _newSkill, value); }
        }
    }
}
