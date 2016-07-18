using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using usb;
using commands;


class Program
{
    static void Main(string[] args)
    {
        USBAdaption.init();

        CommandExecuter executer = USBAdaption.getCommandExecuter();
        while(true)
        {
            executer.execute(new ReadValueCommand());
            System.Threading.Thread.Sleep(1000);
        }
    }
}