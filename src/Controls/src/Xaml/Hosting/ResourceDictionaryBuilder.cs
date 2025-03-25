using System;

namespace Microsoft.Maui.Controls.Hosting;

public class ResourceDictionaryBuilder
{
    private readonly ResourceDictionary _dict = new();

    public void AddXaml(string xamlPath)
    {
        var resource = new ResourceDictionary
        {
            Source = new Uri($"resource://{xamlPath}", UriKind.RelativeOrAbsolute)
        };
        _dict.MergedDictionaries.Add(resource);
    }

    public void Add(string key, object value) => _dict.Add(key, value);

    public ResourceDictionary Build() => _dict;
}