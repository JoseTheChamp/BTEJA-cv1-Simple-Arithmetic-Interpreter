
using Interpreter1;
string vstup = "1+2*3*4-5";
Interpreter interpreter = new Interpreter(vstup);
interpreter.NactiVyraz();
Console.WriteLine("Vysledek:  " + vstup + "  je " + interpreter.getResult());