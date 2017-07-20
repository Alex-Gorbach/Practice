using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Through this class we will transfer information about users to the presentation level or, conversely,
// get data from this layer. This class contains all the basic properties that correspond to the properties
// Models ApplicationUser and ClientProfile.
namespace Journey.BLL.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Role { get; set; }
    }
}
