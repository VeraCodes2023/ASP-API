using System.Text.Json.Serialization;

namespace API.Models
{
    [JsonConverter(typeof (JsonStringEnumConverter))]
    public enum Role
    {
        Admin,
        Customer
    }
}