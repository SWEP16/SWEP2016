using System;
using System.Collections.Generic;
using System.Text;

namespace commands
{
    class LoadConfigCommand : SimpleCommand
    {
        private string path;

        LoadConfigCommand(string path)
        {
            this.path = path;
        }

        public void execute()
        {
            // ... lade configuration via Filepfad "path"
        }
    }
}
