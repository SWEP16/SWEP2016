<<<<<<< HEAD:Application/model/model/model/MeasurementSeries.cs
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public abstract class MeasurementSeries{
        public string name { get; set; }
        public abstract int getMeasurementsLength();
    }
}
