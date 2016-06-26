using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace URLShortener.Models.Responses
{ 
        /// <typeparam name="T"></typeparam>
        public class ItemResponse<T> : SuccessResponse
        {

            public T Item { get; set; }

        }
}