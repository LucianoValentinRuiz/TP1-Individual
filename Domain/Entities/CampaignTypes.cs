﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CampaignTypes
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Projects> Projects { get; set; }
    }
}
