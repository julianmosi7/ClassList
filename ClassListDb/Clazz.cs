﻿using System;
using System.Collections.Generic;

namespace ClassListDb
{
    public partial class Clazz
    {
        public Clazz()
        {
            Students = new HashSet<Student>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
