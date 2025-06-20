using System.Text.RegularExpressions;

namespace HexagonalTemplate.Adapters.WebApi.Transformers;

public class SlugyParamatersTransformer: IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
        => Regex.Replace(value?.ToString() ?? string.Empty, "([a-z])([A-Z])", "$1-$2").ToLowerInvariant();
}