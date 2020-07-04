namespace Lasm.BoltExtensions.Humility
{
    /// <summary>
    /// A generator that sets up a body { } for you. Easily add what comes before, during, and after the body.
    /// </summary>
    public abstract class BodyGenerator : ConstructGenerator
    {
        /// <summary>
        /// Generates the entire body, includes before and after, as a string.
        /// </summary>
        public override sealed string Generate(int indent)
        {
            var before = GenerateBefore(indent);
            var body = GenerateBody(indent + 1);
            var after = GenerateAfter(indent);
            var output = (string.IsNullOrEmpty(before) || string.IsNullOrWhiteSpace(before)) ? string.Empty : before + "\n";
            output += CodeBuilder.OpenBody(indent) + "\n";
            output += (string.IsNullOrEmpty(body) || string.IsNullOrWhiteSpace(body)) ? string.Empty : body;
            output += "\n" + CodeBuilder.CloseBody(indent);
            output += (string.IsNullOrEmpty(after) || string.IsNullOrWhiteSpace(after)) ? string.Empty : after + "\n";
            return output;
        }

        /// <summary>
        /// Override to generate what comes before the body. Such as a method or type declaration, or even a lambda expression.
        /// </summary>
        protected abstract string GenerateBefore(int indent);

        /// <summary>
        /// Override to generate what is inside the body.
        /// </summary>
        protected abstract string GenerateBody(int indent);

        /// <summary>
        /// Override to generate what comes after the body. For instance, you may way to close a lambda expression by adding a ); after.
        /// </summary>
        protected abstract string GenerateAfter(int indent);
    }
}