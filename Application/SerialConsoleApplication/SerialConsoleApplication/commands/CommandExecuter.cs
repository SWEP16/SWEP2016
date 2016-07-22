using System;
using System.Collections.Generic;
using System.Text;
using commands.reactivecommands;
using commands.simplecommands;
using System.Threading;

namespace commands
{
    public class CommandExecuter
    {
        private Queue<ReactiveHalfCommand> halfCommandQueuePort1 = new Queue<ReactiveHalfCommand>();
        private Queue<ReactiveHalfCommand> halfCommandQueuePort2 = new Queue<ReactiveHalfCommand>();

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

        public void executeOnPort1(ReactiveHalfCommand command)
        {
            try
            {
                this.halfCommandQueuePort1.Enqueue(command);
                if (this.halfCommandQueuePort1.Count == 1)
                {
                    command.execute(this.serialPort1);
                }
            }
            catch (Exception e)
            {
                Console.Write("Half Reactive Command ist fehlgeschlagen...\n");
                Console.Write(e.Message + "\n");
            }
        }

        public void executeOnPort2(ReactiveHalfCommand command)
        {
            try
            {
                this.halfCommandQueuePort2.Enqueue(command);
                if (this.halfCommandQueuePort2.Count == 1)
                {
                    command.execute(this.serialPort2);
                }
            }
            catch (Exception e)
            {
                Console.Write("Half Reactive Command ist fehlgeschlagen...\n");
                Console.Write(e.Message + "\n");
            }
        }

        public void execute(ReactiveFullCommand command)
        {
            this.executeOnPort1(command.getHalfCommand1());
            this.executeOnPort2(command.getHalfCommand2());
        }

        public void notifyOnPort1(char[] answerData)
        {
            ReactiveHalfCommand command = this.halfCommandQueuePort1.Dequeue();
            if (command.isCorrectAnswerFormat(answerData))
            {
                try
                {
                    command.react(answerData);
                   
                    if(this.halfCommandQueuePort1.Count != 0)
                    {
                        command = this.halfCommandQueuePort1.Peek();
                        command.execute(this.serialPort1);
                    }
                }
                catch (Exception e)
                {
                    Console.Write("Reactive Half Command ist im Antwortverhalten fehlgeschlagen...\n");
                    Console.Write(e.Message + "\n");
                }
            }
        }

        public void notifyOnPort2(char[] answerData)
        {
            ReactiveHalfCommand command = this.halfCommandQueuePort2.Dequeue();

            
            if (command.isCorrectAnswerFormat(answerData))
            {
                try
                {
                    command.react(answerData);

                    if (this.halfCommandQueuePort2.Count != 0)
                    {
                        command = this.halfCommandQueuePort2.Peek();
                        command.execute(this.serialPort2);
                    }
                }
                catch (Exception e)
                {
                    Console.Write("Reactive Half Command ist im Antwortverhalten fehlgeschlagen...\n");
                    Console.Write(e.Message + "\n");
                }
            }
        }
    }
}
