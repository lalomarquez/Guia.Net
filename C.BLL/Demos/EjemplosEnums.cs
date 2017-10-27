using System;

namespace C.BLL.Demos
{
    public enum OperatingSystems
    {
        Windows = 1,
        Mac = 2,
        Linux = 4,
        Other = 8
    }

    [Flags]
    public enum DaysOfWeek
    {
        Sun = 1,
        Mon = 2,
        Tue = 4,
        Wed = 8,
        Thu = 16,
        Fri = 32,
        Sat = 64
    }
}