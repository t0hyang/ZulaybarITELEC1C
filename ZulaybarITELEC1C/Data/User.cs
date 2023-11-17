namespace ZulaybarITELEC1C.Data;
using Microsoft.AspNetCore.Identity;
    public class User : IdentityUser
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set;}
    }
