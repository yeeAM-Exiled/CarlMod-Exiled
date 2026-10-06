using Newtonsoft.Json;

namespace _n4361726c6672656c6c6574742e47616d65706c61790;

public sealed class BadgeTitleRecord
{
	[JsonProperty("title")]
	public string Title { get; set; }

	[JsonProperty("type")]
	public BadgeTitleType Type { get; set; }

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Color { get; set; }
}
