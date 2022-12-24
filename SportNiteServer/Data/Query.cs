using System.Security.Claims;
using SportNiteServer.Database;
using SportNiteServer.Dto;
using SportNiteServer.Entities;
using SportNiteServer.Services;

namespace SportNiteServer.Data;

public class Query
{
    public string version() => "1.0.0";

    public async Task<User> Me(ClaimsPrincipal claimsPrincipal, AuthService authService)
    {
        return await authService.GetUser(Utils.GetFirebaseUserId(claimsPrincipal));
    }

    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public async Task<IEnumerable<Offer>> MyOffers(ClaimsPrincipal claimsPrincipal, AuthService authService,
        OfferService offerService)
    {
        return await offerService.GetMyOffers(await authService.GetUser(Utils.GetFirebaseUserId(claimsPrincipal)));
    }

    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public async Task<IEnumerable<Response>> GetMyResponses(ClaimsPrincipal claimsPrincipal,
        ResponseService responseService, AuthService authService)
    {
        return await responseService.GetMyResponses(
            await authService.GetUser(Utils.GetFirebaseUserId(claimsPrincipal)));
    }

    public async Task<List<Weather>> GetForecast(DateTime startDay, double latitude, double longitude,
        WeatherService weatherService)
    {
        return await weatherService.GetForecast(startDay, latitude, longitude);
    }


    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public async Task<IEnumerable<User?>> GetUsers(AuthService authService)
    {
        return await authService.GetUsers();
    }


    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public async Task<IEnumerable<Offer?>> GetOffers(OfferService offerService)
    {
        return await offerService.GetOffers();
    }

    public async Task<List<Place>> GetPlaces(PlaceQueryFilter filter, PlaceService placeService)
    {
        return await placeService.GetPlaces(filter);
    }

    
    [UseFiltering]
    [UseSorting]
    public async Task<IEnumerable<Offer>> IncomingOffers(ClaimsPrincipal claimsPrincipal, AuthService authService,
        OfferService offerService)
    {
        return await offerService.GetIncomingOffers(
            await authService.GetUser(Utils.GetFirebaseUserId(claimsPrincipal)));
    }
}