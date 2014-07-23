using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuuFinder.Model
{
    class IssuuResponse
    {
        private Response _response;

        public Response Response
        {
            get { return _response; }
            set { _response = value; }
        } 
    }

    class Response
    {
        private int _start;

        public int Start
        {
            get { return _start; }
            set { _start = value; }
        }

        private int _numFound;

        public int NumFound
        {
            get { return _numFound; }
            set { _numFound = value; }
        }

        private List<IssuuDocument> _docs;

        public List<IssuuDocument> Docs
        {
            get { return _docs; }
            set { _docs = value; }
        }
    }
}
