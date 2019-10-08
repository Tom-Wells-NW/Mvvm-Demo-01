using Fss.HumanCapitalManager.Core.Models.Interfaces;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fss.HumanCapitalManager.Core.Models
{
    public class RolePickList : ObservableObject, IRolePickList
    {
        private Func<RoleCollection> _roleCollectionFactory;
        private Func<IRole> _roleFactory;
        public RolePickList(Func<RoleCollection> roleCollectionFactory, Func<IRole> roleFactory)
        {
            _roleFactory = roleFactory;
            _roleCollectionFactory = roleCollectionFactory;
            Roles = _roleCollectionFactory.Invoke();
            Roles.Clear();
            _selectedRole = null;
        }

        private IRole _selectedRole;
        public IRole SelectedRole
        {
            get { return _selectedRole; }
            set
            {
                if (RoleExists(value))
                {
                    Set(ref _selectedRole, value);
                }
            }
        }

        private bool RoleExists(IRole role)
        {
            return Roles.Where(s => s.RoleID == role.RoleID   
                                 && s.Name == role.Name)
                         .Count() > 0;
        }

        private RoleCollection _roles;
        public RoleCollection Roles
        {
            get { return _roles; }
            private set { Set(ref _roles, value); }
        }

        public void AddRole(IRole newRole)
        {
            var role = _roleFactory.Invoke();
                role.RoleID = newRole.RoleID;
                role.Name = newRole.Name;

            Roles.Add(role);
        }

        public bool RemoveRole(IRole role)
        {
            IRole obsoleteRole = null;
            if (RoleExists(role))
            {
                obsoleteRole = Roles.Where(s => s.RoleID == role.RoleID
                                             && s.Name == role.Name)
                                    .First();
            }
            return Roles.Remove(obsoleteRole);
        }
    }
}
