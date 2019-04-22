
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aws_lambda_crt_db
{
    [Table("district")]
    public class DistrictModel
    {
        [Column("district_id")]
        public int DistrictId { get; set; }

        [Column("code")]
        public int Code { get; set; }

        [Column("title_tha")]
        public string TitleTha { get; set; }

        [Column("title_eng")]
        public string TitleEng { get; set; }

        [Column("province_id")]
        public int ProvinceId { get; set; }

    }

}
