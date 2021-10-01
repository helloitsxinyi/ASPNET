using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutingWshp.Models
{
   public class Person
   {
      public string Name { get; set; }
      public int Age { get; set; }

      public override string ToString()
      {
         return string.Format("{0}, Age {1}", Name, Age);
      }
   }
}
