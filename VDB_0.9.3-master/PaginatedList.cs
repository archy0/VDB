using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VDB {
    public class PaginatedList<T> : List<T> {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public int ElementCount { get; private set; }
        public int PageSize { get; private set; }

        public bool HasPreviousPage {
            get {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage {
            get {
                return (PageIndex < TotalPages);
            }
        }
        

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize) {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            ElementCount = count;
            PageSize = pageSize;

            this.AddRange(items);
        }

        public static async Task<PaginatedList<T>> Create(List<T> source, int pageIndex, int pageSize) {
            int count = source.Count();
            //List<T> items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            List<T> items = await Task.FromResult(source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList());

            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
