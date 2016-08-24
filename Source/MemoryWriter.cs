using Ada.Framework.Development.Log4Me.Entities;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Ada.Framework.Development.Log4Me.Writers.MemoryWrite
{
    [Serializable]
    public class MemoryWriter : ALogWriter
    {
        public static IList<RegistroInLineTO> Registros { get; set; }
        public static string Salida;
        
        public static string FormatoSalidaEstatico { get; private set; }
        public static char SeparadorFormatoEstatico { get; set; }

        [XmlIgnore]
        public Tipo Tipo
        {
            get
            {
                return Tipo.ObtenerEnumeracion(_Tipo) as Tipo;
            }
            set
            {
                _Tipo = value.Codigo;
            }
        }

        [XmlAttribute("Type")]
        public string _Tipo{ get; set; }

        public MemoryWriter()
        {
            if (Registros == null)
            {
                Registros = new List<RegistroInLineTO>();
            }
        }

        public override void Inicializar() { }

        protected override void Agregar(RegistroInLineTO registro)
        {
            if (Tipo == null) Tipo = Tipo.Entity;

            if (Tipo == Tipo.Entity)
            {
                Salida += Formatear(registro) + "\r\n";
            }
            else if (Tipo == Tipo.Entity)
            {
                Registros.Add(registro);
            }
        }

        public override void AgregarParametros()
        {
            FormatoSalidaEstatico = FormatoSalida;
            SeparadorFormatoEstatico = SeparadorSalida;
        }
    }
}
