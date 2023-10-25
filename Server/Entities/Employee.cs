

using System;

namespace Server.Entities
{
    [Serializable]
   
        public class Employee : IEntity
        {
            public string EmpName { get; }

            public Employee(string empname)
            {
                this.EmpName = empname;
            }
        }
}
    

