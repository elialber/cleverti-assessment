using System.Collections.Generic;

namespace Cleverti.Assessment.CrossCutting.Extensions.Models
{
    public class Page<T> : PageBase where T : class
    {
        public IList<T> Result { get; set; }

        public Page()
        {
            Result = new List<T>();
        }
    }
}
