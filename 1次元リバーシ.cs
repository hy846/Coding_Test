using System;
using System.IO;
using System.Collections.Generic;

public class MainApp
{

    static public void Main(string[] args)
    {
        var lines = GetStdin();
        int bn = 1;
        int wn = 1;
        string reverse = lines[0];
        char[] rev = reverse.ToCharArray();
        string around = "LR";
        char[] ar = around.ToCharArray();
        for (int i = 0; i < reverse.Length; i++)
        {
          if (i == 0){
            if (rev[0] == ar[0]){
              bn += 1;
            }
            else if(rev[0] == ar[1]){
              bn = bn + wn + 1;
              wn = 0;
            }
          }
          else if (i == 1){
            if (rev[1] == ar[0] && bn == 2){
              wn = wn + bn + 1;
              bn = 0;
            }
            else{
              wn += 1;
            }
          }
          else if (i >= 2){
            if (i % 2 == 0){
              if (rev[i] == rev[i-1] && bn != 0){
                bn = bn + wn + 1;
                wn = 0;
              }
              else{
                bn += 1;
              } 
            }
            else if (i % 2 == 1){
              if (rev[i] == rev[i-1] && wn != 0){
                wn = wn + bn + 1;
                bn = 0;
              }
              else{
                wn += 1;
              }
            }
          }
        }
        string result = string.Format("{0} {1}",bn,wn);
        Console.WriteLine(result);
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