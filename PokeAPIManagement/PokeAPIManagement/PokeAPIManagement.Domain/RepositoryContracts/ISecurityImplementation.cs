using System.Collections.Generic;

namespace PokeAPIManagement.Data.RepositoryImplementations.SecurityCopy
{
    public interface ISecurityImplementation
    {
        bool SecurityCopy(List<string> copy);
    }
}