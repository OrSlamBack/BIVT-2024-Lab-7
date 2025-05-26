using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab_6
{
    public class White_5
    {
        public struct Match
        {
            private readonly int goals;
            private readonly int misses;
            public int Goals => goals;
            public int Misses => misses;
            public int Difference
            {
                get
                {
                    return Goals - Misses;
                }
            }
            public int Score
            {
                get
                {
                    if(Difference > 0)
                    {
                        return 3;
                    }
                    if (Difference == 0) {
                        return 1;
                    }
                    return 0;
                }
            }
            public Match(int _goals, int _misses)
            {
                goals = _goals;
                misses = _misses;
            }
            public void Print()
            {
                Console.WriteLine();
                Console.WriteLine($"Голов : {Goals}");
                Console.WriteLine($"Пропущено : {Misses}");
                Console.WriteLine($"Очков : {Score}");
            }
        };
        public struct Team
        {
            private string name;
            private Match[] matches;
            public string Name => name;
            public Match[] Matches
            {
                get
                {
                    return matches;
                }
            }
            public int TotalDifference
            {
                get
                {
                    if(matches == null)
                    {
                        return 0;
                    }
                    if(matches.Length == 0)
                    {
                        return 0;
                    }
                    int res = 0;
                    for(int i = 0;i < matches.Length; i++)
                    {
                        res += matches[i].Difference;
                    }
                    return res;
                }
            }
            public int TotalScore
            {
                get
                {
                    if (matches == null)
                    {
                        return 0;
                    }
                    if (matches.Length==0)
                    {
                        return 0;
                    }
                    int res = 0;
                    for (int i = 0; i < matches.Length; i++)
                    {
                        res += matches[i].Score;
                    }
                    return res;
                }
            }
            public Team(string _name) { 
                name = _name;
                matches = new Match[0];
            }
            public void PlayMatch(int goals, int misses)
            {
                if(matches == null)
                {
                    matches = new Match[0];
                }
                Match[] t = matches;
                matches = new Match[t.Length + 1];
                for (int i = 0; i < t.Length; i++)
                {
                    matches[i] = t[i];
                }
                matches[t.Length] = new Match(goals, misses);
            }
            public static void SortTeams(Team[] array)
            {
                if(array == null)
                {
                    return;
                }
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = i; j - 1 >= 0; j--)
                    {
                        if (array[j].TotalScore > array[j-1].TotalScore)
                        {
                            (array[j], array[j-1]) = (array[j-1], array[j]);
                        }
                        else if(array[j].TotalScore == array[j-1].TotalScore && array[j].TotalDifference > array[j-1].TotalDifference)
                        {
                              (array[j], array[j-1]) = (array[j -1], array[j]);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            public void Print()
            {
                if (Name == null) return;
                if(Matches == null) return;
                Console.Write(Name);
                Console.Write(" ");
                Console.Write(TotalScore);
                Console.Write(" ");
                Console.WriteLine(TotalDifference);
            }
        };

    }
}
