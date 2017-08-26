using EPQProjectCMD;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptionToolsGUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Main2();
            //Console.WriteLine(Enigma.numOfEncryptionsToBreak(3, 100, 4, 10));
            //Console.WriteLine(Enigma.numOfEncryptionsToBreak(3, 100, 4, 50));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Launcher());
            //Console.WriteLine("Hello world");


            //Application.Run(new CaesarForm());
        }

        static void Main2()
        {
            using (StreamWriter file = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\output.txt"))
            { 
                string hello = "ITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESS";
                string hello2 = "LKWFLWYEGXVKOKMLDEXBWNAXMKVWTKVKOKMLDEXBWNAXMKVALXRWWNLGFMNMZRSYAHRGJHIWOTELJHSXVJ";
                string[] m3rotors = new string[] { "EKMFLGDQVZNTOWYHXUSPAIBRCJ", "AJDKSIRUXBLHWTMCQGZNPYFVOE", "BDFHJLCPRTXVZNYEIWGAKMUSQO" };
                //string reflectorB = "YRUHQSLDPXNGOKMIEBFZCWVJAT";
                char[][] testKey = new char[][] { new char[] { 'A', 'B' }, new char[] { 'C', 'D' }, new char[] { 'E', 'F' } };
                /*foreach (char item in reverseRotor(m3rotors[1]))
                {
                    if (item != null)
                        file.Write(item + ", ");
                    else
                        file.Write("null, ");
                }*/

                Enigma e = new Enigma(new int[] { 1, 2, 3 }, 2, "LBJ", new char[][] { new char[] { 'A', 'D' }, new char[] { 'R', 'C' }, new char[] { 'L', 'M' }, new char[] { 'E', 'V' } }, "JFK");
                string text2 = "TherewereakingwithalargejawandaqueenwithaplainfaceonthethroneofEnglandtherewereakingwithalargejawandaqueenwithafairfaceonthethroneofFranceInbothcountriesitwasclearerthancrystaltothelordsoftheStatepreservesofloavesandfishesthatthingsingeneralweresettledforeverItwastheyearofOurLordonethousandsevenhundredandseventyfiveSpiritualrevelationswereconcededtoEnglandatthatfavouredperiodasatthisMrsSouthcotthadrecentlyattainedherfiveandtwentiethblessedbirthdayofwhomapropheticprivateintheLifeGuardshadheraldedthesublimeappearancebyannouncingthatarrangementsweremadefortheswallowingupofLondonandWestminsterEventheCocklaneghosthadbeenlaidonlyarounddozenofyearsa";
                file.WriteLine(e.encrypt(text2));

                int[] pos = new int[] { 25, 17, 4 };
                e = new Enigma(new int[] { 1, 2, 3 }, 2, pos, new char[][] { new char[] { 'A', 'D' }, new char[] { 'R', 'C' } }, new int[] { 0, 13, 13 });
                //file.WriteLine(e.enigmaEncrypt("ITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESI"));
                //file.WriteLine("\n\n\n" + (new Enigma("123", 'B', "ARN", Enigma.PlugboardMaker("AD RC"), "QVA")).enigmaEncrypt("ITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESI"));
                //e.setRotors(new int[] { 3, 2, 1 });
                //file.WriteLine(e.enigmaEncrypt("ITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESI"));

                //    m3rotors, reflectorB, new char[] { 'S', 'D', 'T' }, new char[] { 'E', 'V' }, new char[][] { new char[] { 'A', 'D' }, new char[] { 'R', 'C' } }, new char[] { 'L', 'B', 'A' }));


                /*file.WriteLine("\n\n\n" + Enigma.sinkov("POETYRFFNTQYXAEXJOMUJQHFOCHEUUEWEXJUXDRZJTHGFQBIVDKXQQJTNQLNSRVXJDFPJQGIHIMEAPPMIJKUILPRNXHRIWXPUPVANONXQBMSQBJVLEFRMJUNTBVLXKNTASEWHYJCYMFGKUHGWWAIIZBVRZGSWKUFZYXVPWESKIBCUINBZLOKCPAEKSOODMHFEOMJYDMLFYGSWBSXXELMOTBBNLNAVLVAVWVEIWWMJAHNYLWFHRMYMXEWZKNQRJZQTCLCSLBIZEEJJOEMYMNOJNMKFDDYHQYTLTHRQYYPZQDYDXQXAJYRIWZNUDSGMXKCYYLYWQVMVFJDXVYOZMNUTANGDTOSPKZJQVKCSZXHKYECRZHVNNKDJVOIFGVKZCQKDJSAMCDEKWMONVEGFJTGTWTFTOTEEZPUPPCCUELBMTQXEJPFTCUAGRZZBGBVVGYQQP"));
                file.WriteLine(Enigma.sinkov("ITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESI"));
                file.WriteLine(Enigma.sinkov("TherewereakingwithalargejawandaqueenwithaplainfaceonthethroneofEnglandtherewereakingwithalargejawandaqueenwithafairfaceonthethroneofFranceInbothcountriesitwasclearerthancrystaltothelordsoftheStatepreservesofloavesandfishesthatthingsingeneralweresettledforeverItwastheyearofOurLordonethousandsevenhundredandseventyfiveSpiritualrevelationswereconcededtoEnglandatthatfavouredperiodasatthisMrsSouthcotthadrecentlyattainedherfiveandtwentiethblessedbirthda"));
                Random random = new Random();
                file.WriteLine(Enigma.sinkov(new string(Enumerable.Repeat(ALPHABET, 450).Select(s => s[random.Next(s.Length)]).ToArray())));
                */

                e = new Enigma(new int[] { 1, 2, 3 }, 2, "ARN", new char[0][], "BNM");
                //const string mysteryText = "WOYEPUCQSLMPXLLKNCIZPNTRBBIIXVBVOZREQHWBHEDNNOKNEICSNVKOPHEGUCRBHRYDSFSILPNEFIZFZSYFIZLXIORLNTSQPFSEGVCJZWOHNYRIZTLJSKHSUJQLYEFEMFXRRNWCOKRONSKIXKJRHBWRHLLRJONPPVHBEDOPSKTHCSVQGGSIQENSYKCZLICCCIVCCBBHFHZWNYNIDLWJVWOJGAYBDJBRGYGSJCNVQUFLVVVOPETPRGDNEIYHQVQNBTJEULIWHCDVCHSXCEIVSTGOXSQNRDLRNZPWKPQCPTKTYJMJVJJTPIXLDTVZQMTCJMEWJSEIPOVRXXDGGEXDTQTMMZMVFUPVOIEFSEVFBRWGTEEPZLSIBLEDQCRVDDHKJEQVAZRVKEDNERRPUMPNHAVZKTYVNWYPIZSQCOCTXOMDZGYMQNWOSSZVYLBGUWEDVYCFUISLFXTDQXSUXFHVJESFNVWWGKHGBJUEAGVCEBVEQZPSVGOKWOFHXXUSQWDZOSLVUHLUSPVYQDVDXBMHDBSEMVIFICTPBYZPECMKNCLSOAXCLMQTYMBHTXGTZTENULQFSCBXSFVXZAARFOVHHHXHVPTKILUQZQWDYLTCBXORHBAFUSZTQWJTJTOVKNKCOECAXDYOLP";
                string mysteryText = "PNKZYMMHCJPGCEEQFAXKEKVJCZEZIEYCKBSMVLGCPKAERLPIIKCEFCBEVCHVYCUAJUKXAMPPMTMZHLDMDBQQRNRNTPJLEGBOGBUWEHNCYAGYFJSWPDVYDLWCTKCNLPLZTTKJUOBEPINPYEDMUNNLPTKBREMPIYIJDZFZBMPJCTSBBGDNAVNGMDJFHIIUENGBNGPFJPKKMCHSUWYCBVEIMYHBBCRIFPGATOOQGWYTPVYSEQNOTDSGIKPQKXJQZRUFDDJJPOIMECCWQCFEEKDCXWJZKLMKVRBAIGSQFYQCOVBTFKTRIIZAKBXFPDFHBOZVIGVIZBKSHCQWARHFAAKYGPKTELMZOVEPUTTRIUIZZVJKOHLSQKKAETAOHIDKYSSITNHHUTYESEEUSPMUFXLODQGWHJFCLUVBEJLYRXBKCWOIKFRSHDQEOZSXMZCETNQCXCRARVETEUBSCFXBHWMWTJBEZFDVCILZNCZVLWLXPLCAOSLGJMKGQFFDXYMNLDPGRDMSNXIUCZNCWRSUNERKNLXKTMSFTMRNLKWDAJFSRQJSKDHJRSFGGFRLHHDOFXYVVJJWJDJMPUMHUHZCRMVXCLFQUXNNBYYPYUJPECPRDGGZQVZOYYVVVILSEYRTNYXIROEAWPRSMR";
                char[][] plugBoard = new char[][] { new char[] { 'A', 'D' }, new char[] { 'R', 'C' } };
                int[][] results = Enigma.findBestRingSetting(new int[] { 1, 2, 3 }, new int[] { 25, 4, 1 }, mysteryText);


                string text = CaesarAndVigenere.stripText("TherewereakingwithalargejawandaqueenwithaplainfaceonthethroneofEnglandtherewereakingwithalargejawandaqueenwithafairfaceonthethroneofFranceInbothcountriesitwasclearerthancrystaltothelordsoftheStatepreservesofloavesandfishesthatthingsingeneralweresettledforeverItwastheyearofOurLordonethousandsevenhundredandseventyfiveSpiritualrevelationswereconcededtoEnglandatthatfavouredperiodasatthisMrsSouthcotthadrecentlyattainedherfiveandtwentiethblessedbirthdayofwhomapropheticprivateintheLifeGuardshadheraldedthesublimeappearancebyannouncingthatarrangementsweremadefortheswallowingupofLondonandWestminsterEventheCocklaneghosthadbeenlaidonlyarounddozenofyearsa").ToUpper();
                file.WriteLine("Score of plaintext: " + Enigma.sinkov(text));
                text = Regex.Replace(text, Char.ToString('A'), Char.ToString('d'));
                text = Regex.Replace(text, Char.ToString('D'), Char.ToString('a'));
                text = Regex.Replace(text, Char.ToString('R'), Char.ToString('c'));
                text = Regex.Replace(text, Char.ToString('C'), Char.ToString('r'));
                text = text.ToUpper();

                /*file.WriteLine("Score of plugged plaintext from python: " + Enigma.sinkov("THECEWQCEDKINGWITYDLDCGWJDWDNADQUEXNWITHDPKDINFDREJNTHETHCONEVUENVLANATHECEWECEDKINGWITHDLKCGEJDWDNADQFEENWITHTFDICFDREONTHETHCONEOOTCDGREZNBOTHROUKTCIPSITODSRLEDCECJHDNRCYVTDLTOTHELOCASGFTHZYMDTDICESECVESOFLGDVESDNAFQSHOSTGDTTHIFGSINGENECDLWECYSXTTLEAFOCEVECITWDSTUKYXDCOZOUCLOCAONETSTUYDNASEVEIHUNACEADNASEVENTRFIVESPLCITUDLCEVELGTIGNSWEJERONREAEATOENGLDNADTTODTFDVOUCEAPECCOWISAPTHISMCOSZUTHFOTJWDACEREITLYDTTDINEAHECBIOEDNAZWENTIETHBLESSEABICTGADIOFWHOMDPQOPHETIRPCIVDTEINTHELIFEGHDCOSHDAHECDLAEATHESUBLIMEAPPEDCDNREBYDNNSUPRINGFHDTDCCDNLEMENTSWNCEMZAEFHCPHESWDLLOWINGUPOFLONAOMDNAWESTSTTSTECEVENTHERORKLDNEBHOSBHDAOEEOLDIAONLYDCOUNAAOHENLQYIDCSD"));
                file.WriteLine("Score of plugged plaintext from C#: " + Enigma.sinkov(e.encrypt("THECEWQCEDKINGWITYDLDCGWJDWDNADQUEXNWITHDPKDINFDREJNTHETHCONEVUENVLANATHECEWECEDKINGWITHDLKCGEJDWDNADQFEENWITHTFDICFDREONTHETHCONEOOTCDGREZNBOTHROUKTCIPSITODSRLEDCECJHDNRCYVTDLTOTHELOCASGFTHZYMDTDICESECVESOFLGDVESDNAFQSHOSTGDTTHIFGSINGENECDLWECYSXTTLEAFOCEVECITWDSTUKYXDCOZOUCLOCAONETSTUYDNASEVEIHUNACEADNASEVENTRFIVESPLCITUDLCEVELGTIGNSWEJERONREAEATOENGLDNADTTODTFDVOUCEAPECCOWISAPTHISMCOSZUTHFOTJWDACEREITLYDTTDINEAHECBIOEDNAZWENTIETHBLESSEABICTGADIOFWHOMDPQOPHETIRPCIVDTEINTHELIFEGHDCOSHDAHECDLAEATHESUBLIMEAPPEDCDNREBYDNNSUPRINGFHDTDCCDNLEMENTSWNCEMZAEFHCPHESWDLLOWINGUPOFLONAOMDNAWESTSTTSTECEVENTHERORKLDNEBHOSBHDAOEEOLDIAONLYDCOUNAAOHENLQYIDCSD")));
                */

                file.WriteLine("Positions: [" + results[0][0] + ", " + results[0][1] + ", " + results[0][2] + "] " +
                    "Rings: [" + results[1][0] + ", " + results[1][1] + ", " + results[1][2] + "] ");

                System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();

                //DataRow[] dRows = Enigma.findBestRotors(mysteryText, 3, 1000);
                //DataTable dt = Enigma.breakEnigma(mysteryText, 3, 10, 2);
                DataTable dt = Enigma.finalEnigma(mysteryText, 3, 100, 4, 10);
                DataRow[] dr = new DataRow[10];
                Array.Copy(dt.Select("", "Score DESC"), dr, 10);

                //DataRow[] dr = Enigma.finalEnigma(mysteryText, 3, 100, 4, 10);

                //DataTable dt = Enigma.findRingsAndRotors(mysteryText, 3, 100);
                /*char[][] plugs = (Enigma.findPlugboard(mysteryText, new int[] { 1, 2, 3 }, new int[] { 25, 17, 14 },
                    new int[] { 0, 13, 13 }, 2));
                StringBuilder sb = new StringBuilder();
                foreach (char[] plug in plugs)
                {
                    sb.Append("[" + plug[0] + ", " + plug[1] + "], ");
                }
                sb.Remove(sb.Length - 1, 1);
                file.WriteLine("Plugs found: " + sb.ToString());*/
                //Enigma.sinkov("ITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESITWASTHEAGEOFWISDOMITWASTHEAGEOFFOOLISHNESSITWASTHEBESTOFTIMESITWASTHEWORSTOFTIMESI");

                watch.Stop();
                long elapsedMs = watch.ElapsedMilliseconds;
                file.WriteLine((double)elapsedMs / 1000.0);

                Enigma f = new Enigma(new int[] { 1, 2, 3 }, 2, "ARN", new char[][] { new char[] { 'A', 'D' }, new char[] { 'R', 'C' } }, "QVA");
                file.WriteLine("Answer: [" + f.rotorPositions[0] + ", " + f.rotorPositions[1] + ", " + f.rotorPositions[2] + "]\n");

                //foreach (DataRow row in dt.Select())
                foreach (DataRow row in dr)
                {
                    int[] positions = row.Field<int[]>(1);
                    int[] rotors = row.Field<int[]>(2);
                    int[] rings = row.Field<int[]>(3);
                    char[][] plugs2 = row.Field<char[][]>(4);
                    //char[][] plugs = new char[0][];
                    //if (positions[0] == 25)
                    //  if (positions[1] == 4)
                    //      if (positions[2] == 1)
                    //          file.Write("Found it!: ");
                    Enigma s = new Enigma(rotors, 2, positions, plugs2, rings);
                    file.WriteLine(s.ToString() + " Score: " + row.Field<double>(0));

                    //file.WriteLine("Position: [" + positions[0] + ", " + positions[1] + ", " + positions[2] + "], Rotors: [" +
                    //    rotors[0] + ", " + rotors[1] + ", " + rotors[2] + "], Rings: ["+ rings[0] + ", " + rings[1] + ", " +
                    //    rings[2] + "] Old Score: " + row.Field<double>(0));

                }
            }
        }
    }
}