using commands.reactivecommands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace commands {
    namespace simplecommands {
        class ConfigFromXMLCommand : SimpleCommand {
            string path;
            CommandExecuter commandExecuter;
            ConfigFromXMLCommand(CommandExecuter ce, string path) {
                this.path = path;
                this.commandExecuter = ce;
            }

            public void execute() {
                XmlReader reader = XmlReader.Create(this.path);
                List<string> paths = new List<string>();

                while (reader.Read()) {
                    if (reader.NodeType == XmlNodeType.Element) {
                        paths.Add(reader.Name);
                    }
                    else if (reader.NodeType == XmlNodeType.EndElement) {
                        paths.RemoveAt(paths.Count - 1);
                    }
                    else if (reader.NodeType == XmlNodeType.Text) {
                        this.configurationCommand(paths.ToArray(), int.Parse(reader.Value));
                    }
                }
                // ... lade configuration via Filepfad "path"
            }


            private void configurationCommand(string[] paths, int value) {
                string selector = string.Join(".", paths);
                int tempFilterDet11 = 0;
                int tempFilterDet12 = 0;
                int tempFilterDet21 = 0;
                int dspoints1 = 0;
                int dspoints2 = 0;

                Console.WriteLine(selector);
                switch (selector) {
                    //unit1 out1
                    case "units.unit1.out1.calc":
                        this.commandExecuter.executeOnPort1(new CalcConfigurationCommand(1, value));
                        break;
                    case "units.unit1.out1.outmsrmode":
                        this.commandExecuter.executeOnPort1(new MeasureModeConfigurationCommand(1, value));
                        break;
                    case "units.unit1.out1.filterdet":
                        tempFilterDet11 = value;
                        //zwischen speichern
                        break;
                    case "units.unit1.out1.filtertype":
                        this.commandExecuter.executeOnPort1(new FilterConfigurationCommand(1, tempFilterDet11, value));
                        break;
                    case "units.unit1.out1.dispdigit":
                        this.commandExecuter.executeOnPort1(new SmallestDisplayUnitConfigurationCommand(1, value));
                        break;
                    //unit1 out2
                    case "units.unit1.out2.calc":
                        this.commandExecuter.executeOnPort1(new CalcConfigurationCommand(2, value));
                        break;
                    case "units.unit1.out2.outmsrmode":
                        this.commandExecuter.executeOnPort1(new MeasureModeConfigurationCommand(2, value));
                        break;
                    case "units.unit1.out2.filterdet":
                        tempFilterDet12 = value;
                        break;
                    case "units.unit1.out2.filtertype":
                        this.commandExecuter.executeOnPort1(new FilterConfigurationCommand(2, tempFilterDet12, value));
                        break;
                    case "units.unit1.out2.dispdigit":
                        this.commandExecuter.executeOnPort1(new SmallestDisplayUnitConfigurationCommand(2, value));
                        break;
                    //unit1 common
                    case "units.unit1.common.samprate":
                        this.commandExecuter.executeOnPort1(new SamplingRateConfigurationCommand(value));
                        break;
                    case "units.unit1.common.dspoints":
                        dspoints1 = value;
                        break;
                    case "units.unit1.common.dsfreq":
                        this.commandExecuter.executeOnPort1(new AmountOfDataConfigurationCommand(1, dspoints1, value));
                        this.commandExecuter.executeOnPort1(new AmountOfDataConfigurationCommand(2, dspoints1, value));
                        break;
                    //unit2 out1
                    case "units.unit2.out1.calc":
                        this.commandExecuter.executeOnPort2(new CalcConfigurationCommand(1, value));
                        break;
                    case "units.unit2.out1.outmsrmode":
                        this.commandExecuter.executeOnPort2(new MeasureModeConfigurationCommand(1, value));
                        break;
                    case "units.unit2.out1.filterdet":
                        tempFilterDet21 = value;
                        break;
                    case "units.unit2.out1.filtertype":
                        this.commandExecuter.executeOnPort2(new FilterConfigurationCommand(1, tempFilterDet12, value));
                        break;
                    case "units.unit2.out1.dispdigit":
                        this.commandExecuter.executeOnPort2(new SmallestDisplayUnitConfigurationCommand(1, value));
                        break;
                    //unit2 common
                    case "units.unit2.common.samprate":
                        this.commandExecuter.executeOnPort2(new SamplingRateConfigurationCommand(value));
                        break;
                    case "units.unit2.common.dspoints":
                        dspoints2 = value;
                        break;
                    case "units.unit2.common.dsfreq":
                        this.commandExecuter.executeOnPort2(new AmountOfDataConfigurationCommand(1, dspoints1, value));
                        break;
                }
            }
        }
    }
}
