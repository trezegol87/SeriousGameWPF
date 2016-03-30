
using System;
using System.Collections.Generic;
using System.IO;
namespace SeriousGameWPF.Helper
{
  public class FileReaderHelper
  {
    private static FileReaderHelper instance;

    private FileReaderHelper() { }

    public static FileReaderHelper Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new FileReaderHelper();
        }
        return instance;
      }
    }

    public List<string> GetWordsFromTextFile(string filePath)
    {
      var words = new List<string>();
      try
      {
        using (StreamReader sr = new StreamReader(filePath))
        {
          String[] line = sr.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
          words.AddRange(line);
          return words;
        }
      }
      catch (Exception e)
      {
        Console.WriteLine("The file could not be read:");
        Console.WriteLine(e.Message);
        return new List<string>();
      }
    }


  }
}
