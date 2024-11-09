using Domain.Common;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ContactRepository : IGenericEntityRepository<Contact>
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
                return Result<Guid>.Failure(ex.InnerException!.ToString());
            }


        }

        public async Task<Result<Guid>> DeleteAsync(Guid id)
        {
            var contact = await context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return Result<Guid>.Failure("Contact not found");
            }
            context.Contacts.Remove(contact);
            await context.SaveChangesAsync();
            return Result<Guid>.Success(id);
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetByIdAsync(Guid id)
        {

            return await context.Contacts.FindAsync(id);
        }

        public async Task<Result<Guid>> UpdateAsync(Contact contact)
        {
            try
            {
                context.Entry(contact).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Result<Guid>.Success(contact.Id);
            }
            catch (Exception ex)
            {
                return Result<Guid>.Failure(ex.InnerException!.ToString());
            }


        }

    }
}