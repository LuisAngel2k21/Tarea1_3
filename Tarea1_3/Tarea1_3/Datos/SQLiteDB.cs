using System;
using System.Collections.Generic;
using SQLite;

namespace Tarea1_3.Datos
{
    public interface ISQLiteDB
    {
        SQLiteAsyncConnection GetConnection();
    }
}
