﻿using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Domain.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error DeplicateEmail = Error.Conflict(code: "User.Duplicate Email", description: "Email is exists.");
        }
    }
}
