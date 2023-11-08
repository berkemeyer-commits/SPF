using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ModelEF6
{
    public interface IRepositorio <TEntidad> : IDisposable where TEntidad:class
    {
        TEntidad Insertar(TEntidad toCreate);
        Boolean Eliminar(TEntidad toDelete);
        Boolean Actualizar(TEntidad toUpdate, Int64 key);
        TEntidad Recuperar(Expression<Func<TEntidad, Boolean>> criteria);
        List<TEntidad> Filtro(Expression<Func<TEntidad, Boolean>> criteria);
        List<TEntidad> ObtenerPagina(Nullable<int> numeroPagina, int tamanhoPagina, Expression<Func<TEntidad, Boolean>> criteria);
    }    
}
