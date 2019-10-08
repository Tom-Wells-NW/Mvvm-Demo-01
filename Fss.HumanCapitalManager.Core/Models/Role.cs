using Fss.HumanCapitalManager.Core.Models.Interfaces;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fss.HumanCapitalManager.Core.Models
{
    [DebuggerDisplay("RoleID: {RoleID}  Name: {Name}")]
    public class Role : ObservableObject, IRole
    {
        private int _roleID;
        public int RoleID
        {
            get { return _roleID; }
            set { Set(ref _roleID, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }

        private int _presentationOrder;
        public int PresentationOrder
        {
            get { return _presentationOrder; }
            set { Set(ref _presentationOrder, value); }
        }

        public override string ToString()
        {
            return $"{Name}";
        }

        public string ToDebugString()
        {
            return $"RoleID: {RoleID}  Name: {Name}";
        }
        
    }
}
