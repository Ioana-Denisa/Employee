﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;
using BaseLibrary.DTOs;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IUserAccount accountInterface) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> CreateAsync(Register user)
        {
            if (user == null) { return BadRequest("Model is empty!"); }
            var result = await accountInterface.CreateAsync(user);
            return Ok(result);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> SignInAsync(Login user)
        {
            if (user == null) { return BadRequest("Model is empty!"); }
            var result = await accountInterface.SingInAsync(user);
            return Ok(result);
        }

        [HttpPost("Refresh-Token")]
        public async Task<IActionResult>RefreshTokenAsync(RefreshToken token)
        {
            if (token == null) return BadRequest("Model is empty");
            var result=await accountInterface.RefreshTokenAsync(token);
            return Ok(result);
        }


    }
}
