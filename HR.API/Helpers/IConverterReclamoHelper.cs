using HR.API.Data.Entities;
using HR.API.Models;

namespace HR.API.Helpers
{
    public interface IConverterReclamoHelper
    {
        Task<Reclamo> ToReclamoAsync(ReclamoViewModel model, bool isNew);
        ReclamoViewModel ToReclamoViewModel(Reclamo reclamo);

    }
}
