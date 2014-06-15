using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace OrdersManager
{
    public class Data<T>
    {
        public T value;
    }

    public class Helper
    {
        public static BackgroundWorker DoInbackground(Action toDo, Action onEnd)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler((sender, e) =>
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
