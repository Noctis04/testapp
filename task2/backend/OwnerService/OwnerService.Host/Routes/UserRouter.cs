using Microsoft.AspNetCore.Identity;
using OwnerService.Domain;

namespace OwnerOfLibrary.Routes;

public static class OwnerRouter
{
    public static WebApplication AddOwnerRouter(this WebApplication application)
    {
        // Производим группировку логики.
        var userGroup = application.MapGroup("/api/users");

        userGroup.MapGet(pattern: "/", handler: GetAllOwners);
        userGroup.MapGet(pattern: "/{id:long}", handler: GetOwnerById);
        userGroup.MapPost(pattern: "/", handler: CreateOwner);
        userGroup.MapPut(pattern: "/", handler: UpdateOwner);
        userGroup.MapDelete(pattern: "/{id:long}", handler: DeleteOwner);

        return application;
    }
    /// <summary>
    ///     Получить всех пользователей
    /// </summary>
    /// <returns>Список всех пользователей</returns>
    private static IResult GetAllOwners(IOwnerManager ownerManager)
    {
        var owners = ownerManager.GetAll();
        return Results.Ok(owners);
    }
    /// <summary>
    ///     Получить пользователя по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор искомого пользователя</param>
    /// <param name="ownerManager"><see cref="IOwnerManager"/></param>
    /// <returns>Данные искомого пользователя</returns>
    private static IResult GetOwnerById(long id, IOwnerManager ownerManager)
    {
        var owner = ownerManager.GetById(id);
        return owner is null
            ? Results.NotFound()
            : Results.Ok(owner);
    }
    /// <summary>
    ///    Добавить пользователя в систему
    /// </summary>
    /// <param name="owner">Идентификатор искомого пользователя</param>
    /// <param name="ownerManager"><see cref="IOwnerManager"/></param>
    /// <returns>Данные добавленного пользователя</returns>
    private static IResult CreateOwner(Owner owner, IOwnerManager ownerManager)
    {
        var createdOwner = ownerManager.Create(owner);
        return Results.Ok(createdOwner);
    }
    /// <summary>
    ///    Обновить данные пользователя в системе
    /// </summary>
    /// <param name="owner">Идентификатор искомого пользователя</param>
    /// <param name="ownerManager"><see cref="IOwnerManager"/></param>
    /// <returns>Данные обновлённого пользователя</returns>
    private static IResult UpdateOwner(Owner owner, IOwnerManager ownerManager)
    {
        var updateOwner = ownerManager.Update(owner);
        return updateOwner is null
            ? Results.NotFound()
            : Results.Ok(owner);
    }
    /// <summary>
    ///     Удалить данные пользователя из системы
    /// </summary>
    /// <param name="id">Идентификатор искомого пользователя</param>
    /// <param name="ownerManager"><see cref="IOwnerManager"/></param>
    /// <returns>Данные удалённого пользователя</returns>
    private static IResult DeleteOwner(long id, IOwnerManager ownerManager)
    {
        var deletedOwner = ownerManager.Delete(id);
        return deletedOwner is null
            ? Results.NotFound()
            : Results.Ok(deletedOwner);
    }
    public static WebApplication AddBookRouter(this WebApplication application)
    {
        return application;
    }
}