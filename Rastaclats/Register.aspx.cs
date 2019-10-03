using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.Cookies;
using Owin;


namespace Rastaclats
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click1(object sender, EventArgs e)
        {
            //create a dbcontext that specified the connection string
            var identityDbContext = new IdentityDbContext("IdentityConnectionString");
            //create user store and user manager
            var userStore = new UserStore<IdentityUser>(identityDbContext);
            var manager = new UserManager<IdentityUser>(userStore);

            var roleStore = new RoleStore<IdentityRole>(identityDbContext);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            IdentityRole adminRole = new IdentityRole("user");
            roleManager.Create(adminRole);

            //create user
            var user = new IdentityUser() { UserName = txtUserName.Text, Email = txtEmail.Text };
            IdentityResult result = manager.Create(user, txtPassword.Text);
            if (result.Succeeded)
            {

                manager.AddToRole(user.Id, "user");
                manager.Update(user);
                //todo; Either authenticate the user (log them in) or redirect them to the login page to log in for themselves
                litRegisterError.Text = "Success";
            }
            else
            {
                litRegisterError.Text = "An error has occured: " + result.Errors.FirstOrDefault();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //create a dbcontext that specified the connection string
            var identityDbContext = new IdentityDbContext("IdentityConnectionString");
            //create user store and user manager
            var userStore = new UserStore<IdentityUser>(identityDbContext);
            var userManager = new UserManager<IdentityUser>(userStore);
            //create user
            var user = userManager.Find(txtLogInUser.Text, txtLogInPassword.Text);
            if (user != null)
            {
                /*

                //todo: Log user in / instruct user to log in
                LogUserIn(userManager, user);
                Page.Response.Redirect("Administration/Administration.aspx");*/
                LogUserIn(userManager, user);
                litLoginError.Text = "Success";

            }
            else
            {
                litLoginError.Text = "Invalid username or password.";
            }
        }
        private void LogUserIn(UserManager<IdentityUser> usermanager, IdentityUser user)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            var userIdentity = usermanager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties() { }, userIdentity);
            //Note: user is automatically redirect if trying to access another page

            String userAdminRoles = usermanager.GetRoles(user.Id).FirstOrDefault();
            if (userAdminRoles.Equals("admin"))
            {
                Response.Redirect("~/Admin/Index.aspx");
            }
            else
            {
                String userRoles = usermanager.GetRoles(user.Id).FirstOrDefault();
                if (userRoles.Equals("user"))
                {
                    Response.Redirect("~/Index.aspx");
                }
            }
        }
    }
}
