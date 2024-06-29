using EverydayIsArtAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EverydayIsArtAPI.Services
{
    /// <inheritdoc cref="IFavouritesService"/>
    public class FavouritesService : IFavouritesService
    {
        private readonly DatabaseContext _context;

        public FavouritesService(DatabaseContext contect)
        {
            _context = contect;
        }

        public async Task<bool> CreateFavouritesGroup(string userId, string title)
        {
            FavouritesGroup group = new()
            {
                UserId = userId,
                Title = title
            };

            try
            {
                await _context.FavouritesGroups.AddAsync(group);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> AddArt(Art art, int favouritesGroupId)
        {
            try
            {
                var favouritesGroup = await _context.FavouritesGroups.FindAsync(favouritesGroupId);
                if (favouritesGroup is null)
                {
                    return false;
                }

                var databaseArt = await _context.Arts.FirstOrDefaultAsync(e => e.SourceUrl == art.SourceUrl);
                if (databaseArt is null)
                {
                    await _context.Arts.AddAsync(art);
                    favouritesGroup.Items.Add(art);
                }
                else
                {
                    favouritesGroup.Items.Add(databaseArt);
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}