using System;
using System.Collections.Generic;
using System.Text;
using commands.reactivecommands;
using commands.simplecommands;

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
                command.execute(this.serialPort1);
                this.halfCommandQueuePort1.Enqueue(command);
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
                command.execute(this.serialPort2);
                this.halfCommandQueuePort2.Enqueue(command);
            }
            catch (Exception e)
            {
                Console.Write("Half Reactive Command ist fehlgeschlagen...\n");
                Console.Write(e.Message + "\n");
            }
        }

        public void execute(ReactiveFullCommand command)
        {
            ReactiveHalfCommandForFullCommandOnPort1 halfCommand1 = command.getHalfCommand1();
            ReactiveHalfCommandForFullCommandOnPort2 halfCommand2 = command.getHalfCommand2();

            try
            {
                command.execute(this.serialPort1, this.serialPort2);
                this.halfCommandQueuePort1.Enqueue(halfCommand1);
                this.halfCommandQueuePort2.Enqueue(halfCommand2);
            }
            catch (Exception e)
            {
                Console.Write("Reactive Full Command ist im Anfrageverhalten fehlgeschlagen...\n");
                Console.Write(e.Message + "\n");
            }
        }

        public void notifyOnPort1(char[] answerData)
        {
            ReactiveHalfCommand command = this.halfCommandQueuePort1.Peek();
            if (command.isCorrectAnswerFormat(answerData) && command.isCorrectAnswerFormat(answerData))
            {
                try
                {
                    command.react(answerData);
                    if (this.halfCommandQueuePort1.Count != 0)
                    {
                        this.halfCommandQueuePort1.Dequeue();
                    }
                }
                catch (Exception e)
                {
                    Console.Write("Reactive Command ist im Antwortverhalten fehlgeschlagen...\n");
                    Console.Write(e.Message + "\n");
                }
            }
        }

        public void notifyOnPort2(char[] answerData)
        {
            ReactiveHalfCommand command = this.halfCommandQueuePort2.Peek();
            if (command.isCorrectAnswerFormat(answerData) && command.isCorrectAnswerFormat(answerData))
            {
                try
                {
                    command.react(answerData);
                    if (this.halfCommandQueuePort2.Count != 0)
                    {
                        this.halfCommandQueuePort2.Dequeue();
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
