using System;

namespace Microsoft.Maui.Hosting;

public static class ResourceDictionariesMauiAppBuilderExtensoins
{
    public static MauiAppBuilder ConfigureResources(this MauiAppBuilder builder, Action<ResourceDictionaryBuilder> configure)
    {
        var builderInstance = new ResourceDictionaryBuilder();
        configure(builderInstance);

        var built = builderInstance.Build();
        foreach (var dict in built.MergedDictionaries)
            GlobalResources.Current.MergedDictionaries.Add(dict);

        foreach (var kvp in built)
            GlobalResources.Current.Add(kvp.Key, kvp.Value);

        return builder;
    }
}
