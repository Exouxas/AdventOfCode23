namespace AdventOfCode23
{
    public abstract class AdventSolver
    {
        protected string[] puzzleInput;
        public AdventSolver()
        {
            puzzleInput = File.ReadAllLines("../../../" + GetFolderName() + "/PuzzleInput.txt");
        }

        protected abstract string GetFolderName();
        public abstract string GetPuzzleOutput1();
        public abstract string GetPuzzleOutput2();
    }
}