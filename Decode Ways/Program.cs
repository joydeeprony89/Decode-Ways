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
      if (s.Length == 0) return 0;
      int?[] memorization = new int?[s.Length];
      int? result = NumDecoding_Helper(s, 0, memorization);
      return result.Value;
    }

    int? NumDecoding_Helper(string s, int k, int?[] memorization)
    {
      // base conditions - reached to the end of the string
      if (k == s.Length) return 1;
      // if starts with 0
      if (s[k] == '0') return 0;

      // check memorization already have the value
      if (memorization[k] != null)
      {
        return memorization[k];
      }

      int? count = NumDecoding_Helper(s, k + 1, memorization);
      // condition for two digit. first digit can be 1 or 2 and second digit should be less than 7 as the max int value is 26 for Z.
      if (k < s.Length - 1 && (s[k] == '1' || s[k] == '2' && s[k+1] < '7'))
      {
        count += NumDecoding_Helper(s, k + 2, memorization);
      }
      memorization[k] = count;
      return count;
    }
  }
}
