using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter1
{
    internal class Interpreter
    {
        private string vstup;
        private int kurzor;
        private Stack<int> stack;

        public Interpreter(string vstup)
        {
            this.vstup = vstup;
            kurzor = 0;
            stack = new Stack<int>();
        }

        public int getResult() { 
            return stack.Pop();
        }

        public bool NactiVyraz() {
            char? operatorr;
            int hodnota1, hodnota2,vysledek;
            if (NactiTerm())
            {
                while (true) {
                    operatorr = NactiPlusMinus();
                    if (operatorr == null)
                    {
                        return true;
                    }
                    NactiTerm();
                    hodnota1 = stack.Pop();
                    hodnota2 = stack.Pop();
                    if (operatorr == '+')
                    {
                        vysledek = hodnota2 + hodnota1;
                        stack.Push(vysledek);
                    }
                    else {
                        vysledek = hodnota2 - hodnota1;
                        stack.Push(vysledek);
                    }
                }
            }
            return false;
        }

        private bool NactiTerm()
        {
            char? operatorr;
            int hodnota1, hodnota2, vysledek;
            if (NactiCislo())
            {
                while (true)
                {
                    operatorr = NactiKratDeleno();
                    if (operatorr == null)
                    {
                        return true;
                    }
                    NactiCislo();
                    hodnota1 = stack.Pop();
                    hodnota2 = stack.Pop();
                    if (operatorr == '*')
                    {
                        vysledek = hodnota2 * hodnota1;
                        stack.Push(vysledek);
                    }
                    else
                    {
                        vysledek = hodnota2 / hodnota1;
                        stack.Push(vysledek);
                    }
                }
            }
            return false;
        }

        private bool NactiFaktor()
        {
            //Nepochopil jsem zamýšlenou funkci této metody. Kromě pouhého předání do metody NactiCislo. 
            return false;
        }

        public bool NactiCislo()
        {
            int ignoreMe;
            string cislice = "";
            while (int.TryParse(vstup[kurzor].ToString(), out ignoreMe))
            {
                cislice += vstup[kurzor].ToString();
                kurzor++;
                if (kurzor == vstup.Length)
                {
                    break;
                }
            }
            if (cislice == "")
            {
                return false;
            }
            stack.Push(int.Parse(cislice));
            return true;
        }

        public char? NactiPlusMinus()
        {
            if (kurzor == vstup.Length)
            {
                return null;
            }
            if (vstup[kurzor] == '+' || vstup[kurzor] == '-')
            {
                kurzor++;
                return vstup[kurzor-1];
            }
            return null;
        }

        public char? NactiKratDeleno()
        {
            if (kurzor == vstup.Length)
            {
                return null;
            }
            if (vstup[kurzor] == '*' || vstup[kurzor] == '/')
            {
                kurzor++;
                return vstup[kurzor-1];
            }
            return null;
        }
    }
}
