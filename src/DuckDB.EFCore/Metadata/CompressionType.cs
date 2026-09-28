namespace DuckDB.EFCore.Metadata;

public enum CompressionType
{
    AUTO = 0,

    UNCOMPRESSED = 1,

    CONSTANT = 2,

    RLE = 3,

    DICTIONARY = 4,

    PFOR_DELTA = 5,

    BITPACKING = 6,

    FSST = 7,

    CHIMP = 8,

    PATAS = 9,

    ALP = 10,

    ALPRD = 11,

    ZSDT = 12,

    ROARING = 13,

    EMPTY = 14,

    DICT_FSST = 15,

    COUNT
}
