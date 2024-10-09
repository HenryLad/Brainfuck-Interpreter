namespace BrainfunLogic;

public class BrainFunLogic
{
   public string[]? inputFileContent;
   public string? input;

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
      int UserInputIndex = 0;
      int ptr = 0;


      int[] IntOutput = [];
      char[] Output = [];


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

               break;
            case ']':

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

      return IntOutput;

   }
   /// <summary>
   /// 
   /// </summary>
   /// <param name="ptr"></param>
   /// <param name="IntOutput"></param>
   /// <returns name="Index">Returns the index of where to continue in the loop</returns>
   public int HandleLoops(int ptr, int[] IntOutput)
   {
      int ClosingIndex = input.TrimStart().IndexOf(']');
      do
      {
         if (IntOutput[ptr] == 0)
         {
            return input.IndexOf(']');
         }

      } while (true);


   }

  
}
