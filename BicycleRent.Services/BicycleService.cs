using BicycleRent.Core;
using BicycleRent.Core.Models;
using BicycleRent.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BicycleRent.Services
{
    public class BicycleService : IBicycleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BicycleService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Bicycle> CreateBicycleAsync(Bicycle newBicycle)
        {
            await _unitOfWork.Bicycles
                .AddAsync(newBicycle);
            await _unitOfWork
                .CommitAsync();
            return newBicycle;
        }

        public async Task DeleteBicycleAsync(Bicycle bicycle)
        {
            _unitOfWork.Bicycles.Remove(bicycle);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Bicycle>> GetAllBicyclesAsync()
        {
            return await _unitOfWork.Bicycles
                .GetAllAsync();
        }



        public async Task<Bicycle> GetBicycleByIdAsync(double id)
        {
            return await _unitOfWork.Bicycles
                .GetBicycleByIdAsync(id);
        }


        public async Task UpdateBicycle(Bicycle bicycleToBeUpdated, Bicycle bicycle)
        {
            if (bicycle.BicycleBrand != 0)
            {
                bicycleToBeUpdated.BicycleBrand = bicycle.BicycleBrand;
            }
            if (bicycle.PricePerDay != 0)
            {
                bicycleToBeUpdated.PricePerDay = bicycle.PricePerDay;
            }
            if (bicycle.BicycleSize != 0)
            {
                bicycleToBeUpdated.BicycleSize = bicycle.BicycleSize;
            }

            await _unitOfWork.CommitAsync();
        }
    }
}
