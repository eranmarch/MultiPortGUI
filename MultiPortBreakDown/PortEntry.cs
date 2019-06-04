using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MultiPortBreakDown
{
    public class PortEntry
    {
        /* Globals */
        public enum p_type { SLOW, SEQUENTIAL, RANDOM, SPRINT, MANAGER };
        public static string pattern = @"^[ \t]*\(([a-zA-Z][a-zA-Z0-9_]*)[ \t]*,[ \t]*(\[a-zA-Z]+)[ \t]*,[ \t]*(\[a-zA-Z]+)[ \t]*,[ \t]*([WwRr])[ \t]*,[ \t]*(\d+)[ \t]*,[ \t]*([aAbB])[ \t]*,[ \t]*([a-zA-Z]+)[ \t]*,[ \t]*(.+)[ \t]*,[ \t]*(\d+)[ \t]*,[ \t]*(\[a-zA-Z]+),[ \t]*(\d+)[ \t]*,[ \t]*(\[NnYy])[ \t]*,[ \t]*(\[a-zA-Z]+)[ \t]*\)[ \t]*,[ \t]*(--[ \t]*(.*)[ \t]*)*";
        public static string final_pattern = @"^[ \t]*\(([a-zA-Z][a-zA-Z0-9_]*)[ \t]*,[ \t]*(\[a-zA-Z]+)[ \t]*,[ \t]*(\[a-zA-Z]+)[ \t]*,[ \t]*([WwRr])[ \t]*,[ \t]*(\d+)[ \t]*,[ \t]*([aAbB])[ \t]*,[ \t]*([a-zA-Z]+)[ \t]*,[ \t]*(.+)[ \t]*,[ \t]*(\d+)[ \t]*,[ \t]*(\[a-zA-Z]+),[ \t]*(\d+)[ \t]*,[ \t]*(\[NnYy])[ \t]*,[ \t]*(\[a-zA-Z]+)[ \t]*\)[ \t]*(--[ \t]*(.*)[ \t]*)*";

        /* Class fields */
        public string Name { get; set; }
        public bool ValidField { get; set; }
        public p_type Type { get; set; }
        public char R_W { get; set; }
        public int Data_size { get; set; }
        public char Bank { get; set; }
        public string Memory_size { get; set; }
        public int Memory_section { get; set; }
        public bool Relative_address { get; set; }
        public int Priority { get; set; }
        public char Anable_emerge { get; set; }
        public bool Read_bk_address { get; set; }

        public string Comment { get; set; }
        public bool IsComment { get; set; }
        public bool IsValid { get; set; }
        public string Reason { get; set; }
        public int Index { get; set; }

        /* Constructors */
        public PortEntry() : this("", false, p_type.SLOW, 'R', 16, 'A', "full", 1, true, 99, 'N', false, "") { }

        public PortEntry(string Name, bool ValidField, p_type Type, char R_W, int Data_size,
            char Bank, string Memory_size, int Memory_section, bool Relative_address,
            int Priority, char Anable_emerge, bool Read_bk_address, string Comment)
        {
            this.Name = Name;
            this.ValidField = ValidField;
            this.Type = Type;
            this.R_W = R_W;
            this.Data_size = Data_size;
            this.Type = Type;
            this.Bank = Bank;
            this.Memory_size = Memory_size;
            this.Memory_section = Memory_section;
            this.Relative_address = Relative_address;
            this.Priority = Priority;
            this.Anable_emerge = Anable_emerge;
            this.Read_bk_address = Read_bk_address;
            this.Comment = Comment;
            IsValid = true;
            IsComment = false;
            Reason = "";
            Index = -1;
        }

        public PortEntry(string Name, string ValidField, string Type, char R_W, string Data_size,
            char Bank, string Memory_size, string Memory_section, string Relative_address,
            string Priority, char Anable_emerge, string Read_bk_address, string Comment) :
            this(Name, bool.Parse(ValidField), (p_type)Enum.Parse(typeof(p_type), Type, true),
                R_W, int.Parse(Data_size), Bank, Memory_size, int.Parse(Memory_section),
                bool.Parse(Relative_address), int.Parse(Priority), Anable_emerge, bool.Parse(Read_bk_address),
                Comment)
        { }

        /* Get and Set functions */
        public string GetName()
        {
            return Name;
        }

        public void SetName(string Name)
        {
            this.Name = Name;
        }

        public bool GetValidField()
        {
            return ValidField;
        }

        public void SetValidField(bool ValidField)
        {
            this.ValidField = ValidField;
        }

        public char GetR_W()
        {
            return R_W;
        }

        public void SetR_W(char R_W)
        {
            this.R_W = R_W;
        }

        public int GetData_size()
        {
            return Data_size;
        }

        public void SetData_size(int Data_size)
        {
            this.Data_size = Data_size;
        }

        public int GetMemory_section()
        {
            return Memory_section;
        }

        public void SetMemory_section(int Memory_section)
        {
            this.Memory_section = Memory_section;
        }

        public p_type GetPortType()
        {
            return Type;
        }

        public void SetPortType(p_type Type)
        {
            this.Type = Type;
        }

        public void SetPortType(string Type)
        {
            SetPortType((p_type)Enum.Parse(typeof(p_type), Type, true));
        }

        public bool GetRelative_address()
        {
            return Relative_address;
        }

        public void SetRelative_address(bool Relative_address)
        {
            this.Relative_address = Relative_address;
        }

        public int GetPriority()
        {
            return Priority;
        }

        public void SetPriority(int Priority)
        {
            this.Priority = Priority;
        }

        public char GetAnable_emerge()
        {
            return Anable_emerge;
        }

        public void SetAnable_emerge(char Anable_emerge)
        {
            this.Anable_emerge = Anable_emerge;
        }

        public bool GetRead_bk_address()
        {
            return Read_bk_address;
        }

        public void SetRead_bk_address(bool Read_bk_address)
        {
            this.Read_bk_address = Read_bk_address;
        }

        public string GetComment()
        {
            return Comment;
        }

        public void SetComment(string Comment)
        {
            this.Comment = Comment;
        }

        public string GetFormat()
        {
            return pattern;
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

        public char GetBank()
        {
            return Bank;
        }

        public void SetBank(char Bank)
        {
            this.Bank = Bank;
        }

        public string GetMemorySize()
        {
            return Memory_size;
        }

        public void SetMemorySize(string Memory_size)
        {
            this.Memory_size = Memory_size;
        }
        /* Validation Functions */
        public bool IsValidR_W()
        {
            return R_W == 'W' || R_W == 'R';
        }

        public bool IsValidData_size()
        {
            for (int i = 3; i <= 9; i++)
                if (Math.Pow(2, i) == Data_size)
                    return true;
            return false;
        }

        public bool IsValidBank()
        {
            return Bank == 'A' || Bank == 'B';
        }

        public bool IsValidPriority()
        {
            return Priority > 0 && Priority < 100;
        }

        public bool IsValidMemorySection()
        {
            return Memory_section > 0;
        }

        public bool IsValidAnableEmerge()
        {
            return Anable_emerge == 'N' || Anable_emerge == 'Y';
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

        /* Output Functions */
        // Returns x spaces
        public static string GetSpaces(int x)
        {
            return string.Concat(Enumerable.Repeat(" ", x));
        }

        public static PortEntry PortEntryParse(string str_entry, bool last)
        {
            throw new NotImplementedException();
            /*string actual = pattern;
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
            return null;*/
        }

        public void EditPort(bool ValidField, p_type Type, char R_W, int Data_size,
            char Bank, string Memory_size, int Memory_section, bool Relative_address,
            int Priority, char Anable_emerge, bool Read_bk_address, string Comment)
        {
            this.ValidField = ValidField;
            this.Type = Type;
            this.R_W = R_W;
            this.Data_size = Data_size;
            this.Type = Type;
            this.Bank = Bank;
            this.Memory_size = Memory_size;
            this.Memory_section = Memory_section;
            this.Relative_address = Relative_address;
            this.Priority = Priority;
            this.Anable_emerge = Anable_emerge;
            this.Read_bk_address = Read_bk_address;
            this.Comment = Comment;
        }

        //override
        public string ToName()
        {
            string tabs = "\t\t\t\t\t\t\t";
            if (IsComment)
                return tabs + "--" + Name + ",\n";
            return tabs + Name + ",\n";
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
            res += "</td><td>" + ValidField.ToString();
            res += "</td><td>" + Type.ToString();
            res += "</td><td>" + R_W;
            res += "</td><td>" + Data_size.ToString();
            res += "</td><td>" + Bank;
            res += "</td><td>" + Memory_size;
            res += "</td><td>" + Memory_section.ToString();
            res += "</td><td>" + Relative_address.ToString();
            res += "</td><td>" + Priority.ToString();
            res += "</td><td>" + Anable_emerge;
            res += "</td><td>" + Read_bk_address.ToString();
            res += "</td><td>" + Comment + "</td></tr>";
            return res;
        }

        public string ToEntry(bool last = false)
        {
            string res = "";
            if (IsComment)
                res += "--";
            res += "\t\t\t\t" + "(" + Name + GetSpaces(39 - Name.Length) + ",";

            string adrs = ValidField.ToString();
            res += GetSpaces(8 - adrs.Length) + adrs + ",";
            res += "  " + Type.ToString() + ",";
            string write_read = R_W.ToString();
            string data_size = Data_size.ToString();
            res += GetSpaces(3 - write_read.Length) + write_read + "," + GetSpaces(3 - data_size.Length) + data_size + ",";
            res += " " + Bank + GetSpaces(4) + ",";
            res += " " + Memory_size + GetSpaces(4 - Memory_size.Length) + ",";
            res += Relative_address.ToString() + ", " + Priority.ToString() + ", " + Anable_emerge + ", " + Read_bk_address + ")";

            if (!last)
                res += ",";

            if (Comment != "")
                res += "\t-- " + Comment;
            res += "\n";
            return res;
        }

        public object[] GetTableEntry()
        {
            return new object[] {Name, ValidField, Type, R_W, Data_size, Bank, Memory_size, Memory_section,
            Relative_address, Priority, Anable_emerge, Read_bk_address, Comment, IsComment, Index};
        }

        override
        public string ToString(){
            return Name + ", " + ValidField + ", " + Type + ", " + R_W + ", " + Data_size + ", " + Bank
                + ", " + Memory_size + ", " + Memory_section + ", " + Relative_address + ", " + Priority
                + ", " + Anable_emerge + ", " + Read_bk_address + ", " + Comment;
        }
    }
}
