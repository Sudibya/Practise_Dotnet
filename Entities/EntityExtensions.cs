using GameStore.API.Dtos;
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
}