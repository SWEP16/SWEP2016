using SensorGUI.MVVM;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace commands
{
    namespace reactivecommands
    {
        public class ReactiveHalfCommandForFullCommandOnPort1 : ReactiveHalfCommand
        {
            private ReactiveFullCommand fullCommand;

            public ReactiveHalfCommandForFullCommandOnPort1(ReactiveFullCommand fullCommand)
            {
                this.fullCommand = fullCommand;
            }

            public override void execute(System.IO.Ports.SerialPort port)
            {
                this.fullCommand.executeOnPort1(port);
            }

            public override void react(char[] answerData, MainWindowViewModel viewModel)
            {
                this.fullCommand.reactOnPort1(answerData, viewModel);
            }

            public override bool isCorrectAnswerFormat(char[] answerData)
            {
                return true;
            }
        }
    }
}
