using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigiMa.Data
{
    public class PreferenceData
    {
        private string PrefID;

        public string PrefID1
        {
            get { return PrefID; }
            set { PrefID = value; }
        }

        private string PrefShortDesc;

        public string PrefShortDesc1
        {
            get { return PrefShortDesc; }
            set { PrefShortDesc = value; }
        }

        private string PrefLongDesc;

        public string PrefLongDesc1
        {
            get { return PrefLongDesc; }
            set { PrefLongDesc = value; }
        }

        private string TaskOne;

        public string TaskOne1
        {
            get { return TaskOne; }
            set { TaskOne = value; }
        }

        private string TaskTwo;

        public string TaskTwo1
        {
            get { return TaskTwo; }
            set { TaskTwo = value; }
        }

        private string TaskThree;

        public string TaskThree1
        {
            get { return TaskThree; }
            set { TaskThree = value; }
        }

        private string CurrentTask;

        public string CurrentTask1
        {
            get { return CurrentTask; }
            set { CurrentTask = value; }
        }

        private string LastTask;

        public string LastTask1
        {
            get { return LastTask; }
            set { LastTask = value; }
        }

        private string FutureTask;

        public string FutureTask1
        {
            get { return FutureTask; }
            set { FutureTask = value; }
        }
        private int TemplateID;

        public int TemplateID1
        {
            get { return TemplateID; }
            set { TemplateID = value; }
        }
    }
}