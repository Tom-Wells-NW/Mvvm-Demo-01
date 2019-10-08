using Fss.HumanCapitalManager.Core.Models.Interfaces;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fss.HumanCapitalManager.Core.Models
{
    public class AssociatePickList : ObservableObject, IAssociatePickList
    {
        private Func<AssociateCollection> _associateCollectionFactory;
        private Func<IAssociate> _associateFactory;

        public AssociatePickList(Func<AssociateCollection> associateCollectionFactory, Func<IAssociate> associateFactory)
        {
            _associateFactory = associateFactory;
            _associateCollectionFactory = associateCollectionFactory;
            Associates = _associateCollectionFactory.Invoke();
            Associates.Clear();
            _selectedAssociate = null;
        }

        private IAssociate _selectedAssociate;
        public IAssociate SelectedAssociate
        {
            get { return _selectedAssociate; }
            set
            {
                if (AssociateExists(value))
                {
                    Set(ref _selectedAssociate, value);
                }
            }
        }

        private AssociateCollection _associates;
        public AssociateCollection Associates
        {
            get { return _associates; }
            private set { Set(ref _associates, value); }
        }


        private bool AssociateExists(IAssociate associate)
        {
            return Associates.Where(s => s.AssociateID == associate.AssociateID
                                      && s.Name == associate.Name)
                             .Count() > 0;
        }

        public void AddAssociate(IAssociate newAssociate)
        {
            var associate = _associateFactory.Invoke();
                associate.AssociateID = newAssociate.AssociateID;
                associate.Name = newAssociate.Name;
                associate.SetCurrentRole(newAssociate.CurrentRole);
                associate.Tenure = newAssociate.Tenure;
            
                foreach(var skill in newAssociate.SkillList.Skills)
                {
                    associate.AddSkill(skill);
                }
                foreach(var role in newAssociate.RoleCapabilities.Roles)
                {
                    associate.AddRoleCapability(role);
                }


            Associates.Add(associate);
        }

        public bool RemoveAssociate(IAssociate associate)
        {
            IAssociate obsoleteAssociate = null;
            if (AssociateExists(associate))
            {
                obsoleteAssociate = Associates.Where(a => a.AssociateID == associate.AssociateID
                                                       && a.Name == associate.Name)
                                              .First();
            }
            return Associates.Remove(obsoleteAssociate);
        }

    }
}
