﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using TAApplication.Areas.Data;

namespace TAApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext<TAUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public async Task InitializeUsers(UserManager<TAUser> um, RoleManager<IdentityRole> rm)
        {
            
            if(rm.Roles.Count() != 3)
            {
                await rm.CreateAsync(new IdentityRole("Administrator"));
                await rm.CreateAsync(new IdentityRole("Professor"));
                await rm.CreateAsync(new IdentityRole("Applicant"));
            }

            var admin = CreateUser();
            var professor = CreateUser();
            var app0 = CreateUser();
            var app1 = CreateUser();
            var app2 = CreateUser();


           
            admin.Unid = "u1234567";
            admin.EmailConfirmed = true;
            admin.FullName = "uofu admin";
            admin.Email = "admin@utah.edu";
            await um.SetUserNameAsync(admin, admin.Email);
         
           
            await um.CreateAsync(admin, "123ABC!@#def");

        
            professor.Unid = "u7654321";
            professor.EmailConfirmed = true;
            professor.FullName = "uofu professor";
            professor.Email = "professor@utah.edu";
            await um.SetUserNameAsync(professor, professor.Email);
          

            await um.CreateAsync(professor, "123ABC!@#def");
 
            app0.Unid = "u0000000";
            app0.EmailConfirmed = true;
            app0.FullName = "app 0";
            app0.Email = "u0000000@utah.edu";
            await um.SetUserNameAsync(app0, app0.Email);
           

            await um.CreateAsync(app0, "123ABC!@#def");

       
            app1.Unid = "u0000001";
            app1.EmailConfirmed = true;
            app1.FullName = "app 1";
            app1.Email = "u0000001@utah.edu";
            await um.SetUserNameAsync(app1, app1.Email);
          

            await um.CreateAsync(app1, "123ABC!@#def");
            app2.Unid = "u0000002";
            app2.EmailConfirmed = true;
            app2.FullName = "app 2";
            app2.Email = "u0000002@utah.edu";
            await um.SetUserNameAsync(app2, app2.Email);
         

            await um.CreateAsync(app2, "123ABC!@#def");
          

            await um.AddToRoleAsync(admin, "Administrator");
            await um.AddToRoleAsync(professor, "Professor");
            await um.AddToRoleAsync(app0, "Applicant");
            await um.AddToRoleAsync(app1, "Applicant");
            await um.AddToRoleAsync(app2, "Applicant");

        }
    private TAUser CreateUser()
    {
        try
        {
            return Activator.CreateInstance<TAUser>();
        }
        catch
        {
            throw new InvalidOperationException($"Can't create an instance of '{nameof(TAUser)}'. " +
                $"Ensure that '{nameof(TAUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
        }
    }
    }
}