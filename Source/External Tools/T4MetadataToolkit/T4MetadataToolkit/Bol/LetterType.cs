using System;

namespace T4MetadataToolkit.Bol
{
    [Flags]
    public enum LetterType
    {
        None = 0,
        Numeral = 1,
        PersianLetter = 2,
        EnglishLetter = 4
    }
}
