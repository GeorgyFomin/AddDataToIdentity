using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AddDataToIdentity.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AddDataToIdentityUser class
public class AddDataToIdentityUser : IdentityUser
{
    [PersonalData]
    public string? Alias { get; set; }
}

