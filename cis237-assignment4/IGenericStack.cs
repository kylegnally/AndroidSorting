using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment4
{
    interface IGenericStack<T>
    {
        void Push(T Data);
        T Pop();

        bool isEmpty { get; }
        int Size { get; }
    }
}
