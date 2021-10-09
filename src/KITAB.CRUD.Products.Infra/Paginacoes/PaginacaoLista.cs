using System;
using System.Collections.Generic;
using System.Linq;

namespace KITAB.CRUD.Products.Infra.Paginacoes
{
    public class PaginacaoLista<T> : List<T>
    {
        public PaginacaoDados PaginacaoDados { get; private set; }

        public PaginacaoLista(List<T> items, int count, int pageNumber, int pageSize)
        {
            PaginacaoDados = new PaginacaoDados
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize),
                HasPrevious = (pageNumber > 1)
            };

            PaginacaoDados.HasNext = (pageNumber < PaginacaoDados.TotalPages);
    
            AddRange(items);
        }
    
        public static PaginacaoLista<T> PaginarDados(List<T> source, int pageNumber, int pageSize)
        {
            int _count = source.Count();

            List<T> _items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
    
            return new PaginacaoLista<T>(_items, _count, pageNumber, pageSize);
        }
    }
}
