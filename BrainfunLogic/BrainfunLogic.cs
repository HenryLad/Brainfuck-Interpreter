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

      if(input.Length == 0){throw new Exception("The giving input in the File is not valid.");}

      return true;
      
   }
   
   public string[] HandleInput(string UserInput = "")
   {
      int UserInputCounter = 0;
      string[] output = [];

      for(int i = 0; i < input.Length; i++)
      {
         for(int y = 0; y < input[i].Length; y++)
         {
            
         }
      }

      return output;

   }
}
