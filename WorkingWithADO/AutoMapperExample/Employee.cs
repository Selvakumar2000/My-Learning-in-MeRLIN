﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperExample
{
    class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public Address address { get; set; }
    }
}
