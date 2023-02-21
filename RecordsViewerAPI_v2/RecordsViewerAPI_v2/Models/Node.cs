using System;
using System.Collections.Generic;

namespace RecordsViewerAPI_v2.Models;

public partial class Node
{
    public int NodeId { get; set; }

    public int ParentNodeId { get; set; }

    public int Type { get; set; }

    public string Name { get; set; } = null!;

    public string? Country { get; set; }

    public string? DateOfBirth { get; set; }
}
