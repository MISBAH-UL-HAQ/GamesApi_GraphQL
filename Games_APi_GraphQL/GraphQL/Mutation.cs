using Games_APi_GraphQL.Model;
using Games_APi_GraphQL.Data;

using Microsoft.EntityFrameworkCore;

namespace Games_APi_GraphQL.GraphQL
{
    public class Mutation
    {
        private readonly ApplicationDbContext _context;

        public Mutation(ApplicationDbContext context)
        {
            _context = context;
        }

        // Mutation to add a new game
        public async Task<Game> AddGame(string title, string genre, string developer)
        {
            var newGame = new Game { Title = title, Genre = genre, Developer = developer };
            _context.Games.Add(newGame);
            await _context.SaveChangesAsync();
            return newGame;
        }

        // Mutation to update an existing game
        public async Task<Game> UpdateGame(int id, string title, string genre, string developer)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);
            if (game == null) return null;

            game.Title = title;
            game.Genre = genre;
            game.Developer = developer;

            _context.Games.Update(game);
            await _context.SaveChangesAsync();

            return game;
        }

        // Mutation to delete a game
        public async Task<bool> DeleteGame(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null) return false;

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
