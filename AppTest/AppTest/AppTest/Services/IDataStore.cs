using System;
using System.Collections.Generic;
using System.Text;

namespace AppTest
{
    public interface IDataStore<T>
    {
        bool CreateItem(T item);
        T ReadItem();
        bool UpdateItem(T item);
        bool DeleteItem(T item);
    }
}
