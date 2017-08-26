using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EPQProjectCMD
{
    class CaesarAndVigenere
    {
        public static readonly double[] ENGLISH_FREQUENCIES = new double[] { 0.08167, 0.01492, 0.02782, 0.04253, 0.12702, 0.02228, 0.02015, 0.06094, 0.06966, 0.00153, 0.00772, 0.04025, 0.02406, 0.06749, 0.07507, 0.01929, 0.00095, 0.05987, 0.06327, 0.09056, 0.02758, 0.00978, 0.02360, 0.00150, 0.01974, 0.00074 };
        public static readonly string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        // A housekeeping function to strip the irrelevant characters from a piece of text, such as spaces or punctuation
        public static string stripText(string text)
        {
            return Regex.Replace(text, "[^a-zA-Z]", "");
        }

        // This function will encrypt some text using the Caesar cipher
        // If `encrypt` is False, then it will decrypt the text
        public static string caesarText(string text, char key, bool encrypt)
        {
            string ciphertext = "";
            key = Char.ToUpper(key);
            text = stripText(text);
            foreach (char letter in text.ToUpper())
            {
                ciphertext += caesarLetter(letter, key, encrypt);
            }
            return ciphertext;
        }

        // This function will encrypt a single character using the Caesar cipher
        // If `encrypt` is False, then it will decrypt the text
        static char caesarLetter(char letter, char key, bool encrypt)
        {
            if (encrypt)
            {
                return (char)(((int)letter - 65 + (int)key - 65) % 26 + 65);
            }
            else
            {
                return (char)(((int)letter - (int)key + 26) % 26 + 65);
            }
        }

        // This function will encrypt some text using the Vigenere cipher
        // If `encrypt` is False, then it will decrypt the text
        public static string vigenereText(string text, string key, bool encrypt)
        {
            string ciphertext = "";
            text = stripText(text).ToUpper();
            key = stripText(key).ToUpper();
            int keyLength = key.Length;

            for (int x = 0; x < text.Length; x++)
            {
                ciphertext += caesarLetter(text[x], key[x % keyLength], encrypt);
            }

            return ciphertext;
        }

        // This function will find the frequencies of all of the letters in a given piece of text
        public static int[] letterFrequencyAnalyser(string text)
        {
            text = stripText(text).ToUpper();
            int[] letterFrequencies = Enumerable.Repeat(0, 26).ToArray();
            foreach (char letter in text)
            {
                letterFrequencies[(int)letter - 65] += 1;
            }

            return letterFrequencies;
        }

        // This function will find Freidman's Index of Coincidence for a piece of text
        public static double indexOfCo(string text)
        {
            text = stripText(text).ToUpper();
            int sum = 0;
            int[] letterFreqs = letterFrequencyAnalyser(text);
            foreach (int freq in letterFreqs)
            {
                sum += freq * (freq - 1);
            }
            return (double)(sum * letterFreqs.Length) / (double)(text.Length * (text.Length - 1));
        }

        // This function will split text into groups of every n'th letter; 
        // letters that were encrypted with the same part of a Vigenere key
        public static string[] vigenereColumnSeparator(string text, int keyLength)
        {
            text = stripText(text).ToUpper();
            string[] textArray = Enumerable.Repeat("", keyLength).ToArray();
            for (int i = 0; i < text.Length; i++)
            {
                textArray[i % keyLength] += text[i];
            }
            return textArray;
        }

        public static double[] vigenereKeyLengthScores(string text, int lengthCeiling)
        {
            double[] scores = Enumerable.Repeat(0.0, lengthCeiling + 1).ToArray();
            for (int keyScore = 1; keyScore < lengthCeiling + 1; keyScore++)
            {
                foreach (string columnText in vigenereColumnSeparator(text, keyScore))
                {
                    scores[keyScore] += indexOfCo(columnText);
                }
                scores[keyScore] /= (double)keyScore;
            }
            return scores;
        }

        // A function that attempts to guess the key length of a piece of text encrypted with the Vigenere cipher
        static int[] vigenereBestKeyLengthsGuesser(string text, int lengthCeiling, int maxGuesses)
        {
            double[] guesses = vigenereKeyLengthScores(text, lengthCeiling);

            double[] sortedGuesses = new double[lengthCeiling + 1];
            Array.Copy(guesses, sortedGuesses, lengthCeiling + 1);
            Array.Sort(sortedGuesses);
            Array.Reverse(sortedGuesses);

            int[] bestGuesses = new int[maxGuesses];
            for (int i = 0; i < maxGuesses; i++)
            {
                bestGuesses[i] = Array.IndexOf(guesses, sortedGuesses[i]);
            }
            return bestGuesses;
        }

        // This function will give the Chi squared score of a piece of text,
        // how likely it is to be part of the English language by default
        public static double chiSquaredScore(string text, double[] expectedFreqs)
        {
            text = stripText(text).ToUpper();
            int length = text.Length;
            int[] freqs = letterFrequencyAnalyser(text);
            double chi = 0;

            // for (count, expectedProportion) in zip(freqs, expectedFreqs)
            for (int i = 0; i < 26; i++)
            {
                double expected = length * expectedFreqs[i];
                chi += ((freqs[i] - expected) * (freqs[i] - expected)) / expected;
            }
            return chi;
        }
        public static double chiSquaredScore(string text)
        {
            return chiSquaredScore(text, ENGLISH_FREQUENCIES);
        }

        // This function will attempt to guess the key letter a piece of text all encoded with the same letter of a Vigenere key
        public static char[] vigenereKeyLetterBreaker(string reducedText, int numberOfKeys)
        {
            double[] scores = new double[26];
            for (int i = 0; i < 26; i++)
            {
                scores[i] = chiSquaredScore(caesarText(reducedText, ALPHABET[i], false));
            }
            double[] sortedScores = new double[26];
            Array.Copy(scores, sortedScores, 26);
            Array.Sort(sortedScores);

            char[] bestScores = new char[numberOfKeys];
            for (int i = 0; i < numberOfKeys; i++)
            {
                bestScores[i] = ALPHABET[Array.IndexOf(scores, sortedScores[i])];
            }
            return bestScores;
        }

        public static char[] vigenereKeyLetterBreaker(string reducedText)
        {
            return vigenereKeyLetterBreaker(reducedText, 1);
        }

        // This function will take a list of possible key letters for each letter in a key,
        // and will return a list of possible overall keys
        public static string[] joinPossibleKeys(char[][] arrayOfCombinationsForEachLetter)
        {
            char[][] letterCombos = arrayOfCombinationsForEachLetter;
            if (letterCombos.Length == 1)
            {
                string[] possibleKeys = new string[letterCombos[0].Length];
                for (int i = 0; i < letterCombos[0].Length; i++)
                {
                    possibleKeys[i] = Char.ToString(letterCombos[0][i]);
                }
                return possibleKeys;
            }
            else
            {
                List<string> possibleKeys = new List<string>();
                string[] joinedEndsOfKeys = joinPossibleKeys(letterCombos.Skip(1).ToArray());
                foreach (char letter in letterCombos[0])
                {
                    foreach (string key in joinedEndsOfKeys)
                    {
                        possibleKeys.Add(letter + key);
                    }
                }
                return possibleKeys.ToArray();
            }
        }

        // This function will attempt to find the plaintext from a piece of ciphertext encrypted with the Vigenere cipher, and a suspected key length
        public static string[] breakVigenereWithKeyLength(string text, int keyLength, int numberOfLetterKeys, int maxFinalGuesses)
        {
            string[] textGroups = vigenereColumnSeparator(text, keyLength);
            char[][] possibleKeysByLetter = new char[keyLength][];
            for (int i = 0; i < textGroups.Length; i++)
            {
                possibleKeysByLetter[i] = vigenereKeyLetterBreaker(textGroups[i], numberOfLetterKeys);
            }

            string[] possibleKeys = joinPossibleKeys(possibleKeysByLetter);
            double[] scores = new double[possibleKeys.Length];
            for (int i = 0; i < possibleKeys.Length; i++)
            {
                scores[i] = (chiSquaredScore(vigenereText(text, possibleKeys[i], false)));
            }
            double[] sortedScores = new double[possibleKeys.Length];
            Array.Copy(scores, sortedScores, possibleKeys.Length);
            Array.Sort(sortedScores);

            string[] bestKeys = new string[maxFinalGuesses];
            for (int i = 0; i < maxFinalGuesses; i++)
            {
                if (i >= scores.Length)
                    break;
                bestKeys[i] = possibleKeys[Array.IndexOf(scores, sortedScores[i])];
            }
            return bestKeys;
        }
        
        //static void Main(string[] args)
        //{
        //  
        //    string hello = "ITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESS";
        //    string hello2 = "LKWFLWYEGXVKOKMLDEXBWNAXMKVWTKVKOKMLDEXBWNAXMKVALXRWWNLGFMNMZRSYAHRGJHIWOTELJHSXVJ";
        //    string[] m3rotors = new string[] { "EKMFLGDQVZNTOWYHXUSPAIBRCJ", "AJDKSIRUXBLHWTMCQGZNPYFVOE", "BDFHJLCPRTXVZNYEIWGAKMUSQO" };
        //    //string reflectorB = "YRUHQSLDPXNGOKMIEBFZCWVJAT";
        //    char[][] testKey = new char[][] { new char[] { 'A', 'B' }, new char[] { 'C', 'D' }, new char[] { 'E', 'F' } };
        //    /*foreach (char item in reverseRotor(m3rotors[1]))
        //    {
        //        if (item != null)
        //            Console.Write(item + ", ");
        //        else
        //            Console.Write("null, ");
        //    }*/
        //
        //    Enigma e = new Enigma(new int[] { 1, 2, 3 }, 2, "LBJ", new char[][] { new char[] { 'A', 'D' }, new char[] { 'R', 'C' }, new char[] { 'L', 'M' }, new char[] { 'E', 'V' } }, "JFK");
        //    string text2 = "TherewereakingwithalargejawandaqueenwithaplainfaceonthethroneofEnglandtherewereakingwithalargejawandaqueenwithafairfaceonthethroneofFranceInbothcountriesitwasclearerthancrystaltothelordsoftheStatepreservesofloavesandfishesthatthingsingeneralweresettledforeverItwastheyearofOurLordonethousandsevenhundredandseventyfiveSpiritualrevelationswereconcededtoEnglandatthatfavouredperiodasatthisMrsSouthcotthadrecentlyattainedherfiveandtwentiethblessedbirthdayofwhomapropheticprivateintheLifeGuardshadheraldedthesublimeappearancebyannouncingthatarrangementsweremadefortheswallowingupofLondonandWestminsterEventheCocklaneghosthadbeenlaidonlyarounddozenofyearsa";
        //    Console.WriteLine(e.encrypt(text2));
        //
        //    int[] pos = new int[] { 25, 17, 4 };
        //    e = new Enigma(new int[] { 1, 2, 3 }, 2, pos, new char[][] { new char[] { 'A', 'D' }, new char[] { 'R', 'C' } }, new int[] { 0, 13, 13 });
        //    //Console.WriteLine(e.enigmaEncrypt("ITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESI"));
        //    //Console.WriteLine("\n\n\n" + (new Enigma("123", 'B', "ARN", Enigma.PlugboardMaker("AD RC"), "QVA")).enigmaEncrypt("ITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESI"));
        //    //e.setRotors(new int[] { 3, 2, 1 });
        //    //Console.WriteLine(e.enigmaEncrypt("ITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESI"));
        //
        //    //    m3rotors, reflectorB, new char[] { 'S', 'D', 'T' }, new char[] { 'E', 'V' }, new char[][] { new char[] { 'A', 'D' }, new char[] { 'R', 'C' } }, new char[] { 'L', 'B', 'A' }));
        //
        //
        //    /*Console.WriteLine("\n\n\n" + Enigma.sinkov("POETYRFFNTQYXAEXJOMUJQHFOCHEUUEWEXJUXDRZJTHGFQBIVDKXQQJTNQLNSRVXJDFPJQGIHIMEAPPMIJKUILPRNXHRIWXPUPVANONXQBMSQBJVLEFRMJUNTBVLXKNTASEWHYJCYMFGKUHGWWAIIZBVRZGSWKUFZYXVPWESKIBCUINBZLOKCPAEKSOODMHFEOMJYDMLFYGSWBSXXELMOTBBNLNAVLVAVWVEIWWMJAHNYLWFHRMYMXEWZKNQRJZQTCLCSLBIZEEJJOEMYMNOJNMKFDDYHQYTLTHRQYYPZQDYDXQXAJYRIWZNUDSGMXKCYYLYWQVMVFJDXVYOZMNUTANGDTOSPKZJQVKCSZXHKYECRZHVNNKDJVOIFGVKZCQKDJSAMCDEKWMONVEGFJTGTWTFTOTEEZPUPPCCUELBMTQXEJPFTCUAGRZZBGBVVGYQQP"));
        //    Console.WriteLine(Enigma.sinkov("ITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESI"));
        //    Console.WriteLine(Enigma.sinkov("TherewereakingwithalargejawandaqueenwithaplainfaceonthethroneofEnglandtherewereakingwithalargejawandaqueenwithafairfaceonthethroneofFranceInbothcountriesitwasclearerthancrystaltothelordsoftheStatepreservesofloavesandfishesthatthingsingeneralweresettledforeverItwastheyearofOurLordonethousandsevenhundredandseventyfiveSpiritualrevelationswereconcededtoEnglandatthatfavouredperiodasatthisMrsSouthcotthadrecentlyattainedherfiveandtwentiethblessedbirthda"));
        //    Random random = new Random();
        //    Console.WriteLine(Enigma.sinkov(new string(Enumerable.Repeat(ALPHABET, 450).Select(s => s[random.Next(s.Length)]).ToArray())));
        //    */
        //
        //    e = new Enigma(new int[] { 1, 2, 3 }, 2, "ARN", new char[0][], "BNM");
        //    //const string mysteryText = "WOYEPUCQSLMPXLLKNCIZPNTRBBIIXVBVOZREQHWBHEDNNOKNEICSNVKOPHEGUCRBHRYDSFSILPNEFIZFZSYFIZLXIORLNTSQPFSEGVCJZWOHNYRIZTLJSKHSUJQLYEFEMFXRRNWCOKRONSKIXKJRHBWRHLLRJONPPVHBEDOPSKTHCSVQGGSIQENSYKCZLICCCIVCCBBHFHZWNYNIDLWJVWOJGAYBDJBRGYGSJCNVQUFLVVVOPETPRGDNEIYHQVQNBTJEULIWHCDVCHSXCEIVSTGOXSQNRDLRNZPWKPQCPTKTYJMJVJJTPIXLDTVZQMTCJMEWJSEIPOVRXXDGGEXDTQTMMZMVFUPVOIEFSEVFBRWGTEEPZLSIBLEDQCRVDDHKJEQVAZRVKEDNERRPUMPNHAVZKTYVNWYPIZSQCOCTXOMDZGYMQNWOSSZVYLBGUWEDVYCFUISLFXTDQXSUXFHVJESFNVWWGKHGBJUEAGVCEBVEQZPSVGOKWOFHXXUSQWDZOSLVUHLUSPVYQDVDXBMHDBSEMVIFICTPBYZPECMKNCLSOAXCLMQTYMBHTXGTZTENULQFSCBXSFVXZAARFOVHHHXHVPTKILUQZQWDYLTCBXORHBAFUSZTQWJTJTOVKNKCOECAXDYOLP";
        //    string mysteryText = "PNKZYMMHCJPGCEEQFAXKEKVJCZEZIEYCKBSMVLGCPKAERLPIIKCEFCBEVCHVYCUAJUKXAMPPMTMZHLDMDBQQRNRNTPJLEGBOGBUWEHNCYAGYFJSWPDVYDLWCTKCNLPLZTTKJUOBEPINPYEDMUNNLPTKBREMPIYIJDZFZBMPJCTSBBGDNAVNGMDJFHIIUENGBNGPFJPKKMCHSUWYCBVEIMYHBBCRIFPGATOOQGWYTPVYSEQNOTDSGIKPQKXJQZRUFDDJJPOIMECCWQCFEEKDCXWJZKLMKVRBAIGSQFYQCOVBTFKTRIIZAKBXFPDFHBOZVIGVIZBKSHCQWARHFAAKYGPKTELMZOVEPUTTRIUIZZVJKOHLSQKKAETAOHIDKYSSITNHHUTYESEEUSPMUFXLODQGWHJFCLUVBEJLYRXBKCWOIKFRSHDQEOZSXMZCETNQCXCRARVETEUBSCFXBHWMWTJBEZFDVCILZNCZVLWLXPLCAOSLGJMKGQFFDXYMNLDPGRDMSNXIUCZNCWRSUNERKNLXKTMSFTMRNLKWDAJFSRQJSKDHJRSFGGFRLHHDOFXYVVJJWJDJMPUMHUHZCRMVXCLFQUXNNBYYPYUJPECPRDGGZQVZOYYVVVILSEYRTNYXIROEAWPRSMR";
        //    char[][] plugBoard = new char[][] { new char[] { 'A', 'D' }, new char[] { 'R', 'C' } };
        //    int[][] results = Enigma.findBestRingSetting(new int[] { 1, 2, 3 }, new int[] { 25, 4, 1 }, mysteryText);
        //
        //
        //    string text = stripText("TherewereakingwithalargejawandaqueenwithaplainfaceonthethroneofEnglandtherewereakingwithalargejawandaqueenwithafairfaceonthethroneofFranceInbothcountriesitwasclearerthancrystaltothelordsoftheStatepreservesofloavesandfishesthatthingsingeneralweresettledforeverItwastheyearofOurLordonethousandsevenhundredandseventyfiveSpiritualrevelationswereconcededtoEnglandatthatfavouredperiodasatthisMrsSouthcotthadrecentlyattainedherfiveandtwentiethblessedbirthdayofwhomapropheticprivateintheLifeGuardshadheraldedthesublimeappearancebyannouncingthatarrangementsweremadefortheswallowingupofLondonandWestminsterEventheCocklaneghosthadbeenlaidonlyarounddozenofyearsa").ToUpper();
        //    Console.WriteLine("Score of plaintext: " + Enigma.sinkov(text));
        //    text = Regex.Replace(text, Char.ToString('A'), Char.ToString('d'));
        //    text = Regex.Replace(text, Char.ToString('D'), Char.ToString('a'));
        //    text = Regex.Replace(text, Char.ToString('R'), Char.ToString('c'));
        //    text = Regex.Replace(text, Char.ToString('C'), Char.ToString('r'));
        //    text = text.ToUpper();
        //
        //    /*Console.WriteLine("Score of plugged plaintext from python: " + Enigma.sinkov("THECEWQCEDKINGWITYDLDCGWJDWDNADQUEXNWITHDPKDINFDREJNTHETHCONEVUENVLANATHECEWECEDKINGWITHDLKCGEJDWDNADQFEENWITHTFDICFDREONTHETHCONEOOTCDGREZNBOTHROUKTCIPSITODSRLEDCECJHDNRCYVTDLTOTHELOCASGFTHZYMDTDICESECVESOFLGDVESDNAFQSHOSTGDTTHIFGSINGENECDLWECYSXTTLEAFOCEVECITWDSTUKYXDCOZOUCLOCAONETSTUYDNASEVEIHUNACEADNASEVENTRFIVESPLCITUDLCEVELGTIGNSWEJERONREAEATOENGLDNADTTODTFDVOUCEAPECCOWISAPTHISMCOSZUTHFOTJWDACEREITLYDTTDINEAHECBIOEDNAZWENTIETHBLESSEABICTGADIOFWHOMDPQOPHETIRPCIVDTEINTHELIFEGHDCOSHDAHECDLAEATHESUBLIMEAPPEDCDNREBYDNNSUPRINGFHDTDCCDNLEMENTSWNCEMZAEFHCPHESWDLLOWINGUPOFLONAOMDNAWESTSTTSTECEVENTHERORKLDNEBHOSBHDAOEEOLDIAONLYDCOUNAAOHENLQYIDCSD"));
        //    Console.WriteLine("Score of plugged plaintext from C#: " + Enigma.sinkov(e.encrypt("THECEWQCEDKINGWITYDLDCGWJDWDNADQUEXNWITHDPKDINFDREJNTHETHCONEVUENVLANATHECEWECEDKINGWITHDLKCGEJDWDNADQFEENWITHTFDICFDREONTHETHCONEOOTCDGREZNBOTHROUKTCIPSITODSRLEDCECJHDNRCYVTDLTOTHELOCASGFTHZYMDTDICESECVESOFLGDVESDNAFQSHOSTGDTTHIFGSINGENECDLWECYSXTTLEAFOCEVECITWDSTUKYXDCOZOUCLOCAONETSTUYDNASEVEIHUNACEADNASEVENTRFIVESPLCITUDLCEVELGTIGNSWEJERONREAEATOENGLDNADTTODTFDVOUCEAPECCOWISAPTHISMCOSZUTHFOTJWDACEREITLYDTTDINEAHECBIOEDNAZWENTIETHBLESSEABICTGADIOFWHOMDPQOPHETIRPCIVDTEINTHELIFEGHDCOSHDAHECDLAEATHESUBLIMEAPPEDCDNREBYDNNSUPRINGFHDTDCCDNLEMENTSWNCEMZAEFHCPHESWDLLOWINGUPOFLONAOMDNAWESTSTTSTECEVENTHERORKLDNEBHOSBHDAOEEOLDIAONLYDCOUNAAOHENLQYIDCSD")));
        //    */
        // 
        //    Console.WriteLine("Positions: [" + results[0][0] + ", " + results[0][1] + ", " + results[0][2] + "] " +
        //        "Rings: [" + results[1][0] + ", " + results[1][1] + ", " + results[1][2] + "] ");
        //
        //    System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
        //
        //    //DataRow[] dRows = Enigma.findBestRotors(mysteryText, 3, 1000);
        //    //DataTable dt = Enigma.breakEnigma(mysteryText, 3, 10, 2);
        //    DataRow[] dr = Enigma.finalEnigma(mysteryText, 3, 100, 4, 10);
        //
        //    //DataTable dt = Enigma.findRingsAndRotors(mysteryText, 3, 100);
        //    /*char[][] plugs = (Enigma.findPlugboard(mysteryText, new int[] { 1, 2, 3 }, new int[] { 25, 17, 14 },
        //        new int[] { 0, 13, 13 }, 2));
        //    StringBuilder sb = new StringBuilder();
        //    foreach (char[] plug in plugs)
        //    {
        //        sb.Append("[" + plug[0] + ", " + plug[1] + "], ");
        //    }
        //    sb.Remove(sb.Length - 1, 1);
        //    Console.WriteLine("Plugs found: " + sb.ToString());*/
        //    //Enigma.sinkov("ITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESI");
        //
        //    watch.Stop();
        //    long elapsedMs = watch.ElapsedMilliseconds;
        //    Console.WriteLine((double)elapsedMs/1000.0);
        //
        //    Enigma f = new Enigma(new int[] { 1, 2, 3 }, 2, "ARN", new char[][] { new char[] { 'A', 'D' }, new char[] { 'R', 'C' } }, "QVA");
        //    Console.WriteLine("Answer: [" + f.rotorPositions[0] + ", " + f.rotorPositions[1] + ", " + f.rotorPositions[2] + "]\n");
        //
        //    //foreach (DataRow row in dt.Select())
        //    foreach (DataRow row in dr)
        //    {
        //        int[] positions = row.Field<int[]>(1);
        //        int[] rotors = row.Field<int[]>(2);
        //        int[] rings = row.Field<int[]>(3);
        //        char[][] plugs2 = row.Field<char[][]>(4);
        //        //char[][] plugs = new char[0][];
        //        //if (positions[0] == 25)
        //        //  if (positions[1] == 4)
        //        //      if (positions[2] == 1)
        //        //          Console.Write("Found it!: ");
        //        Enigma s = new Enigma(rotors, 2, positions, plugs2, rings);
        //        Console.WriteLine(s.ToString() + " Score: " + row.Field<double>(0));
        //      
        //        //Console.WriteLine("Position: [" + positions[0] + ", " + positions[1] + ", " + positions[2] + "], Rotors: [" +
        //        //    rotors[0] + ", " + rotors[1] + ", " + rotors[2] + "], Rings: ["+ rings[0] + ", " + rings[1] + ", " +
        //        //    rings[2] + "] Old Score: " + row.Field<double>(0));
        //    }
        //
        //    /*var watch = System.Diagnostics.Stopwatch.StartNew();
        //
        //    //char[][] plugBoard = new char[][] { new char[] { 'A', 'D' }, new char[] { 'R', 'C' } };
        //
        //    for (int i = 0; i < 17576; i++)
        //    {
        //        Enigma.sinkov((new Enigma("123", 'B', "SDT", plugBoard, "LBA"))
        //            .encrypt("ITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESI"));
        //
        //        //Enigma.sinkov("ITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESI");
        //    }
        //
        //    watch.Stop();
        //    var elapsedMs = watch.ElapsedMilliseconds;
        //    Console.WriteLine(elapsedMs);*/
        //    //Console.WriteLine(joinPossibleKeys(testKey));
        //    //Console.WriteLine(chiSquaredScore(hello2));
        //
        //}
    }
}
