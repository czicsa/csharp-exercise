using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextStatistics.Data;

namespace TextStatistics.Classes
{
    public static class FileReader
    {
        // --- új sor karakterek
        private const char CR = '\r';
        private const char LF = '\n';

        /// <summary>
        /// Egy fájlból kiolvassa a mondatokat
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<SentenceData> GetSentencesFromFile(string path)
        {
            // --- megvizsgáljuk, hogy létezik-e a fájl, ha nem létezik kivételt dobunk
            if (!File.Exists(path))
            {
                throw new Exception("A megadott útvonal nem található!");
            }

            // --- elkésztjük az mondatok listáját
            var result = new List<SentenceData>();

            // --- megnyitjuk a fájlt olvasásra
            using (var reader = new StreamReader(path))
            {
                // --- készítünk egy mondat példányt, és egy üres szót
                var sentence = new SentenceData();
                var word = "";

                // --- addig megyünk a fájl karakterein, amíg a végére nem érünk
                do
                {
                    // --- kiolvassuk a következő karaktert
                    var character = (char)reader.Read();

                    // --- ha szóköz, és a szavunk nem üres, akkor elkészült egy szó (új üres szót készítünk)
                    if (character == ' ')
                    {
                        if (AddNewWord(sentence.Words, word))
                        {
                            word = "";
                        }
                    }
                    // --- ha mondat végi írásjel, akkor elkészült egy szó, ha nem üres, és elkészült egy mondat, ha vannak benne szavak (új üres szót, és mondatot készítünk)
                    else if (character == '.' || character == '!' || character == '?')
                    {
                        if (AddNewWord(sentence.Words, word))
                        {
                            word = "";
                        }
                        if (AddNewSentence(result, sentence))
                        {
                            sentence = new SentenceData();
                        }
                    }
                    // --- ha ez az utolsó karakter
                    else if (reader.EndOfStream)
                    {
                        word = AddCharacterToWord(word, character);
                        if (AddNewWord(sentence.Words, word))
                        {
                            word = "";
                        }
                        if (AddNewSentence(result, sentence))
                        {
                            sentence = new SentenceData();
                        }
                    }
                    // --- egyébként hozzá kell fűzni a szóhoz az aktuális karaktert
                    else
                    {
                        // --- ha nem különleges karakter, akkor hozzáfűzzük a szóhoz a karaktert
                        word = AddCharacterToWord(word, character);
                        
                    }
                } while (!reader.EndOfStream);

                // --- ha esetleg nem írásjellel végződik a fájl, akkor is hozzáadjuk az utolsó mondatot
                AddNewSentence(result, sentence);
            }


            return result;
        }

        /// <summary>
        /// Hozzáad egy szót a mondta szavaihoz, ha nem üres szó
        /// </summary>
        /// <param name="words"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        private static bool AddNewWord(List<string> words, string word)
        {
            if (word.Length > 0)
            {
                words.Add(word);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Hozzáad egy mondatot a mondatokhoz, ha van benne szó
        /// </summary>
        /// <param name="sentences"></param>
        /// <param name="sentence"></param>
        /// <returns></returns>
        private static bool AddNewSentence(List<SentenceData> sentences, SentenceData sentence)
        {
            if (sentence.Words.Count > 0)
            {
                sentences.Add(sentence);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Hozzáad egy karaktert a szóhoz, ha nem különleges karakter
        /// </summary>
        /// <param name="word"></param>
        /// <param name="character"></param>
        private static string AddCharacterToWord(string word, char character)
        {
            if (character != CR && character != LF && character != ',' && character != '-' && character != '"' && character != '\'' && character != '+')
            {
                word += character;
            }
            return word;
        }
    }
}
