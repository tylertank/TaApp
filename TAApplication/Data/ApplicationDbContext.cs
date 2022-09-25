using Microsoft.AspNetCore.Identity;
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

            TAUser admin = new TAUser();
            admin.Unid = "u1234567";
            admin.EmailConfirmed = true;
            admin.FullName = "uofu admin";
            admin.Email = "admin@utah.edu";
            admin.ReferredTo = "test";

            TAUser professor = new TAUser();
            professor.Unid = "u7654321";
            professor.EmailConfirmed = true;
            professor.FullName = "uofu professor";
            professor.Email = "professor@utah.edu";
            professor.ReferredTo = "test";

            TAUser app0 = new TAUser();
            app0.Unid = "u0000000";
            app0.EmailConfirmed = true;
            app0.FullName = "app 0";
            app0.Email = "u0000000@utah.edu";
            app0.ReferredTo = "test";

            TAUser app1 = new TAUser();
            app1.Unid = "u0000001";
            app1.EmailConfirmed = true;
            app1.FullName = "app 1";
            app1.Email = "u0000001@utah.edu";
            app1.ReferredTo = "test";

            TAUser app2 = new TAUser();
            app2.Unid = "u0000002";
            app2.EmailConfirmed = true;
            app2.FullName = "app 2";
            app2.Email = "u0000002@utah.edu";
            app2.ReferredTo = "test";


            await um.CreateAsync(admin, "123ABC!@#def");
            await um.CreateAsync(professor, "123ABC!@#def");
            await um.CreateAsync(app0, "123ABC!@#def");
            await um.CreateAsync(app1, "123ABC!@#def");
            await um.CreateAsync(app2, "123ABC!@#def");

            await um.AddToRoleAsync(admin, "Administrator");
            await um.AddToRoleAsync(professor, "Professor");
            await um.AddToRoleAsync(app0, "Applicant");
            await um.AddToRoleAsync(app1, "Applicant");
            await um.AddToRoleAsync(app2, "Applicant");

        }
    }
}