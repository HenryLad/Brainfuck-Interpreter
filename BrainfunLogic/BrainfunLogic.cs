namespace BrainfunLogic;

public class BrainFunLogic
{
   public string[] input;

   public bool ValidateInput(string path)
   {

      try
      {
         input = File.ReadAllLines(path);
      }
      catch
      {
         throw new Exception($"File Path : {path} is invalid. Please check your Filepath");
      }

      if (input.Length == 0) { throw new Exception("The giving input in the File is not valid."); }

      return true;

   }

   public int[] HandleInput(string UserInput = "")
   {
      int UserInputIndex = 0;
      int ptr = 0;

      System.Console.WriteLine(UserInput);
      int[] IntOutput = [];
      char[] Output = [];

      for (int i = 0; i < input.Length; i++)
      {
         for (int y = 0; y < input[i].Length; y++)
         {
            switch (input[i][y])
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
      }

      return IntOutput;

   }
}
