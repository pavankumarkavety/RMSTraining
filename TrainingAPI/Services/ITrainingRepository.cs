using System.Threading.Tasks;
using TrainingAPI.Models;

namespace TrainingAPI.Services
{
    public interface ITrainingRepository
    {
        Task<bool> Add<T>(T entity) where T: class;

          Task<Training> GetTraining(int id);

          Task<bool> SaveAll();
    }
}