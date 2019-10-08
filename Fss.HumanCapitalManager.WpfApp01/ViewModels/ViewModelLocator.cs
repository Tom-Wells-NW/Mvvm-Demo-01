using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Fss.HumanCapitalManager.Core.Services.Interfaces;
using Fss.HumanCapitalManager.Core.ViewModels;
using Fss.HumanCapitalManager.Core.ViewModels.Interfaces;
//using GalaSoft.MvvmLight.Ioc;
//using Fss.HumanCapitalManager.Core.Models.Interfaces;
//using Fss.HumanCapitalManager.Core.Models;
using Fss.HumanCapitalManager.CoreModule;
using Fss.HumanCapitalManager.DataService;
using Fss.HumanCapitalManager.DesignDataService;
using GalaSoft.MvvmLight;

namespace Fss.HumanCapitalManager.WpfApp01.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            var builder = new ContainerBuilder();
                builder.RegisterModule<CoreModule.CoreModule>();
                if (!ViewModelBase.IsInDesignModeStatic)
                {
                    builder.RegisterModule<DataServiceModule>();
                }
                else
                {
                    builder.RegisterType<Fss.HumanCapitalManager.DesignDataService.DesignDataService>().As<IDataService>().AsSelf();
                }
            Container = builder.Build();
        }

        public IContainer Container { get; set; }

        public IMainViewModel MainViewModel => Container.Resolve<IMainViewModel>();

        public IAssociatesViewModel AssociatesViewModel => Container.Resolve<IAssociatesViewModel>();

        public ISkillsViewModel SkillsViewModel => Container.Resolve<ISkillsViewModel>();
    }
}
