using System;

namespace WB_APP.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
    public class Vegetables
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
