using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetSample
{
    /*
     SELECT TOP (1000) [Id]
      ,[FirstName]
      ,[LastName]
      ,[BirthDate]
  FROM [AdoNetSample].[dbo].[Person]
     */
    internal struct Person
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateTime BirthDate { get; set; }
        public string Description { get; set; }
    }
}
