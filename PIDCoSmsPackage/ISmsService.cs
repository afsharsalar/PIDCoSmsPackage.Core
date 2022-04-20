using System.Collections.Generic;
using System.Threading.Tasks;
using PIDCoSmsPackage.Model;

namespace PIDCoSmsPackage
{
    public interface ISmsService
    {
        Task<List<SendResultViewModel>> Send(SendViewModel model);
    }
}
