using System;
using System.IO;
using System.Collections.Generic;

public class MainApp
{
    static public void Main(string[] args)
    {
        var lines = GetStdin();
        string previousWord = "しりとり";
        int usedWordsCount = 0;
        HashSet<string> usedWords = new HashSet<string>();
        int i = 0;
        while (i < lines.Length)
        {
            string currentWord = lines[i];
            if (previousWord[previousWord.Length - 1] == currentWord[0] && !usedWords.Contains(currentWord))
            {
                usedWords.Add(currentWord);
                usedWordsCount++;
                previousWord = currentWord;
                i = 0;
            }
            i++;
        }
        if (previousWord[previousWord.Length - 1] == 'ん')
        {
            Console.WriteLine(usedWordsCount);
        }
        else
        {
            Console.WriteLine(-1);
        }
    }

    static private string[] GetStdin()
    {
        var list = new List<string>();
        string line;
        while ((line = Console.ReadLine()) != null)
        {
            list.Add(line);
        }
        return list.ToArray();
    }
}
