using Microsoft.AspNetCore.Identity;
using System;

namespace backendv3.Models {
    public class ApplicationRole : IdentityRole<Guid> { }
    public class Role : ApplicationRole { }
}
