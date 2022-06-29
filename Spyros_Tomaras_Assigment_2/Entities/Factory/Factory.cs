using Entities.CustomValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Factory
{
    public static class Factory
    {

        public static Helper CreateHelper()
        {
            return new Helper();
        }
    }
}
