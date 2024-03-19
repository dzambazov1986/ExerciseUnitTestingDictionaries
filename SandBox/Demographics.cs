using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBox
{
    public static class Demographics
    {
        public static Dictionary<string, int> CountUserWithEqualUsernames(List<string> usernames)
        {
            var dataDictionary = new Dictionary<string, int>(); 

            foreach (string name in usernames)
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    continue;
                }

                if (!dataDictionary.ContainsKey(name))
                {
                    dataDictionary.Add(name, 0);    
                }

                dataDictionary[name] += 1;
            }

            return dataDictionary;
        }

        public static Dictionary<char, int> CountCharsString(string text)
        {
            var dataDictionary = new Dictionary<char, int>();

            foreach (char val in text)
            {
                if (!dataDictionary.ContainsKey(val))
                {
                    dataDictionary.Add(val, 0);
                }

                dataDictionary[val] += 1;
            }

            return dataDictionary;
        }

        public static Dictionary<int, int> CountEvenAndOddNumbers(int[] numbers)
        {
            var dataDictionary = new Dictionary<int, int>();

            dataDictionary[0] = 0;
            dataDictionary[1] = 0;

            foreach (char val in numbers)
            {
                if (val % 2 == 0)
                {
                    dataDictionary[0]++;
                }
                else
                {
                    dataDictionary[1]++;
                }

            }

            return dataDictionary;
        }

        //Input:
        //register John CS1234JS
        //register Andy AB4142CD
        //register Jesica VR1223EE
        //unregister Andy

        //Output
        //John => CS1234JS
        //Jesica => VR1223EE
        public static Dictionary<string, string> Database(string[] commandInput)
        {
            var dataDictionary = new Dictionary<string, string>();

            foreach (var val in commandInput)
            {
                string[] commandInfo = val.Split();
                string command = commandInfo[0];

                if (command == "register")
                {
                    string name = commandInfo[1];
                    string id = commandInfo[2];

                    dataDictionary.TryAdd(id, name);
                }
                else if (command == "unregister")
                {
                    string id = commandInfo[1];

                    dataDictionary.Remove(id); //true false
                }
            }

            return dataDictionary;
        }
    }
}
