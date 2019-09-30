using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Enums
{
    public static class EnumHelper<T>
    {
        //Returns the string value from the given enum.
        public static string GetRole(T role)
        {
            string[] roles = Enum.GetNames(typeof(T));

            if (role != null)
            {
                foreach (var item in roles)
                {
                    if (string.Compare(item, role.ToString()) == 0)
                    {
                        return item;
                    }
                }
            }
            return null;
        }
    }
}
