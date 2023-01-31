using System;
using System.Linq;

namespace LinqArrays
{

    public class LinqArrays
    {
        static int DruhaMocnina(int i)
        {
            return i * i;
        }

        public static void Main(string[] args)
        {
            int[] intsA = { 1, 2, 3, 4, 23 };
            int[] intsB = { 2, 3, 5, 7, 11, 13, 17 };
            int[] intsC, distinct;

            var union = intsA.Union(intsB);
            var intersect = intsA.Intersect(intsB);
            
            // Clone() udělá tzv. "shallow copy", tedy "mělkou kopii".
            // Kdyby pole obsahovalo odkazy, například kdyby to bylo
            // pole stringů, kopírovaly by se jen odkazy, ale ne hodnoty
            // stringů
            int[] clone = (int[])intsA.Clone();

            // Metoda Select dělá tzv. projekci, tedy aplikuje operaci,
            // jejíž předpis přijme jako argument, na každý prvek pole
            // a vrátí nové pole, které obsahuje prvky po provedené operaci.
            // V tomto případě vrátí pole, kde je každý prvek druhou 
            // mocninou prkvku v původním poli.
            // Argument i => i * i je tzv. lambda výraz. Čti jej jako
            // "vezmi prvek a projektuj jej na svou druhou mocninu.
            intsA = intsA.Select((i) => i * i).ToArray();

            // Obdobně funguje volání Select s obyčejnou metodou,
            // která provádí totéž, co lambda v předchozím případě.
            // Použití lambdy je kratší, proto se tento způsob volání
            // již reálně nepoužívá
            intsC = intsA.Select(DruhaMocnina).ToArray();

            // Metoda string.Join umožňuje nejsnazší vypsání pole, listu a podobných struktur.
            // Prvním argumentem je oddělovač, druhým datová struktura, kterou chceme vypsat.
            // 
            // intsA bylo nahrazeno polem, které má namísto původních členů jejich druhé mocniny
            Console.WriteLine(string.Join(", ", intsA));

            // clone obsahuje klon původního pole !
            Console.WriteLine(string.Join(", ", clone));

            // union obsahuje sloučení původních polí, kde je každý prvek pole jednou
            // (chová se jako množina)
            Console.WriteLine(string.Join(", ", union));

            // intersect obsahuje pouze prvky, které jsou v obou polích
            Console.WriteLine(string.Join(", ", intersect));

            // Pole má objekt enumerator, který umožňuje k němu přistupovat 
            // sekvenčně. Tento princip používá cyklus foreach.
            // Na začátku je enumerator neinicializovaný, aby začal
            // fungovat přístup k aktuálnímu prvku (ienum.Curren),
            // musí se napřed zavolat metoda ienum.MoveNext().
            // ienum se nedá použít 2x, pokud chceme znovu procházet
            // sekvenčně polem, musíme znovu získat enumerator
            // voláním intsA.GetEnumerator()
            var ienum = intsA.GetEnumerator();
            while (ienum.MoveNext())
            {
                Console.WriteLine(ienum.Current);
            }

            // Metoda Distinct() odstarní duplicity v poli a vrátí typ
            // Enumerable, který se dá převést na pole.
            // V tomto případě se nově vytvořené pole s duplicitními prvky
            // přetvoří na nové pole, které bude mít pouze unikátní prvky.
            distinct = new int[] { 1, 1, 2, 3, 2, 5, 5 }.Distinct().ToArray();
            Console.WriteLine(string.Join(", ", distinct));
        }
    }
}