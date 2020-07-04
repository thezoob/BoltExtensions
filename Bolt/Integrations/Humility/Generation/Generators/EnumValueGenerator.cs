namespace Lasm.BoltExtensions.Humility
{
    public sealed class EnumValueGenerator : ConstructGenerator
    {
        public string name = string.Empty;
        public int index = 0;

        public override string Generate(int indent)
        {
            return CodeBuilder.Indent(indent) + name + " = " + index.ToString();
        }
    }
}