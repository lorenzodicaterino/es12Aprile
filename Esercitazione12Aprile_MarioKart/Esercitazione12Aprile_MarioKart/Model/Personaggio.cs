using System.ComponentModel.DataAnnotations.Schema;

namespace Esercitazione12Aprile_MarioKart.Model
{
    [Table ("Personaggio")]
    public class Personaggio
    {
        [Column("personaggioID")]
        public int PersonaggioId { get; set; }
        [Column("codice_personaggio")]
        public string CodicePersonaggio { get; set; }
        [Column("nome")]
        public string NomePersonaggio { get; set; }
        [Column("costo")]
        public int CostoPersonaggio { get; set; }
        [Column("categoria")]
        public int CategoriaPersonaggio { get; set; }
        [Column("foto")]
        public string FotoPersonaggio { get; set; }
        public Squadra? SquadraRifNavigation{ get; set; }
        [Column("squadraRIF")]
        public int? SquadraRif { get; set; }
    }
}
