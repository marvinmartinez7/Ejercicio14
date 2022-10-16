using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Ejercicio14.Model;
using System.Threading.Tasks;

namespace Ejercicio14.Controller
{
    

    public class Database
    {

        readonly SQLiteAsyncConnection db;

        //Constructor
        public Database(String pathdb)
        {
            //Crear conexion a la BD
            db = new SQLiteAsyncConnection(pathdb);

            //Crear tabla Imagen en SQLite
            db.CreateTableAsync<Imagen>().Wait();
        }

        //READ
        public Task<List<Imagen>> ListaImagen()
        {
            return db.Table<Imagen>().ToListAsync();

        }

        //INSERT & UPDATE
        public Task<int> GrabarImagen(Imagen imagen)
        {
            if (imagen.id != 0)
            {
                return db.UpdateAsync(imagen);
            }
            else
            {

                return db.InsertAsync(imagen);
            }
        }

        //DELETE
        public Task<int> EliminarImagen(Imagen imagen)
        {
            return db.DeleteAsync(imagen);
        }
    }
}
