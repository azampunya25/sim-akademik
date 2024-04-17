using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using SIMA.Universitas.Application.Interfaces.Repositories;
using SIMA.Universitas.Domain.Entities.Catalog;
using SIMA.Universitas.Infrastructure.CacheKeys;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMA.Universitas.Infrastructure.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IRepositoryAsync<Brand> _repository;
        private readonly IDistributedCache _distributedCache;

        public BrandRepository(IDistributedCache distributedCache, IRepositoryAsync<Brand> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<Brand> Brands => _repository.Entities;

        public async Task DeleteAsync(Brand brand)
        {
            await _repository.DeleteAsync(brand);
            await _distributedCache.RemoveAsync(BrandCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(BrandCacheKeys.GetKey(brand.Id));
        }

        public async Task<Brand> GetByIdAsync(int brandId)
        {
            return await _repository.Entities.Where(p => p.Id == brandId).FirstOrDefaultAsync();
        }

        public async Task<List<Brand>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(Brand brand)
        {
            await _repository.AddAsync(brand);
            await _distributedCache.RemoveAsync(BrandCacheKeys.ListKey);
            return brand.Id;
        }

        public async Task UpdateAsync(Brand brand)
        {
            await _repository.UpdateAsync(brand);
            await _distributedCache.RemoveAsync(BrandCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(BrandCacheKeys.GetKey(brand.Id));
        }
    }
}