using System.Text.Json.Serialization;

namespace ThunderClient.CollectionToCurl
{
    public class Collection
    {
        [JsonPropertyName("filename")]
        public string FileName { get; set; }
        
        [JsonPropertyName("client")]
        public string Client { get; set; }

        [JsonPropertyName("collectionName")]
        public string CollectionName { get; set; }

        [JsonPropertyName("dateExported")]
        public DateTime DateExported { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("folders")]
        public object[] Folders { get; set; }

        [JsonPropertyName("requests")]
        public Request[] Requests { get; set; }
    }

    public class Request
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("colId")]
        public string ColId { get; set; }

        [JsonPropertyName("containerId")]
        public string ContainerId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("method")]
        public string Method { get; set; }

        [JsonPropertyName("sortNum")]
        public int SortNum { get; set; }

        [JsonPropertyName("created")]
        public DateTime Created { get; set; }

        [JsonPropertyName("modified")]
        public DateTime Modified { get; set; }

        [JsonPropertyName("headers")]
        public Header[] Headers { get; set; }

        [JsonPropertyName("_params")]
        public object[] Params { get; set; }

        [JsonPropertyName("body")]
        public Body Body { get; set; }

        [JsonPropertyName("auth")]
        public Auth Auth { get; set; }

        [JsonPropertyName("tests")]
        public object[] Tests { get; set; }
    }

    public class Body
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("raw")]
        public string Raw { get; set; }

        [JsonPropertyName("form")]
        public object[] Form { get; set; }
    }

    public class Auth
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("bearer")]
        public string Bearer { get; set; }
    }
    
    public class Header
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}