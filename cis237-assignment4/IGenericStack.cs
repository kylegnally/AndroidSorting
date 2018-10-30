using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment4
{
    interface IGenericStack
    {
        void Push(Droid droid);
        void Pop();

        bool isEmpty;
        int size;
    }
}
