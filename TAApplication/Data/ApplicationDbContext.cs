﻿/**
 * Author:    Cole Hanlon
 * Partner:   Tyler Harkness
 * Date:      12/8/2022
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Cole Hanlon, Tyler Harkness - This work may not be copied for use in Academic Coursework.
 *
 * I, Cole Hanlon & Tyler harkness, certify that I have made modifications to this code based on course
 * guidance. The base code has been provided through tutorials from Microsoft Corporation. 
 *
 * File Contents
 *
 *      This file seeds the database with 5 intial users and 2 applications. It also seeds 5 courses.
 *      
 *      Updated to seed Enrollments, and Availability
*/
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SendGrid.Helpers.Mail;
using System.Collections;
using System.Globalization;
using System.Xml.Linq;
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

        /// <summary>
        /// Stores database and http context
        /// </summary>
        /// <param name="options"></param>
        /// <param name="http"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor http)
            : base(options)
        {
            _httpContextAccessor = http;
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

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
        public async Task IntializeSlots(UserManager<TAUser> um, ApplicationDbContext context)
        {

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
            ArrayList slotList = new ArrayList();
              
            for(int i = 0; i < 240; i++)
            {
                if(i < 16 ||( i >= 192 && i < 208))
                {
                    slotList.Add(new Slot(u0, i, true));

                }else if(( i >= 64 && i < 84) || i >= 160 && i < 180)
                {
                    slotList.Add(new Slot(u0, i, true));

                }
                else
                {

                slotList.Add(new Slot(u0, i, false));
                }
            }
            for (int j = 0; j < 240; j++)
            {
                if (j % 3 == 0)
                {
                    slotList.Add(new Slot(u1, j, true));

                }
                else
                {
                slotList.Add(new Slot(u1, j, false));

                }
            }

            foreach (Slot slots in slotList)
            {
                context.Slot.Add(slots);
            }

         
            await context.SaveChangesAsync();

        }
        public async Task IntializeEnrollments(ApplicationDbContext context)
        {
            string[,] seedEnroll;
            using (var reader = new StreamReader(@"wwwroot\uploads\temp.csv"))
            {
                    var line = reader.ReadLine();
                    var headers = line.Split(',');
                    seedEnroll = new string[headers.Length, 14];
                for (int i = 0; i < seedEnroll.GetLength(0); i++)
                {
                    seedEnroll[i,0] = headers[i];
                }
                    int count = 1;
                while (!reader.EndOfStream)
                {
                    
                    line = reader.ReadLine();
                    headers = line.Split(',');
                    for(int i = 0; i < headers.Length; i++)
                    {
                        seedEnroll[i,count] = headers[i];
                    }
                    count++;
                }
            }

            for(int i = 1; i < seedEnroll.GetLength(1); i++)
            {
                int space = seedEnroll[0, i].IndexOf(" ");

                int courseNum=  int.Parse(seedEnroll[0, i].Substring(space, seedEnroll[0,i].Length-space));
                string courseDep = seedEnroll[0, i].Substring(0, 2);
                var courseList = context.Course.Where(o => o.courseNumber == courseNum && o.department == courseDep).ToArray();
                for(int j = 1; j < seedEnroll.GetLength(0); j++)
                {
                    string dateStr = seedEnroll[j, 0] + ", 2022";
                    var parsedDate = DateTime.Parse(dateStr);
                    var c = courseList[0];
                    int enrolled = int.Parse(seedEnroll[j, i]);
                    context.Add(new Enrollment(c, parsedDate,enrolled ));
                }
            }
            await context.SaveChangesAsync();
  
           

            }
        public async Task IntializeCourses(UserManager<TAUser> um, ApplicationDbContext context)
        {
            var users = um.Users;
          

            var course1 = new Course();
            var course2 = new Course();
            var course3 = new Course();
            var course4 = new Course();
            var course5 = new Course();
            var course6 = new Course();
            var course7 = new Course();
            var course8 = new Course();
            var course9 = new Course();
            var course10 = new Course();
            var course11 = new Course();
            var course12 = new Course();
            var course13 = new Course();

            course1.semesterOffered = "Spring";
            course2.semesterOffered = "Spring";
            course3.semesterOffered = "Spring";
            course4.semesterOffered = "Spring";
            course5.semesterOffered = "Spring";
            course6.semesterOffered = "Spring";
            course7.semesterOffered = "Spring";
            course8.semesterOffered = "Spring";
            course9.semesterOffered = "Spring";
            course10.semesterOffered = "Spring";
            course11.semesterOffered = "Spring";
            course12.semesterOffered = "Spring";
            course13.semesterOffered = "Spring";


            course1.yearOffered = 2023;
            course2.yearOffered = 2023;
            course3.yearOffered = 2023;
            course4.yearOffered = 2023;
            course5.yearOffered = 2023;
            course6.yearOffered = 2023;
            course7.yearOffered = 2023;
            course8.yearOffered = 2023;
            course10.yearOffered = 2023;
            course12.yearOffered = 2023;
            course13.yearOffered = 2023;
            course9.yearOffered = 2023;
            course11.yearOffered = 2023;

            course1.title = "Intro Comp Programming";
            course1.department = "CS";
            course1.courseNumber = 1400;
            course1.section = 001;
            course1.description = "An intro to programming";
            course1.professorUID = "u7654321";
            course1.professorName = "uofu professor";
            course1.dayAndTimeOffered = "MoWe/01:25PM-02:45PM";
            course1.location = "S BEH AUD";
            course1.creditHours = 4;
            course1.enrollment = 160;
            course1.Note = "We need 5 TAs";

            course2.title = "Discrete Structures";
            course2.department = "CS";
            course2.courseNumber = 2100;
            course2.section = 001;
            course2.description = "Learn about discrete mathematics";
            course2.professorUID = "u7654321";
            course2.professorName = "uofu professor";
            course2.dayAndTimeOffered = "MoWe/08:05AM-09:25AM";
            course2.location = "WEB L104";
            course2.creditHours = 3;
            course2.enrollment = 120;
            course2.Note = "";

            course3.title = "Intro Alg & Data Structures";
            course3.department = "CS";
            course3.courseNumber = 2420;
            course3.section = 001;
            course3.description = "Learn about intro algorithms and data structures";
            course3.professorUID = "u7654321";
            course3.professorName = "uofu professor";
            course3.dayAndTimeOffered = "TuTh/12:25PM-01:45PM";
            course3.location = "S BEH AUD";
            course3.creditHours = 4;
            course3.enrollment = 160;
            course3.Note = "";

            course4.title = "Models of Computation";
            course4.department = "CS";
            course4.courseNumber = 3100;
            course4.section = 001;
            course4.description = "Learn about models of computation";
            course4.professorUID = "u7654321";
            course4.professorName = "uofu professor";
            course4.dayAndTimeOffered = "MoWe/01:25PM-02:45PM";
            course4.location = "GC 2950";
            course4.creditHours = 3;
            course4.enrollment = 140;
            course4.Note = "";

            course5.title = "Computer Systems";
            course5.department = "CS";
            course5.courseNumber = 4400;
            course5.section = 001;
            course5.description = "Learn about computer systems";
            course5.professorUID = "u7654321";
            course5.professorName = "uofu professor";
            course5.dayAndTimeOffered = "MoWe/11:50AM-01:10PM";
            course5.location = "HEB 2004";
            course5.creditHours = 3;
            course5.enrollment = 150;
            course5.Note = "Course needs 4 more TAs";

            course6.title = "Object Programming";
            course6.department = "CS";
            course6.courseNumber = 1410;

            course7.title = "Advanced Object Oriented Programming";
            course7.department = "CS";
            course7.courseNumber = 1420;

            course8.title = "Computer";
            course8.department = "CS";
            course8.courseNumber = 3200;

            course9.title = "Software Engineering 2";
            course9.department = "CS";
            course9.courseNumber = 3500;


            course10.title = "Algorithms";
            course10.department = "CS";
            course10.courseNumber = 4150;

            course11.title = "Computer Security";
            course11.department = "CS";
            course11.courseNumber = 4480;

            course12.title = "Captsone Design";
            course12.department = "CS";
            course12.courseNumber = 4500;

            course13.title = "Database Systems";
            course13.department = "CS";
            course13.courseNumber = 4530;

            context.Course.Add(course1);
            context.Course.Add(course2);
            context.Course.Add(course3);
            context.Course.Add(course4);
            context.Course.Add(course5);
            context.Course.Add(course6);
            context.Course.Add(course7);
                
            context.Course.Add(course8);
            context.Course.Add(course9);
            context.Course.Add(course10);
            context.Course.Add(course11);
            context.Course.Add(course12);
            context.Course.Add(course13);

 

            await context.SaveChangesAsync();
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
        /// <summary>
        /// JIM: this code adds time/user to DB entry
        /// 
        /// Check the DB tracker to see what has been modified, and add timestamps/names as appropriate.
        /// 
        /// </summary>
        public DbSet<TAApplication.Models.Course> Course { get; set; }
        /// <summary>
        /// JIM: this code adds time/user to DB entry
        /// 
        /// Check the DB tracker to see what has been modified, and add timestamps/names as appropriate.
        /// 
        /// </summary>
        public DbSet<TAApplication.Models.Slot> Slot { get; set; }
        /// <summary>
        /// JIM: this code adds time/user to DB entry
        /// 
        /// Check the DB tracker to see what has been modified, and add timestamps/names as appropriate.
        /// 
        /// </summary>
        public DbSet<TAApplication.Models.Enrollment> Enrollment { get; set; }
    }
}