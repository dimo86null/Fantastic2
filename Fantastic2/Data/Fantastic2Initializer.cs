﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Fantastic2.Models;

namespace Fantastic2.Data
{
    public class Fantastic2Initializer: DropCreateDatabaseAlways<Fantastic2Context>
    {
        protected override void Seed(Fantastic2Context context)
        {

        }
    }
}