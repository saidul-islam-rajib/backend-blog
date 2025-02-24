﻿namespace Sober.Contracts.Response.Authentication;

public record AuthenticationResponse(
    Guid Id,
    string Name,
    string Email,
    string Token);
