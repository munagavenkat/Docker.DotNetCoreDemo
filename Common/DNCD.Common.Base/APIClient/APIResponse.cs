using System;

namespace DNCD.Common.Base.APIClient
{
    public class APIResponse
    {
        public bool IsSuccessful { get; set; }
        public string Result { get; set; }
        public Exception ErrorException { get; set; }
    }
}
