using System;
using System.Collections.Generic;
using System.Text;

namespace commands
{
    namespace reactivecommands
    {
        public abstract class ReactiveFullCommand
        {
            private ReactiveHalfCommandForFullCommandOnPort1 halfCommand1;
            private ReactiveHalfCommandForFullCommandOnPort2 halfCommand2;

            private char[] bufferedAnswerData1;
            private char[] bufferedAnswerData2;

            public ReactiveFullCommand()
            {
                this.halfCommand1 = new ReactiveHalfCommandForFullCommandOnPort1(this);
                this.halfCommand2 = new ReactiveHalfCommandForFullCommandOnPort2(this);

                this.bufferedAnswerData1 = null;
                this.bufferedAnswerData2 = null;
            }

            abstract public void executeOnPort1(System.IO.Ports.SerialPort port);
            abstract public void executeOnPort2(System.IO.Ports.SerialPort port);
            abstract public void react(char[] answerData1, char[] answerData2);
            abstract public bool isCorrectAnswerFormat(char[] answerData);

            public void execute(System.IO.Ports.SerialPort port1, System.IO.Ports.SerialPort port2)
            {
                this.halfCommand1.execute(port1);
                this.halfCommand2.execute(port2);
            }

            public void reactOnPort1(char[] answerData)
            {
                this.bufferedAnswerData1 = answerData;
                if (this.bufferedAnswerData2 != null)
                {
                    this.react(answerData, bufferedAnswerData2);
                    this.bufferedAnswerData1 = null;
                    this.bufferedAnswerData2 = null;
                }
            }

            public void reactOnPort2(char[] answerData)
            {
                this.bufferedAnswerData2 = answerData;
                if (this.bufferedAnswerData1 != null)
                {
                    this.react(bufferedAnswerData1, answerData);
                    this.bufferedAnswerData1 = null;
                    this.bufferedAnswerData2 = null;
                }
            }

            public ReactiveHalfCommandForFullCommandOnPort1 getHalfCommand1()
            {
                return this.halfCommand1;
            }

            public ReactiveHalfCommandForFullCommandOnPort2 getHalfCommand2()
            {
                return this.halfCommand2;
            }
        }
    }
}
