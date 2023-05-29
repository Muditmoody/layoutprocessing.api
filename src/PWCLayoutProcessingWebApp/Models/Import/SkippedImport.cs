using Newtonsoft.Json;

namespace PWCLayoutProcessingWebApp.Models.Import
{
    public record SkippedImport<T>(string message, T items);
}
