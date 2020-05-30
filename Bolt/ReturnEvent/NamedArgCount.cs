namespace Lasm.BoltExtensions
{
    public struct NamedArgCount
    {
        public string name;
        public int args;

        public NamedArgCount(string name, int args)
        {
            this.name = name;
            this.args = args;
        }
    }


}