using System;
using System.Collections.Generic;
using System.Linq;

namespace EisenhowerMain
{
    public class TodoMatrix {
        private Dictionary<string, TodoQuarter> TodoQuarters { get; set; }

        public TodoMatrix()
        {
            TodoQuarters = new Dictionary<string, TodoQuarter>()
            {
                { "IU", new TodoQuarter() },
                { "IN", new TodoQuarter() },
                { "NU", new TodoQuarter() },
                { "NN", new TodoQuarter() }
            };
        }

        public Dictionary<string, TodoQuarter> GetQuarters()
        {
            return TodoQuarters;
        }

        public TodoQuarter GetQuarter(string status)
        {
            return TodoQuarters[status];
        }
    }

}