using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject.Managers
{
    public static class FileIOManager
    {
        public static SpriteFont font = Shared.Content.Load<SpriteFont>("fonts/scoreFont");
        public static void WriteScoreToFile()
        {
            string fileName = @"HighScores.txt";
            using (FileStream fileStream = new FileStream(fileName, FileMode.Append, FileAccess.Write))
            using (StreamWriter streamWriter = new StreamWriter(fileStream))
            {
                streamWriter.WriteLine(Shared.TotalScore);
            }
        }

        public static void ReadTopScoresFromFile()
        {
            var TopScores = File.ReadLines("HighScores.txt")
            .Select(scoreline => int.Parse(scoreline))
            .OrderByDescending(score => score)
            .Take(10);

            int counter = 0;
            int spacing = 130;

            foreach (var TopScore in TopScores)
            { 
                counter++;
                Shared.SpriteBatch.DrawString(font , counter + " - " + TopScore, new Vector2(715, spacing), Color.White);
                spacing += 60;
            }
        }
    }
}
