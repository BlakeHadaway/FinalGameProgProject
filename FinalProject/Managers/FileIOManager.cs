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
    /// <summary>
    /// this class is for saving and loading the highscores from a text file
    /// also making this class static to call it without having to create an instance
    /// </summary>
    public static class FileIOManager
    {
        // declaring a font to be used on the scores page
        public static SpriteFont font = Shared.Content.Load<SpriteFont>("fonts/scoreFont");

        /// <summary>
        /// this method is to write the player score to the files after they die
        /// </summary>
        public static void WriteScoreToFile()
        {
            // creating a string for the file name
            string fileName = @"HighScores.txt";

            // creating filestream var, and setting the mode to append, and access to write
            using (FileStream fileStream = new FileStream(fileName, FileMode.Append, FileAccess.Write))
            {
                // creating a streamwriter var
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    // writing the new highscore to the file
                    streamWriter.WriteLine($"{Shared.playerName}-" + Shared.Score);
                }
            }
        }

        /// <summary>
        /// This is to read the top 10 highscores from the file
        /// </summary>
        public static void ReadTopScoresFromFile()
        {
            // This is defining a var to take the scores from the file,
            // while parsing for the names and scores
            var scores = File.ReadLines("HighScores.txt")
            // selecting the line and using lamda expression to path to the line split
            .Select(line => {
            // then spliting lines base on the dash
            string[] parts = line.Split('-');
            // then return a new sting with name and score
            return new { Name = parts[0], Score = int.Parse(parts[1]) };
            })
            // then order by descending, using a lamda expression to path to the score 
            .OrderByDescending(highScore => highScore.Score)
            // then taking the top 10 reults
            .Take(10);

            // declaring a counter and spacing
            int counter = 0;
            int spacing = 130;

            // foreach of the top scores in scores
            foreach (var TopScore in scores)
            { 
                // adding to the counter (being # 1 score, then 2 and etc.
                counter++;

                // drawing the string to display the highscores
                Shared.SpriteBatch.DrawString(font , counter + " - " + TopScore, new Vector2(500, spacing), Color.White);

                // adding to the spacing so it spaces well
                spacing += 60;
            }
        }
    }
}
