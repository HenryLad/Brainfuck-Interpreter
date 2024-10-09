namespace BrainfunLogic;

public class BrainFunLogic
{
   public string[]? inputFileContent;
   public string? input;

   public char[] Output = new char[30000];

   public int UserInputIndex = 0;


   public bool ValidateInput(string path)
   {
      char[] allowedChars = new char[] { '>', '<', '+', '-', '.', ',', '[', ']' };

      try
      {
         inputFileContent = File.ReadAllLines(path);
         input = string.Join("", inputFileContent
             .SelectMany(line => line.Where(c => allowedChars.Contains(c))));
      }
      catch
      {
         throw new Exception($"File Path : {path} is invalid. Please check your Filepath");
      }

      if (string.IsNullOrEmpty(input))
      {
         throw new Exception("The given input in the File is not valid.");
      }

      System.Console.WriteLine(input);
      return true;
   }

   public int[] HandleInput(string UserInput = "")
   {

      int ptr = 0;


      int[] IntOutput = new int[30000];



      for (int i = 0; i < input?.Length; i++)
      {
         switch (input[i])
         {
            case '+':
               IntOutput[ptr]++;
               break;
            case '-':
               IntOutput[ptr]--;
               break;
            case '<':
               ptr--;
               break;
            case '>':
               ptr++;
               break;
            case '[':
               IntOutput = HandleLoops(ptr, IntOutput, i, UserInput);
               break;
            case ',':
               char inputChar = UserInput[UserInputIndex];
               UserInputIndex++;
               IntOutput[ptr] = (int)inputChar;
               break;
            case '.':
               Output[ptr] = (char)IntOutput[ptr];
               break;


         }

      }
    System.Console.WriteLine(IntOutput[0]);
      return IntOutput;

   }
   /// <summary>
   /// 
   /// </summary>
   /// <param name="ptr"></param>
   /// <param name="IntOutput"></param>
   /// <returns name="Index">Returns the index of where to continue in the loop</returns>
   public int[] HandleLoops(int ptr, int[] IntOutput, int index, string UserInput = "")
   {
      int StartingIndex = index;
      int i = 0;
      int ClosingIndex = input.Substring(index).IndexOf(']');
      if (ClosingIndex == -1) { throw new Exception("The loop was not closed correctly"); }
      string loopContent = input.Substring(StartingIndex, ClosingIndex);
      while (IntOutput[ptr] != 0)
      {
         switch (input[i])
         {
            case '+':
               IntOutput[ptr]++;
               break;
            case '-':
               IntOutput[ptr]--;
               break;
            case '<':
               ptr--;
               break;
            case '>':
               ptr++;
               break;
            case ']':
               continue;
            case ',':
               char inputChar = UserInput[UserInputIndex];
               UserInputIndex++;
               IntOutput[ptr] = (int)inputChar;
               break;
            case '.':
               Output[ptr] = (char)IntOutput[ptr];
               break;
         }
         i++;
      }

      return IntOutput;



   }


}
