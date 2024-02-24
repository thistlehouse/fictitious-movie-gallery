using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MovieGallery.Domain.Movies.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum MovieCategory
{
    Action,
    Adventure,
    Animation,
    Biography,
    Comedy,
    Crime,
    Documentary,
    Drama,
    Family,
    Fantasy,
    Fiction,
    History,
}