using Microsoft.EntityFrameworkCore;
using Task.Data;
using Task.Data.Entities;
using Task.Models;
using Task.Utilities;

namespace Task.Services
{
    public class ImportService : IImportService
    {
        private readonly ApplicationDbContext _context;
        public ImportService(ApplicationDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// return List of Imported Requests
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<ImportRequest> GetRequestList()
        {
            try
            {
                var requestList = _context.ImportRequests.ToList();
                return requestList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// create Import Request with Item Details
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool CreateRequest(ImportRequestResponseViewModel request)
        {
            try
            {
                ImportRequest model = new ImportRequest()
                {
                    ExportCity = request.ExportCity,
                    ExportCountry = request.ExportCountry,
                    ImportDate  = request.ImportDate,   
                    ImporterEmail = request.ImporterEmail,
                    ImporterMobile = request.ImporterMobile,
                    ImporterName = request.ImporterName,
                };
                var insertedItem = _context.ImportRequests.Add(model).Entity;
                _context.SaveChanges();
                foreach (var item in request.ItemsList)
                {
                var importItem = new ImportItem()
                {
                    RequestId=insertedItem.Id,
                    Count=item.Count,
                    ItemId=item.Id,
                };
                 _context.ImportItems.Add(importItem);

                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
         
        /// <summary>
        /// return Item List
        /// </summary>
        /// <returns></returns>
        public List<ItemViewModel> getItemsList()
        {
            return _context.Items.Select(x => new ItemViewModel
            {
                Id = x.Id,
                Name = x.Name,
                TypeId = x.TypeId,
            }).ToList();
        }

        /// <summary>
        /// Get Request With details by importrequestId
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>ImportRequestResponseViewModel</returns>
        public ImportRequestResponseViewModel GetRequestForView(int Id)
        {
            return _context.ImportRequests.Include(x=>x.ImportItems)
                .ThenInclude(x=>x.Items)
                .Where(x=>x.Id==Id)
                .Select(x => new ImportRequestResponseViewModel
            {
                ExportCity = x.ExportCity,
                ExportCountry = x.ExportCountry,
                ImportDate=x.ImportDate,
                Id = Id,
                ImporterEmail = x.ImporterEmail,
                ImporterMobile = x.ImporterMobile,
                ImporterName = x.ImporterName,
                ItemsList = x.ImportItems.Select(x => new ItemViewModel
                {
                    Name=x.Items.Name,
                    Count=x.Count
                    }).ToList()
            }).FirstOrDefault();
        }
    }
}
