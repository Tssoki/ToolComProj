using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public enum EPriority
{
    LOW,
    MEDIUM,
    HIGH
}

public enum EStatus
{
    UNPROCESSED,
    IN_PROGRESS,
    COMPLETE
}

namespace ToolComProjet
{
    internal class Entry
    {
        public EPriority Priority { get; set; }
        public EStatus Status { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }


    }
}
