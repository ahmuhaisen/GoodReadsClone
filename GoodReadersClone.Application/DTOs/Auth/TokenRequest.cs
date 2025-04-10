﻿using System.ComponentModel.DataAnnotations;

namespace GoodReadsClone.Application.DTOs.Auth;

public class TokenRequest
{
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }

    [MinLength(6)]
    public required string Password { get; set; }
}
