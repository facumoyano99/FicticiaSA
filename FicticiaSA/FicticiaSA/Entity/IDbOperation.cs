using Microsoft.EntityFrameworkCore.Storage;

namespace FicticiaSA.Entity
{
    public interface IDbOperation
    {
        public Task<bool> Save();
        public bool SaveSync();
    }
}
