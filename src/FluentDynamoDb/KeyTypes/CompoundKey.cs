namespace FluentDynamoDb
{
    public class CompoundKey<THashKey, TRangeKey> 
    {
        public THashKey HashKey { get; set; }
        public TRangeKey RangeKey { get; set; }

        public CompoundKey(THashKey hashKey, TRangeKey rangeKey)
        {
            HashKey = hashKey;
            RangeKey = rangeKey;
        }
    }
}