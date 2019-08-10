using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainingAPI.Data;
using TrainingAPI.Models;

namespace TrainingAPI.Services
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly TrainingContext _context;
        public TrainingRepository(TrainingContext context)
        {
            _context = context;

        }
        public async Task<bool> Add<T>(T entity) where T : class
        {
            _context.Add(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Training> GetTraining(int id)
        {
             var training = await _context.Training.FirstOrDefaultAsync(t => t.Id == id);
            return training;
        }

        public async Task<bool> SaveAll()
        {
             return await _context.SaveChangesAsync() > 0;
        }
    }
}