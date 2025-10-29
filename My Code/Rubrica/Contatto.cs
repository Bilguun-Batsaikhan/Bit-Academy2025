using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaUtils
{
    public class Contatto
    {
        public string Nome {  get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public TipoContatto TipoContatto { get; set; } = TipoContatto.Altro;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Indirizzo Indirizzo {  get; set; }

        public Contatto() { }
        public Contatto (string nome, string cognome, TipoContatto tipoContatto, string telefono, string email, Indirizzo indirizzo)
        {
            Nome = nome;
            Cognome = cognome;
            TipoContatto = tipoContatto;
            Telefono = telefono;
            Email = email;
            Indirizzo = indirizzo;
        }

        public override string ToString()
        {
            return $@"----------------------------------------
            Nome:        {Nome}
            Cognome:     {Cognome}
            Tipo:        {TipoContatto}
            Telefono:    {Telefono}
            Email:       {Email}
            Indirizzo:   {Indirizzo}
            ----------------------------------------";
        }

    }
}
