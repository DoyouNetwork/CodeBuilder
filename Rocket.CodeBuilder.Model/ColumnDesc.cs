namespace Rocket.CodeBuilder
{
    public class ColumnDesc
    {
        public string Field { get; set; }

        private string _type;
        public string Type => _type;

        public void SetType(string type)
        {
            type = type.Replace("(", "");
            type = type.Replace(")", "");
            type = type.Replace(",", "");
            type = type.Replace(".", "");
            type = type.Replace("1", "");
            type = type.Replace("2", "");
            type = type.Replace("3", "");
            type = type.Replace("4", "");
            type = type.Replace("5", "");
            type = type.Replace("6", "");
            type = type.Replace("7", "");
            type = type.Replace("8", "");
            type = type.Replace("9", "");
            type = type.Replace("0", "");

            _type = type;
        }

        public bool Null { get; set; }

        public bool Key { get; set; }

        public string Comment { get; set; }
    }
}
