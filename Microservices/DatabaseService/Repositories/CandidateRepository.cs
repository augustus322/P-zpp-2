﻿using DatabaseService.Data;
using DatabaseService.Model;
using Microsoft.EntityFrameworkCore;

namespace DatabaseService.Repositories
{
    public class CandidateRepository : IRepository<Candidate>
    {
        private readonly HrDBContext _context;

        public CandidateRepository(HrDBContext context)
        {
            _context = context;
        }

        public void Add(Candidate entity)
        {
            _context.Add(entity);
        }

        public async Task DeleteAsync(int id)
        {
            Candidate entity = _context.Candidates.Find(id);
            if (entity != null)
            {
                _context.Candidates.Remove(entity);
            }
        }

        public IQueryable<Candidate> GetAll()
        {
            return _context.Candidates.AsQueryable();
        }

        public async Task<Candidate?> GetByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Candidate entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
