using EncryptionToolsGUI;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace EPQProjectCMD
{
    class Enigma
    {      
        public static double sinkov(string text)
        {
            double sinkov = 0;

            int[] freqs = CaesarAndVigenere.letterFrequencyAnalyser(text);

            for (int i = 0; i < 26; i++)
            {
                sinkov += freqs[i] * LOG_ENGLISH_FREQS[i];
            }

            return sinkov;
        }

        // A housekeeping function to strip the irrelevant characters from a piece of text, such as spaces or punctuation
        static string stripText(string text)
        {
            return Regex.Replace(text, "[^a-zA-Z]", "");
        }

        // This simple function takes a list of plugcable pairings, and makes it into a list of letters affected
        string getListOfPlugboardLetters()
        {
            string letters = "";
            foreach (char[] plugCable in plugboard)
            {
                foreach (char letter in plugCable)
                {
                    letters += letter;
                }
            }
            return letters;
        }

        // This simple function finds the other letter that a letter is paired with in the plugboard
        char findOtherLetterInPlug(char letter)
        {
            foreach (char[] plugCable in plugboard)
            {
                if (plugCable.Contains(letter))
                    if (Array.IndexOf(plugCable, letter) == 0)
                        return plugCable[1];
                    else
                        return plugCable[0];
            }
            return '-';
        }

        // This applies the plugboard to a piece of text, swapping letters as appropriate
        string applyPlugboard(string text)
        {
            text = stripText(text).ToUpper();
            foreach (char letter in getListOfPlugboardLetters())
            {
                char swapLetter = Char.ToLower(findOtherLetterInPlug(letter));
                text = Regex.Replace(text, Char.ToString(letter), Char.ToString(swapLetter));
            }
            text = text.ToUpper();
            return text;
        }

        // A function used in rototating the rotors that accounts for movement of the rotor on the output side of the rotor
        static String incRotor(string rotor, int inc)
        {
            return rotor.Substring(inc) + rotor.Substring(0, inc);
        }

        // A function used in rototating the rotors that accounts for movement of the rotor on the input side of the rotor
        static String adjustRotorLetters(string rotor, int inc)
        {
            int rotorLength = rotor.Length;
            StringBuilder sb = new StringBuilder(26);
            foreach (char letter in rotor)
            {
                //int x = (ALPHABET.IndexOf(letter) + 26 - inc) % rotorLength;
                //if (x < 0 || x >= 26)
                //    Console.WriteLine("Bad index: " + x + "Inc: " + inc);
                sb.Append(ALPHABET[(ALPHABET.IndexOf(letter) + 52 - inc) % rotorLength]);
            }
            return sb.ToString();
        }

        // This function simulates passing current through a rotor
        static char passThroughRotor(char letter, string rotor, int position)
        {
            //if (position >= 26)
            //    Console.WriteLine(rotor);
            rotor = incRotor(adjustRotorLetters(rotor, position), position);
            return rotor[((int)letter - 65) % 26];
        }

        // Reverse the rotor, digitally flip the rotor around as if the current was entering from the other side 
        // and passing through the rotor in the other direction
        static string reverseRotor(string rotor)
        {
            char[] newRotor = Enumerable.Repeat(' ', rotor.Length).ToArray();
            for (int i = 0; i < rotor.Length; i++)
            {
                newRotor[(int)rotor[i] - 65] = (char)(i + 65);
                //newRotor = newRotor.Substring(0, position) + (char)(i + 65) + newRotor.Substring(position + 1);
            }
            return new String(newRotor);
        }

        int[] shiftRotorPosition(int rotorNumber, bool forwards, int shift)
        {
            return shiftRotorPosition(this.rotorPositions, rotorNumber, forwards, shift);
        }

        // Shifts the position number of the rotor by one
        static int[] shiftRotorPosition(int[] rotorPositions, int rotorNumber, bool forwards, int shift)
        {
            if (forwards)
                rotorPositions[rotorNumber] += shift;
            else
                rotorPositions[rotorNumber] += 26 - shift;
            rotorPositions[rotorNumber] %= 26;
            return rotorPositions;
        }

        int[] shiftRotorPosition(int rotorNumber)
        {
            return shiftRotorPosition(rotorNumber, true, 1);
        }

        /*static int[] applyRingSettingsToPositions(int[] rotorPositions, int[] ringShifts, bool forwards)
        {
            // Apply the ring setting to the rotor positions
            if (forwards)
                for (int i = 0; i < rotorPositions.Length; i++)
                    rotorPositions = shiftRotorPosition(rotorPositions, i, false, ringShifts[i]);
            else
                for (int i = 0; i < rotorPositions.Length; i++)
                    rotorPositions = shiftRotorPosition(rotorPositions, i, false, ringShifts[i]);
            return rotorPositions;

        }

        static int[] applyRingSettingsToNotches(int[] stepLettersAfter, int[] ringShifts, bool forwards)
        {
            // Apply the ring setting to the rotor step points
            // stepLettersAfter = map(lambda x, y: (x - y) % 26, stepLettersAfter, ringShifts[1:])
            for (int i = 0; i < stepLettersAfter.Length; i++)
                stepLettersAfter[i] = (stepLettersAfter[i] - ringShifts[i + 1] + 26) % 26;
            return stepLettersAfter;
        }
        */

        public static char[][] PlugboardMaker(string plugboard)
        {
            List<char[]> pb = new List<char[]>();
            plugboard = stripText(plugboard).ToUpper();

            for (int i = 0; i < plugboard.Length; i++)
            {
                if (i % 2 == 0)
                {
                    pb.Add(new char[2]);
                    pb[i / 2][0] = plugboard[i];
                }
                else
                {
                    pb[i / 2][1] = plugboard[i];
                }
            }

            return pb.ToArray();
        }

        public int[] stepRotors()
        {
            int[] initialRotorPositions = (int[])rotorPositions.Clone();
            // Apply rings to rotors
            for (int i = 0; i < rotorPositions.Length; i++)
                rotorPositions = shiftRotorPosition(i, false, ringShifts[i]);

            int[] initalStepPositions = (int[])stepLettersAfter.Clone();
            // Apply rings to notches
            for (int i = 0; i < stepLettersAfter.Length; i++)
                stepLettersAfter[i] = (stepLettersAfter[i] - ringShifts[i + 1] + 26) % 26;


            rotorPositions = shiftRotorPosition(2);

            // Check for the double step and slow rotor step
            if (rotorPositions[1] == ((stepLettersAfter[0]) % 26))
            {
                rotorPositions = shiftRotorPosition(0);
                rotorPositions = shiftRotorPosition(1);
            }

            // Step middle rotor
            if (rotorPositions[2] == ((stepLettersAfter[1] + 1) % 26))
            {
                rotorPositions = shiftRotorPosition(1);
            }

            // Remove rings from rotors
            for (int i = 0; i < rotorPositions.Length; i++)
                rotorPositions = shiftRotorPosition(i, true, ringShifts[i]);

            int[] newPositions = (int[])rotorPositions.Clone();
            rotorPositions = initialRotorPositions;
            stepLettersAfter = initalStepPositions;

            return newPositions;
        }

        // The overall Enigma function that encrypts text according to a list of different settings
        public string encrypt(string text)
        {
            /*char[] copyText = new char[text.Length];
            text.CopyTo(0, copyText, 0, text.Length);*/

            text = stripText(text).ToUpper();
            text = applyPlugboard(text);
            int[] initialPosition = (int[])rotorPositions.Clone();


            // Apply the ring setting to the rotor positions
            for (int i = 0; i < rotorPositions.Length; i++)
                rotorPositions = shiftRotorPosition(i, false, ringShifts[i]);

            //Console.WriteLine(rotorPositions[0] + " " + rotorPositions[1] + " " + rotorPositions[2]);

            // Apply the ring setting to the rotor step points
            // stepLettersAfter = map(lambda x, y: (x - y) % 26, stepLettersAfter, ringShifts[1:])
            int[] initalStepPositions = (int[])stepLettersAfter.Clone();
            for (int i = 0; i < stepLettersAfter.Length; i++)
                stepLettersAfter[i] = (stepLettersAfter[i] - ringShifts[i + 1] + 26) % 26;

            StringBuilder newText = new StringBuilder(text.Length);
            // Apply rotors
            foreach (char c in text)
            {
                char letter = c;
                // Step the rotors
                // Step the fast rotor
                rotorPositions = shiftRotorPosition(2);

                // Check for the double step and slow rotor step
                if (rotorPositions[1] == ((stepLettersAfter[0]) % 26))
                {
                    rotorPositions = shiftRotorPosition(0);
                    rotorPositions = shiftRotorPosition(1);
                }

                // Step middle rotor
                if (rotorPositions[2] == ((stepLettersAfter[1] + 1) % 26))
                {
                    rotorPositions = shiftRotorPosition(1);
                }

                // Pass through rotors
                rotors = rotors.Reverse().ToArray();
                rotorPositions = rotorPositions.Reverse().ToArray();
                for (int i = 0; i < rotors.Length; i++)
                {
                    letter = passThroughRotor(letter, rotors[i], rotorPositions[i] % 26);
                }

                // Pass through reflector
                letter = passThroughRotor(letter, reflector, 0);

                // Pass back through rotors
                rotors = rotors.Reverse().ToArray();
                rotorPositions = rotorPositions.Reverse().ToArray();
                for (int i = 0; i < rotors.Length; i++)
                {
                    letter = passThroughRotor(letter, reverseRotor(rotors[i]), rotorPositions[i] % 26);
                }

                newText.Append(letter);
            }
            rotorPositions = initialPosition;
            //text = new String(copyText);
            stepLettersAfter = initalStepPositions;
            return applyPlugboard(newText.ToString());
        }

        public static DataTable findBestRotorPositions(Enigma e, string text)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Score", typeof(double));
            dt.Columns.Add("Positions", typeof(int[]));
            dt.Columns.Add("Rotors", typeof(int[]));

            int[] rotors = new int[3];
            for (int i = 0; i < 3; i++)
                rotors[i] = m3rotors.IndexOf(e.rotors[i]) + 1;
            ConcurrentBag<DataTable> tables = new ConcurrentBag<DataTable>();

            
            ConcurrentBag<DataRow> rows = new ConcurrentBag<DataRow>();
            //int x = 0;
            //Parallel.For(0, 26, x =>
            for (int x = 0; x < 26; x++)
            {
                for (int y = 0; y < 26; y++)
                {
                    for (int z = 0; z < 26; z++)
                    {
                        DataRow row = dt.NewRow();
                        int[] positions = new int[] { x, y, z };
                        e.rotorPositions = positions;

                        row[0] = sinkov(e.encrypt(text));
                        row[1] = new int[] { x, y, z };
                        row[2] = rotors;
                        dt.Rows.Add(row);
                    }
                }
            }

            /*Parallel.For(0, 26, x =>
            //for (int x = 0; x < 26; x++)
            {
                DataTable table = new DataTable();
                table.Columns.Add("Score", typeof(double));
                table.Columns.Add("Positions", typeof(int[]));
                table.Columns.Add("Rotors", typeof(int[]));
                Enigma enigma = e.Clone();

                for (int y = 0; y < 26; y++)
                {
                    for (int z = 0; z < 26; z++)
                    {
                        DataRow row = table.NewRow();
                        int[] positions = new int[] { x, y, z };
                        enigma.rotorPositions = positions;

                        row[0] = sinkov(enigma.encrypt(text));
                        row[1] = new int[] { x, y, z };
                        row[2] = rotors;

                        //dt.Rows.Add(row);
                        table.Rows.Add(row);
                    }
                }
            });

            foreach (DataTable table in tables)
            {
                dt.Merge(table);
            }*/

            /*int[] answer = new int[] { 0, 17, 13 };
            e.rotorPositions = answer;
            Console.WriteLine("Value of [0, 17, 13]: " + sinkov(e.enigmaEncrypt(text)));*/

            return dt;
        }

        public static DataRow[] findBestRotorPositions(Enigma e, string text, int holdLength)
        {
            DataTable dt = findBestRotorPositions(e, text);
            DataRow[] sortedRows = new DataRow[holdLength];
            Array.Copy(dt.Select("", "Score DESC"), sortedRows, holdLength);
            return sortedRows;
        }

        public static DataRow[] findBestRotors(string text, int rotorLimit, int holdLength)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Score", typeof(double));
            dt.Columns.Add("Positions", typeof(int[]));
            dt.Columns.Add("Rotors", typeof(int[]));
            ConcurrentBag<DataTable> tables = new ConcurrentBag<DataTable>();

            //int x = 1;
            //for (int x = 1; x <= rotorLimit; x++)
            Parallel.For(1, rotorLimit + 1, x =>
            {
                Enigma enigma = new Enigma("123", 'B', "AAA", new char[0][], "AAA");
                for (int y = 1; y <= rotorLimit; y++)
                {
                    if (x == y)
                        continue;
                    for (int z = 1; z <= rotorLimit; z++)
                    {
                        if (x == z || y == z)
                            continue;
                        enigma.setRotors(new int[] { x, y, z });
                        //dt.Merge(findBestRotorPositions(enigma, text));
                        tables.Add(findBestRotorPositions(enigma, text));
                    }
                }
            });

            foreach (DataTable table in tables)
            {
                dt.Merge(table);
            }

            DataRow[] sortedRows = new DataRow[holdLength];
            Array.Copy(dt.Select("", "Score DESC"), sortedRows, holdLength);
            return sortedRows;
        }

        public static int[][] findBestRingSetting(int[] rotors, int[] rotorPositions, string text)
        {
            int[] ringShift = new int[] { 0, 0, 0 };
            int[] initialRotorPositions = (int[])rotorPositions.Clone();
            Enigma enigma = new Enigma(rotors, 2, (int[])rotorPositions.Clone(), new char[0][], "AAA");

            double[] scores = new double[26];
            // Find the best fast (rightmost) ring
            // Test them all
            for (int x = 0; x < 26; x++)
            {
                scores[x] = sinkov(enigma.encrypt(text));
                //Console.WriteLine(x + ": " + scores[x] + " Enigma: " + enigma.ToString());
                enigma.incrementRotorsAndRings(2);
            }
            // Choose the best
            ringShift[2] = Array.IndexOf(scores, scores.Max());
            initialRotorPositions[2] = (initialRotorPositions[2] + ringShift[2]) % 26;
            
            /*ringShift[2] = 12;
            initialRotorPositions[2] = 13;*/

            // Find the best middle ring
            // Reset from last tests
            enigma.rotorPositions[2]++;
            enigma.rotorPositions[2] = initialRotorPositions[2];
            enigma.ringShifts = ringShift;
            // Test them all
            for (int x = 0; x < 26; x++)
            {
                scores[x] = sinkov(enigma.encrypt(text));
                //Console.WriteLine(x + ": " + scores[x] + " Enigma: " + enigma.ToString());
                enigma.incrementRotorsAndRings(1);
            }
            // Choose the best
            ringShift[1] = Array.IndexOf(scores, scores.Max());
            initialRotorPositions[1] = (initialRotorPositions[1] + ringShift[1]) % 26;

            return new int[][] { initialRotorPositions, ringShift };
        }

        public static DataTable findRingsAndRotors(string text, int rotorLimit, int holdLength)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Score", typeof(double));
            dt.Columns.Add("Positions", typeof(int[]));
            dt.Columns.Add("Rotors", typeof(int[]));
            dt.Columns.Add("Rings", typeof(int[]));

            /*DataRow de = dt.NewRow();
            de[0] = -2500.0;
            de[1] = new int[] { 25, 17, 14 };
            de[2] = new int[] { 1, 2, 3 };
            de[3] = new int[] { 0, 13, 13 };
            dt.Rows.Add(de);
            return dt;*/

            /*DataTable testTable = new DataTable();
            testTable.Columns.Add("Score", typeof(double));
            testTable.Columns.Add("Positions", typeof(int[]));
            testTable.Columns.Add("Rotors", typeof(int[]));
            DataRow dr = testTable.NewRow();
            dr[0] = -2500.0;
            dr[1] = new int[] { 4, 7, 19 };
            dr[2] = new int[] { 1, 2, 3 };
            testTable.Rows.Add(dr);*/


            //DataRow[] rotorTableRows = findBestRotors(text, rotorLimit, holdLength);

            //foreach (DataRow row in testTable.Select())
            //foreach (DataRow row in findBestRotorPositions(new Enigma("123", 'B', "AAA", new char[0][], "AAA"), text, 100))
            //foreach (DataRow row in findBestRotors(text, rotorLimit, holdLength))
            Parallel.ForEach(findBestRotors(text, rotorLimit, holdLength), row =>
            {
                int[][] positionsAndRings = findBestRingSetting((int[])row[2], (int[])row[1], text);
                //Console.WriteLine(positionsAndRings[0][0] + " " + positionsAndRings[0][1] + " " + positionsAndRings[0][2] +
                //    positionsAndRings[1][0] + " " + positionsAndRings[1][1] + " " + positionsAndRings[1][2]);
                DataRow newRow = dt.NewRow();
                newRow[0] = sinkov((new Enigma((int[])row[2], 2, (int[])positionsAndRings[0].Clone(), new char[0][], positionsAndRings[1])).encrypt(text));
                newRow[1] = new int[] { positionsAndRings[0][0], positionsAndRings[0][1], positionsAndRings[0][2] };
                newRow[2] = row[2];
                newRow[3] = positionsAndRings[1];
                //Console.WriteLine(((int[])(newRow[1]))[0] + " " + ((int[])(newRow[1]))[1] + " " + ((int[])(newRow[1]))[2]);

                int[] positions = newRow.Field<int[]>(1);
                int[] rotors = newRow.Field<int[]>(2);
                int[] rings = newRow.Field<int[]>(3);
                //Console.WriteLine("randrPosition2: [" + positions[0] + ", " + positions[1] + ", " + positions[2] + "], Rotors: [" +
                //    rotors[0] + ", " + rotors[1] + ", " + rotors[2] + "], Rings: ["+ rings[0] + ", " + rings[1] + ", " +
                //    rings[2] + "] Old Score: " + row.Field<double>(0));

                dt.Rows.Add(newRow);
            });


            return dt;
        }

        public static char[][] findPlugboard(string text, int[] rotors, int[] rotorPositions, int[] ringShifts, 
            int numberOfPlugs)
        {
            /*DataTable dt = new DataTable();
            dt.Columns.Add("Score", typeof(double));
            dt.Columns.Add("Positions", typeof(int[]));
            dt.Columns.Add("Rotors", typeof(int[]));
            dt.Columns.Add("Rings", typeof(int[]));*/

            List<char[]> plugboard = new List<char[]>();
            List<char> plugLetters = new List<char>();
            Enigma enigma = new Enigma(rotors, 2, rotorPositions, new char[0][], ringShifts);

            for (int x = 0; x < numberOfPlugs; x++)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Score", typeof(double));
                dt.Columns.Add("Plug", typeof(char[]));
                plugboard.Add(new char[0]);

                for (char firstLetter = 'A'; firstLetter < 'Z'; firstLetter++)
                {
                    if (plugLetters.Contains(firstLetter))
                        continue;

                    for (char secondLetter = (char)(firstLetter + 1); secondLetter <= 'Z'; secondLetter++)
                    {
                        if (plugLetters.Contains(secondLetter))
                            continue;
                        DataRow newRow = dt.NewRow();

                        plugboard[x] = new char[] { firstLetter, secondLetter };
                        enigma.plugboard = plugboard.ToArray();
                        newRow[0] = sinkov(enigma.encrypt(text));

                        newRow[1] = new char[] { firstLetter, secondLetter };

                        dt.Rows.Add(newRow);
                    }
                }
                // Choose best plug
                DataRow[] sortedRows = new DataRow[5];
                Array.Copy(dt.Select("", "Score DESC"), sortedRows, 5);
                plugboard[x] = ((char[])(sortedRows[0])[1]);
                plugLetters.Add(((char[])(sortedRows[0])[1])[0]);
                plugLetters.Add(((char[])(sortedRows[0])[1])[1]);

                /*
                Console.WriteLine("Plug " + x + ": [" + ((char[])(sortedRows[0][1]))[0] + ", " + ((char[])(sortedRows[0][1]))[1] + "], Score: " + sortedRows[0][0]);
                Console.WriteLine("Plug " + x + ": [" + ((char[])(sortedRows[1][1]))[0] + ", " + ((char[])(sortedRows[1][1]))[1] + "], Score: " + sortedRows[1][0]);
                Console.WriteLine("Plug " + x + ": [" + ((char[])(sortedRows[2][1]))[0] + ", " + ((char[])(sortedRows[2][1]))[1] + "], Score: " + sortedRows[2][0]);
                Console.WriteLine("Plug " + x + ": [" + ((char[])(sortedRows[3][1]))[0] + ", " + ((char[])(sortedRows[3][1]))[1] + "], Score: " + sortedRows[3][0]);
                Console.WriteLine("Plug " + x + ": [" + ((char[])(sortedRows[4][1]))[0] + ", " + ((char[])(sortedRows[4][1]))[1] + "], Score: " + sortedRows[4][0]);
                */
            }
            return plugboard.ToArray();
        }

        public static DataTable breakEnigma(string text, int rotorLimit, int holdLength, int numberOfPlugs)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Score", typeof(double));
            dt.Columns.Add("Positions", typeof(int[]));
            dt.Columns.Add("Rotors", typeof(int[]));
            dt.Columns.Add("Rings", typeof(int[]));
            dt.Columns.Add("Plugboard", typeof(char[][]));

            //foreach (DataRow row in findRingsAndRotors(text, rotorLimit, holdLength).Select())
            Parallel.ForEach(findRingsAndRotors(text, rotorLimit, holdLength).Select(), row =>
            {
                DataRow newRow = dt.NewRow();

                char[][] plugboard = findPlugboard(text, (int[])row[2], (int[])((int[])row[1]).Clone(), (int[])row[3], numberOfPlugs);
                //Enigma e = new Enigma((int[])((int[])row[2]).Clone(), 2, (int[])((int[])row[1]).Clone(), plugboard, (int[])((int[])row[3]).Clone());
                Enigma e = new Enigma((int[])row[2], 2, (int[])((int[])row[1]).Clone(), plugboard, (int[])row[3]);

                //Console.WriteLine("BE: " + e);
                newRow[0] = sinkov(e.encrypt(text));
                newRow[1] = row[1];
                newRow[2] = row[2];
                newRow[3] = row[3];
                newRow[4] = plugboard;
                dt.Rows.Add(newRow);
            });

            return dt;
        }

        //public static DataRow[] finalEnigma(string text, int rotorLimit, int holdLength, int numberOfPlugs, int finalNumber)
        public static DataTable finalEnigma(string text, int rotorLimit, int holdLength, int numberOfPlugs, int finalNumber)
        {
            DataRow[] sortedRows = new DataRow[finalNumber];
            DataTable dt = breakEnigma(text, rotorLimit, holdLength, numberOfPlugs);
            Array.Copy(dt.Select("", "Score DESC"), sortedRows, finalNumber);
            //Console.WriteLine("SR Length: " + sortedRows.Length);

            dt = new DataTable();
            dt.Columns.Add("Score", typeof(double));
            dt.Columns.Add("Positions", typeof(int[]));
            dt.Columns.Add("Rotors", typeof(int[]));
            dt.Columns.Add("Rings", typeof(int[]));
            dt.Columns.Add("Plugboard", typeof(char[][]));

            /*DataRow fRow = dt.NewRow();
            fRow[0] = -1800;
            fRow[1] = new int[] { 2, 0, 9 };
            fRow[2] = new int[] { 1, 2, 3 };
            fRow[3] = new int[] { 0, 4, 10 };
            fRow[4] = new char[][] { new char[] { 'C', 'R' }, new char[] { 'A', 'D' }, new char[] { 'E', 'V' }, new char[] { 'L', 'M' } };*/

            //foreach (DataRow row in new DataRow[] { fRow })
            //foreach (DataRow row in sortedRows)
            Parallel.ForEach(sortedRows, row =>
            {
                Enigma enigma = new Enigma((int[])(((int[])(row[2])).Clone()), 2, (int[])(((int[])(row[1])).Clone()), (char[][])(((char[][])(row[4])).Clone()), (int[])(((int[])(row[3])).Clone()));
                int[] positions = (int[])(((int[])(row[1])).Clone());
                int[] rings = (int[])(((int[])(row[3])).Clone());
                Console.WriteLine("Engima: " + enigma.ToString() + " Sc: " + row[0]);

                DataTable finalShifts = new DataTable();
                finalShifts.Columns.Add("Score", typeof(double));
                finalShifts.Columns.Add("Positions", typeof(int[]));
                finalShifts.Columns.Add("Rings", typeof(int[]));

                for (int middlePos = -2; middlePos < 3; middlePos++)
                {
                    for (int rightPos = -3; rightPos < 4; rightPos++)
                    {
                        DataRow newRow = finalShifts.NewRow();
                        //enigma.se = new int[] { positions[0], (positions[1] + middle + 26)%26,
                        //(positions[1] + middle + 26)%26) };
                        //Console.WriteLine("Untouched: " + positions[0] + " " + positions[1] + " " + positions[2]);
                        enigma.rotorPositions = new int[] { positions[0], (positions[1] + middlePos + 26 ) % 26,
                            (positions[2] + rightPos + 26 ) % 26 };
                        enigma.ringShifts = new int[] { rings[0], (rings[1] + middlePos + 26 ) % 26,
                            (rings[2] + rightPos + 26 ) % 26 };
                        //Console.WriteLine("First: " + enigma.ToString());

                        newRow[0] = sinkov(enigma.encrypt(text));
                        newRow[1] = new int[] { positions[0], (positions[1] + middlePos + 26 ) % 26,
                            (positions[2] + rightPos + 26 ) % 26 };
                        newRow[2] = new int[] { rings[0], (rings[1] + middlePos + 26 ) % 26,
                            (rings[2] + rightPos + 26 ) % 26 };
                        finalShifts.Rows.Add(newRow);

                        //Console.WriteLine(/*"Second: " +*/ enigma.ToString() + newRow[0]);
                    }
                }

                for (int x = 0; x < 2; x++)
                {
                    DataRow finalShiftRow = finalShifts.Select("", "Score DESC")[x];
                    DataRow finalRow = dt.NewRow();
                    finalRow[0] = finalShiftRow[0];
                    finalRow[1] = finalShiftRow[1];
                    finalRow[2] = row[2];
                    finalRow[3] = finalShiftRow[2];
                    finalRow[4] = row[4];

                    dt.Rows.Add(finalRow);
                }

            });
            /*sortedRows = new DataRow[finalNumber];
            Array.Copy(dt.Select("", "Score DESC"), sortedRows, finalNumber);
            return sortedRows;*/
            return dt;
        }

        public static DataTable findBestRotorPositions(Enigma e, string text, EnigmaBreakerForm parent)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Score", typeof(double));
            dt.Columns.Add("Positions", typeof(int[]));
            dt.Columns.Add("Rotors", typeof(int[]));

            int[] rotors = new int[3];
            for (int i = 0; i < 3; i++)
                rotors[i] = m3rotors.IndexOf(e.rotors[i]) + 1;
            ConcurrentBag<DataTable> tables = new ConcurrentBag<DataTable>();


            ConcurrentBag<DataRow> rows = new ConcurrentBag<DataRow>();
            //int x = 0;
            //Parallel.For(0, 26, x =>
            for (int x = 0; x < 26; x++)
            {
                for (int y = 0; y < 26; y++)
                {
                    for (int z = 0; z < 26; z++)
                    {
                        DataRow row = dt.NewRow();
                        int[] positions = new int[] { x, y, z };
                        e.rotorPositions = positions;

                        row[0] = sinkov(e.encrypt(text));
                        row[1] = new int[] { x, y, z };
                        row[2] = rotors;
                        dt.Rows.Add(row);
                    }
                }
                Console.WriteLine("Moving to update");
                parent.Update(676, Thread.CurrentThread.ManagedThreadId.ToString());
            }

            /*Parallel.For(0, 26, x =>
            //for (int x = 0; x < 26; x++)
            {
                DataTable table = new DataTable();
                table.Columns.Add("Score", typeof(double));
                table.Columns.Add("Positions", typeof(int[]));
                table.Columns.Add("Rotors", typeof(int[]));
                Enigma enigma = e.Clone();

                for (int y = 0; y < 26; y++)
                {
                    for (int z = 0; z < 26; z++)
                    {
                        DataRow row = table.NewRow();
                        int[] positions = new int[] { x, y, z };
                        enigma.rotorPositions = positions;

                        row[0] = sinkov(enigma.encrypt(text));
                        row[1] = new int[] { x, y, z };
                        row[2] = rotors;

                        //dt.Rows.Add(row);
                        table.Rows.Add(row);
                    }
                }
            });

            foreach (DataTable table in tables)
            {
                dt.Merge(table);
            }*/

            /*int[] answer = new int[] { 0, 17, 13 };
            e.rotorPositions = answer;
            Console.WriteLine("Value of [0, 17, 13]: " + sinkov(e.enigmaEncrypt(text)));*/

            return dt;
        }


        public static DataRow[] findBestRotors(string text, int rotorLimit, int holdLength, EnigmaBreakerForm parent)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Score", typeof(double));
            dt.Columns.Add("Positions", typeof(int[]));
            dt.Columns.Add("Rotors", typeof(int[]));
            ConcurrentBag<DataTable> tables = new ConcurrentBag<DataTable>();

            //int x = 1;
            //for (int x = 1; x <= rotorLimit; x++)
            Parallel.For(1, rotorLimit + 1, x =>
            {
                Enigma enigma = new Enigma("123", 'B', "AAA", new char[0][], "AAA");
                for (int y = 1; y <= rotorLimit; y++)
                {
                    if (x == y)
                        continue;
                    for (int z = 1; z <= rotorLimit; z++)
                    {
                        if (x == z || y == z)
                            continue;
                        enigma.setRotors(new int[] { x, y, z });
                        //dt.Merge(findBestRotorPositions(enigma, text));
                        tables.Add(findBestRotorPositions(enigma, text, parent));
                    }
                }
            });

            foreach (DataTable table in tables)
            {
                dt.Merge(table);
            }

            DataRow[] sortedRows = new DataRow[holdLength];
            Array.Copy(dt.Select("", "Score DESC"), sortedRows, holdLength);
            return sortedRows;
        }

        public static DataTable findRingsAndRotors(string text, int rotorLimit, int holdLength, EnigmaBreakerForm parent)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Score", typeof(double));
            dt.Columns.Add("Positions", typeof(int[]));
            dt.Columns.Add("Rotors", typeof(int[]));
            dt.Columns.Add("Rings", typeof(int[]));

            /*DataRow de = dt.NewRow();
            de[0] = -2500.0;
            de[1] = new int[] { 25, 17, 14 };
            de[2] = new int[] { 1, 2, 3 };
            de[3] = new int[] { 0, 13, 13 };
            dt.Rows.Add(de);
            return dt;*/

            /*DataTable testTable = new DataTable();
            testTable.Columns.Add("Score", typeof(double));
            testTable.Columns.Add("Positions", typeof(int[]));
            testTable.Columns.Add("Rotors", typeof(int[]));
            DataRow dr = testTable.NewRow();
            dr[0] = -2500.0;
            dr[1] = new int[] { 4, 7, 19 };
            dr[2] = new int[] { 1, 2, 3 };
            testTable.Rows.Add(dr);*/


            //DataRow[] rotorTableRows = findBestRotors(text, rotorLimit, holdLength);

            //foreach (DataRow row in testTable.Select())
            //foreach (DataRow row in findBestRotorPositions(new Enigma("123", 'B', "AAA", new char[0][], "AAA"), text, 100))
            //foreach (DataRow row in findBestRotors(text, rotorLimit, holdLength))
            Parallel.ForEach(findBestRotors(text, rotorLimit, holdLength, parent), row =>
            {
                int[][] positionsAndRings = findBestRingSetting((int[])row[2], (int[])row[1], text);
                //Console.WriteLine(positionsAndRings[0][0] + " " + positionsAndRings[0][1] + " " + positionsAndRings[0][2] +
                //    positionsAndRings[1][0] + " " + positionsAndRings[1][1] + " " + positionsAndRings[1][2]);
                DataRow newRow = dt.NewRow();
                newRow[0] = sinkov((new Enigma((int[])row[2], 2, (int[])positionsAndRings[0].Clone(), new char[0][], positionsAndRings[1])).encrypt(text));
                newRow[1] = new int[] { positionsAndRings[0][0], positionsAndRings[0][1], positionsAndRings[0][2] };
                newRow[2] = row[2];
                newRow[3] = positionsAndRings[1];
                //Console.WriteLine(((int[])(newRow[1]))[0] + " " + ((int[])(newRow[1]))[1] + " " + ((int[])(newRow[1]))[2]);

                int[] positions = newRow.Field<int[]>(1);
                int[] rotors = newRow.Field<int[]>(2);
                int[] rings = newRow.Field<int[]>(3);
                //Console.WriteLine("randrPosition2: [" + positions[0] + ", " + positions[1] + ", " + positions[2] + "], Rotors: [" +
                //    rotors[0] + ", " + rotors[1] + ", " + rotors[2] + "], Rings: ["+ rings[0] + ", " + rings[1] + ", " +
                //    rings[2] + "] Old Score: " + row.Field<double>(0));

                dt.Rows.Add(newRow);

                parent.Update(52, Thread.CurrentThread.ManagedThreadId.ToString());
            });



            return dt;
        }

        public static DataTable breakEnigma(string text, int rotorLimit, int holdLength, int numberOfPlugs, EnigmaBreakerForm parent)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Score", typeof(double));
            dt.Columns.Add("Positions", typeof(int[]));
            dt.Columns.Add("Rotors", typeof(int[]));
            dt.Columns.Add("Rings", typeof(int[]));
            dt.Columns.Add("Plugboard", typeof(char[][]));

            int plugCombos = getNumOfPlugCombinations(numberOfPlugs);

            //foreach (DataRow row in findRingsAndRotors(text, rotorLimit, holdLength).Select())
            Parallel.ForEach(findRingsAndRotors(text, rotorLimit, holdLength, parent).Select(), row =>
            {
                DataRow newRow = dt.NewRow();

                char[][] plugboard = findPlugboard(text, (int[])row[2], (int[])((int[])row[1]).Clone(), (int[])row[3], numberOfPlugs);
                //Enigma e = new Enigma((int[])((int[])row[2]).Clone(), 2, (int[])((int[])row[1]).Clone(), plugboard, (int[])((int[])row[3]).Clone());
                Enigma e = new Enigma((int[])row[2], 2, (int[])((int[])row[1]).Clone(), plugboard, (int[])row[3]);

                //Console.WriteLine("BE: " + e);
                newRow[0] = sinkov(e.encrypt(text));
                newRow[1] = row[1];
                newRow[2] = row[2];
                newRow[3] = row[3];
                newRow[4] = plugboard;
                dt.Rows.Add(newRow);

                parent.Update(plugCombos, Thread.CurrentThread.ManagedThreadId.ToString());
            });

            return dt;
        }

        public static DataTable finalEnigma(string text, int rotorLimit, int holdLength, int numberOfPlugs, int finalNumber, EnigmaBreakerForm parent)
        {
            DataRow[] sortedRows = new DataRow[finalNumber];
            DataTable dt = breakEnigma(text, rotorLimit, holdLength, numberOfPlugs, parent);
            Array.Copy(dt.Select("", "Score DESC"), sortedRows, finalNumber);
            //Console.WriteLine("SR Length: " + sortedRows.Length);

            dt = new DataTable();
            dt.Columns.Add("Score", typeof(double));
            dt.Columns.Add("Positions", typeof(int[]));
            dt.Columns.Add("Rotors", typeof(int[]));
            dt.Columns.Add("Rings", typeof(int[]));
            dt.Columns.Add("Plugboard", typeof(char[][]));

            /*DataRow fRow = dt.NewRow();
            fRow[0] = -1800;
            fRow[1] = new int[] { 2, 0, 9 };
            fRow[2] = new int[] { 1, 2, 3 };
            fRow[3] = new int[] { 0, 4, 10 };
            fRow[4] = new char[][] { new char[] { 'C', 'R' }, new char[] { 'A', 'D' }, new char[] { 'E', 'V' }, new char[] { 'L', 'M' } };*/

            //foreach (DataRow row in new DataRow[] { fRow })
            //foreach (DataRow row in sortedRows)
            Parallel.ForEach(sortedRows, row =>
            {
                Enigma enigma = new Enigma((int[])(((int[])(row[2])).Clone()), 2, (int[])(((int[])(row[1])).Clone()), (char[][])(((char[][])(row[4])).Clone()), (int[])(((int[])(row[3])).Clone()));
                int[] positions = (int[])(((int[])(row[1])).Clone());
                int[] rings = (int[])(((int[])(row[3])).Clone());
                Console.WriteLine("Engima: " + enigma.ToString() + " Sc: " + row[0]);

                DataTable finalShifts = new DataTable();
                finalShifts.Columns.Add("Score", typeof(double));
                finalShifts.Columns.Add("Positions", typeof(int[]));
                finalShifts.Columns.Add("Rings", typeof(int[]));

                for (int middlePos = -2; middlePos < 3; middlePos++)
                {
                    for (int rightPos = -3; rightPos < 4; rightPos++)
                    {
                        DataRow newRow = finalShifts.NewRow();
                        //enigma.se = new int[] { positions[0], (positions[1] + middle + 26)%26,
                        //(positions[1] + middle + 26)%26) };
                        //Console.WriteLine("Untouched: " + positions[0] + " " + positions[1] + " " + positions[2]);
                        enigma.rotorPositions = new int[] { positions[0], (positions[1] + middlePos + 26 ) % 26,
                            (positions[2] + rightPos + 26 ) % 26 };
                        enigma.ringShifts = new int[] { rings[0], (rings[1] + middlePos + 26 ) % 26,
                            (rings[2] + rightPos + 26 ) % 26 };
                        //Console.WriteLine("First: " + enigma.ToString());

                        newRow[0] = sinkov(enigma.encrypt(text));
                        newRow[1] = new int[] { positions[0], (positions[1] + middlePos + 26 ) % 26,
                            (positions[2] + rightPos + 26 ) % 26 };
                        newRow[2] = new int[] { rings[0], (rings[1] + middlePos + 26 ) % 26,
                            (rings[2] + rightPos + 26 ) % 26 };
                        finalShifts.Rows.Add(newRow);

                        //Console.WriteLine(/*"Second: " +*/ enigma.ToString() + newRow[0]);
                    }
                }

                for (int x = 0; x < 2; x++)
                {
                    DataRow finalShiftRow = finalShifts.Select("", "Score DESC")[x];
                    DataRow finalRow = dt.NewRow();
                    finalRow[0] = finalShiftRow[0];
                    finalRow[1] = finalShiftRow[1];
                    finalRow[2] = row[2];
                    finalRow[3] = finalShiftRow[2];
                    finalRow[4] = row[4];

                    dt.Rows.Add(finalRow);
                }
                parent.Update(35, Thread.CurrentThread.ManagedThreadId.ToString());
            });
            /*sortedRows = new DataRow[finalNumber];
            Array.Copy(dt.Select("", "Score DESC"), sortedRows, finalNumber);
            return sortedRows;*/
            return dt;
        }




        public static int getNumOfPlugCombinations(int numberOfPlugs)
        {
            int count = 0;
            for (int i = 0; i < numberOfPlugs; i++)
            {
                if (i == 12)
                    break;
                count += ((25 - 2 * i) * (26 - 2 * i)) / 2;
            }
            return count;
        }

        public static int numOfEncryptionsToBreak(int rotorLimit, int holdLength, int numberOfPlugs, int finalNumber)
        {
            int count = 0;
            count += rotorLimit * (rotorLimit - 1) * (rotorLimit - 2) * 17576;

            count += holdLength * 52;

            count += holdLength * getNumOfPlugCombinations(numberOfPlugs);

            count += 35 * finalNumber;

            return count;
        }

        public override string ToString()
        {
            string s = "Rotor Numbers: [" + (m3rotors.IndexOf(rotors[0]) + 1) + ", " + (m3rotors.IndexOf(rotors[1]) + 1) + ", " +
                (m3rotors.IndexOf(rotors[2]) + 1) + "] Reflector: " + (char)(Array.IndexOf(reflectors, reflector) + 65) +
                " Rotor Positions: [" + rotorPositions[0] + ", " + rotorPositions[1] + ", " + rotorPositions[2] + "] Rings: [" +
                ringShifts[0] + ", " + ringShifts[1] + ", " + ringShifts[2] + "] Plugboard: ";
            StringBuilder sb = new StringBuilder(s);
            foreach (char[] plug in plugboard)
            {
                sb.Append("[" + plug[0] + ", " + plug[1] + "], ");
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        public Enigma()
        {
            rotors = new List<string>(m3rotors).GetRange(0, 3).ToArray();
            stepLettersAfter[0] = m3rotorNotches[1];
            stepLettersAfter[1] = m3rotorNotches[2];
            reflector = reflectors[1];
            plugboard = new char[0][];
            rotorPositions = new int[] { 0, 0, 0 };
            ringShifts = new int[] { 0, 0, 0 };
        }

        public Enigma(string[] rotors, string reflector, int[] rotorPositions, int[] stepLettersAfter, char[][] plugboard,
            int[] ringShifts)
        {
            this.rotors = rotors;
            this.reflector = reflector;
            this.rotorPositions = rotorPositions;
            this.stepLettersAfter = stepLettersAfter;
            this.plugboard = plugboard;
            this.ringShifts = ringShifts;
        }

        public Enigma(int[] rotors, int reflector, string rotorPositions, char[][] plugboard, 
            string ringShifts)
        {
            for (int i = 0; i < 3; i++)
            {
                this.rotors[i] = m3rotors[rotors[i] - 1];
                this.rotorPositions[i] = (int)rotorPositions[i] - 65;
                this.ringShifts[i] = (int)ringShifts[i] - 65;
            }
            stepLettersAfter[0] = m3rotorNotches[rotors[1] - 1];
            stepLettersAfter[1] = m3rotorNotches[rotors[2] - 1];
            this.reflector = reflectors[reflector - 1];
            this.plugboard = plugboard;
        }

        public Enigma(int[] rotors, int reflector, int[] rotorPositions, char[][] plugboard,
            string ringShifts)
        {
            for (int i = 0; i < 3; i++)
            {
                this.rotors[i] = m3rotors[rotors[i] - 1];
                this.ringShifts[i] = (int)ringShifts[i] - 65;
            }
            stepLettersAfter[0] = m3rotorNotches[rotors[1] - 1];
            stepLettersAfter[1] = m3rotorNotches[rotors[2] - 1];
            this.reflector = reflectors[reflector - 1];
            this.plugboard = plugboard;
            this.rotorPositions = rotorPositions;
        }

        public Enigma(int[] rotors, int reflector, int[] rotorPositions, char[][] plugboard,
            int[] ringShifts)
        {
            for (int i = 0; i < 3; i++)
            {
                this.rotors[i] = m3rotors[rotors[i] - 1];
            }
            stepLettersAfter[0] = m3rotorNotches[rotors[1] - 1];
            stepLettersAfter[1] = m3rotorNotches[rotors[2] - 1];
            this.reflector = reflectors[reflector - 1];
            this.plugboard = plugboard;
            this.rotorPositions = rotorPositions;
            this.ringShifts = ringShifts;
        }

        public Enigma(string rotors, char reflector, string rotorPositions, char[][] plugboard,
            string ringShifts)
        {
            for (int i = 0; i < 3; i++)
            {
                this.rotors[i] = m3rotors[(int)rotors[i] - 49];
                this.rotorPositions[i] = (int)rotorPositions[i] - 65;
                this.ringShifts[i] = (int)ringShifts[i] - 65;
            }
            stepLettersAfter[0] = m3rotorNotches[(int)rotors[1] - 49];
            stepLettersAfter[1] = m3rotorNotches[(int)rotors[2] - 49];
            this.reflector = reflectors[(int)reflector - 65];
            this.plugboard = plugboard;
        }

        /*
         * int[] rotorPositions = new int[rotorPositionLetters.Length];
            int[] stepLettersAfter = new int[stepLettersAfterChars.Length];
            int[] ringShifts = new int[ringPositionLetters.Length];

            for (int i = 0; i < rotorPositionLetters.Length; i++)
                rotorPositions[i] = ALPHABET.IndexOf(rotorPositionLetters[i]);
            for (int i = 0; i < stepLettersAfterChars.Length; i++)
                stepLettersAfter[i] = ALPHABET.IndexOf(stepLettersAfterChars[i]);
            for (int i = 0; i < ringPositionLetters.Length; i++)
                ringShifts[i] = ALPHABET.IndexOf(ringPositionLetters[i]);
                */

        public void setRotors(int[] rotors)
        {
            for (int i = 0; i < 3; i++)
            {
                this.rotors[i] = m3rotors[rotors[i] - 1];
            }
            stepLettersAfter[0] = m3rotorNotches[rotors[1] - 1];
            stepLettersAfter[1] = m3rotorNotches[rotors[2] - 1];
        }

        public void incrementRotorsAndRings(int rotorNumber)
        {
            shiftRotorPosition(rotorNumber);
            ringShifts[rotorNumber] += 27;
            ringShifts[rotorNumber] %= 26;
        }

        public Enigma Clone()
        {
            return new Enigma((string[])rotors.Clone(), reflector, (int[])rotorPositions.Clone(),
                (int[])stepLettersAfter.Clone(), (char[][])plugboard.Clone(), (int[])ringShifts.Clone());
        }

        public string[] rotors { get; private set; } = new string[3];
        public string reflector { get; set; }
        public int[] rotorPositions { get; set; } = new int[3];
        int[] stepLettersAfter { get; set; } = new int[2];
        public char[][] plugboard { get; set; }
        public int[] ringShifts { get; set; } = new int[3];

        static readonly List<string> m3rotors = new List<string>(new string[] { "EKMFLGDQVZNTOWYHXUSPAIBRCJ", "AJDKSIRUXBLHWTMCQGZNPYFVOE", "BDFHJLCPRTXVZNYEIWGAKMUSQO", "ESOVPZJAYQUIRHXLNFTGKDCMWB", "VZBRGITYUPSDNHLXAWMJQOFECK" });
        static readonly int[] m3rotorNotches = new int[] { 16, 4, 21, 9, 25 };
        static readonly char[] m3rotorNotchesChars = new char[] { 'Q', 'E', 'V', 'J', 'Z' };
        static readonly string[] reflectors = new string[] { "EJMZALYXVBWFCRQUONTSPIKHGD", "YRUHQSLDPXNGOKMIEBFZCWVJAT", "FVPJIAOYEDRZXWGCTKUQSBNMHL" };

        static readonly double[] ENGLISH_FREQUENCIES = new double[] { 0.08167, 0.01492, 0.02782, 0.04253, 0.12702, 0.02228, 0.02015, 0.06094, 0.06966, 0.00153, 0.00772, 0.04025, 0.02406, 0.06749, 0.07507, 0.01929, 0.00095, 0.05987, 0.06327, 0.09056, 0.02758, 0.00978, 0.02360, 0.00150, 0.01974, 0.00074 };
        static readonly string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static double[] LOG_ENGLISH_FREQS = ENGLISH_FREQUENCIES.Select(x => Math.Log(x)).ToArray();
    }
}
