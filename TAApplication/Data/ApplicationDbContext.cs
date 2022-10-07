/**
 * Author:    Cole Hanlon
 * Partner:   Tyler Harkness
 * Date:      9/27/2022
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Cole Hanlon, Tyler Harkness - This work may not be copied for use in Academic Coursework.
 *
 * I, Cole Hanlon & Tyler harkness, certify that I have made modifications to this code based on course
 * guidance. The base code has been provided through tutorials from Microsoft Corporation. 
 *
 * File Contents
 *
 *      This file seeds the database with 5 intial users. 
*/
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SendGrid.Helpers.Mail;
using TAApplication.Areas.Data;
using TAApplication.Models;
using static System.Net.Mime.MediaTypeNames;
using Application = TAApplication.Models.Application;

namespace TAApplication.Data
{
    public enum a
    {
        BS
    }
    public class ApplicationDbContext : IdentityDbContext<TAUser>
    {
        public IHttpContextAccessor _httpContextAccessor;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor http)
            : base(options)
        {
            _httpContextAccessor = http;
        }

        public DbSet<Application> Applications { get; set; }

 
        /// <summary>
        /// Intializes all the seeding users in the database. 
        /// </summary>
        /// <param name="um"></param>
        /// <param name="rm"></param>
        /// <returns></returns>
        public async Task InitializeUsers(UserManager<TAUser> um, RoleManager<IdentityRole> rm)
        {

            if (rm.Roles.Count() != 3)
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

        /// <summary>
        /// Fills the application table of the database with the application seeding data.
        /// </summary>
        /// <param name="um"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task IntializeApplication(UserManager<TAUser> um, ApplicationDbContext context)
        {
            var u0App = new Application();
            var u1App = new Application();


            u0App.pursuing = 0;
            u1App.pursuing = 0;
            u0App.Dept = "CS";
            u1App.Dept = "DS";
            u0App.hours = 5;
            u1App.hours = 15;
            u0App.GPA = 4.0;
            u1App.GPA = 3.0;
            u0App.avaliableBeforeSchoo = true;
            u1App.avaliableBeforeSchoo = true;
            u0App.semestersCompleted = 5;
            u1App.semestersCompleted = 5;
            u0App.personalStatement = "this is a personal statement hi";
            u0App.transferSchool = "BYU";
            u0App.linkedInURL = "https://www.linkedin.com/in/tyler-harkness-51469873/";
            u0App.resumeFileName = "~/Images/testpdf.pdf";
    

            var users = um.Users;
            TAUser u0 = null;
            TAUser u1 = null;
            foreach (TAUser u in users)
            {
                if (u.Unid == "u0000000")
                {
                    u0 = u;
                }
                else if (u.Unid == "u0000001")
                {
                    u1 = u;
                }
            }

         
            if(u0 != null && u1 != null)
            {
            u0App.TAUser = u0;
            u1App.TAUser = u1;
            }
            context.Applications.Add(u0App);
            context.Applications.Add(u1App);

            await context.SaveChangesAsync();


        }


        /// <summary>
        /// This method is taken from the Register.cshtml.cs to help create a user in the database.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
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
        /// <summary>
        /// This method is taken from the Register.cshtml.cs to help create a user in the database.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public DbSet<TAApplication.Models.Application> Application { get; set; }


        /// <summary>
        /// Every time Save Changes is called, add timestamps
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()  // JIM: Override save changes to add timestamps
        {
            AddTimestamps();
            return base.SaveChanges();
        }
        /// <summary>
        /// Every time Save Changes (Async) is called, add timestamps
        /// </summary>
        /// <returns></returns>
        public override async Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken = default)
        {
            AddTimestamps();   // JIM: Override save changes async to add timestamps
            return await base.SaveChangesAsync(cancellationToken);
        }
        /// <summary>
        /// JIM: this code adds time/user to DB entry
        /// 
        /// Check the DB tracker to see what has been modified, and add timestamps/names as appropriate.
        /// 
        /// </summary>
        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is ModificationTracking
                        && (x.State == EntityState.Added || x.State == EntityState.Modified));

            var currentUsername = "";

            if (_httpContextAccessor.HttpContext == null) // happens during startup/initialization code
            {
                currentUsername = "DBSeeder";
            }
            else
            {
                currentUsername = _httpContextAccessor.HttpContext.User.Identity?.Name;
            }

            currentUsername ??= "Sadness"; // JIM: compound assignment magic... test for null, and if so, assign value

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((ModificationTracking)entity.Entity).CreationDate = DateTime.UtcNow;
                    ((ModificationTracking)entity.Entity).CreatedBy = currentUsername;
                }
                ((ModificationTracking)entity.Entity).ModificationDate = DateTime.UtcNow;
                ((ModificationTracking)entity.Entity).ModifiedBy = currentUsername;
            }
        }
    }
}