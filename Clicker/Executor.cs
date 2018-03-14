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

        public ArrayList metadata = new ArrayList() { "go", "click", "sleep"};

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

        public int getSize() {
            return commanders.Count;
        }

        public bool add(String line) {
            if (line != null) {
                String[] commander = line.Split(spliter);
                if (commander != null && metadata.Contains(commander[0]))
                {
                    commanders.Add(commander);
                    return true;
                }
                else {
                    commanders.Add(line);
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
