using EjercicioAlbumFotos.Clases;

namespace EjercicioAlbumFotos
{
    class Program
    {
        static void Main(string[] args)
        {
            AlbumFotos album1 = new AlbumFotos();
            AlbumFotos album2 = new AlbumFotos(24);
            SuperAlbumFotos album3 = new SuperAlbumFotos();

            album1.GetNumeroPaginas();
            album2.GetNumeroPaginas();
            album3.GetNumeroPaginas();
        }

    }

}
