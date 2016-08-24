using Ada.Framework.Core;

namespace Ada.Framework.Development.Log4Me.Writers.MemoryWrite
{
    public class Tipo : Enumeracion<string>
    {
        protected Tipo(string codigo) : base(codigo) { }

        public static Tipo Entity = new Tipo("Entity");
        public static Tipo String = new Tipo("String");
    }
}
