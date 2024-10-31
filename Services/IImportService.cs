using Task.Data.Entities;
using Task.Models;

namespace Task.Services
{
    public interface IImportService
    {
        List<ImportRequest> GetRequestList();
        bool CreateRequest(ImportRequestResponseViewModel request);
        List<ItemViewModel> getItemsList();
        ImportRequestResponseViewModel GetRequestForView(int Id);
    }
}
