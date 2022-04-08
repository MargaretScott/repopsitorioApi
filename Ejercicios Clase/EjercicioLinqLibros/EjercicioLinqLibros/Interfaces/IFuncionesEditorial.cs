using EjercicioLinqLibros.Entidades;

namespace EjercicioLinqLibros.Interfaces
{
    public interface IFuncionesEditorial
    {
        List<Book> GetTop3BookMaxSales();
        List<Book> GetTop3BookMinSales();
        List<Book> GetBooks50Years();
    }
}
