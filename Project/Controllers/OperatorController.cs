using Microsoft.AspNetCore.Authorization;

namespace Project.Controllers
{

    [Authorize(Roles= "Operator")]
    public class OperatorController
    {
        
    }
}