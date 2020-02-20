using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeaconnectedWebApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BeaconnectedWebApp
{
    public class RoleAction
    {
        internal void AddAdminRole()
        {
            Models.ApplicationDbContext context = new ApplicationDbContext();
            IdentityResult IdRoleResult;
            IdentityResult IdUserResult;

            var roleStore = new RoleStore<IdentityRole>(context);
            
            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            if (!roleMgr.RoleExists("Super"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole { Name = "Super" });
            }

            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = new ApplicationUser
            {
                UserName = "beaconnected@beacon.com",
                Email = "beaconnected@beacon.com"
            };
            IdUserResult = userMgr.Create(appUser, "$uper8eacon");

            if (!userMgr.IsInRole(userMgr.FindByEmail("beaconnected@beacon.com").Id, "Super"))
            {
                IdUserResult = userMgr.AddToRole(userMgr.FindByEmail("beaconnected@beacon.com").Id, "Super");
            }
        }
    }
}