using BrainfunLogic;





if(args.Length == 0) {throw new Exception("Please provide the path of the input file");}
else
{
   var bfl = new BrainFunLogic();
   if(bfl.ValidateInput(args[0])){System.Console.WriteLine("File is ready for compiling");}
   if(args.Length == 2)
   {
      bfl.HandleInput(args[1]);
   }
   else{
      bfl.HandleInput();
   }

   
   
}

