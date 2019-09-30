using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance
{
    public interface ISeed
    {
        bool CreateBasicRoles();
        bool CreateAdminUser();
        void SeedCountries(); 
        void SeedStates();
        void SeedCities();
        void UpdateCountryIds();
    }
}
