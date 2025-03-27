
using Games_APi_GraphQL.Data;
using Games_APi_GraphQL.Model;
using Microsoft.EntityFrameworkCore;


namespace Games_APi_GraphQL.GraphQL
{
    public class Query
    {
        private readonly ApplicationDbContext _context;

        public Query(ApplicationDbContext context)
        {
            _context = context;
        }

        // GraphQL query to get all games
        public async Task<List<Game>> Games() =>
            await _context.Games.ToListAsync();
    }
}
