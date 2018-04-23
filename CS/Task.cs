using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication {
    public class Task {
        public string Name { get; set; }
        public DateTime FinishDate { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsCompleted { get; set; }
        public Task() { }

        public Task(string name, DateTime startDate, DateTime finishDate, bool completed) {
            Name = name;
            FinishDate = finishDate;
            StartDate = startDate;
            IsCompleted = completed;
        }
    }
}
