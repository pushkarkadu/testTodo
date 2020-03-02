using System;
using System.Collections.Generic;
using System.Text;

namespace MyApplication
{
    public interface IConcurrencyStamp
    {
        string ConcurrencyStamp { get; set; }
    }
}
