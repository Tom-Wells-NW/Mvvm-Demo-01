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
    public class AssociateCollection : ObservableCollection<IAssociate>, ICollection<IAssociate>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        public AssociateCollection() : base() { }

        public AssociateCollection(List<IAssociate> list) : base(list) { }

        public AssociateCollection(IEnumerable<IAssociate> collection) : base(collection) { }
    }
}
