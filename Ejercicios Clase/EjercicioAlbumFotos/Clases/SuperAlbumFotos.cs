using EjercicioAlbumFotos.Interfaces;

namespace EjercicioAlbumFotos.Clases
{
    public class SuperAlbumFotos : AlbumFotos, ISuperAlbumFotos
    {
        public SuperAlbumFotos()
        {
            NumPaginas = 64;
        }
    }
}
