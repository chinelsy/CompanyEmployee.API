﻿using AutoMapper;
using CompanyEmployee.API.ActionFilters;
using CompanyEmployee.Entities.Models;
using CompanyEmployee.Entities.Models.DTOS;
using CompanyEmployee.LoggerService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CompanyEmployee.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper; 
        private readonly UserManager<User> _userManager;

        public AuthenticationController(ILoggerManager logger, IMapper mapper, UserManager<User> userManager)
        { 
            _logger = logger; 
            _mapper = mapper; 
            _userManager = userManager; 
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            var user = _mapper.Map<User>(userForRegistration);

            var result = await _userManager.CreateAsync(user, userForRegistration.Password); 
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                { 
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            await _userManager.AddToRolesAsync(user, userForRegistration.Roles);

            return StatusCode(201);
        }
    }
}
