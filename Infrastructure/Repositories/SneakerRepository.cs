using Application.Interfaces;
using Azure.Core;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public class SneakerRepository : ISneakerRepository
{
    private readonly SneakerDbContext _context;

    public SneakerRepository(SneakerDbContext context)
    {
        _context = context;
    }

    public async Task<Sneaker> Add(Sneaker toCreate)
    {
        _context.Sneakers.Add(toCreate);
        await _context.SaveChangesAsync();

        return toCreate;
    }

    public async Task DeleteById(Guid sneakerId)
    {
        var sneaker = _context.Sneakers
            .FirstOrDefault(p => p.Id == sneakerId);

        if (sneaker is null) return;

        _context.Sneakers.Remove(sneaker);

        await _context.SaveChangesAsync();
    }

    public async Task<List<Sneaker>> GetAll()
    {
        return await _context.Sneakers.ToListAsync();
    }

    public List<Sneaker> GetAllPredicate(Func<Sneaker, bool> where, Func<Sneaker, object> order)
    {
        return _context.Sneakers
             .OrderBy(order)
             .Where(where)
             .ToList();
    }

    public async Task<Sneaker> GetById(Guid sneakerId)
    {
        return await _context.Sneakers.FirstOrDefaultAsync(p => p.Id == sneakerId);
    }

    public async Task<Sneaker> Update(Sneaker updatedSneaker)
    {
        var sneaker = await _context.Sneakers
            .FirstOrDefaultAsync(p => p.Id == updatedSneaker.Id);

        sneaker.Name = updatedSneaker.Name;
        sneaker.Brand = updatedSneaker.Brand;
        sneaker.Size = updatedSneaker.Size;
        sneaker.Price = updatedSneaker.Price;
        sneaker.Year = updatedSneaker.Year;
        sneaker.Rating = updatedSneaker.Rating;

        await _context.SaveChangesAsync();

        return sneaker;
    }

}
