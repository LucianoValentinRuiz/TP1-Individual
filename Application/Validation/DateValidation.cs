﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validation
{
    public class DateValidation
    {
        public bool IsValid(DateTime start, DateTime end)
        {
            return start < end;
        }
    }
}
