using System.Diagnostics;

namespace AdventOfCode23.Day10
{
    internal class Solver : AdventSolver
    {
        public override string GetPuzzleOutput1()
        {
            // Generate pipe layout
            Pipe[][] pipes = new Pipe[puzzleInput.Length][];
            for (int i = 0; i < puzzleInput.Length; i++)
            {
                pipes[i] = new Pipe[puzzleInput[i].Length];
                for (int j = 0; j < puzzleInput[i].Length; j++)
                {
                    pipes[i][j] = new Pipe(puzzleInput[i][j]);
                }
            }

            Pipe currentPosition = null;

            // Connect pipes
            for (int y = 0; y < pipes.Length; y++)
            {
                for (int x = 0; x < pipes[y].Length; x++)
                {
                    Pipe currentPipe = pipes[y][x];
                    switch (currentPipe.Symbol)
                    {
                        case 'S':
                            currentPosition = currentPipe;
                            break;
                        case 'F':
                            currentPipe.Down = GrabPipe(pipes, x, y + 1);
                            currentPipe.Right = GrabPipe(pipes, x + 1, y);
                            break;
                        case '7':
                            currentPipe.Down = GrabPipe(pipes, x, y + 1);
                            currentPipe.Left = GrabPipe(pipes, x - 1, y);
                            break;
                        case 'L':
                            currentPipe.Up = GrabPipe(pipes, x, y - 1);
                            currentPipe.Right = GrabPipe(pipes, x + 1, y);
                            break;
                        case 'J':
                            currentPipe.Up = GrabPipe(pipes, x, y - 1);
                            currentPipe.Left = GrabPipe(pipes, x - 1, y);
                            break;
                        case '|':
                            currentPipe.Up = GrabPipe(pipes, x, y - 1);
                            currentPipe.Down = GrabPipe(pipes, x, y + 1);
                            break;
                        case '-':
                            currentPipe.Left = GrabPipe(pipes, x - 1, y);
                            currentPipe.Right = GrabPipe(pipes, x + 1, y);
                            break;
                    }
                }
            }


            return (TraversePipe(pipes, currentPosition) / 2).ToString();
        }

        public override string GetPuzzleOutput2()
        {
            return "ERR";
        }

        private static Pipe GrabPipe(Pipe[][] pipes, int x, int y)
        {
            if (x < 0 || x >= pipes[0].Length || y < 0 || y >= pipes.Length) return null;

            return pipes[y][x];
        }

        private static long TraversePipe(Pipe[][] pipes, Pipe start)
        {
            // Very lazy traversion
            Dictionary<Pipe, bool> pairs = new();

            long steps = 1;
            Pipe prev = start;
            Pipe curr = start.First();

            while(curr != start)
            {
                Pipe next = curr.Next(prev);
                prev = curr;
                curr = next;
                steps++;
            }

            return steps;
        }

        protected override string GetFolderName()
        {
            return "Day10";
        }
    }
}
