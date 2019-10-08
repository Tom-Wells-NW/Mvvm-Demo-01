using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Fss.HumanCapitalManager.Core.Models;
using Fss.HumanCapitalManager.Core.Models.Interfaces;
using Fss.HumanCapitalManager.Core.Services.Interfaces;
using Fss.HumanCapitalManager.Core.ViewModels.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Fss.HumanCapitalManager.Core.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {

        public MainViewModel(Func<IDataService> dataServiceFactory)
        {
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            //AddSelectedAvailableSkillCommand = new RelayCommand(() => AddSelectedAvailableSkillToAssociate());
            //AddSelectedAvailableRoleCommand = new RelayCommand(() => AddSelectedAvailableRoleToAssociate());
        }

    }
}
