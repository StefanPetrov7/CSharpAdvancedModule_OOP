﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes.Attributes
{
    public class MyRequiredAttribute : MyValidationAttribue
    {
        public override bool IsValid(object obj) => obj != null;
     
    }
}
