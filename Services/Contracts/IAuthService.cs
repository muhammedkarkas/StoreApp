﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IAuthService
    {
        //Sistem içerisindeki roller bir liste olarak istendi
        IEnumerable<IdentityRole> Roles { get; }

    }
}
