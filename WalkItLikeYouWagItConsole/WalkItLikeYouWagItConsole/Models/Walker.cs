﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WalkItLikeYouWagItConsole.Models
{
    public class Walker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NeighborhoodId { get; set; }

        public Neighborhood Neighborhood { get; set; }
    }
}
