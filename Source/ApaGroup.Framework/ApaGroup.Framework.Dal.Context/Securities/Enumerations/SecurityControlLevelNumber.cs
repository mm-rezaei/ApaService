
using System;

namespace ApaGroup.Framework.Dal.Context.Securities.Enumerations
{
    [Flags]
    public enum SecurityControlLevelNumber
    {
        Level1 = 1,
        Level2 = 2,
        Level3 = 4,
        Level4 = 8,
        Level5 = 16,
        Level6 = 32,
        Level7 = 64,
        Level8 = 128,
        Level9 = 256,
        Level10 = 512
    }
}
