namespace Evently.Api.Extensions;

internal static class ConfigurationExtensions {
    internal static void AddModuleConfiguration(this IConfigurationBuilder configurationBuilder, string[] modules) {
        foreach (string module in modules) {
            configurationBuilder.AddJsonFile($"module.{module}.json", reloadOnChange: true, optional: false);
            configurationBuilder.AddJsonFile($"module.{module}.Development.json", reloadOnChange: true, optional: true);
        }
    }
}
