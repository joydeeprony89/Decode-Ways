using System;

namespace Decode_Ways
{
  // https://www.youtube.com/watch?v=qli-JCrSwuk
  class Program
  {
    static void Main(string[] args)
    {
      Program p = new Program();
      Console.WriteLine(p.NumDecodings("11106")); // 26, 06, 12
    }
    public int NumDecodings(string s)
    {
      int?[] memorization = new int?[s.Length + 1];
      int? result = NumDecoding_Helper(s, s.Length, memorization);
      return result.Value;
    }

    int? NumDecoding_Helper(string s, int k, int?[] memorization)
    {
      // base conditions
      // 1. if the length is 0
      if (k == 0) return 1;
      // 2. if starts with 0
      int firstCharacterIndex = s.Length - k;
      if (s[firstCharacterIndex] == '0') return 0;

      // check memorization already have the value
      if (memorization[k] != null)
      {
        return memorization[k];
      }

      int? count = NumDecoding_Helper(s, k - 1, memorization);
      if (k >= 2 && Convert.ToInt32(s.Substring(firstCharacterIndex, 2)) <= 26)
      {
        count += NumDecoding_Helper(s, k - 2, memorization);
      }
      memorization[k] = count;
      return count;
    }
  }
}
