﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPortBreakDown
{
    class PortEntry
    {
        /* Globals */
        public enum p_type { SLOW, SEQUENTIAL, RANDOM, SPRINT };
        public enum fpga_field { G, D, A, B, C, ABC, ABCG };

        /* Class fields */
        public string Name { get; set; }
        public bool IsValid { get; set; }
        public p_type Type { get; set; }

        public int Address { get; set; }
        public int MAIS { get; set; }
        public int LSB { get; set; }
        public int MSB { get; set; }
        
        public fpga_field FPGA { get; set; }
        public string Init { get; set; }
        public string Comment { get; set; }
        public string Group { get; set; }
        public List<PortEntry> Fields { get; set; }
        
        public bool IsComment { get; set; }
        public string Reason { get; set; }
        public int Index { get; set; }
        public int SecondaryIndex { get; set; }

        public static string pattern = @"^[ \t]*\(([a-zA-Z][a-zA-Z0-9_]*)[ \t]*,[ \t]*(\d+)[ \t]*,[ \t]*([0124])[ \t]*,[ \t]*(\d+)[ \t]*,[ \t]*(\d+)[ \t]*,[ \t]*([a-zA-Z_]+)[ \t]*,[ \t]*([a-zA-Z_]+)[ \t]*,[ \t]*(\w+)[ \t]*\)[ \t]*,[ \t]*(--[ \t]*(.*)[ \t]*)*";
        public static string final_pattern = @"^[ \t]*\(([a-zA-Z][a-zA-Z0-9_]*)[ \t]*,[ \t]*(\d+)[ \t]*,[ \t]*([0124])[ \t]*,[ \t]*(\d+)[ \t]*,[ \t]*(\d+)[ \t]*,[ \t]*([a-zA-Z_]+)[ \t]*,[ \t]*([a-zA-Z_]+)[ \t]*,[ \t]*(\w+)[ \t]*\)[ \t]*(--[ \t]*(.*)[ \t]*)*";

        /* Constructors */
        public PortEntry() : this("", -1, 0, 0, 31, p_type.RD, fpga_field.G, "", "", "") { }

        public PortEntry(string Name, int Address, int MAIS, int LSB, int MSB,
            p_type Type, fpga_field FPGA, string Init, string Comment, string Group)
        {
            this.Name = Name;
            this.Address = Address;
            this.MAIS = MAIS;
            this.LSB = LSB;
            this.MSB = MSB;
            this.Type = Type;
            this.FPGA = FPGA;
            this.Init = Init;
            this.Comment = Comment;
            this.Group = Group;
            Fields = new List<PortEntry>();
            IsValid = true;
            IsComment = false;
            Reason = "";
            Index = -1;
            SecondaryIndex = -1;
        }

        public PortEntry(string Name, int Address, string MAIS, string LSB, string MSB,
            string type, string FPGA, string Init, string Comment, string Group) :
            this(Name, Address, int.Parse(MAIS), int.Parse(LSB), int.Parse(MSB),
                (p_type)Enum.Parse(typeof(p_type), type, true),
                (fpga_field)Enum.Parse(typeof(fpga_field), FPGA, true),
                Init, Comment, Group)
        { }

        /* Get and Set functions */
        public String GetName()
        {
            return Name;
        }

        public void SetName(string Name)
        {
            this.Name = Name;
        }

        public int GetAddress()
        {
            return Address;
        }

        public void SetAddress(int Address)
        {
            this.Address = Address;
        }

        public int GetMAIS()
        {
            return MAIS;
        }

        public void SetMAIS(int Mais)
        {
            MAIS = Mais;
        }

        public int GetLSB()
        {
            return LSB;
        }

        public void SetLSB(int LSB)
        {
            this.LSB = LSB;
        }

        public int GetMSB()
        {
            return MSB;
        }

        public void SetMSB(int MSB)
        {
            this.MSB = MSB;
        }

        public p_type GetRegType()
        {
            return Type;
        }

        public void SetRegType(p_type Type)
        {
            this.Type = Type;
        }

        public void SetRegType(string Type)
        {
            SetRegType((p_type)Enum.Parse(typeof(p_type), Type, true));
        }

        public fpga_field GetFPGA()
        {
            return FPGA;
        }

        public void SetFPGA(fpga_field FPGA)
        {
            this.FPGA = FPGA;
        }

        public void SetFPGA(string FPGA)
        {
            SetFPGA((fpga_field)Enum.Parse(typeof(fpga_field), FPGA, true));
        }

        public String GetInit()
        {
            return Init;
        }

        public void SetInit(string Init)
        {
            this.Init = Init;
        }

        public String GetComment()
        {
            return Comment;
        }

        public void SetComment(string Comment)
        {
            this.Comment = Comment;
        }

        public String GetGroup()
        {
            return Group;
        }

        public void SetGroup(string Group)
        {
            this.Group = Group;
        }

        public List<PortEntry> GetFields()
        {
            return Fields;
        }

        public string GetFormat()
        {
            return pattern;
        }

        public void AddField(PortEntry Field)
        {
            Field.SetGroup(Group);
            Field.SetSecondaryIndex(Fields.Count);
            Fields.Add(Field);
        }

        public string GetReason()
        {
            return Reason;
        }

        public void SetReason(string reason)
        {
            Reason = reason;
        }

        public bool GetValid()
        {
            return IsValid;
        }

        public void SetValid(bool valid)
        {
            IsValid = valid;
        }

        public bool GetIsComment()
        {
            return IsComment;
        }

        public void SetIsComment(bool IsComment)
        {
            this.IsComment = IsComment;
        }

        public int GetIndex()
        {
            return Index;
        }

        public void SetIndex(int Index)
        {
            this.Index = Index;
        }

        public int GetSecondaryIndex()
        {
            return SecondaryIndex;
        }

        public void SetSecondaryIndex(int index)
        {
            SecondaryIndex = index;
        }

        /* Validation Functions */
        public bool IsValidLsbMsb()
        {
            return MSB >= LSB;
        }

        public static bool IsValidLsbMsb(string msb, string lsb)
        {
            int lsbInt = Int32.Parse(lsb);
            int msbInt = Int32.Parse(msb);
            return msbInt >= lsbInt;
        }

        public bool IsValidMAIS()
        {
            return MAIS == 0 || MAIS == 1 || MAIS == 2 || MAIS == 4;
        }

        public bool IsValidAddress()
        {
            return Address >= 0 && Address < 1024;
        }

        // Check fields don't intersect
        public bool FieldValidation()
        {
            if (!IsComment && Fields.Count > 0)
            {
                List<Interval> fieldsIntervals = new List<Interval>();
                foreach (PortEntry item in Fields)
                    fieldsIntervals.Add(new Interval(item.Name, item.LSB, item.MSB));
                Tuple<string, string> inter = Interval.IsIntersectList(fieldsIntervals);
                string field1 = inter.Item1, field2 = inter.Item2;
                if (!(field1.Equals("") && field2.Equals("")))
                {
                    Reason = "Field bits " + field1 + " and " + field2 + " of register " + GetName() + " (" + Address + ") intersect";
                    IsValid = false;
                    return false;
                }
            }
            return true;
        }

        public bool IsValidLSB()
        {
            return LSB >= 0 && LSB < 32;
        }

        public bool IsValidMSB()
        {
            return MSB >= 0 && MSB < 32;
        }

        public static bool IsValidType(string Type)
        {
            try
            {
                p_type t = (p_type)Enum.Parse(typeof(p_type), Type, true);
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }

        public static bool IsValidFPGA(string fpga)
        {
            try
            {
                fpga_field t = (fpga_field)Enum.Parse(typeof(fpga_field), fpga, true);
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }

        /* Output Functions */
        // Returns x spaces
        public static string getSpaces(int x)
        {
            return string.Concat(Enumerable.Repeat(" ", x));
        }

        public static PortEntry RegEntryParse(String str_entry, String group, bool last)
        {
            string actual = pattern;
            if (last)
                actual = final_pattern;
            string[] fields = Regex.Split(str_entry, actual);
            if (fields.Length > 1)
            {
                string comment = "";
                if (fields.Length == 12)
                    comment = fields[10];
                if (!IsValidType(fields[6]) || !IsValidFPGA(fields[7]))
                    return null;
                return new PortEntry(fields[1], Int32.Parse(fields[2]), fields[3], fields[4], fields[5], fields[6], fields[7], fields[8], comment, group);
            }
            return null;
        }

        public void EditRegister(string mais, string lsb, string msb, p_type t, fpga_field r, string init, string comment, string group)
        {
            MAIS = Int32.Parse(mais);
            LSB = Int32.Parse(lsb);
            MSB = Int32.Parse(msb);
            Type = t;
            FPGA = r;
            Init = init;
            Comment = comment;
            Group = group;
        }

        //override
        public string toName()
        {
            string res = "";

            if (IsComment)
                res += "--";

            if (Type != p_type.SPRINT)
                res += "\t\t\t\t" + Name + ",\n";
            else
                res += "\t\t\t\t\t" + Name + ",\n";
            return res;
        }

        public string ToXMLstring()
        {
            string res = "";
            if (IsComment)
                res += "<tr bgcolor = 'green'>";
            else if (!IsValid)
                res += "<tr bgcolor = 'red'>";
            else
                res += "<tr>";
            res += "<td>" + Name;
            res += "</td><td>" + Group;
            res += "</td><td>" + Address.ToString();
            res += "</td><td>" + MAIS.ToString();
            res += "</td><td>" + LSB.ToString();
            res += "</td><td>" + MSB.ToString();
            res += "</td><td>" + valid_type[(int)Type];
            res += "</td><td>" + valid_fpga[(int)FPGA];
            res += "</td><td>" + Init;
            res += "</td><td>" + Comment + "</td></tr>";
            return res;
        }

        public string ToEntry(bool last = false)
        {
            string res = "";
            if (IsComment)
                res += "--";
            if (Type == p_type.SPRINT)
                res += "\t\t\t\t\t" + "(" + Name + getSpaces(35 - Name.Length) + ",";

            else
                res += "\t\t\t\t" + "(" + Name + getSpaces(39 - Name.Length) + ",";

            string adrs = Address.ToString();
            res += getSpaces(8 - adrs.Length) + adrs + ",";
            res += "  " + MAIS.ToString() + ",";
            string lsb = LSB.ToString();
            string msb = MSB.ToString();
            res += getSpaces(3 - lsb.Length) + lsb + "," + getSpaces(3 - msb.Length) + msb + ",";
            res += " " + valid_type[(int)Type] + getSpaces(5 - valid_type[(int)Type].Length) + ",";
            res += " " + valid_fpga[(int)FPGA] + getSpaces(4 - valid_fpga[(int)FPGA].Length) + ",";

            if (int.TryParse(Init, out int x))
                res += getSpaces(Math.Max(4 - Init.Length, 0)) + Init + ")";

            else
                res += Init + ")";

            if (!last)
                res += ",";

            if (Comment != "")
                res += "\t-- " + Comment;
            res += "\n";
            return res;
        }

        public object[] GetTableEntry()
        {
            return new object[] { Name, Address, MAIS, LSB, MSB, Type, FPGA, Init, Comment, Index, SecondaryIndex };
        }

        /*public int CompareTo(RegisterEntry other)
        {
            int comp = Name.CompareTo(other.GetName());
            if (comp < 0)
                return -1;
            else if (comp > 0)
                return 1;
            comp = Address.CompareTo(other.GetAddress());
            if (comp < 0)
                return -1;
            else if (comp > 0)
                return 1;
            comp = MAIS.CompareTo(other.GetMAIS());
            if (comp < 0)
                return -1;
            else if (comp > 0)
                return 1;
            comp = LSB.CompareTo(other.GetLSB());
            if (comp < 0)
                return -1;
            else if (comp > 0)
                return 1;
            comp = MSB.CompareTo(other.GetMSB());
            if (comp < 0)
                return -1;
            else if (comp > 0)
                return 1;
            comp = Type.CompareTo(other.GetRegType());
            if (comp < 0)
                return -1;
            else if (comp > 0)
                return 1;
            comp = FPGA.CompareTo(other.GetFPGA());
            if (comp < 0)
                return -1;
            else if (comp > 0)
                return 1;
            comp = Init.CompareTo(other.GetInit());
            if (comp < 0)
                return -1;
            else if (comp > 0)
                return 1;
            comp = Group.CompareTo(other.GetGroup());
            if (comp < 0)
                return -1;
            else if (comp > 0)
                return 1;
            return 0;
        }*/
    }
}
