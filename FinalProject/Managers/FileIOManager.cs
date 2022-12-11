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
                streamWriter.WriteLine($"{Shared.playerName}-" + Shared.Score);
            }
        }

        public static void ReadTopScoresFromFile()
        {
            var scores = File.ReadLines("HighScores.txt")
            .Select(line => {
            string[] parts = line.Split('-');
            return new { Name = parts[0], Score = int.Parse(parts[1]) };
            }).OrderByDescending(highScore => highScore.Score)
            .Take(10);

            int counter = 0;
            int spacing = 130;

            foreach (var TopScore in scores)
            { 
                counter++;
                Shared.SpriteBatch.DrawString(font , counter + " - " + TopScore, new Vector2(500, spacing), Color.White);
                spacing += 60;
            }
        }
    }
}
