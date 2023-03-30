using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Auth_Mvc_App.Areas.Identity.Data;

public class User : IdentityUser
{
    [MaxLength(20, ErrorMessage = "Maximum length is 20 characters")]
    [MinLength(3, ErrorMessage = "Minimum length is 3 characters")]
    public string FirstName { get; set; }

    [MaxLength(20, ErrorMessage = "Maximum length is 20 characters")]
    [MinLength(3, ErrorMessage = "Minimum length is 3 characters")]
    public string LastName { get; set; }
}

