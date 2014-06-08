using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace OrdersManager
{
    public class Helper
    {
        public static BackgroundWorker DoInbackground(Action toDo, Action onEnd)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.ProgressChanged += new ProgressChangedEventHandler((sender, e) =>
            {
                toDo();
            });
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler((sender, e) =>
            {
                onEnd();
            });
            worker.RunWorkerAsync();
            return worker;
        }
    }
}
