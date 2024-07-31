﻿using Domain.Models;
using Infraestructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Services
{
    public class InvoicesService
    {
        private readonly CodigoContext _context;

        public InvoicesService(CodigoContext context)
        {
            _context = context;
        }

        public List<Invoice> GetByFilters(string? number)
        {
            IQueryable<Invoice> query = _context.Invoices.Where(x => x.IsActive);

            if (!string.IsNullOrEmpty(number))
                query = query.Where(x => x.Number.Contains(number));

            return query.Include(x => x.Customer).ToList();
        }

        public void Insert(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            _context.SaveChanges();
        }
    }
}