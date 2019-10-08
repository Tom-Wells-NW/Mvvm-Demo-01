using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Fss.HumanCapitalManager.Core.Models;
using Fss.HumanCapitalManager.Core.Models.Interfaces;
using Fss.HumanCapitalManager.Core.ViewModels;
using Fss.HumanCapitalManager.Core.ViewModels.Interfaces;


namespace Fss.HumanCapitalManager.CoreModule
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Models
            builder.RegisterType<MainViewModel>()
                   .As<IMainViewModel>()
                   .AsSelf();

            builder.RegisterType<AssociatesViewModel>()
                   .As<IAssociatesViewModel>()
                   .AsSelf();


            builder.RegisterType<SkillsViewModel>()
                   .As<ISkillsViewModel>()
                   .AsSelf();

            builder.RegisterType<Role>()
                   .As<IRole>()
                   .AsSelf();

            builder.RegisterType<RoleCollection>()
                   .AsSelf();

            builder.RegisterType<RolePickList>()
                   .As<IRolePickList>()
                   .AsSelf();




            builder.RegisterType<Skill>()
                   .As<ISkill>()
                   .AsSelf();

            builder.RegisterType<SkillCollection>()
                   .AsSelf();

            builder.RegisterType<SkillPickList>()
                   .As<ISkillPickList>()
                   .AsSelf();



            builder.RegisterType<Associate>()
                   .As<IAssociate>()
                   .AsSelf();

            builder.RegisterType<AssociateCollection>()
                   .AsSelf();

            builder.RegisterType<AssociatePickList>()
                   .As<IAssociatePickList>()
                   .AsSelf();

            //// Factories
            //builder.RegisterType<FactoryBase>()
            //       .As<IFactoryBase>();

            


        }
    }

}
