using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost.Helper
{
   
    public class Response
    {
        private readonly Dictionary<string, string> _store;

        public Response()
        {
            _store = new Dictionary<string, string>();
        }

        public string this[string key]
        {
            get => _store[key];
            set => _store[key] = value;
        }

        public Dictionary<string, string> Get()
        {
            return _store;
        }
    }
}
