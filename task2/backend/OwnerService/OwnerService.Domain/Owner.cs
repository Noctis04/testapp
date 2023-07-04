using System.ComponentModel.DataAnnotations;
namespace OwnerService.Domain;

public class Owner 
{
    [Key]
    public long Id { get; set; }

    /// <summary>
    ///     Логин пользователя
    /// </summary>
    public string Login { get; set; } = "";

    /// <summary>
    ///     Пароль пользователя
    /// </summary>
    public string Password { get; set; } = "";

    // <summary>
    ///     Имя пользователя
    /// </summary>
    public string Name { get; set; } = "";
}
