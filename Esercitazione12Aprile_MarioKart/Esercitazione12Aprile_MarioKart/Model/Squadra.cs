using System.ComponentModel.DataAnnotations.Schema;

namespace Esercitazione12Aprile_MarioKart.Model
{
    [Table("Squadra")]
    public class Squadra
    {

        [Column("squadraID")]
        public int SquadraId { get; set; }
        [Column("codice_squadra")]
        public string CodiceSquadra { get; set; }
        [Column("nome")]
        public string NomeSquadra { get; set; }
        [Column("crediti")]
        public int Crediti { get; set; }
        public List<Personaggio> Personaggi { get; set; }
    }
}
