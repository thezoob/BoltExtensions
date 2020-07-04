using System.Collections.Generic;

namespace Lasm.BoltExtensions.Humility
{
    public class NamespaceGenerator : BodyGenerator
    {
        private string @namespace;
        private List<ClassGenerator> classes = new List<ClassGenerator>();
        private List<StructGenerator> structs = new List<StructGenerator>();
        private List<EnumGenerator> enums = new List<EnumGenerator>();
        private List<InterfaceGenerator> interfaces = new List<InterfaceGenerator>();

        private NamespaceGenerator() { }

        public static NamespaceGenerator Namespace(string @namespace)
        {
            var namespc = new NamespaceGenerator();
            namespc.@namespace = @namespace;
            return namespc;
        }

        protected override string GenerateAfter(int indent)
        {
            return string.Empty;
        }

        protected override string GenerateBefore(int indent)
        {
            return "namespace " + @namespace;
        }

        protected override string GenerateBody(int indent)
        {
            var output = string.Empty;

            for (int i = 0; i < classes.Count; i++)
            {
                output += classes[i].Generate(indent) + (i < classes.Count - 1 ? "\n" : string.Empty);
            }

            output += structs.Count > 0 && classes.Count > 0? "\n" : string.Empty;

            for (int i = 0; i < structs.Count; i++)
            {
                output += structs[i].Generate(indent) + (i < structs.Count - 1 ? "\n" : string.Empty);
            }

            output += interfaces.Count > 0 && (structs.Count > 0 || classes.Count > 0) ? "\n" : string.Empty;

            for (int i = 0; i < interfaces.Count; i++)
            {
                output += interfaces[i].Generate(indent) + (i < interfaces.Count - 1 ? "\n" : string.Empty);
            }

            output += enums.Count > 0 && (structs.Count > 0 || classes.Count > 0 || interfaces.Count > 0) ? "\n" : string.Empty;

            for (int i = 0; i < enums.Count; i++)
            {
                output += enums[i].Generate(indent) + (i < enums.Count - 1 ? "\n" : string.Empty);
            }

            return output;
        }

        public NamespaceGenerator AddClass(ClassGenerator @class)
        {
            classes.Add(@class);
            return this;
        }

        public NamespaceGenerator AddStruct(StructGenerator @struct)
        {
            structs.Add(@struct);
            return this;
        }

        public NamespaceGenerator AddEnum(EnumGenerator @enum)
        {
            enums.Add(@enum);
            return this;
        }

        public NamespaceGenerator AddInterface(InterfaceGenerator @interface)
        {
            interfaces.Add(@interface);
            return this;
        }
    }
}