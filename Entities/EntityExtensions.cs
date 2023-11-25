using GameStore.API.Dtos;
using GameStore.API.Entities;


namespace GameStore.API.Entities;

public static class EntityExtensions
{
         public static GameDto AsDto(this Game game){
            return new GameDto(

                #region Endpoints call
                game.Id,
                game.Name,
                game.Genre,
                game.Price,
                game.ReleaseDate,
                game.ImageUrl
             
                #endregion
            );
         }

         public static UserMasterDto AsDto(this UserMaster user)
        {
            return new UserMasterDto
            (
                user.Id,
                user.UserName,
                user.Password,
                user.LoginId,
                user.DateOfActivation,
               user.EmployeeId
                // Additional properties as needed
            );
         }

}