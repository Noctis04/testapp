using OwnerService.Domain;
using OwnerService.Infrastructure.Context;

namespace OwnerService.Infrastructure.Managers;

/// <summary>
///     Реализация интерфейса <see cref="IOwnerManager"/>
/// </summary>
public class OwnerManager : IOwnerManager
{
    private readonly OwnerContext _context;

    /// <inheritdoc cref="IOwnerManager" />
    public OwnerManager(OwnerContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public List<Owner> GetAll()
    {
        return _context.Owners.ToList();
    }

    /// <inheritdoc />
    public Owner? GetById(long id)
    {
        return _context.Owners.FirstOrDefault(x => x.Id == id);
    }

    /// <inheritdoc />
    public Owner Create(Owner owner)
    {
        var entry = _context.Add(owner);
        _context.SaveChanges();
        return entry.Entity;
    }

    /// <inheritdoc />
    public Owner? Update(Owner Owner)
    {
        var existingOwner = _context.Owners.FirstOrDefault(x => x.Id == Owner.Id);
        if (existingOwner is null)
        {
            return null;
        }

        existingOwner.Login = Owner.Login;
        existingOwner.Password = Owner.Password;
        existingOwner.Name = Owner.Name;

        var entry = _context.Update(Owner);
        _context.SaveChanges();
        return entry.Entity;
    }

    /// <inheritdoc />
    public Owner? Delete(long id)
    {
        var existingOwner = _context.Owners.FirstOrDefault(x => x.Id == id);
        if (existingOwner is null)
        {
            return null;
        }

        var entry = _context.Remove(existingOwner);
        _context.SaveChanges();
        return entry.Entity;
    }
}
