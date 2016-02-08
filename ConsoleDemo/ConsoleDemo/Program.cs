using System;
using PluginLib;

namespace ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string testStrToLow = "StringToLower plugin test";
            StringToLower strToLow = new StringToLower();
            testStrToLow = strToLow.Modify(testStrToLow);
            Console.WriteLine(testStrToLow);
            Console.WriteLine();

            string testStrToUp = "StringToUpper plugin test";
            StringToUpper strToUp = new StringToUpper();
            testStrToUp = strToUp.Modify(testStrToUp);
            Console.WriteLine(testStrToUp);
            Console.WriteLine();

            PluginCollection<string> plCol = new PluginCollection<string>();
            plCol.Add(strToLow);
            plCol.Add(strToUp);
            string testPlCol = "PluginCollection plugin Test";
            testPlCol = plCol.Modify(testPlCol);
            Console.WriteLine(testPlCol);
            Console.WriteLine();

            string testPlPrint = "PluginPrinter  test";
            PluginPrinter<string> plPrinter = new PluginPrinter<string>(strToLow, testPlPrint);
            plPrinter.Print();
            Console.WriteLine();

            Console.WriteLine("DoublePlugin plugin test");
            double testDouble = -54.582;
            DoublePlugin doublePl = new DoublePlugin();
            Console.WriteLine(doublePl.Modify(testDouble));
            Console.WriteLine();

            Console.WriteLine("PluginablePlugin plugin test");
            PluginablePlugin plaginablePl = new PluginablePlugin(doublePl);
            Console.WriteLine(plaginablePl.Modify(testDouble));

            Console.ReadLine();
        }
    }
}
