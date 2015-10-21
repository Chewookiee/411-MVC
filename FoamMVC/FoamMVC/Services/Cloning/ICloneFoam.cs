using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoamMVC.Services.Cloning
{
    public interface ICloneFoam
    {
        object ShallowCopy();
        object DeepCopy();
    }
}