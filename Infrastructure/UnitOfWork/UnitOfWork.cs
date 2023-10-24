using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Interfaces.Inventory;
using Infrastructure.Data;
using Infrastructure.Repositories.Inventory;

namespace Infrastructure.UnitOfWork;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly PharmaInventContext _context;
         private CInvenMangRepo _invenMana;
    
        public UnitOfWork(PharmaInventContext context)
        {
            _context = context;
        }
    
        public IInventoryManagement Auditors
        {
            get
            {
                if (_invenMana == null)
                {
                    _invenMana = new CInvenMangRepo(_context);
                }
                return _invenMana;
            }
        }
    
        public void Dispose()
        {
            _context.Dispose();
        }
    
        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }