﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApp.Models
{
    public class UserListViewModel
    {
        public bool HasPreviousPage
        {
            get;set;
        }

        public bool HasNextPage
        {
            get; set;
        }
        public int? CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public List<UserViewModel> Users { get; set; }
    }
}
