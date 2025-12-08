using DomeGym.Application.Profiles.Commands.CreateProfile;
using DomeGym.Application.Profiles.Queries.GetProfile;
using DomeGym.Application.Profiles.Queries.ListProfilesQuery;
using DomeGym.Contracts.Profiles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DomeGym.Api.Controllers;

[Route("users/{userId:guid}/profiles")]
public class ProfilesController(ISender sender) : ApiController {
    [EndpointSummary("Create a profile for a user.")]
    [HttpPost]
    public async Task<IActionResult> CreateProfileAsync(CreateProfileRequest request, Guid userId) {
        if (!Domain.Profiles.ProfileType.TryFromName(request.ProfileType.ToString(), out var profileType))
            return Problem("Invalid profile type", statusCode: StatusCodes.Status400BadRequest);

        var command = new CreateProfileCommand(profileType, userId);

        var createProfileResult = await sender.Send(command);

        return createProfileResult.Match(
            id => CreatedAtAction(
                nameof(GetProfileAsync),
                new { userId, profileTypeString = request.ProfileType.ToString() },
                new ProfileResponse(id, request.ProfileType)),
            Problem);
    }

    [EndpointSummary("List profiles for a user.")]
    [HttpGet]
    public async Task<IActionResult> ListProfilesAsync(Guid userId) {
        var listProfilesQuery = new ListProfilesQuery(userId);

        var listProfilesResult = await sender.Send(listProfilesQuery);

        return listProfilesResult.Match(
            profiles => Ok(profiles.ConvertAll(profile => new ProfileResponse(
                profile.Id,
                ToDto(profile.ProfileType)))),
            Problem);
    }

    [EndpointSummary("Get a specific profile for a user.")]
    [HttpGet("{profileTypeString}")]
    public async Task<IActionResult> GetProfileAsync(Guid userId, string profileTypeString) {
        if (!Domain.Profiles.ProfileType.TryFromName(profileTypeString, out var profileType))
            return Problem("Invalid profile type", statusCode: StatusCodes.Status400BadRequest);

        var query = new GetProfileQuery(userId, profileType);

        var getProfileResult = await sender.Send(query);

        return getProfileResult.Match(
            profile => profile is null
                ? Problem(statusCode: StatusCodes.Status404NotFound)
                : Ok(new ProfileResponse(profile.Id, ToDto(profile.ProfileType))),
            Problem);
    }

    private static ProfileType ToDto(Domain.Profiles.ProfileType profileType) {
        return profileType.Name switch {
            nameof(Domain.Profiles.ProfileType.Admin) => ProfileType.Admin,
            nameof(Domain.Profiles.ProfileType.Participant) => ProfileType.Participant,
            nameof(Domain.Profiles.ProfileType.Trainer) => ProfileType.Trainer,
            _ => throw new InvalidOperationException()
        };
    }
}
