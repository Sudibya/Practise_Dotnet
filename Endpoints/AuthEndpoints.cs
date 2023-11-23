// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Practise_Dotnet.Entities;

// namespace Practise_Dotnet.Endpoints;

// [Route("api/UserMaster")]
// [ApiController]
// public class AuthEndpoints :ControllerBase
// {
       
//        const string AuthEndpointsName = "AuthEndpoints";

//        public static  RouteGroupBuilder MapUserEndpoints(this IEndpointRouteBuilder routes){

//             var group = routes.MapGroup("/Users").WithParameterValidation();

//             group.MapGet("/", async (IIGameRepository gameRepository) => (await gameRepository.GetAllAsync()).Select(game => game.AsDto()));
//        }
// }