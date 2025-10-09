namespace SAP_Backend.Domain.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using SAP_Backend.Models;
    public class PetRepository : IDisposable
    {
        private PetContext _context;

        public PetRepository(PetContext context)
        {
            this._context = context;
        }

        public IEnumerable<Pet> GetPets()
        {
            return _context.Pets.ToList();
        }

        public Pet? GetStudentByName(string name)
        {
            return _context.Pets.Find(name);
        }

        public void InsertPet(Pet pet)
        {
            _context.Pets.Add(pet);
        }

        public void DeletePet(string name)
        {
            Pet? pet = _context.Pets.Find(name);
            if(pet != null)
            {
                _context.Pets.Remove(pet);
            }
        }

        public void UpdatePet(Pet pet)
        {
            _context.Entry(pet).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
