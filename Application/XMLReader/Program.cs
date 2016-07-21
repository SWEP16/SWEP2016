using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApplication3 {
    class Program {

        static void configurationCommand(string[] paths, string value) {
            string selector = string.Join(".", paths);

            Console.WriteLine(selector);
            switch (selector) {
                //unit1 out1
                case "units.unit1.out1.calc":
                    break;
                case "units.unit1.out1.outmsrmode":
                    break;
                case "units.unit1.out1.filterdet":
                    break;
                case "units.unit1.out1.filtertype":
                    break;
                case "units.unit1.out1.dispdigit":
                    break;
                //unit1 out2
                case "units.unit1.out2.calc":
                    break;
                case "units.unit1.out2.outmsrmode":
                    break;
                case "units.unit1.out2.filterdet":
                    break;
                case "units.unit1.out2.filtertype":
                    break;
                case "units.unit1.out2.dispdigit":
                    break;
                //unit1 common
                case "units.unit1.common.samprate":
                    break;
                case "units.unit1.common.dspoints":
                    break;
                case "units.unit1.common.dsfreq":
                    break;
                //unit2 out1
                case "units.unit2.out1.calc":
                    break;
                case "units.unit2.out1.outmsrmode":
                    break;
                case "units.unit2.out1.filterdet":
                    break;
                case "units.unit2.out1.filtertype":
                    break;
                case "units.unit2.out1.dispdigit":
                    break;
                //unit2 common
                case "units.unit2.common.samprate":
                    break;
                case "units.unit2.common.dspoints":
                    break;
                case "units.unit2.common.dsfreq":
                    break;
            }
                
        }
        static void Main(string[] args) {
            XmlReader reader = XmlReader.Create("\\\\vmware-host\\Shared Folders\\Dokumente\\Programmierung\\GitProjects\\SWEP2016\\konfig.xml");
            List<string> paths = new List<string>();

            while (reader.Read()) {
                if (reader.NodeType == XmlNodeType.Element) {
                    paths.Add(reader.Name);
                }
                else if (reader.NodeType == XmlNodeType.EndElement) {
                    paths.RemoveAt(paths.Count - 1);
                }
                else if (reader.NodeType == XmlNodeType.Text) {
                    configurationCommand(paths.ToArray(), reader.Value);
                }
            }
            Console.ReadKey();
        }
    }
}