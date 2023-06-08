﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Core
{
    public class JwtActor
    {
        public int Id { get; set; }
        public string Identity { get; set; }
        public IEnumerable<int> AllowedUseCases { get; set; }
    }
}
