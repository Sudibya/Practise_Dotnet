using System.Reflection;
using GameStore.API.Dtos;


namespace GameStore.API.Entities;

public static class EntityExtensions
{
    public static GameDto AsDto(this Game game)
    {
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

    public static ModuleMasterDto AsDto(this ModuleMaster module)
    {
        return new ModuleMasterDto
        (
                module.ModuleID,
                module.ModuleName
        
        );
    }

    public static ProgramMasterDto AsDto(this ProgramMaster program)
{
    if (program == null)
    {
        throw new ArgumentNullException(nameof(program), "ProgramMaster cannot be null");
    }

    // Check if ModuleMaster is null before calling AsDto
    ModuleMasterDto moduleMasterDto = program.ModuleMaster != null ? program.ModuleMaster.AsDto() : null;

    return new ProgramMasterDto
    (
        program.ProgramID,
        program.ProgramName,
        program.ModuleID,
        moduleMasterDto, // Use the safe variable instead of calling AsDto directly
        program.ModuleName,
        program.Active,
        program.ActiveDate,
        program.DeactiveDate,
        program.ProgramHeader
        // Additional properties as needed
    );
}

    

}