namespace BookingEngine.Application.ExternalService
{
    public interface ILanguageApiClient
    {
        Task<List<string>> GetActiveLanguageCodesAsync();
    }

}
