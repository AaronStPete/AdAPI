﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostingSite.ViewModels
{
    public class SearchParameters
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
       
    }
}