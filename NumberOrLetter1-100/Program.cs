using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOrLetter1_100 {
    class Program {
        static void Main(string[] args) {
            int minValue = 1;
            int maxValue = 100;
            ListOfDivisorText listOfDivisorText = new ListOfDivisorText(new ConsoleWriter());
            listOfDivisorText.add(new DivisorText(3, "A"));
            listOfDivisorText.add(new DivisorText(5, "B"));
            listOfDivisorText.add(new DivisorText(7, "C"));
            for(int i = minValue; i <= maxValue; i++) {
                listOfDivisorText.printValue(i);
            }
        }
    }

    interface Printer {
        void startPrinting();
        void print(string thingToPrint);
        void stopPrinting();
    }
    class ConsoleWriter : Printer {
        public void startPrinting() { }
        public void print(string thingToPrint) {
            Console.Write(thingToPrint);
        }
        public void stopPrinting() {
            Console.WriteLine("");
        }
    }
    class DivisorText {
        public int divisor { get; set; }
        public string text { get; set; }
        public DivisorText(int divisor, string text) {
            this.divisor = divisor;
            this.text = text;
        }
    }
    class ListOfDivisorText {
        private Printer printer;
        List<DivisorText> theList = new List<DivisorText>();
        public ListOfDivisorText(Printer printer) {
            this.printer = printer;
        }
        public void add(DivisorText divisorText) {
            theList.Add(divisorText);
        }
        private bool isDivisable(int dividend) {
            foreach(DivisorText divisorText in theList) {
                if(dividend % divisorText.divisor == 0)
                    return true;
            }
            return false;
        }
        private void printNumber(int number) {
            printer.print(number.ToString());
        }
        private void printText(int dividend) {
            foreach(DivisorText divisorText in theList) {
                if(dividend % divisorText.divisor == 0)
                    printer.print(divisorText.text);
            }
        }
        public void printValue(int dividend) {
            printer.startPrinting();
            if(isDivisable(dividend)) {
                printText(dividend);
            } else {
                printNumber(dividend);
            }
            printer.stopPrinting();
        }
    }
}