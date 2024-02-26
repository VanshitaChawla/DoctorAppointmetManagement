﻿using Microsoft.AspNetCore.Identity;
using System;
using DoctorAppointmentManagement.Constants;

namespace DoctorAppointmentManagement.Data
{
    public static class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
        {
           var userManager=service.GetService<UserManager<ApplicationUser>>();
            var roleManager=service.GetService<RoleManager<IdentityRole>>();
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Doctors.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Patient.ToString()));
            var user = new ApplicationUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                Name = "Admin  ",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var userInDb = await userManager.FindByEmailAsync(user.Email);
            if (userInDb == null)
            {
                await userManager.CreateAsync(user, "Admin@123");
                await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
            }
        }

    }
}
