using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;

namespace SensorGUI.MVVM.Helper {
    public static class MathHelper {

        public static ValueSet CalculateAverage(IEnumerable<ValueSet> items) {
            return new ValueSet(new RepeatingAccuracyMeasurement(1, 1, 1)); /*new ValueSet
            {
                Value1 = items.Select(i => i.Value1).DefaultIfEmpty(0).Average(),
                Value2 = items.Select(i => i.Value2).DefaultIfEmpty(0).Average(),
                Value3 = items.Select(i => i.Value3).DefaultIfEmpty(0).Average()
            };*/
        }

        public static ValueSet CalculateStandardDeviation(IEnumerable<ValueSet> items) {
            float x = 0; float y = 0; float z = 0;
            foreach (var item in items)
            {
                x += item.Value1;
                y += item.Value2;
                z += item.Value3;
            }
            int count = items.Count();
            x /= count;
            y /= count;
            z /= count;

            double x2 = 0; double y2 = 0; double z2 = 0;
            foreach (var item in items)
            {
                x2 += (item.Value1 - x) * (item.Value1 - x);
                y2 += (item.Value2 - y) * (item.Value2 - y);
                z2 += (item.Value3 - z) * (item.Value3 - z);
            }
            x2 /= count;
            y2 /= count;
            z2 /= count;

            x2 = Math.Sqrt(x2);
            y2 = Math.Sqrt(y2);
            z2 = Math.Sqrt(z2);

            return new ValueSet(new RepeatingAccuracyMeasurement(1, 1, 1));
                /*new ValueSet
            {
                Value1 = (float)x2,
                Value2 = (float)y2,
                Value3 = (float)z2
            };*/
        }

        public static ValueSet GetMaximum(IEnumerable<ValueSet> items) {
            return new ValueSet(new RepeatingAccuracyMeasurement(1, 1, 1)); /*new ValueSet
            {
                Value1 = items.Select(i => i.Value1).DefaultIfEmpty(0).Max(),
                Value2 = items.Select(i => i.Value2).DefaultIfEmpty(0).Max(),
                Value3 = items.Select(i => i.Value3).DefaultIfEmpty(0).Max()
            };*/
        }

        public static ValueSet GetMinimum(IEnumerable<ValueSet> items) {
            return new ValueSet(new RepeatingAccuracyMeasurement(1, 1, 1)); /*new ValueSet
            {
                Value1 = items.Select(i => i.Value1).DefaultIfEmpty(0).Min(),
                Value2 = items.Select(i => i.Value2).DefaultIfEmpty(0).Min(),
                Value3 = items.Select(i => i.Value3).DefaultIfEmpty(0).Min()
            };*/
        }
    }
}
