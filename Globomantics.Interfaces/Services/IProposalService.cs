using System.Collections.Generic;
using System.Threading.Tasks;
using Globomantics.Models;

namespace Globomantics.Interfaces.Services
{
    public interface IProposalService
    {
        Task Add(ProposalModel proposal);

        Task<ProposalModel> Approve(int proposalId);

        Task<IEnumerable<ProposalModel>> GetAll(int conferenceId);
    }
}
