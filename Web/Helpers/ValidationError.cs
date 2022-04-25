using Newtonsoft.Json;

public class ValidationError
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; set; }

        public string Message { get; set; }
    }