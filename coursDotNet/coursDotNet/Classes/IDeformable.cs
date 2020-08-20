using System;
using System.Collections.Generic;
using System.Text;

namespace coursDotNet.Classes
{
    interface IDeformable
    {
        Figure Deformation(double coeffH, double coeffV);
    }
}
