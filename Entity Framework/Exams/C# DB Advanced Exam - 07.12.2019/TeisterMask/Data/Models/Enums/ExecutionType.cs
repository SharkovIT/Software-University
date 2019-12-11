using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.Data.Models.Enums
{
    public enum ExecutionType
    {
        ProductBacklog = 0,

        SprintBacklog = 1,

        InProgress = 2,

        Finished = 3
    }
}
