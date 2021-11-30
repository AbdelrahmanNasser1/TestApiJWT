﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApiJWT.Models;
using TestApiJWT.Services;

namespace TestApiJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result =  await _authService.RegisterAsync(model);

            if (result.IsAuthenticated ==false)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpPost("Token")]
        public async Task<IActionResult> createToken([FromBody] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result =  await _authService.GetTokenAsync(model);

            if (result.IsAuthenticated ==false)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [Authorize]
        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole([FromBody] RoleModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result =  await _authService.AddRoleAsync(model);

            if (!string.IsNullOrEmpty(result))
            {
                return BadRequest(result);
            }
            return Ok(model);
        }
    }
}
