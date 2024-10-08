namespace BrainfunLogic;

public class BrainFunLogic
{

   public bool ValidateInput(string path)
   {
      string[] input; 
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

}
