

using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext context;
        public ContactRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Result<Guid>> AddAsync(Contact contact)
        {
            try
            {
                await context.Contacts.AddAsync(contact);
                await context.SaveChangesAsync();
                return Result<Guid>.Success(contact.Id);
            }
            catch (Exception ex)
            {
                return Result<Guid>.Failure(ex.InnerException.ToString());
            }

        }

        //public Task DeleteAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<Contact>> GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Contact> GetByIdAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task UpdateAsync(Contact contact)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
