using EjercicioAlbumFotos.Interfaces;

namespace EjercicioAlbumFotos.Clases
{
    public class AlbumFotos : IAlbumFotos
    {
        protected int NumPaginas { get; set; }

        public AlbumFotos()
        {
            NumPaginas = 16;
        }

        public AlbumFotos(int numPaginas)
        {
            NumPaginas = numPaginas;
        }

        public void GetNumeroPaginas()
        {
            Console.WriteLine("El album tiene " + NumPaginas + " páginas");
        }

    }
}
