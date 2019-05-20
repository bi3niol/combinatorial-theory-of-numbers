using CombinatorialTheoryOfNumbers.LibDotNet;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CombinatorialTheoryOfNumbers.AppDotNet
{
    public class FileStatePresenter : IStatePresenter<int, int>
    {
        StreamWriter stream;

        public FileStatePresenter(string filename)
        {
            stream = new StreamWriter(filename);
        }

        public void WriteString(string str)
        {
            stream.WriteLine(str);
        }

        public void ShowState(IGameState<int, int> state)
        {
            foreach (var result in state.RoundResults)
            {
                stream.Write("{0}:{1} ", result.Player1Result, result.Player2Result);
            }
            stream.WriteLine();
        }

        public void Close()
        {
            stream.Close();
        }
    }
}
