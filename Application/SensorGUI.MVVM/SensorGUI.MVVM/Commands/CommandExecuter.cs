using System;
using System.Collections.Generic;
using System.Text;
using commands.reactivecommands;
using commands.simplecommands;
using System.Threading;
using SensorGUI.MVVM;
using System.Runtime.CompilerServices;

namespace commands
{
    public class CommandExecuter
    {
        private Queue<ReactiveHalfCommand> halfCommandQueuePort1 = new Queue<ReactiveHalfCommand>();
        private Queue<ReactiveHalfCommand> halfCommandQueuePort2 = new Queue<ReactiveHalfCommand>();

        private System.IO.Ports.SerialPort serialPort1;
        private System.IO.Ports.SerialPort serialPort2;

        private MainWindowViewModel viewModel;


        public CommandExecuter(MainWindowViewModel viewModel, System.IO.Ports.SerialPort serialPort1, System.IO.Ports.SerialPort serialPort2)
        {
            this.viewModel = viewModel;
            this.serialPort1 = serialPort1;
            this.serialPort2 = serialPort2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void execute(SimpleCommand command)
        {
            try
            {
                command.execute();
                viewModel.update();
            }
            catch (Exception e)
            {
                Console.Write("Simple Command ist fehlgeschlagen...\n");
                Console.Write(e.Message + "\n");
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
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
                Console.Write("Half Reactive Command ist fehlgeschlagen auf Port1...\n");
                Console.Write(e.Message + "\n");
                this.viewModel.DisplayErrorMessage(e.Message);
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
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
                Console.Write("Half Reactive Command ist fehlgeschlagen auf Port2...\n");
                Console.Write(e.Message + "\n");
                this.viewModel.DisplayErrorMessage(e.Message);
            }
        }

        public bool areQueuesEmpty() 
        {
            bool queue1Empty = this.halfCommandQueuePort1.Count == 0;
            bool queue2Empty = this.halfCommandQueuePort2.Count == 0;

            return queue1Empty && queue2Empty;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void execute(ReactiveFullCommand command)
        {
            this.executeOnPort1(command.getHalfCommand1());
            this.executeOnPort2(command.getHalfCommand2());
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void notifyOnPort1(char[] answerData)
        {
            ReactiveHalfCommand command = this.halfCommandQueuePort1.Dequeue();
            if (command.isCorrectAnswerFormat(answerData))
            {
                try
                {
                    command.react(answerData, this.viewModel);
                   
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
                    this.viewModel.DisplayErrorMessage(e.Message);
                }
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void notifyOnPort2(char[] answerData)
        {
            ReactiveHalfCommand command = this.halfCommandQueuePort2.Dequeue();

            
            if (command.isCorrectAnswerFormat(answerData))
            {
                try
                {
                    command.react(answerData, this.viewModel);

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
                    this.viewModel.DisplayErrorMessage(e.Message);
                }
            }
        }
    }
}
