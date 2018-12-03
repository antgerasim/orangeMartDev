using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace orangeMartDev.Data
{
    [Owned]
    public class Name : ValueObject
    {
        public string First { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return First;
            yield return Middle;
            yield return Last;
        }
    }
}
