namespace ConexionesDB.Architectur
{
    public class Parameter
    {
        public Parameter(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public object Value { get; set; }
    }
}
