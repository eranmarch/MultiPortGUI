using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiPortBreakDown
{
    class FileValidator
    {
        private List<PortEntry> Ports { get; set; }
        private List<string> names;

        private string path_to_file;
        private readonly char[] charsToTrimGlobal = { ' ', '\t' };
        private readonly string[] keywords = { "signal", "bus", "component", "wait" };
        private readonly string path_to_correct = "mycorrect.vhd";
        readonly string pattern = @"^[ \t]*--[ \t]*(.*)[ \t]*";

        enum Cmp_mod { Start, Port_names, Middle, Port_entrys, End };

        public FileValidator(string path_to_file)
        {
            this.path_to_file = path_to_file;
            Ports = new List<PortEntry>();
            names = new List<string>();
        }

        public List<PortEntry> GetPortList()
        {
            return Ports;
        }

        public List<string> GetNames()
        {
            return names;
        }

        private string TrimAndLower(string str)
        {
            str = str.Trim(charsToTrimGlobal);
            str = str.ToLower();
            return str;
        }

        private string RemoveComment(string str)
        {
            int comment_index = 0;
            if (-1 != (comment_index = str.IndexOf("--")))
            {
                str = str.Substring(0, comment_index).TrimEnd(charsToTrimGlobal);
            }
            return str;
        }

        private bool IsNotComment(string str)
        {
            return !str.StartsWith("#");
        }

        private bool IsNotCommentMakaf(string str)
        {
            return !str.StartsWith("--");
        }

        private bool IsValidPortName(string port_name)
        {
            string pattern = @"^[ \t]*([a-zA-Z][a-zA-Z0-9_]*)[ \t]*,[ \t]*";
            Match result = Regex.Match(port_name, pattern);
            if (result.Success)
            {
                string[] substrings = Regex.Split(port_name, pattern);
                //MessageBox.Show(substrings[1] + " " + substrings[1].Length.ToString());
                names.Add(substrings[1]);
                return true;
            }
            return false;
        }

        public bool IsFileValid()
        {
            // Prepare texts for comparison: remove comments and convert to lower case
            Console.WriteLine("Preparing to compile " + path_to_file);
            string[] lines_correct = File.ReadAllLines(path_to_correct);
            string[] lines = File.ReadAllLines(path_to_file);
            for (int i = 0; i < lines_correct.Length; i++)
                lines_correct[i] = TrimAndLower(lines_correct[i]);
            for (int i = 0; i < lines.Length; i++)
                lines[i] = TrimAndLower(lines[i]);
            lines_correct = Array.FindAll(lines_correct, IsNotComment).ToArray();
            lines = Array.FindAll(lines, IsNotComment).ToArray();

            // Init state of comparison
            int run_state = (int)Cmp_mod.Start;
            int j = 0;

            // Parsing Analysis: Compare
            Console.WriteLine("Compiling...");
            for (int i = 0; i < lines.Length; i++)
            {
                // Skip empty lines
                //lines_correct[j] = RemoveComment(lines_correct[j]);
                bool b1 = string.IsNullOrWhiteSpace(lines_correct[j]);
                bool b2 = Regex.Match(lines_correct[j], @"^[ \t]*--(.*)").Success;
                while (j < lines_correct.Length && (lines_correct[j].Equals("") || b1 || b2))
                {
                    j++;
                    if (j == lines_correct.Length - 1)
                        break;
                    b1 = string.IsNullOrWhiteSpace(lines_correct[j]);
                    //b1 = Regex.Match(lines_correct[j], @"^[\r\n]*").Success;
                    b2 = Regex.Match(lines_correct[j], @"^[ \t]*--(.*)").Success;
                }
                // Finished current state
                if (j == lines_correct.Length)
                    break;
                if (lines_correct[j].Equals("0o0o0o0o0o0o0o0o0o0o0o0o0o00o0o0o0o0o0o00o0o0o0o0o0"))
                {
                    j = j + 2;
                    run_state++;
                }
                else if (lines_correct[j].Equals("0o0o0o0o0o0o0o0o0o0o0o0o0o00o0o0o0o0o0o00o0o0o0o0o0o"))
                {
                    j = j + 1;
                    run_state++;
                }
                if (run_state == (int)Cmp_mod.Port_names || run_state == (int)Cmp_mod.Port_entrys)
                {
                    int k;
                    for (k = i; k < lines.Length && !lines_correct[j - 1].Equals(lines[k]); k++)
                    {
                        Match result = Regex.Match(lines[k], pattern);
                        if (result.Success)
                        {
                            if (run_state == (int)Cmp_mod.Port_names)
                                continue;
                            string port_str = Regex.Split(lines[k], pattern)[1];
                            PortEntry pe = PortEntry.PortEntryParse(port_str, lines[k + 1].Equals(lines_correct[j - 1]));
                            if (pe != null)
                            {
                                //MessageBox.Show("Comment port!");
                                pe.SetIsComment(true);
                                Ports.Add(pe);
                                continue;
                            }
                        }
                        // Save Names
                        if (run_state == (int)Cmp_mod.Port_names)
                        {
                            if (!IsValidPortName(lines[k]))
                            {
                                MessageBox.Show("COMPILATION 1: Parsing error at line " + (k + 1));
                                Console.WriteLine("COMPILATION 1: Parsing error at line " + (k + 1) + "\nFinishing compilation....");
                                return false;
                            }
                        }
                        else if (run_state == (int)Cmp_mod.Port_entrys)
                        {
                            bool last = lines[k + 1].Equals(lines_correct[j]);
                            PortEntry entry = PortEntry.PortEntryParse(lines[k], last);
                            if (entry != null)
                            {
                                //MessageBox.Show(entry.GetName() + " " + entry.GetName().Length.ToString());
                                string type = entry.GetPortType().ToString();
                                Ports.Add(entry);
                            }
                            else
                            {
                                b1 = string.IsNullOrWhiteSpace(lines[k]);
                                b2 = Regex.Match(lines[k], @"^[ \t]*--(.*)").Success;
                                if (k < lines.Length && (lines[k].Equals("") || b1 || b2))
                                    continue;
                                MessageBox.Show("COMPILATION 2: Parsing error at line " + (k + 1));
                                Console.WriteLine("COMPILATION 2: Parsing error at line " + (k + 1) + "\nFinishing compilation....");
                                return false;
                            }
                            if (last) {
                                //j--;
                                //k++;
                                break;
                            }
                        }
                    }
                    run_state++;
                    i = k;
                }
                else
                {
                    //lines[i] = RemoveComment(lines[i]);
                    b1 = string.IsNullOrWhiteSpace(lines[i]);
                    b2 = Regex.Match(lines[i], @"^[ \t]*--(.*)").Success;
                    bool b3 = Regex.Match(lines[i], @"^use(.)*").Success || Regex.Match(lines[i], @"^library(.*)").Success;
                    while (i < lines.Length && (lines[i].Equals("") || b1 || b2 || b3))
                    {
                        i++;
                        if (i == lines.Length - 1)
                            break;
                        b1 = string.IsNullOrWhiteSpace(lines[i]);
                        b2 = Regex.Match(lines[i], @"^[ \t]*--(.*)").Success;
                        b3 = Regex.Match(lines[i], @"^use(.)*").Success || Regex.Match(lines[i], @"^library(.*)").Success;
                    }
                    if (!lines_correct[j].Equals(lines[i]))
                    {
                        MessageBox.Show("COMPILATION 3: Invalid file\n" + lines[i] + "\n" + lines_correct[j]);
                        Console.WriteLine("COMPILATION 3: Invalid file\n" + lines[i] + "!=" + lines_correct[j] + "\nFinishing compilation....");
                        return false;
                    }
                    j++;
                }
            }
            Console.WriteLine("Logic analysis...");
            if (!NamesCrossValid())
                return false;
            ValidRegLogic(); // Sematic Analysis, add everything from here
            Console.WriteLine("Compilation is complete");
            return true;
        }

        private void PriotityDuplicate()
        {
            for (int i = 1; i < Ports.Count; i++)
            {
                if (Ports[i].GetIsComment())
                    continue;
                for (int j = 0; j < i; j++)
                {
                    if (Ports[j].GetIsComment() || j == i)
                        continue;
                    /*if (Ports[i].GetPriority() == Ports[j].GetPriority())
                    {
                        Ports[i].SetReason("Register " + Ports[i].GetName() + " has the same priority as register " + Ports[j].GetName());
                        Ports[i].SetValid(false);
                    }*/
                    if (Ports[i].GetName().Equals(Ports[j].GetName()))
                    {
                        Ports[i].SetReason("Port " + Ports[i].GetName() + " appears at priority " + Ports[j].GetPriority() + " already");
                        Ports[i].SetValid(false);
                    }
                }
            }
        }

        private bool NamesCrossValid()
        {
            string namePort;
            foreach (PortEntry entry in Ports)
            {
                if (entry.GetIsComment())
                    continue;
                namePort = entry.GetName().Trim();
                if (!names.Contains(namePort))
                {
                    MessageBox.Show("Port " + namePort + " doesn't appear in the first list");
                    return false;
                }
            }
            foreach (string name in names)
            {
                bool test = false;
                foreach (PortEntry entry in Ports)
                {
                    namePort = entry.GetName().Trim();
                    if (namePort.Equals(name.Trim()))
                    {
                        test = true;
                        break;
                    }
                }
                if (!test)
                {
                    MessageBox.Show("Port " + name + " doesn't appear in the second list");
                    return false;
                }
            }
            return true;
        }

        public static bool ValidEntry(PortEntry entry)
        {
            if (entry.GetIsComment())
                return true;
            bool b = true;
            if (!entry.IsValidData_size())
            {
                entry.SetReason("The port " + entry.GetName() + " has invalid data size: " + entry.GetData_size());
                entry.SetValid(false);
                b = false;
            }
            if (!entry.IsValidMemorySection())
            {
                entry.SetReason("The port " + entry.GetName() + " has invalid memory section: " + entry.GetMemory_section());
                entry.SetValid(false);
                b = false;
            }
            if (!entry.IsValidPriority())
            {
                entry.SetReason("The port " + entry.GetName() + " has Priority out of range [0, 99]");
                entry.SetValid(false);
                b = false;
            }
            if (!entry.IsValidR_W())
            {
                entry.SetReason("The port " + entry.GetName() + " has R_W different from 'R' or 'W': " + entry.GetR_W());
                entry.SetValid(false);
                b = false;
            }
            if (!entry.IsValidAnableEmerge())
            {
                entry.SetReason("The port " + entry.GetName() + " has anable emerge different from 'N' or 'Y': " + entry.GetAnable_emerge());
                entry.SetValid(false);
                b = false;
            }
            if (!entry.IsValidBank())
            {
                entry.SetReason("The port " + entry.GetName() + " has bank different from 'A' or 'B': " + entry.GetBank());
                entry.SetValid(false);
                b = false;
            }
            return b;
        }

        private void ValidRegLogic()
        {
            int n = Ports.Count;
            for (int j = 0; j < n; j++)
                ValidEntry(Ports[j]);
            PriotityDuplicate();
        }
    }
}