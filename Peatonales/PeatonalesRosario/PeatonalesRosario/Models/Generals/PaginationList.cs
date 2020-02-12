using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio.Models.Generals
{
    public class PaginationList<T>
    {
        public Int32 total { get; set; }
        public List<T> mylist;
        public PaginationList(List<T> _mylist,Int32 _total)
        {
            mylist = _mylist;
            total = _total;
        }
    }
}