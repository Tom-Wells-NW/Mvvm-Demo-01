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
    public class RoleCollection : ObservableCollection<IRole>, ICollection<IRole>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        public RoleCollection() : base() { }

        public RoleCollection(List<IRole> list) : base(list) { }

        public RoleCollection(IEnumerable<IRole> collection) : base(collection) { }
    }
}
