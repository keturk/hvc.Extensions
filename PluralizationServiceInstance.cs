using System.Globalization;
using PluralizationService;
using PluralizationService.English;

namespace hvc.Extensions;

public static class PluralizationServiceInstance
{
    private static readonly IPluralizationApi Api;
    private static readonly CultureInfo CultureInfo;

    static PluralizationServiceInstance()
    {
        var builder = new PluralizationApiBuilder();
        builder.AddEnglishProvider();

        Api = builder.Build();
        CultureInfo = new CultureInfo("en-US");
    }

    public static Boolean IsSingular(this String name)
    {
        return !String.IsNullOrWhiteSpace(name) && Api.IsSingular(name);
    }

    public static String ToPlural(this String value)
    {
        return Api.Pluralize(value, CultureInfo);
    }

    public static String ToSingular(this String value)
    {
        return Api.Singularize(value, CultureInfo);
    }
}