using System.Text.Json;
using System.Text.Json.Serialization;

namespace MotoMaintenance.Api.Common.Converters;
public sealed class EmptyStringGuidConverter : JsonConverter<Guid>
{
    public override Guid Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var raw = reader.GetString();
            if (string.IsNullOrWhiteSpace(raw))
                return Guid.Empty;

            if (Guid.TryParse(raw, out var guid))
                return guid;

            throw new JsonException($"The value '{raw}' is not a valid GUID.");
        }

        if (reader.TokenType == JsonTokenType.Null)
            return Guid.Empty;

        throw new JsonException("Expected a string for GUID property.");
    }

    public override void Write(Utf8JsonWriter writer, Guid value, JsonSerializerOptions options)
        => writer.WriteStringValue(value);
}