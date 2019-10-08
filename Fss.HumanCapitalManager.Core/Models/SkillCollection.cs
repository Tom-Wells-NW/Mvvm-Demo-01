using Fss.HumanCapitalManager.Core.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fss.HumanCapitalManager.Core.Models
{
    public class SkillCollection : ObservableCollection<ISkill>, ICollection<ISkill>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        public SkillCollection() { }

        public SkillCollection(List<ISkill> list) : base(list) { }

        public SkillCollection(IEnumerable<ISkill> collection) : base(collection) { }
    }

}
