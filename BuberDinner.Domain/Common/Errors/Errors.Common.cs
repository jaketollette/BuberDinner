using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;
public static partial class Errors
{
    public static class Common
    {
        public static Error InvalidId => Error.Validation(
            code: "Common.InvalidId",
            description: "Supplied ID is invalid.");
    }
}
