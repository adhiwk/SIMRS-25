using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMRS25.Dtos
{
    public class AntreanOnlineBpjsDto<T>
    {
        public T? response { get; set; }
        public AntrolMetaData? metadata { get; set; }
    }

    public class AntrolMetaData
    {
        public string? message { get; set; }
        public int code { get; set; }
    }
    public class ListJadwalDokter
    {
        public string? kodesubspesialis { get; set; }
        public int hari { get; set; }
        public int kapasitaspasien { get; set; }
        public int libur { get; set; }
        public string? namahari { get; set; }
        public string? jadwal { get; set; }
        public string? namasubspesialis { get; set; }
        public string? namadokter { get; set; }
        public string? kodepoli { get; set; }
        public string? namapoli { get; set; }
        public int? kodedokter { get; set; }
    }

    public class AntrolResRefJadwalDokter : List<ListJadwalDokter>
    {
    }

    public class AntrolResRefDokter : List<ListDokter> { }
    public class ListDokter
    {
        public string? namadokter { get; set; }
        public string? kodedokter { get; set; }
    }

    public class AntrolResRefPoli : List<ListPoli> { }
    public class ListPoli
    {
        public string? nmpoli { get; set; }
        public string? nmsubspesialis { get; set; }
        public string? kdsubspesialis { get; set; }
        public string? kdpoli { get; set; }
    }
}
