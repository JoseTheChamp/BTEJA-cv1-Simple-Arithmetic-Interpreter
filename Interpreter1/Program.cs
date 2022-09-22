
using Interpreter1;

Interpreter interpreter = new Interpreter("1+2*3*4-5");
interpreter.NactiVyraz();
Console.WriteLine(interpreter.getResult());