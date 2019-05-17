using Jil;

namespace AqarPress.Core
{
    public static class JilOptions
    {
        public static Options Server =>
          new Options(
              dateFormat: DateTimeFormat.ISO8601,
              prettyPrint: true,
              excludeNulls: true,
              serializationNameFormat: SerializationNameFormat.CamelCase,
              includeInherited: true,
              unspecifiedDateTimeKindBehavior: UnspecifiedDateTimeKindBehavior.IsUTC
              );
    }
}