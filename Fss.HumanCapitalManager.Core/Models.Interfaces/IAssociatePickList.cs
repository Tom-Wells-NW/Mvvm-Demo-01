using Fss.HumanCapitalManager.Core.Models.Interfaces;

namespace Fss.HumanCapitalManager.Core.Models.Interfaces
{
    public interface IAssociatePickList
    {
        IAssociate SelectedAssociate { get; set; }
        AssociateCollection Associates { get; }

        void AddAssociate(IAssociate newAssociate);
        bool RemoveAssociate(IAssociate associate);
    }
}