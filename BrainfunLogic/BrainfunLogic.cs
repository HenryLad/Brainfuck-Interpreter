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
                    i = HandleLoops(ptr, IntOutput, i, UserInput);
                    break;
                case ',':
                    if (UserInputIndex < UserInput.Length)
                    {
                        char inputChar = UserInput[UserInputIndex];
                        UserInputIndex++;
                        IntOutput[ptr] = (int)inputChar;
                    }
                    break;
                case '.':
                    Output[ptr] = (char)IntOutput[ptr];
                    System.Console.Write(Output[ptr]);
                    break;
            }
        }
        foreach(var a in IntOutput)
        {
            if(a == 0){continue;}
            else{
                System.Console.WriteLine(a);

            }
        }

        return IntOutput;
    }

    public int HandleLoops(int ptr, int[] IntOutput, int index, string UserInput = "")
    {
        int StartingIndex = index;
        int ClosingIndex = FindClosingBracketIndex(index);

        if (ClosingIndex == -1)
        {
            throw new Exception("The loop was not closed correctly");
        }

        while (IntOutput[ptr] != 0)
        {
            for (int i = StartingIndex + 1; i < ClosingIndex; i++)
            {
                switch (input?[i])
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
                        i = HandleLoops(ptr, IntOutput, i, UserInput);
                        break;
                    case ',':
                        if (UserInputIndex < UserInput.Length)
                        {
                            char inputChar = UserInput[UserInputIndex];
                            UserInputIndex++;
                            IntOutput[ptr] = (int)inputChar;
                        }
                        break;
                    case '.':
                        Output[ptr] = (char)IntOutput[ptr];
                        System.Console.Write(Output[ptr]);
                        break;
                }
            }
        }

        return ClosingIndex;
    }

    private int FindClosingBracketIndex(int startIndex)
    {
        int openBrackets = 1;
        for (int i = startIndex + 1; i < input?.Length; i++)
        {
            if (input[i] == '[') openBrackets++;
            if (input[i] == ']') openBrackets--;
            if (openBrackets == 0) return i;
        }
        return -1;
    }
}