using System.Collections;
using System.Collections.Generic;

namespace API.Errors
{
    public class ApiValidationErrorResponsec : ApiResponse
    {
        public ApiValidationErrorResponsec() : base(400)
        {
        }

        public IEnumerable<string>  Errors { get; set; }
    }
}
