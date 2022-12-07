using System;
using System.Collections.Generic;
using System.Text;

namespace AMM_LAB_v1_S15_16.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsNew { get; set; }
        public int Stock { get; set; }

    }
}
