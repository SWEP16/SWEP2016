using System;
using System.Collections.Generic;
using System.Text;
using commands.reactivecommands;
using commands.simplecommands;

namespace commands
{
    public class CommandExecuter
    {
        private Queue<ReactiveCommand> commandQueue = new Queue<ReactiveCommand>();

        private System.IO.Ports.SerialPort serialPort1;
        private System.IO.Ports.SerialPort serialPort2;


        public CommandExecuter(System.IO.Ports.SerialPort serialPort1, System.IO.Ports.SerialPort serialPort2)
        {
            this.serialPort1 = serialPort1;
            this.serialPort2 = serialPort2;
        }

        public void execute(SimpleCommand command)
        {
            try
            {
                command.execute();
            }
            catch (Exception e)
            {
                Console.Write("Simple Command ist fehlgeschlagen...\n");
                Console.Write(e.Message + "\n");
            }
        }

        public void execute(ReactiveCommand command)
        {
            try
            {
                command.execute(this.serialPort1, this.serialPort2);
                this.commandQueue.Enqueue(command);
            }
            catch (Exception e)
            {
                Console.Write("Reactive Command ist im Anfrageverhalten fehlgeschlagen...\n");
                Console.Write(e.Message + "\n");
            }
        }

        public void notify(char[] answerData1, char[] answerData2)
        {
            ReactiveCommand command = this.commandQueue.Peek();
            if (command.isCorrectAnswerFormat(answerData1) && command.isCorrectAnswerFormat(answerData1))
            {
                try
                {
                    command.react(answerData1, answerData2);
                    if (this.commandQueue.Count != 0)
                    {
                        this.commandQueue.Dequeue();
                    }
                }
                catch (Exception e)
                {
                    Console.Write("Reactive Command ist im Antwortverhalten fehlgeschlagen...\n");
                    Console.Write(e.Message + "\n");
                }
            }
        }
    }
}
