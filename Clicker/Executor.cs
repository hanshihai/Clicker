using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace Clicker
{
    class Executor
    {
        public ArrayList commanders = new ArrayList();

        private ArrayList subCommanders = new ArrayList();

        private int loopCount = 0;

        private bool inLoop = false;

        public ArrayList metadata = new ArrayList() { "go", "click", "sleep", "loop", "end-loop"};

        public char[] spliter = new char[1];

        public Executor() {
            spliter[0] = ' ';
        }

        public String Go() {
            return (String)metadata[0];
        }

        public String Click()
        {
            return (String)metadata[1];
        }

        public String Sleep()
        {
            return (String)metadata[2];
        }

        public String Loop() {
            return (String)metadata[3];
        }

        public String EndLoop() {
            return (String)metadata[4];
        }

        public int getSize() {
            return commanders.Count;
        }

        public bool add(String line) {
            if (line != null) {
                String[] commander = line.Split(spliter);
                if (commander != null && metadata.Contains(commander[0]))
                {
                    if (Loop().Equals(commander[0]))
                    {
                        inLoop = true;
                        loopCount = int.Parse(commander[1]);
                        subCommanders = new ArrayList();
                    }
                    else if (EndLoop().Equals(commander[0]))
                    {
                        for (int i = 0; i < loopCount; i++)
                        {
                            commanders.AddRange(subCommanders);
                        }
                        loopCount = 0;
                        inLoop = false;
                        subCommanders = new ArrayList();
                    }
                    else {
                        if (inLoop)
                        {
                            subCommanders.Add(commander);
                        }
                        else {
                            commanders.Add(commander);
                        }
                    }
                    return true;
                }
                else {
                    String[] comment = new string[1];
                    comment[0] = line;
                    commanders.Add(comment);
                    return true;
                }
            }
            return false;
        }

        public String[] get(int i) {
            if (i < commanders.Count) {
                String[] element = (String[])commanders[i];
                return element;
            }
            return null;
        }

    }
}
