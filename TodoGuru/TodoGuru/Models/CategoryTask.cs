using System;
using System.Collections.Generic;
using System.Text;

namespace TodoGuru
{
    public class CategoryTask
    {
        public string CategoryName { get; set; }
        public List<UserTask> Tasks { get; set; }
    }
}
