using Autofac;
using Fss.HumanCapitalManager.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fss.HumanCapitalManager.DataService
{
    public class DataServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<HcmEntities>().AsSelf();
            builder.RegisterType<Associate>().AsSelf();
            builder.RegisterType<Role>().AsSelf();
            builder.RegisterType<Skill>().AsSelf();
            builder.RegisterType<AssociateRoleLink>().AsSelf();
            builder.RegisterType<AssociateSkillLink>().AsSelf();

            builder.RegisterType<DataService>()
                   .As<IDataService>()
                   .SingleInstance()
                   .AsSelf();
        }
    }
}
