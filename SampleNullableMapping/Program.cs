internal record SourceItem(int? SourceNumber, int SourceId);
internal record Source(SourceItem? Item);
internal record Target(int TargetNumber, int TargetId);

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName, ThrowOnPropertyMappingNullMismatch = true, ThrowOnMappingNullMismatch = true)]
[UseStaticMapper(typeof(WhenNull))]
internal partial class Mapper
{
    [MapProperty([nameof(Source.Item), nameof(Source.Item.SourceNumber)], nameof(Target.TargetNumber))]
    [MapProperty([nameof(Source.Item), nameof(Source.Item.SourceId)], nameof(Target.TargetId))]
    public partial Target ToTarget(Source source);
}

[Mapper]
internal static partial class WhenNull
{
    public static int Convert(int? value) => value ?? 0;
}