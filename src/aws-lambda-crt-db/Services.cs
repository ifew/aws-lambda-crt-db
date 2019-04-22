using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace aws_lambda_crt_db
{
    public class Services
    {
        private readonly DistrictContext _context;

        public Services(DistrictContext context)
        {
            _context = context;
        }

        public List<DistrictModel> List_district()
        {
            return _context.Districts.ToList();
        }
    }

}
