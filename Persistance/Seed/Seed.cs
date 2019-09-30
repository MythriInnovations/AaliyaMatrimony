using Domain.Enums;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Persistance
{
    public class Seed : ISeed
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        //private readonly ILogger _logger;

        public Seed(DataContext context,UserManager<User> userManager,RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
           // _logger = logger;
        }

        public bool CreateAdminUser()
        {
            try
            {
                var adminUser = new User
                {
                    UserName = "hiran",
                    Email = "hirankailas@gmail.com",
                    MobileNumber = "9497776923"
                };

                IdentityResult result = _userManager.CreateAsync(adminUser, "password").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(adminUser, EnumHelper<ERole>.GetRole(ERole.Admin));
                    return true;
                }
            }
            catch(Exception ex)
            {
               // _logger.Log(LogLevel.Error, ex.Message);
            }

            return false;
        }

        public bool CreateBasicRoles()
        {
            try
            {
                var roles = new List<IdentityRole>
                {
                    new IdentityRole{ Name = EnumHelper<ERole>.GetRole(ERole.Admin)},
                    new IdentityRole{ Name = EnumHelper<ERole>.GetRole(ERole.User)},
                };

                foreach(IdentityRole role in roles)
                {
                    _roleManager.CreateAsync(role).Wait();
                }
            }
            catch (Exception ex)
            {
                //_logger.Log(LogLevel.Error, ex.Message);
            }

            return false;
        }

        public void SeedCountries()
        {
            var countryData = System.IO.File.ReadAllText("Data/countries.json");
            var countries = JsonConvert.DeserializeObject<List<Country>>(countryData);

            foreach (var country in countries)
            {
                _context.Add(country);
            }
            _context.SaveChangesAsync().Wait();
        }
        public void SeedStates()
        {
            var stateData = System.IO.File.ReadAllText("Data/states.json");
            var states = JsonConvert.DeserializeObject<List<State>>(stateData);

            foreach (var state in states)
            {
                _context.Add(state);
            }
            _context.SaveChangesAsync().Wait();
        }

        public void SeedCities()
        {
            var cityData = System.IO.File.ReadAllText("Data/cities.json");
            var cities = JsonConvert.DeserializeObject<List<City>>(cityData);

            foreach (var city in cities)
            {
                _context.Add(city);
            }
            _context.SaveChangesAsync().Wait();
        }

        public void UpdateCountryIds()
        {
            List<State> states = _context.States.ToList();

            foreach (var item in states)
            {
                item.country_id = item.Country.id;
            }
            _context.SaveChangesAsync().Wait();
        }
    }
   
}
