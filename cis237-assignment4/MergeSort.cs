using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment4
{
    class MergeSort
    {
        // This class should not be instantiated.
        private MergeSort() { }

        private IDroid[] Droids;

        private IDroid[] aux;
        /**
         * Reads in a sequence of strings from standard input; mergesorts them; 
         * and prints them to standard output in ascending order. 
         *
         * @param args the command-line arguments
         */
        public MergeSort(IDroid[] droids)
        {
            Droids = droids;
            MergeSort.sort(Droids);
            show(Droids);
        }

        // stably merge a[lo .. mid] with a[mid+1 ..hi] using aux[lo .. hi]
        private static void merge(IDroid[] a, IDroid[] aux, int lo, int mid, int hi)
        {
            // precondition: a[lo .. mid] and a[mid+1 .. hi] are sorted subarrays
            Debug.Assert(isSorted(a, lo, mid));
            Debug.Assert(isSorted(a, mid+1, hi));

            // copy to aux[]
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = a[k];
            }

            // merge back to a[]
            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid) a[k] = aux[j++];
                else if (j > hi) a[k] = aux[i++];
                else if (less(aux[j], aux[i])) a[k] = aux[j++];
                else a[k] = aux[i++];
            }

            // postcondition: a[lo .. hi] is sorted
            Debug.Assert(isSorted(a, lo, hi));
        }

        // mergesort a[lo..hi] using auxiliary array aux[lo..hi]
        // this is called from inside the class
        private static void sort(IDroid[] a, IDroid[] aux, int lo, int hi)
        {
            if (hi <= lo) return; // this is the base case
                                  // it's importat that the midpoint is done this way
            int mid = lo + (hi - lo) / 2;
            // left half
            sort(a, aux, lo, mid);

            // right half
            sort(a, aux, mid + 1, hi);

            // merge them
            merge(a, aux, lo, mid, hi);
        }

        /**
         * Rearranges the array in ascending order, using the natural order.
         * @param a the array to be sorted
         */
        // this is called from the outside
        // the methods have different signatures so the recursive call will be made
        // to the above method
        public static void sort(IDroid[] a)
        {
            IDroid[] aux = new IDroid[a.Length];
            sort(a, aux, 0, a.Length- 1);
            Debug.Assert(isSorted(a));
        }


        /***************************************************************************
         *  Helper sorting function.
         ***************************************************************************/

        // is v < w ?
        private static bool less(IDroid v, IDroid w)
        {
            if (v == null || w == null) return false;
            return v.CompareTo(w) < 0;
        }

        /***************************************************************************
         *  Check if array is sorted - useful for debugging.
         ***************************************************************************/
        private static bool isSorted(IDroid[] a)
        {
            return isSorted(a, 0, a.Length - 1);
        }

        private static bool isSorted(IDroid[] a, int lo, int hi)
        {
            for (int i = lo + 1; i <= hi; i++)
                if (less(a[i], a[i - 1])) return false;
            return true;
        }


        /***************************************************************************
         *  Index mergesort.
         ***************************************************************************/
        // stably merge a[lo .. mid] with a[mid+1 .. hi] using aux[lo .. hi]
        private static void merge(IDroid[] a, int[] index, int[] aux, int lo, int mid, int hi)
        {

            // copy to aux[]
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = index[k];
            }

            // merge back to a[]
            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid) index[k] = aux[j++];
                else if (j > hi) index[k] = aux[i++];
                else if (less(a[aux[j]], a[aux[i]])) index[k] = aux[j++];
                else index[k] = aux[i++];
            }
        }

        ///**
        // * Returns a permutation that gives the elements in the array in ascending order.
        // * @param a the array
        // * @return a permutation {@code p[]} such that {@code a[p[0]]}, {@code a[p[1]]},
        // *    ..., {@code a[p[N-1]]} are in ascending order
        // */
        //public static int[] indexSort(IComparable[] a)
        //{
        //    int n = a.Length;
        //    int[] index = new int[n];
        //    for (int i = 0; i < n; i++)
        //        index[i] = i;

        //    int[] aux = new int[n];
        //    sort(a, index, aux, 0, n - 1);
        //    return index;
        //}

        // mergesort a[lo..hi] using auxiliary array aux[lo..hi]
        private static void sort(IDroid[] a, int[] index, int[] aux, int lo, int hi)
        {
            if (hi <= lo) return;
            int mid = lo + (hi - lo) / 2;
            sort(a, index, aux, lo, mid);
            sort(a, index, aux, mid + 1, hi);
            merge(a, index, aux, lo, mid, hi);
        }

        //print array to standard output
        private static void show(IDroid[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }
        }
    }
}
