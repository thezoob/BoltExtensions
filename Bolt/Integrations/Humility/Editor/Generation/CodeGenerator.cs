namespace Lasm.BoltExtensions.Humility
{
    public abstract class CodeGenerator<T> : Decorator<CodeGenerator<T>, CodeGenAttribute, T>
    {
        public abstract string Generate(int indent);
    }
}