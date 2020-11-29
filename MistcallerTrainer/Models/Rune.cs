using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MistcallerTrainer.Models
{
    public enum Symbol
    {
        Leaf = 0,
        Flower = 1
    }

    public class Rune
    {
        public Symbol Symbol { get; set; }
        public bool Inked { get; set; }
        public bool Circle { get; set; }

        public override bool Equals(object obj)
        {
            bool result = false;

            if (obj is Rune)
            {
                if (((Rune)obj).Symbol == this.Symbol && ((Rune)obj).Inked == this.Inked && ((Rune)obj).Circle == this.Circle) 
                {
                    result = true;
                }
            }

            return result;
        }

        public override string ToString()
        {
            string symbol, inked, circle;

            symbol = Symbol.ToString();
            inked = Inked ? "Inked" : "Not Inked";
            circle = Circle ? "With Circle" : "Without Circle";

            return string.Format("{0} {1} {2}", symbol, inked, circle);
        }

        public string GetCode()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append((int)Symbol);
            sb.Append(Inked ? "1" : "0");
            sb.Append(Circle ? "1" : "0");

            return sb.ToString();
        }

        public Rune() { }

        public Rune(Symbol symbol, bool inked, bool circle)
        {
            Symbol = symbol;
            Inked = inked;
            Circle = circle;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }

    public class RuneSet
    {
        public List<Rune> Runes { get; set; }

        public RuneSet()
        {
            Random r = new Random();

            int commonDenom = r.Next(1, 3);

            Runes = new List<Rune>();

            int v = r.Next(2);
            Symbol s = (Symbol)(v);
            Symbol sa = (Symbol)(v == 0 ? 1 : 0);

            bool ink = r.Next(2) == 0;
            bool circle = r.Next(2) == 0;

            switch (commonDenom)
            {
                case 1: // Symbol
                    Runes.Add(new Rune(s, ink, circle));
                    Runes.Add(new Rune(s, ink, !circle));
                    Runes.Add(new Rune(s, !ink, !circle));
                    Runes.Add(new Rune(sa, !ink, circle));

                    break;
                case 2: // Inked
                    Runes.Add(new Rune(s, ink, circle));
                    Runes.Add(new Rune(s, ink, !circle));
                    Runes.Add(new Rune(sa, ink, circle));
                    Runes.Add(new Rune(sa, !ink, !circle));
                    break;
                case 3: // Circle
                    Runes.Add(new Rune(s, ink, circle));
                    Runes.Add(new Rune(s, !ink, circle));
                    Runes.Add(new Rune(sa, ink, circle));
                    Runes.Add(new Rune(sa, !ink, !circle));
                    break;
            }

            int n = Runes.Count;

            for (int i = Runes.Count - 1; i > 1; i--)
            {
                int rnd = r.Next(i + 1);
                Rune value = Runes[rnd];
                Runes[rnd] = Runes[i];
                Runes[i] = value;
            }
        }
    }
}
