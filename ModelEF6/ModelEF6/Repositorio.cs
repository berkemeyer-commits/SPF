using System;
using System.Reflection;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace ModelEF6
{
    public class Repositorio<TEntidad> : IRepositorio<TEntidad> where TEntidad : class
    {
        public BerkeDBEntities Context = null;

        public Repositorio()
        {
            Context = new BerkeDBEntities();
            Context.Configuration.LazyLoadingEnabled = false;
        }

        //public Repositorio(string connString)
        //{
        //    Context = new BerkeDBEntities(connString);
        //    Context.Configuration.LazyLoadingEnabled = false;
        //}

        public Repositorio(BerkeDBEntities context)
        {
            Context = new BerkeDBEntities();
            Context.Database.Connection.ConnectionString = context.Database.Connection.ConnectionString;
            Context.Configuration.LazyLoadingEnabled = false;
        }

        private DbSet<TEntidad> EntitySet
        {
            get { return this.Context.Set<TEntidad>(); }
        }

        public TEntidad Insertar(TEntidad toCreate)
        {
            TEntidad Result = null;

            try
            {
                EntitySet.Add(toCreate);
                Context.SaveChanges();
                Result = toCreate;
            }
            catch //(Exception ex)
            {
                throw;
            }
            return Result;
        }

        public bool Insertar<TEntidad2>(TEntidad master, List<TEntidad2> listToCreate, string pkName, string fkName) where TEntidad2 : class
        {
            bool Result = false;

            try
            {
                foreach (TEntidad2 toCreate in listToCreate)
                {
                    Context.Entry(toCreate).Property(fkName).CurrentValue = Context.Entry(master).Property(pkName).CurrentValue;
                    this.Context.Set<TEntidad2>().Add(toCreate);
                    Context.SaveChanges();
                }
                Result = true;
            }
            catch (Exception ex)
            {
                throw;
            }
            return Result;
        }

        public bool Actualizar<TEntidad2>(TEntidad master, List<TEntidad2> listToUpdate) where TEntidad2 : class
        {
            bool Result = false;

            try
            {
                foreach (TEntidad2 toUpdate in listToUpdate)
                {
                    var entry = Context.Entry(toUpdate);
                    //Si la clave principal de la tabla es 0, es un registro nuevo
                    string fieldName = this.GetPrimaryKeyName<TEntidad2>();
                    int value = (int)entry.Property(fieldName).CurrentValue;
                    if (value == 0)
                    {
                        this.Context.Set<TEntidad2>().Add(toUpdate);
                    }
                    else if (value < 0)// La clave negativa indica que la fila se debe eliminar
                    {
                        //Volvemos positivo el valor de la clave
                        //Context.Entry(toUpdate).Property(fieldName).CurrentValue = (int)Context.Entry(toUpdate).Property(fieldName).CurrentValue * -1;
                        value = (int)Context.Entry(toUpdate).Property(fieldName).CurrentValue * -1;
                        this.Context.Set<TEntidad2>().Remove(this.Context.Set<TEntidad2>().Find(value));
                    }
                    else
                    {
                        var key = entry.Property(this.GetPrimaryKeyName<TEntidad2>()).CurrentValue;

                        if (entry.State == EntityState.Detached)
                        {
                            var currentEntry = this.EntitySet.Find(key);
                            if (currentEntry != null)
                            {
                                var attachedEntry = this.Context.Entry(currentEntry);
                                attachedEntry.CurrentValues.SetValues(toUpdate);
                            }
                            else
                            {
                                //this.EntitySet.Attach(toUpdate);
                                this.Context.Set<TEntidad2>().Attach(toUpdate);
                                entry.State = EntityState.Modified;
                            }
                        }
                    }
                    Context.SaveChanges();
                }
                Result = true;
            }
            catch //(Exception ex)
            {
                throw;
            }
            return Result;
        }

        public bool Eliminar(TEntidad toDelete)
        {
            Boolean Result = false;

            try
            {
                EntitySet.Attach(toDelete);
                EntitySet.Remove(toDelete);
                Result = Context.SaveChanges() > 0;
            }
            catch //(Exception ex)
            {
                throw;
            }

            return Result;
        }

        public bool Actualizar(TEntidad toUpdate, Int64 key)
        {
            Boolean Result = false;

            try
            {
                var entry = Context.Entry(toUpdate);
                //var key = this.GetPrimaryKey(entry);

                if (entry.State == EntityState.Detached)
                {
                    var currentEntry = this.EntitySet.Find(key);
                    if (currentEntry != null)
                    {
                        var attachedEntry = this.Context.Entry(currentEntry);
                        attachedEntry.CurrentValues.SetValues(toUpdate);
                    }
                    else
                    {
                        this.EntitySet.Attach(toUpdate);
                        entry.State = EntityState.Modified;
                    }
                }      
                                       
                Result = Context.SaveChanges() > 0;
            }
            catch //(Exception ex)
            {
                throw;
            }

            return Result;
        }

        public bool Actualizar<TEntidad2>(List<TEntidad2> listToCreate) where TEntidad2 : class
        {
            bool Result = false;

            try
            {
                foreach (TEntidad2 toUpdate in listToCreate)
                {
                    var entry = Context.Entry(toUpdate);
                    var key = this.GetPrimaryKeyInfo<TEntidad2>();

                    if (entry.State == EntityState.Detached)
                    {
                        var currentEntry = this.Context.Set<TEntidad2>().Find(key);
                        if (currentEntry != null)
                        {
                            var attachedEntry = this.Context.Entry(currentEntry);
                            attachedEntry.CurrentValues.SetValues(toUpdate);
                        }
                        else
                        {
                            this.Context.Set<TEntidad2>().Attach(toUpdate);
                            entry.State = EntityState.Modified;
                        }
                    }
                }
                Context.SaveChanges();
                Result = true;
            }
            catch //(Exception ex)
            {
                throw;
            }
            return Result;
        }

        public TEntidad Actualizar(TEntidad toUpdate)
        {
            TEntidad Result = null;

            try
            {
                var entry = Context.Entry(toUpdate);
                //var key = this.GetPrimaryKeyInfo<TEntidad>();
                //var key = this.GetPrimaryKeyValue(entry);
                var key = entry.Property(this.GetPrimaryKeyName<TEntidad>()).CurrentValue;

                if (entry.State == EntityState.Detached)
                {
                    var currentEntry = this.EntitySet.Find(key);
                    if (currentEntry != null)
                    {
                        var attachedEntry = this.Context.Entry(currentEntry);
                        attachedEntry.CurrentValues.SetValues(toUpdate);
                    }
                    else
                    {
                        this.EntitySet.Attach(toUpdate);
                        entry.State = EntityState.Modified;
                    }
                }
                Context.SaveChanges();
                Result = toUpdate;
            }
            catch //(Exception ex)
            {
                throw;
            }
            return Result;
        }

        
        public TEntidad Recuperar(System.Linq.Expressions.Expression<Func<TEntidad, bool>> criteria)
        {
            TEntidad Result = null;

            try
            {
                Result = EntitySet.FirstOrDefault(criteria);
            }
            catch //(Exception ex)
            {
                throw;
            }

            return Result;
        }

        public List<TEntidad> Filtro(System.Linq.Expressions.Expression<Func<TEntidad, bool>> criteria)
        {
            List<TEntidad> Result = null;

            try
            {
                Result = EntitySet.Where(criteria).ToList();
            }
            catch //(Exception ex)
            {
                throw;
            }

            return Result;
        }

        public List<TEntidad> ObtenerPagina(Nullable<int> numeroPagina, int tamanhoPagina, System.Linq.Expressions.Expression<Func<TEntidad, Boolean>> criteria)
        {
            List<TEntidad> Result = null;

            try
            {
                Result = EntitySet.Where(criteria).Skip(tamanhoPagina * (((numeroPagina.HasValue) ? numeroPagina.Value : 1) - 1)).Take(tamanhoPagina).ToList();
            }
            catch //(Exception ex)
            {                
                throw;
            }

            return Result;
        }

        /// <summary>
        /// Devuelve la primera 
        /// </summary>
        /// <returns></returns>
        public string GetPrimaryKeyName<T>() where T : class
        {
            var adapter = (IObjectContextAdapter)Context;
            var objectContext = adapter.ObjectContext;
            var objectSet = objectContext.CreateObjectSet<T>();
            var entitySet = objectSet.EntitySet;
            return entitySet.ElementType.KeyMembers[0].Name;
        }

        public object GetPrimaryKeyValue(DbEntityEntry entry)
        {
            var objectStateEntry = ((IObjectContextAdapter)Context).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
            return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
        }
        
        public PropertyInfo GetPrimaryKeyInfo<T>()
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo pI in properties)
            {
                System.Object[] attributes = pI.GetCustomAttributes(true);
                foreach (object attribute in attributes)
                {
                    
                    if (attribute is EdmScalarPropertyAttribute)
                    {
                        if ((attribute as EdmScalarPropertyAttribute).EntityKeyProperty == true)
                            return pI;
                    }
                    else if (attribute is ColumnAttribute)
                    {

                        if ((attribute as ColumnAttribute).IsPrimaryKey == true)
                            return pI;
                    }
                }
            }
            return null;
        }

        private bool SetFieldValueByName<T>(string fieldName, Int32 fieldValue)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo pI in properties)
            {
                System.Object[] attributes = pI.GetCustomAttributes(true);
                foreach (object attribute in attributes)
                {
                    if (attribute is ColumnAttribute)
                    {
                        if ((attribute as ColumnAttribute).Name == fieldName)
                        {
                            pI.SetValue(attribute, fieldValue);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private int GetPrimaryKey(DbEntityEntry entry)
        {
            var myObject = entry.Entity;
            var property =
                myObject.GetType()
                     .GetProperties().FirstOrDefault(prop => Attribute.IsDefined(prop, typeof(KeyAttribute)));
            return (int)property.GetValue(myObject, null);
        }

        public void Dispose()
        {
            if (this.Context != null)
            {
                this.Context.Dispose();
            }
        }

        public string GetDBName()
        {
            return this.Context.Database.Connection.Database;
        }

        public string GetDBServer()
        {
            return this.Context.Database.Connection.DataSource;
        }
    }
}
