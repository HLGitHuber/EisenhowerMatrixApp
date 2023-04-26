using System;
using System.Collections.Generic;

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
    }

}