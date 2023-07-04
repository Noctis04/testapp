

namespace OwnerService.Domain
{
    public interface IOwnerManager
    {
        /// <summary>
        ///     Вернуть список всех пользователей
        /// </summary>
        /// <returns>Список всех пользователей</returns>
        List<Owner> GetAll();

        /// <summary>
        ///     Получить пользователя по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Данные искомого пользователя</returns>
        Owner? GetById(long id);

        /// <summary>
        ///     Добавить пользователя в систему
        /// </summary>
        /// <param name="user">Данные добавляемого пользователя</param>
        /// <returns>Данные добавленного пользователя</returns>
        Owner Create(Owner user);

        /// <summary>
        ///     Обновить данные пользователя в системе
        /// </summary>
        /// <param name="user">Данные обновляемого пользователя</param>
        /// <returns>Данные обновленного пользователя</returns>
        Owner? Update(Owner user);

        /// <summary>
        ///     Удалить данные пользователя из системы
        /// </summary>
        /// <param name="id">Идентификатор обновляемого пользователя</param>
        /// <returns>Данные удаленного пользователя</returns>
        Owner? Delete(long id);
    }
}
